using System;
using System.Windows.Forms;
using GameLogic;

namespace WinFormsUI
{
	internal static class Program
	{
		private static void Main()
		{
			ApplicationConfiguration.Initialize();
			SettingsForm settingsForm = new SettingsForm();
			if (settingsForm.ShowDialog() == DialogResult.OK)
			{
				GameManager gameManager = new GameManager(settingsForm.Settings);
				Application.Run(new GameBoardForm(gameManager));
			}

		}
	}
}
