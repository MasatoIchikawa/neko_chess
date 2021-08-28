using neko_chess.Controls.Judgs;
using neko_chess.Enums;
using neko_chess.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neko_chess.Pieces
{
    public class Piece
    {
        public List<Tuple<int, int>> Range = new List<Tuple<int, int>>();
        
        protected bool CheckIndex(int x, int y)
        {
            if (x >= 0 && y >= 0 && x <= 7 && y <= 7)
            {
                return true;
            }
            return false;
        }

        protected bool EnemyOrEmpty(int pieceNumber)
        {
            //何もないマスなら動かせる
            if (Empty(pieceNumber)) return true;
            return Enemy(pieceNumber);
        }

        //空白のマスならtrue
        protected bool Empty(int pieceNumber)
        {
            return pieceNumber == (int)PieceEnum.Nothing;
        }

        protected bool Enemy(int pieceNumber)
        {
            //敵の駒ならtrueとする
            if (ChessItem.Turn == TurnEnum.White)
            {
                return PieceColorJudg.IsBlack(pieceNumber);
            }
            else
            {
                return PieceColorJudg.IsWhite(pieceNumber);
            }
        }

        protected bool Friend(int pieceNumber)
        {
            //味方の駒ならtrueとする
            if (ChessItem.Turn == TurnEnum.White)
            {
                return PieceColorJudg.IsWhite(pieceNumber);
            }
            else
            {
                return PieceColorJudg.IsBlack(pieceNumber);
            }
        }
    }
}
