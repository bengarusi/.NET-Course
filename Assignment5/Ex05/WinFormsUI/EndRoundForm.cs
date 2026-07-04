using System.Windows.Forms;

namespace WinFormsUI
{
    public partial class EndRoundForm : Form
    {
        public EndRoundForm(string i_Caption, string i_Message)
        {
            InitializeComponent();

            this.Text = i_Message;
            labelMessage.Text = i_Caption;
        }

    }
}