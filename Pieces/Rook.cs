using static neko_chess.Items.ChessItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace neko_chess.Pieces
{
    public class Rook : Piece
    {
        public Rook(int row, int col)
        {
            Range = new List<Tuple<int, int>>();

            //①上方向に行けるだけ
            for (var i = row - 1; i >= 0; i--)
            {
                if (CheckPoint(i, col)) break;
            }

            //②下方向に行けるだけ
            for (var i = row + 1; i <= 7; i++)
            {
                if (CheckPoint(i, col)) break;
            }

            //③右方向に行けるだけ
            for (var i = col + 1; i <= 7; i++)
            {
                if (CheckPoint(row, i)) break;
            }

            //④左右方向に行けるだけ
            for (var i = col - 1; i >= 0; i--)
            {
                if (CheckPoint(row, i)) break;
            }
        }

        private bool CheckPoint(int row, int col)
        {
            //盤面外なら進めないためforを抜ける
            if (!CheckIndex(row, col))
            {
                return true;
            }

            var point = Board[row , col];
            if (Empty(point)) //空きマスなら進める
            {
                Range.Add(Tuple.Create(row , col));
                return false; //もっと先のマスへ進める
            }

            if (Friend(point)) //味方の駒なら取れない
            {
                return true; //取れないためrangeにも入れず、breakでforを抜ける
            }

            if (Enemy(point)) //敵の駒なら取れる
            {
                Range.Add(Tuple.Create(row, col));
                return true; ; //それ以上進めないためbreakでforを抜ける
            }

            return true;
        }
    }
}
