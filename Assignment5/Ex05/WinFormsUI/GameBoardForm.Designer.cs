using System.Windows.Forms;
      
namespace WinFormsUI
{
	partial class GameBoardForm
	{
		private System.ComponentModel.IContainer components = null;

		private Label labelPlayer1Score;
		private Label labelPlayer2Score;

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
            labelPlayer1Score = new Label();
            labelPlayer2Score = new Label();
            SuspendLayout();
            // 
            // labelPlayer1Score
            // 
            labelPlayer1Score.AutoSize = true;
            labelPlayer1Score.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            labelPlayer1Score.Location = new Point(184, 0);
            labelPlayer1Score.Margin = new Padding(6, 0, 6, 0);
            labelPlayer1Score.Name = "labelPlayer1Score";
            labelPlayer1Score.Size = new Size(127, 26);
            labelPlayer1Score.TabIndex = 0;
            labelPlayer1Score.Text = "Player 1: 0";
            // 
            // labelPlayer2Score
            // 
            labelPlayer2Score.AutoSize = true;
            labelPlayer2Score.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            labelPlayer2Score.Location = new Point(184, 0);
            labelPlayer2Score.Margin = new Padding(6, 0, 6, 0);
            labelPlayer2Score.Name = "labelPlayer2Score";
            labelPlayer2Score.Size = new Size(127, 26);
            labelPlayer2Score.TabIndex = 1;
            labelPlayer2Score.Text = "Player 2: 0";
            // 
            // GameBoardForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(615, 677);
            Controls.Add(labelPlayer1Score);
            Controls.Add(labelPlayer2Score);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(6);
            MaximizeBox = false;
            Name = "GameBoardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TicTacToeMisere";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
