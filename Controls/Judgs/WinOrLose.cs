using neko_chess.Controls.Pieces;
using neko_chess.Forms.Message;
using neko_chess.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static neko_chess.Items.ChessItem;

namespace neko_chess.Controls.Judgs
{
    public static class WinOrLose
    {
        public static MessageEnum Judg()
        {
            if (WhiteWin()) return MessageEnum.WinWhite;
            if (BlackWin()) return MessageEnum.WinBlack;
            return MessageEnum.None;
        }

        private static bool WhiteWin()
        {
            foreach (var b in Board)
            {
                //黒のキングがあれば、まだ勝利していない
                if (b == (int)PieceEnum.BlackKing) return false;
            }

            //盤面に黒のキングが見当たらないため勝利
            return true;
        }

        private static bool BlackWin()
        {
            foreach (var b in Board)
            {
                //白のキングがあれば、まだ勝利していない
                if (b == (int)PieceEnum.WhiteKing) return false;
            }

            //盤面に白のキングが見当たらないため勝利
            return true;
        }

        public static bool Check()
        {
            //自分の駒のみ取得
            var pieceList = new List<Tuple<int, int>>();
            for (var row = 0; row <= 7; row++)
            {
                for (var col = 0; col <= 7; col++)
                {
                    var pieceNumber = Board[row, col];
                    if (pieceNumber == (int)PieceEnum.Nothing) continue;
                    if (Turn == Enums.TurnEnum.White)
                    {
                        if (PieceColorJudg.IsBlack(pieceNumber)) continue;
                    }
                    else
                    {
                        if (PieceColorJudg.IsWhite(pieceNumber)) continue;
                    }

                    pieceList.Add(Tuple.Create(row, col));
                }
            }

            //黒の駒のうち、移動できる駒のみを取得
            //ついでにMoveRangeへ移動可能なマスも取得
            foreach (var i in pieceList)
            {
                var range = PieceRange.Get(i);
                if (!range.Any()) continue;

                //キングの駒を取れそうであれば、trueを返す
                foreach (var g in range)
                {
                    var piece = Board[g.Item1, g.Item2];
                    if (piece == (int)PieceEnum.BlackKing || piece == (int)PieceEnum.WhiteKing)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
