using System.Windows.Forms;
namespace WinFormsUI
{
	partial class SettingsForm
	{
		private System.ComponentModel.IContainer components = null;

		private Label labelPlayers;
		private Label labelPlayer1;
		private TextBox textBoxPlayer1;
		private CheckBox checkBoxPlayer2;
		private TextBox textBoxPlayer2;
		private Label labelBoardSize;
		private Label labelRows;
		private NumericUpDown numericUpDownRows;
		private Label labelCols;
		private NumericUpDown numericUpDownCols;
		private Button buttonStart;

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
			this.labelPlayers = new System.Windows.Forms.Label();
			this.labelPlayer1 = new System.Windows.Forms.Label();
			this.textBoxPlayer1 = new System.Windows.Forms.TextBox();
			this.checkBoxPlayer2 = new System.Windows.Forms.CheckBox();
			this.textBoxPlayer2 = new System.Windows.Forms.TextBox();
			this.labelBoardSize = new System.Windows.Forms.Label();
			this.labelRows = new System.Windows.Forms.Label();
			this.numericUpDownRows = new System.Windows.Forms.NumericUpDown();
			this.labelCols = new System.Windows.Forms.Label();
			this.numericUpDownCols = new System.Windows.Forms.NumericUpDown();
			this.buttonStart = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownRows)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCols)).BeginInit();
			this.SuspendLayout();
			//
			// labelPlayers
			//
			this.labelPlayers.AutoSize = true;
			this.labelPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.labelPlayers.Location = new System.Drawing.Point(18, 15);
			this.labelPlayers.Name = "labelPlayers";
			this.labelPlayers.Text = "Players:";
			//
			// labelPlayer1
			//
			this.labelPlayer1.AutoSize = true;
			this.labelPlayer1.Location = new System.Drawing.Point(30, 48);
			this.labelPlayer1.Name = "labelPlayer1";
			this.labelPlayer1.Text = "Player 1:";
			//
			// textBoxPlayer1
			//
			this.textBoxPlayer1.Location = new System.Drawing.Point(110, 45);
			this.textBoxPlayer1.Name = "textBoxPlayer1";
			this.textBoxPlayer1.Size = new System.Drawing.Size(160, 23);
			//
			// checkBoxPlayer2
			//
			this.checkBoxPlayer2.AutoSize = true;
			this.checkBoxPlayer2.Location = new System.Drawing.Point(33, 82);
			this.checkBoxPlayer2.Name = "checkBoxPlayer2";
			this.checkBoxPlayer2.Text = "Player 2:";
			this.checkBoxPlayer2.CheckedChanged += new System.EventHandler(this.checkBoxPlayer2_CheckedChanged);
			//
			// textBoxPlayer2
			//
			this.textBoxPlayer2.Enabled = false;
			this.textBoxPlayer2.Location = new System.Drawing.Point(110, 80);
			this.textBoxPlayer2.Name = "textBoxPlayer2";
			this.textBoxPlayer2.Size = new System.Drawing.Size(160, 23);
			this.textBoxPlayer2.Text = "[Computer]";
			//
			// labelBoardSize
			//
			this.labelBoardSize.AutoSize = true;
			this.labelBoardSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.labelBoardSize.Location = new System.Drawing.Point(18, 120);
			this.labelBoardSize.Name = "labelBoardSize";
			this.labelBoardSize.Text = "Board Size:";
			//
			// labelRows
			//
			this.labelRows.AutoSize = true;
			this.labelRows.Location = new System.Drawing.Point(30, 153);
			this.labelRows.Name = "labelRows";
			this.labelRows.Text = "Rows:";
			//
			// numericUpDownRows
			//
			this.numericUpDownRows.Location = new System.Drawing.Point(80, 151);
			this.numericUpDownRows.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
			this.numericUpDownRows.Minimum = new decimal(new int[] { 4, 0, 0, 0 });
			this.numericUpDownRows.Name = "numericUpDownRows";
			this.numericUpDownRows.Size = new System.Drawing.Size(45, 23);
			this.numericUpDownRows.Value = new decimal(new int[] { 4, 0, 0, 0 });
			this.numericUpDownRows.ValueChanged += new System.EventHandler(this.numericUpDownRows_ValueChanged);
			//
			// labelCols
			//
			this.labelCols.AutoSize = true;
			this.labelCols.Location = new System.Drawing.Point(150, 153);
			this.labelCols.Name = "labelCols";
			this.labelCols.Text = "Cols:";
			//
			// numericUpDownCols
			//
			this.numericUpDownCols.Location = new System.Drawing.Point(195, 151);
			this.numericUpDownCols.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
			this.numericUpDownCols.Minimum = new decimal(new int[] { 4, 0, 0, 0 });
			this.numericUpDownCols.Name = "numericUpDownCols";
			this.numericUpDownCols.Size = new System.Drawing.Size(45, 23);
			this.numericUpDownCols.Value = new decimal(new int[] { 4, 0, 0, 0 });
			this.numericUpDownCols.ValueChanged += new System.EventHandler(this.numericUpDownCols_ValueChanged);
			//
			// buttonStart
			//
			this.buttonStart.Location = new System.Drawing.Point(30, 195);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(240, 32);
			this.buttonStart.Text = "Start!";
			this.buttonStart.UseVisualStyleBackColor = true;
			this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
			//
			// SettingsForm
			//
			this.AcceptButton = this.buttonStart;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(300, 250);
			this.Controls.Add(this.buttonStart);
			this.Controls.Add(this.numericUpDownCols);
			this.Controls.Add(this.labelCols);
			this.Controls.Add(this.numericUpDownRows);
			this.Controls.Add(this.labelRows);
			this.Controls.Add(this.labelBoardSize);
			this.Controls.Add(this.textBoxPlayer2);
			this.Controls.Add(this.checkBoxPlayer2);
			this.Controls.Add(this.textBoxPlayer1);
			this.Controls.Add(this.labelPlayer1);
			this.Controls.Add(this.labelPlayers);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SettingsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Game Settings";
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownRows)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCols)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion
	}
}
