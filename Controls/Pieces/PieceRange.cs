using neko_chess.Controls;
using neko_chess.Controls.Judgs;
using neko_chess.Enums;
using neko_chess.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static neko_chess.Items.ChessItem;

namespace neko_chess.Controls.Pieces
{
    public static class PieceRange
    {
        public static List<Tuple<int, int>> Get(Tuple<int, int> tag)
        {
            var pieceNumber = Board[tag.Item1, tag.Item2];

            //黒のターン中に、白の駒を動かそうとしたらreturn
            if (PieceColorJudg.IsWhite(pieceNumber) && Turn == TurnEnum.Black) return new List<Tuple<int, int>>();
            //白のターン中に、黒の駒を動かそうとしたらreturn
            if (PieceColorJudg.IsBlack(pieceNumber) && Turn == TurnEnum.White) return new List<Tuple<int, int>>();
            switch (pieceNumber)
            {
                case (int)PieceEnum.WhitePawn:
                case (int)PieceEnum.BlackPawn:
                    return new Pawn(tag.Item1, tag.Item2).Range;
                case (int)PieceEnum.WhiteRook:
                case (int)PieceEnum.BlackRook:
                    return new Rook(tag.Item1, tag.Item2).Range;
                case (int)PieceEnum.WhiteKnight:
                case (int)PieceEnum.BlackKnight:
                    return new Knight(tag.Item1, tag.Item2).Range;
                case (int)PieceEnum.WhiteBishop:
                case (int)PieceEnum.BlackBishop:
                    return new Bishop(tag.Item1, tag.Item2).Range;
                case (int)PieceEnum.WhiteQueen:
                case (int)PieceEnum.BlackQueen:
                    return new Queen(tag.Item1, tag.Item2).Range;
                case (int)PieceEnum.WhiteKing:
                case (int)PieceEnum.BlackKing:
                    return new King(tag.Item1, tag.Item2).Range;
                default:
                    return new List<Tuple<int, int>>();
            }
        }
    }
}
