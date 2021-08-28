using neko_chess.Enums;
using neko_chess.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace neko_chess
{
    public partial class ChangePiece : Form
    {
        public int SelectPiece;

        public ChangePiece()
        {
            InitializeComponent();
        }

        private void ChangePiece_Load(object sender, EventArgs e)
        {
            //PictureBoxに表示する画像を準備
            var canvas = new Bitmap(Width, Height);
            var g = Graphics.FromImage(canvas);

            //枠線を描く
            var color = Color.Blue;
            var p = new Pen(color, 10);
            g.DrawRectangle(p, 0, 0, Width, Height);

            //リソース解放。これをしないと段々重くなる
            p.Dispose();
            g.Dispose();
            BackgroundImage = canvas;

            SelectPiece = (int)PieceEnum.Nothing;
            if (ChessItem.Turn == TurnEnum.Black)
            {
                _BlackImage();
            }
            else
            {
                _WhiteImage();
            }
        }

        private void _BlackImage()
        {
            picKnight.Image = Properties.Resources.Black_Knight;
            picRook.Image = Properties.Resources.Black_Rook;
            picBishop.Image = Properties.Resources.Black_Bishop;
            picQueen.Image = Properties.Resources.Black_Queen;

            picKnight.Tag = (int)PieceEnum.BlackKnight;
            picRook.Tag = (int)PieceEnum.BlackRook;
            picBishop.Tag = (int)PieceEnum.BlackBishop;
            picQueen.Tag = (int)PieceEnum.BlackQueen;
        }

        private void _WhiteImage()
        {
            picKnight.Image = Properties.Resources.White_Knight;
            picRook.Image = Properties.Resources.White_Rook;
            picBishop.Image = Properties.Resources.White_Bishop;
            picQueen.Image = Properties.Resources.White_Queen;

            picKnight.Tag = (int)PieceEnum.WhiteKnight;
            picRook.Tag = (int)PieceEnum.WhiteRook;
            picBishop.Tag = (int)PieceEnum.WhiteBishop;
            picQueen.Tag = (int)PieceEnum.WhiteQueen;
        }

        private void Pic_Click(object sender, EventArgs e)
        {
            var pic = sender as PictureBox;
            if (pic == null) return;

            SelectPiece = Convert.ToInt32(pic.Tag);
            Close();
        }

        private void ChangePiece_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SelectPiece != (int)PieceEnum.Nothing) return;
            e.Cancel = true;
        }
    }
}
