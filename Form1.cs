using System;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private Stopwatch stopwatch = new Stopwatch();

        public Form1()
        {
            InitializeComponent();
            // Ensure the timer is started when necessary.
            timer1.Tick += timer1_Tick;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Select a CSV File",
                Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*",
                FilterIndex = 1,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;

                // Show the progress form
                ProgressForm progressForm = new ProgressForm();
                progressForm.Show();

                // Start the timer and stopwatch
                stopwatch.Restart();
                timer1.Start(); // Start the timer

                try
                {
                    // Load the CSV file in a background thread
                    Task.Run(() =>
                    {
                        DataTable csvData = LoadCsvFileWithProgress(selectedFilePath, progressForm);
                        Invoke(new Action(() =>
                        {
                            dataGridView1.DataSource = csvData;
                            progressForm.Close(); // Close the progress form when done
                            timer1.Stop(); // Stop the timer
                            stopwatch.Stop(); // Stop the stopwatch
                        }));
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while loading the file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    progressForm.Close(); // Ensure the progress form is closed on error
                    timer1.Stop();
                    stopwatch.Stop();
                }
            }
        }

        private DataTable LoadCsvFileWithProgress(string filePath, ProgressForm progressForm)
        {
            DataTable dataTable = new DataTable();

            using (StreamReader reader = new StreamReader(filePath))
            {
                using (var csv = new CsvHelper.CsvReader(reader, new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = true, // Assume the first row contains headers
                    Delimiter = ",",        // Default delimiter
                    BadDataFound = null,    // Skip malformed rows
                    IgnoreBlankLines = true // Ignore empty lines
                }))
                {
                    // Dynamically read the header row
                    csv.Read();
                    csv.ReadHeader();
                    foreach (string header in csv.HeaderRecord)
                    {
                        dataTable.Columns.Add(header.Trim()); // Add columns based on headers from CSV
                    }

                    // Read rows with progress tracking
                    long totalBytes = reader.BaseStream.Length;
                    while (csv.Read())
                    {
                        var row = dataTable.NewRow();

                        // Iterate over all columns for this row
                        foreach (string header in csv.HeaderRecord)
                        {
                            row[header] = csv.GetField(header); // Get the field value for each header
                        }

                        dataTable.Rows.Add(row);

                        // Update progress
                        int progress = (int)((double)reader.BaseStream.Position / totalBytes * 100);
                        progressForm.UpdateProgress(progress, $"Loading... {progress}%");
                    }
                }
            }

            return dataTable;

        }




        // Timer tick event to update the elapsed time
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<ProgressForm>().FirstOrDefault() is ProgressForm progressForm)
            {
                progressForm.UpdateTimeElapsed(stopwatch.Elapsed);
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            // Get the DataTable bound to the DataGridView
            if (dataGridView1.DataSource is DataTable dataTable)
            {
                string searchValue = textBox1.Text.Trim(); // Get the search text

                if (string.IsNullOrEmpty(searchValue))
                {
                    // Clear filter if search box is empty
                    dataTable.DefaultView.RowFilter = string.Empty;
                }
                else
                {
                    try
                    {
                        // Escape special characters in the search text
                        string sanitizedSearchValue = searchValue.Replace("'", "''"); // Handle single quotes

                        // Build the filter string (case-insensitive)
                        string filter = string.Join(" OR ", dataTable.Columns.Cast<DataColumn>()
                            .Select(col => $"CONVERT([{col.ColumnName}], 'System.String') LIKE '%{sanitizedSearchValue}%'"));

                        // Apply the filter
                        dataTable.DefaultView.RowFilter = filter;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error applying filter: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("No data loaded in the grid.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void SortAlpha_Click(object sender, EventArgs e)
        {
            // Check if the DataGridView has data
            if (dataGridView1.DataSource is DataTable dataTable)
            {
                // Show a prompt to ask the user which column to sort
                string columnNames = string.Join(Environment.NewLine, dataTable.Columns.Cast<DataColumn>().Select(c => c.ColumnName));
                string columnName = Microsoft.VisualBasic.Interaction.InputBox(
                    "Please enter the column name you want to sort alphabetically:\n\n" + columnNames,
                    "Select Column to Sort",
                    dataTable.Columns[0].ColumnName // Default to the first column
                );

                // Check if the column exists
                if (!dataTable.Columns.Contains(columnName))
                {
                    MessageBox.Show("Invalid column name. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ProgressForm progressForm = new ProgressForm();
                progressForm.Show();

                try
                {
                    Task.Run(() =>
                    {
                        // Simulate progress with a delay (optional for small datasets)
                        for (int progress = 0; progress <= 100; progress += 10)
                        {
                            progressForm.UpdateProgress(progress, $"Sorting data by column '{columnName}'...");
                            Thread.Sleep(50); // Simulate some work (remove if unnecessary)
                        }

                        // Perform sorting
                        DataView dataView = dataTable.DefaultView;
                        dataView.Sort = $"{columnName} ASC"; // Sort by the selected column
                        dataTable = dataView.ToTable();

                        // Update the UI
                        Invoke(new Action(() =>
                        {
                            dataGridView1.DataSource = dataTable;
                            progressForm.Close();
                        }));
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred during sorting: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    progressForm.Close();
                }
            }
            else
            {
                MessageBox.Show("No data available to sort.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


    }
}
