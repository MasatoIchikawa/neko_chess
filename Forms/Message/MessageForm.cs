using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace neko_chess.Forms.Message
{
    public partial class MessageForm : Form
    {
        private MessageEnum _messageEnum;
        public MessageForm(MessageEnum messageEnum)
        {
            InitializeComponent();
            _messageEnum = messageEnum;
        }

        private void MessageForm_Load(object sender, EventArgs e)
        {
            switch (_messageEnum)
            {
                case MessageEnum.Check:
                    pic.Image = Properties.Resources.check;
                    CloseTimer.Start();
                    break;
                case MessageEnum.WinBlack:
                    pic.Image = Properties.Resources.win_black;
                    break;
                case MessageEnum.WinWhite:
                    pic.Image = Properties.Resources.win_white;
                    break;
                default:
                    Close();
                    return;
            }
            Size = pic.Size;
            BringToFront();
        }

        private void pic_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CloseTimer_Tick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
