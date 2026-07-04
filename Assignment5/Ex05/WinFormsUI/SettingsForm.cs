using System;
using System.Windows.Forms;
using GameLogic;

namespace WinFormsUI
{
	public partial class SettingsForm : Form
	{
		private const string k_ComputerText = "[Computer]";
		private const string k_DefaultPlayer1Name = "Player 1";
		private const string k_DefaultPlayer2Name = "Player 2";
		private const string k_ComputerName = "Computer";

		private bool m_IsSyncingBoardSize = false;

		public SettingsForm()
		{
			InitializeComponent();
		}

		public GameSettings Settings
		{
			get
			{
				return new GameSettings(getBoardSize(), getPlayer1Name(), getPlayer2Name(), getGameMode());
			}
		}

		private int getBoardSize()
		{
			return (int)numericUpDownRows.Value;
		}

		private eGameMode getGameMode()
		{
			eGameMode selectedMode;

			if (checkBoxPlayer2.Checked)
			{
				selectedMode = eGameMode.HumanVsHuman;
			}
			else
			{
				selectedMode = eGameMode.HumanVsComputer;
			}

			return selectedMode;
		}

		private string getPlayer1Name()
		{
			return getNameOrDefault(textBoxPlayer1.Text, k_DefaultPlayer1Name);
		}

		private string getPlayer2Name()
		{
			string player2Name = k_ComputerName;

			if (checkBoxPlayer2.Checked)
			{
				player2Name = getNameOrDefault(textBoxPlayer2.Text, k_DefaultPlayer2Name);
			}

			return player2Name;
		}

		private string getNameOrDefault(string i_Text, string i_DefaultName)
		{
			string trimmedText = i_Text.Trim();
			string nameOrDefault;

			if (trimmedText.Length == 0)
			{
				nameOrDefault = i_DefaultName;
			}
			else
			{
				nameOrDefault = trimmedText;
			}

			return nameOrDefault;
		}

		private void checkBoxPlayer2_CheckedChanged(object sender, EventArgs e)
		{
			textBoxPlayer2.Enabled = checkBoxPlayer2.Checked;

			if (checkBoxPlayer2.Checked)
			{
				textBoxPlayer2.Text = string.Empty;
			}
			else
			{
				textBoxPlayer2.Text = k_ComputerText;
			}
		}

		private void numericUpDownRows_ValueChanged(object sender, EventArgs e)
		{
			synchronizeBoardSize(numericUpDownRows, numericUpDownCols);
		}

		private void numericUpDownCols_ValueChanged(object sender, EventArgs e)
		{
			synchronizeBoardSize(numericUpDownCols, numericUpDownRows);
		}

		private void synchronizeBoardSize(NumericUpDown i_ChangedField, NumericUpDown i_FieldToMirror)
		{
			if (!m_IsSyncingBoardSize)
			{
				m_IsSyncingBoardSize = true;
				i_FieldToMirror.Value = i_ChangedField.Value;
				m_IsSyncingBoardSize = false;
			}
		}

		private void buttonStart_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}
