using System;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class ProgressForm : Form
    {
        public ProgressForm()
        {
            InitializeComponent();
        }

        // Updates the progress bar and message
        public void UpdateProgress(int progress, string message)
        {
            // Check if we need to marshal the update to the UI thread
            if (progressBar1.InvokeRequired)
            {
                progressBar1.Invoke(new Action<int, string>((p, m) =>
                {
                    progressBar1.Value = p;
                    lblMessage.Text = m;
                }), progress, message);
            }
            else
            {
                // If we're already on the UI thread, we can directly update the controls
                progressBar1.Value = progress;
                lblMessage.Text = message;
            }
        }

        // Updates the elapsed time
        public void UpdateTimeElapsed(TimeSpan elapsed)
        {
            lblTimeElapsed.Text = $"Time Elapsed: {elapsed:mm\\:ss}";
        }

        private void ProgressForm_Load(object sender, EventArgs e)
        {

        }
    }
}
