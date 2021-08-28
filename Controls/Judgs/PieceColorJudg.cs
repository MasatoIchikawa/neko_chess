using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neko_chess.Controls.Judgs
{
    public static class PieceColorJudg
    {
        public static bool IsBlack(int pieceNumber)
        {
            switch (pieceNumber)
            {
                case (int)PieceEnum.BlackPawn:
                case (int)PieceEnum.BlackRook:
                case (int)PieceEnum.BlackKnight:
                case (int)PieceEnum.BlackBishop:
                case (int)PieceEnum.BlackQueen:
                case (int)PieceEnum.BlackKing:
                    return true;
            }

            return false;
        }

        public static bool IsWhite(int pieceNumber)
        {
            switch (pieceNumber)
            {
                case (int)PieceEnum.WhitePawn:
                case (int)PieceEnum.WhiteRook:
                case (int)PieceEnum.WhiteKnight:
                case (int)PieceEnum.WhiteBishop:
                case (int)PieceEnum.WhiteQueen:
                case (int)PieceEnum.WhiteKing:
                    return true;
            }

            return false;
        }
    }
}
