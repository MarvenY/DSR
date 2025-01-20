namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            dataGridView1 = new DataGridView();
            QuitButton = new Button();
            textBox1 = new TextBox();
            menuStrip1 = new MenuStrip();
            FileMenu = new ToolStripMenuItem();
            OpenFile = new ToolStripMenuItem();
            SearchButton = new Button();
            SortAlpha = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 79);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1560, 670);
            dataGridView1.TabIndex = 0;
            // 
            // QuitButton
            // 
            QuitButton.Location = new Point(1451, 49);
            QuitButton.Name = "QuitButton";
            QuitButton.Size = new Size(75, 23);
            QuitButton.TabIndex = 3;
            QuitButton.Text = "Quit";
            QuitButton.UseVisualStyleBackColor = true;
            QuitButton.Click += QuitButton_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(169, 50);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(487, 23);
            textBox1.TabIndex = 4;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.ActiveBorder;
            menuStrip1.Items.AddRange(new ToolStripItem[] { FileMenu });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1584, 24);
            menuStrip1.TabIndex = 5;
            menuStrip1.Text = "menuStrip1";
            // 
            // FileMenu
            // 
            FileMenu.BackColor = SystemColors.Info;
            FileMenu.DropDownItems.AddRange(new ToolStripItem[] { OpenFile });
            FileMenu.Name = "FileMenu";
            FileMenu.Size = new Size(37, 20);
            FileMenu.Text = "File";
            // 
            // OpenFile
            // 
            OpenFile.Name = "OpenFile";
            OpenFile.Size = new Size(103, 22);
            OpenFile.Text = "Open";
            OpenFile.Click += OpenFile_Click;
            // 
            // SearchButton
            // 
            SearchButton.Location = new Point(662, 50);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(75, 23);
            SearchButton.TabIndex = 6;
            SearchButton.Text = "Search";
            SearchButton.UseVisualStyleBackColor = true;
            SearchButton.Click += SearchButton_Click;
            // 
            // SortAlpha
            // 
            SortAlpha.Location = new Point(12, 50);
            SortAlpha.Name = "SortAlpha";
            SortAlpha.Size = new Size(75, 23);
            SortAlpha.TabIndex = 7;
            SortAlpha.Text = "AlphaSort";
            SortAlpha.UseVisualStyleBackColor = true;
            SortAlpha.Click += SortAlpha_Click;
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1584, 761);
            Controls.Add(SortAlpha);
            Controls.Add(SearchButton);
            Controls.Add(textBox1);
            Controls.Add(QuitButton);
            Controls.Add(dataGridView1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "DSR";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button Sort;
        private Button button2;
        private Button QuitButton;
        private TextBox textBox1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem FileMenu;
        private ToolStripMenuItem OpenFile;
        private Button SearchButton;
        private Button SortAlpha;
        private System.Windows.Forms.Timer timer1;
    }
}
