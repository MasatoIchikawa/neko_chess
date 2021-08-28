using neko_chess.Controls.Boards;
using neko_chess.Controls.Cpus;
using neko_chess.Controls.Getters;
using neko_chess.Controls.Judgs;
using neko_chess.Controls.Pieces;
using neko_chess.Enums;
using neko_chess.Forms.Message;
using System;
using System.Drawing;
using System.Windows.Forms;
using static neko_chess.Items.ChessItem;

namespace neko_chess
{
    public partial class MainBoard : Form
    {
        private Cpu _cpu = new Cpu();

        public MainBoard()
        {
            InitializeComponent();
        }

        private void MainBoard_Load(object sender, EventArgs e)
        {
            _Init();
            cmbCpu.SelectedIndex = 1;
        }

        private void _Init()
        {
            //盤面配列をクリアする
            BoardControl.BoardClear(pnlBoard);

            //盤面配列に初期配置セット
            BoardControl.BoardSet();

            //盤面配列を盤面へ表示させる
            BoardControl.DisplayPiece(pnlBoard);

            Turn = TurnEnum.White;
            _Turn();
        }

        private void _Reload()
        {
            BoardControl.DisplayPiece(pnlBoard);
            var winComment = WinOrLose.Judg();
            if (winComment != MessageEnum.None)
            {
                //勝利条件を満たしたため、メッセージを表示
                _Win(winComment);
                return;
            }

            var check = WinOrLose.Check();
            if (check)
            {
                MessageShow.Check();
            }
        }

        private void _Win(MessageEnum messageEnum)
        {
            cmbCpu.SelectedIndex = 0;
            MessageShow.Win(messageEnum);
            _Init();
        }

        private void _Turn()
        {
            string turnColor;
            if (Turn == TurnEnum.White)
            {
                turnColor = "白";
                lblTurn.BackColor = Color.White;
                lblTurn.ForeColor = Color.Black;
            }
            else
            {
                turnColor = "黒";
                lblTurn.BackColor = Color.Black;
                lblTurn.ForeColor = Color.White;
            }

            lblTurn.Text = $@"{turnColor}の番";
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            //CPUが動いている、かつ、CPUのターンの時は何もできない
            if (CPU_Timer.Enabled && Turn == TurnEnum.Black)
            {
                return;
            }

            var pic = sender as Control;
            if (pic == null) return;
            var tag = PieceGetter.GetTag(pic.Tag);
            BoardEvent(tag);
        }

        public void BoardEvent(Tuple<int, int> tag)
        {
            var m = new PieceControl(pnlBoard, tag);
            if (Selecter == null)
            {
                m.CheckRange();
            }
            else
            {
                //全部のマスを白色に戻す
                BoardControl.MoveRangePaint(pnlBoard);

                //移動しなかったらreturn
                if (!m.Move()) return;

                _Reload();
                //動かなかった場合は何もしない
                BoardControl.TurnChange();
                _Turn();
            }
        }

        private void CPU_Tick(object sender, EventArgs e)
        {
            if (Turn == TurnEnum.White) return;
            BoardEvent(_cpu.Get());
        }

        private void cmbCpu_SelectedIndexChanged(object sender, EventArgs e)
        {
            CpuLevel = cmbCpu.SelectedIndex;
            if (CpuLevel == (int)CpuLevelEnum.None)
            {
                CPU_Timer.Stop();
            }
            else
            {
                CPU_Timer.Start();
            }
        }

        private void btnRezain_Click(object sender, EventArgs e)
        {
            //CPUが動いている、かつ、CPUのターンの時はリザイン不可
            if (CPU_Timer.Enabled && Turn == TurnEnum.Black)
            {
                return;
            }

            var messageEnum = Turn == TurnEnum.White ? MessageEnum.WinBlack : MessageEnum.WinWhite;
            _Win(messageEnum);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
