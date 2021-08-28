using neko_chess.Controls.Getters;
using neko_chess.Enums;
using neko_chess.Items;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static neko_chess.Items.ChessItem;

namespace neko_chess.Controls.Boards
{
    public static class BoardControl
    {
        public static void BoardClear(Panel pnlBoard)
        {
            Board = new int[,]
            {
                {0,0,0,0,0,0,0,0 },
                {0,0,0,0,0,0,0,0 },
                {0,0,0,0,0,0,0,0 },
                {0,0,0,0,0,0,0,0 },
                {0,0,0,0,0,0,0,0 },
                {0,0,0,0,0,0,0,0 },
                {0,0,0,0,0,0,0,0 },
                {0,0,0,0,0,0,0,0 },
            };
            Selecter = null;
            BoardControl.MoveRangePaint(pnlBoard);
        }

        public static void BoardSet()
        {
            Board[0, 0] = (int)PieceEnum.BlackRook;
            Board[0, 1] = (int)PieceEnum.BlackKnight;
            Board[0, 2] = (int)PieceEnum.BlackBishop;
            Board[0, 3] = (int)PieceEnum.BlackQueen;
            Board[0, 4] = (int)PieceEnum.BlackKing;
            Board[0, 5] = (int)PieceEnum.BlackBishop;
            Board[0, 6] = (int)PieceEnum.BlackKnight;
            Board[0, 7] = (int)PieceEnum.BlackRook;
            Board[1, 0] = (int)PieceEnum.BlackPawn;
            Board[1, 1] = (int)PieceEnum.BlackPawn;
            Board[1, 2] = (int)PieceEnum.BlackPawn;
            Board[1, 3] = (int)PieceEnum.BlackPawn;
            Board[1, 4] = (int)PieceEnum.BlackPawn;
            Board[1, 5] = (int)PieceEnum.BlackPawn;
            Board[1, 6] = (int)PieceEnum.BlackPawn;
            Board[1, 7] = (int)PieceEnum.BlackPawn;

            Board[6, 0] = (int)PieceEnum.WhitePawn;
            Board[6, 1] = (int)PieceEnum.WhitePawn;
            Board[6, 2] = (int)PieceEnum.WhitePawn;
            Board[6, 3] = (int)PieceEnum.WhitePawn;
            Board[6, 4] = (int)PieceEnum.WhitePawn;
            Board[6, 5] = (int)PieceEnum.WhitePawn;
            Board[6, 6] = (int)PieceEnum.WhitePawn;
            Board[6, 7] = (int)PieceEnum.WhitePawn;
            Board[7, 0] = (int)PieceEnum.WhiteRook;
            Board[7, 1] = (int)PieceEnum.WhiteKnight;
            Board[7, 2] = (int)PieceEnum.WhiteBishop;
            Board[7, 3] = (int)PieceEnum.WhiteKing;
            Board[7, 4] = (int)PieceEnum.WhiteQueen;
            Board[7, 5] = (int)PieceEnum.WhiteBishop;
            Board[7, 6] = (int)PieceEnum.WhiteKnight;
            Board[7, 7] = (int)PieceEnum.WhiteRook;
        }

        public static void DisplayPiece(Panel pnlBoard)
        {
            var pieces = pnlBoard.Controls;
            foreach (var p in pieces)
            {
                //Buttonかどうか判定
                var pic = p as PictureBox;
                if (pic == null) continue;

                //Tagが未設定であればContinue
                var tag = Convert.ToString(pic.Tag);
                if (tag == string.Empty) continue;

                //Tagの先頭と後ろの文字を数値型に変換
                var tags = tag.Split(',');
                var row = Convert.ToInt32(tags[0]);
                var col = Convert.ToInt32(tags[1]);

                //PictureBoxへ表示させる画像を取得
                var image = PieceGetter.GetPieceImage(row, col);
                pic.BackgroundImage = image;
            }
        }

        public static void MoveRangePaint(Panel pnl, List<Tuple<int, int>> range = null)
        {
            if (range == null) range = new List<Tuple<int, int>>();
            foreach (var ob in pnl.Controls)
            {
                var pic = ob as PictureBox;
                if (pic == null) continue;
                var tag = PieceGetter.GetTag(pic.Tag);
                pic.Image = null;

                var isSelecter = false;
                if (ChessItem.Selecter != null && range.Count > 0)
                {
                    isSelecter = ChessItem.Selecter.Item1 == tag.Item1 && ChessItem.Selecter.Item2 == tag.Item2;
                }
                //選択移動範囲、または、選択中のマスであればtrue
                if (range.Contains(tag) || isSelecter)
                {
                    //PictureBoxに表示する画像を準備
                    var canvas = new Bitmap(pic.Width, pic.Height);
                    var g = Graphics.FromImage(canvas);

                    //枠線を描く
                    var color = isSelecter ? Color.Blue : Color.Red;
                    var p = new Pen(color, 10);
                    g.DrawRectangle(p, 0, 0, pic.Width, pic.Height);

                    //リソース解放。これをしないと段々重くなる
                    p.Dispose();
                    g.Dispose();
                    pic.Image = canvas;
                }
                else
                {
                    //PictureBoxの再描写
                    pic.Refresh();
                }
            }
        }

        public static void TurnChange()
        {
            if (ChessItem.Turn == TurnEnum.White)
            {
                ChessItem.Turn = TurnEnum.Black;
            }
            else
            {
                ChessItem.Turn = TurnEnum.White;
            }
        }
    }
}
