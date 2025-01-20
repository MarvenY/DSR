namespace WinFormsApp1
{
    partial class ProgressForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            progressBar1 = new ProgressBar();
            label2 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            lblMessage = new Label();
            lblTimeElapsed = new Label();
            SuspendLayout();
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(41, 95);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(617, 23);
            progressBar1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(41, 46);
            label2.Name = "label2";
            label2.Size = new Size(113, 15);
            label2.TabIndex = 2;
            label2.Text = "Proccessing DataSet";
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Location = new Point(41, 77);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(0, 15);
            lblMessage.TabIndex = 3;
            // 
            // lblTimeElapsed
            // 
            lblTimeElapsed.AutoSize = true;
            lblTimeElapsed.Location = new Point(44, 159);
            lblTimeElapsed.Name = "lblTimeElapsed";
            lblTimeElapsed.Size = new Size(110, 15);
            lblTimeElapsed.TabIndex = 4;
            lblTimeElapsed.Text = "Time Elapsed: 00:00";
            // 
            // ProgressForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(719, 214);
            Controls.Add(lblTimeElapsed);
            Controls.Add(lblMessage);
            Controls.Add(label2);
            Controls.Add(progressBar1);
            Name = "ProgressForm";
            Text = "ProgressForm";
            Load += ProgressForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ProgressBar progressBar1;
        private Label label2;
        private System.Windows.Forms.Timer timer1;
        private Label lblMessage;
        private Label lblTimeElapsed;
    }
}