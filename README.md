<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    
</head>
<body>
    <h1>CSV/Dataset File Viewer by Marven Younes</h1>
    <p>
        A Windows Forms Application that allows users to load, view, and search large CSV files efficiently. 
        The application features a progress bar to show file-loading progress and includes a search bar for 
        filtering data in the DataGridView.
    </p>
    <h2>Features</h2>
    <ul>
        <li>Load large CSV files with progress tracking.</li>
        <li>Dynamically adjust the DataGridView size to match the window size.</li>
        <li>Resize the grid by dragging its borders.</li>
        <li>Search functionality to filter data by matching terms across all columns.</li>
        <li>Handles special characters in CSV headers and search terms.</li>
    </ul>
    <h2>Requirements</h2>
    <ul>
        <li><strong>.NET Framework 4.8</strong> or higher</li>
        <li><a href="https://joshclose.github.io/CsvHelper/" target="_blank">CsvHelper</a> NuGet package for robust CSV parsing</li>
    </ul>
    <h2>Installation</h2>
    <ol>
        <li>Clone the repository:
            <pre><code>git clone https://github.com/MarvenY/DSR.git
cd DSR</code></pre>
        </li>
        <li>Open the project in Visual Studio.</li>
        <li>Install the required NuGet package:
            <pre><code>Install-Package CsvHelper</code></pre>
        </li>
        <li>Build and run the application.</li>
    </ol>
    <h2>Usage</h2>
    <ol>
        <li>Click the "Open File" button to select a CSV file from your system.</li>
        <li>Wait for the file to load while monitoring the progress bar.</li>
        <li>Use the search bar to filter rows based on keywords.</li>
        <li>Resize the application window or drag the DataGridView border to adjust its size.</li>
    </ol>
    <h2>Contributing</h2>
    <p>Contributions are welcome! Please fork the repository and submit a pull request with your improvements or bug fixes.</p>
    <h2>License</h2>
    <p>This project is licensed under the MIT License. See the <code>LICENSE</code> file for details.</p>
</body>
</html>
