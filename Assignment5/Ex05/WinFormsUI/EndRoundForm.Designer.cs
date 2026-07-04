using System.Windows.Forms;

namespace WinFormsUI
{
    partial class EndRoundForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label labelMessage;
        private Button buttonYes;
        private Button buttonNo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            labelMessage = new Label();
            buttonYes = new Button();
            buttonNo = new Button();
            SuspendLayout();
            // 
            // labelMessage
            // 
            labelMessage.AutoSize = true;
            labelMessage.Location = new Point(44, 45);
            labelMessage.Name = "labelMessage";
            labelMessage.Size = new Size(159, 32);
            labelMessage.TabIndex = 1;
            labelMessage.Text = "labelMessage";
            labelMessage.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // buttonYes
            // 
            buttonYes.DialogResult = DialogResult.Yes;
            buttonYes.Location = new Point(70, 150);
            buttonYes.Name = "buttonYes";
            buttonYes.Size = new Size(150, 53);
            buttonYes.TabIndex = 2;
            buttonYes.Text = "Yes";
            buttonYes.UseVisualStyleBackColor = true;
            // 
            // buttonNo
            // 
            buttonNo.DialogResult = DialogResult.No;
            buttonNo.Location = new Point(271, 150);
            buttonNo.Name = "buttonNo";
            buttonNo.Size = new Size(150, 53);
            buttonNo.TabIndex = 3;
            buttonNo.Text = "No";
            buttonNo.UseVisualStyleBackColor = true;
            // 
            // EndRoundForm
            // 
            AcceptButton = buttonYes;
            CancelButton = buttonNo;
            ClientSize = new Size(498, 224);
            Controls.Add(labelMessage);
            Controls.Add(buttonYes);
            Controls.Add(buttonNo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EndRoundForm";
            StartPosition = FormStartPosition.CenterParent;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}