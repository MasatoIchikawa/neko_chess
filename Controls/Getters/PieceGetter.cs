using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static neko_chess.Items.ChessItem;

namespace neko_chess.Controls.Getters
{
    public static class PieceGetter
    {
        public static Tuple<int, int> GetTag(object tag)
        {
            //Tagが未設定であればContinue
            var tagStr = Convert.ToString(tag);
            if (tagStr == string.Empty)
            {
                return null;
            }

            //Tagの先頭と後ろの文字を数値型に変換
            var tags = tagStr.Split(',');
            var row = Convert.ToInt32(tags[0]);
            var col = Convert.ToInt32(tags[1]);
            return new Tuple<int, int>(row, col);
        }

        public static Bitmap GetPieceImage(int row, int col)
        {
            var pieceNumber = Board[row, col];
            switch (pieceNumber)
            {
                case (int)PieceEnum.BlackPawn:
                    return Properties.Resources.Black_Pawn;
                case (int)PieceEnum.BlackRook:
                    return Properties.Resources.Black_Rook;
                case (int)PieceEnum.BlackKnight:
                    return Properties.Resources.Black_Knight;
                case (int)PieceEnum.BlackBishop:
                    return Properties.Resources.Black_Bishop;
                case (int)PieceEnum.BlackQueen:
                    return Properties.Resources.Black_Queen;
                case (int)PieceEnum.BlackKing:
                    return Properties.Resources.Black_King;

                case (int)PieceEnum.WhitePawn:
                    return Properties.Resources.White_Pawn;
                case (int)PieceEnum.WhiteRook:
                    return Properties.Resources.White_Rook;
                case (int)PieceEnum.WhiteKnight:
                    return Properties.Resources.White_Knight;
                case (int)PieceEnum.WhiteBishop:
                    return Properties.Resources.White_Bishop;
                case (int)PieceEnum.WhiteQueen:
                    return Properties.Resources.White_Queen;
                case (int)PieceEnum.WhiteKing:
                    return Properties.Resources.White_King;
                default:
                    return null;
            }
        }
    }
}
