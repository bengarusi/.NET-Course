using System;
using System.Windows.Forms;
using GameLogic;

namespace WinFormsUI
{
	public class Program
	{
		public static void Main()
		{
			ApplicationConfiguration.Initialize();
			SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog();

            if (settingsForm.IsStartClicked)
            {
                GameManager gameManager = new GameManager(settingsForm.Settings);
                Application.Run(new GameBoardForm(gameManager));
            }

        }
	}
}
