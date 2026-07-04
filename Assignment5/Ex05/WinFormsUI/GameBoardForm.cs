using System;
using System.Drawing;
using System.Windows.Forms;
using GameLogic;

namespace WinFormsUI
{
    public partial class GameBoardForm : Form
    {
        private const int k_CellSize = 50;
        private const int k_Margin = 40;
        private const int k_ScoreAreaHeight = 40;
        private const int k_ScoreGap = 20;

        private readonly GameManager r_GameManager;
        private readonly Button[,] r_CellButtons;
        private int m_ScoreLabelsTop = 0;

        public GameBoardForm(GameManager i_GameManager)
        {
            r_GameManager = i_GameManager;
            InitializeComponent();
            r_CellButtons = new Button[r_GameManager.BoardSize, r_GameManager.BoardSize];
            buildBoard();
            subscribeToGameEvents();
            updateScoreLabels(r_GameManager.Player1Score, r_GameManager.Player2Score);
        }

        private void buildBoard()
        {
            int boardSize = r_GameManager.BoardSize;
            int boardPixels = boardSize * k_CellSize;

            for (int row = 0; row < boardSize; row++)
            {
                for (int col = 0; col < boardSize; col++)
                {
                    Button cellButton = createCellButton(row, col);
                    r_CellButtons[row, col] = cellButton;
                    this.Controls.Add(cellButton);
                }
            }

            this.ClientSize = new Size(
                (2 * k_Margin) + boardPixels,
                (2 * k_Margin) + boardPixels + k_ScoreAreaHeight);

            placeScoreLabels(boardPixels);
        }

        private Button createCellButton(int i_Row, int i_Col)
        {
            Button cellButton = new Button();
            cellButton.Size = new Size(k_CellSize, k_CellSize);
            cellButton.Location = new Point(
                k_Margin + (i_Col * k_CellSize),
                k_Margin + (i_Row * k_CellSize));
            cellButton.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            cellButton.Tag = new Point(i_Row, i_Col);
            cellButton.Click += cellButton_Click;

            return cellButton;
        }

        private void placeScoreLabels(int i_BoardPixels)
        {
            m_ScoreLabelsTop = k_Margin + i_BoardPixels + k_Margin;
        }

        private void subscribeToGameEvents()
        {
            r_GameManager.CellChanged += game_CellChanged;
            r_GameManager.ScoreChanged += game_ScoreChanged;
            r_GameManager.RoundEnded += game_RoundEnded;
            r_GameManager.BoardCleared += game_BoardCleared;
        }

        private void cellButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            Point cellPosition = (Point)clickedButton.Tag;

            r_GameManager.PlayMove(cellPosition.X, cellPosition.Y);
        }

        private void game_CellChanged(object sender, CellChangedEventArgs e)
        {
            Button cellButton = r_CellButtons[e.Row, e.Col];
            cellButton.Text = getSignDisplayText(e.Sign);
            cellButton.Enabled = false;
        }

        private void game_ScoreChanged(object sender, ScoreChangedEventArgs e)
        {
            updateScoreLabels(e.Player1Score, e.Player2Score);
        }

        private void game_RoundEnded(object sender, RoundEndedEventArgs e)
        {
            string roundEndMessage = buildRoundEndMessage(e);
            string messageCaption;

            if (e.Result == eRoundResult.Win)
            {
                messageCaption = "A Win!";
            }
            else
            {
                messageCaption = "A Tie!";
            }

            EndRoundForm roundEndDialogForm = new EndRoundForm(roundEndMessage, messageCaption);
            DialogResult userAnswer = roundEndDialogForm.ShowDialog(this);
            if (userAnswer == DialogResult.Yes)
            {
                r_GameManager.StartNewRound();
            }
            else
            {
                Application.Exit();
            }
        }
       
        private void game_BoardCleared(object sender, EventArgs e)
        {
            int boardSize = r_GameManager.BoardSize;

            for (int row = 0; row < boardSize; row++)
            {
                for (int col = 0; col < boardSize; col++)
                {
                    r_CellButtons[row, col].Text = string.Empty;
                    r_CellButtons[row, col].Enabled = true;
                }
            }
        }

        private string buildRoundEndMessage(RoundEndedEventArgs i_RoundEndedArgs)
        {
            string headline;

            if (i_RoundEndedArgs.Result == eRoundResult.Win)
            {
                headline = string.Format("The winner is {0}!", i_RoundEndedArgs.WinnerName);
            }
            else
            {
                headline = "Tie!";
            }

            string fullMessage = headline + Environment.NewLine + "Would you like to play another round?";

            return fullMessage;
        }

        private void updateScoreLabels(int i_Player1Score, int i_Player2Score)
        {
            labelPlayer1Score.Text = string.Format("{0}: {1}", r_GameManager.Player1Name, i_Player1Score);
            labelPlayer2Score.Text = string.Format("{0}: {1}", r_GameManager.Player2Name, i_Player2Score);

            int totalWidth = labelPlayer1Score.Width + k_ScoreGap + labelPlayer2Score.Width;
            int startX = (this.ClientSize.Width - totalWidth) / 2;

            labelPlayer1Score.Location = new Point(startX, m_ScoreLabelsTop);
            labelPlayer2Score.Location = new Point(labelPlayer1Score.Right + k_ScoreGap, m_ScoreLabelsTop);
        }

        private string getSignDisplayText(eSign i_Sign)
        {
            string displayText = string.Empty;

            if (i_Sign == eSign.X)
            {
                displayText = "X";
            }
            else if (i_Sign == eSign.O)
            {
                displayText = "O";
            }

            return displayText;
        }

      
    }
}
