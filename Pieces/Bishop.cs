using System;
using System.Collections.Generic;
using static neko_chess.Items.ChessItem;

namespace neko_chess.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(int row, int col)
        {
            Range = new List<Tuple<int, int>>();

            //①右上に行けるだけ
            var r = row;
            var c = col;
            while (true)
            {
                r--;
                c++;
                if (CheckPoint(r, c)) break;
            }

            //②右下に行けるだけ
            r = row;
            c = col;
            while (true)
            {
                r++;
                c++;
                if (CheckPoint(r, c)) break;
            }

            //③左下に行けるだけ
            r = row;
            c = col;
            while (true)
            {
                r++;
                c--;
                if (CheckPoint(r, c)) break;
            }

            //④左上に行けるだけ
            r = row;
            c = col;
            while (true)
            {
                r--;
                c--;
                if (CheckPoint(r, c)) break;
            }
        }

        private bool CheckPoint(int row, int col)
        {
            //盤面外なら進めないためforを抜ける
            if (!CheckIndex(row, col))
            {
                return true;
            }

            var point = Board[row, col];
            if (Empty(point)) //空きマスなら進める
            {
                Range.Add(Tuple.Create(row, col));
                return false; //もっと先のマスへ進める
            }

            if (Friend(point)) //味方の駒なら取れない
            {
                return true; //取れないためrangeにも入れずforを抜ける
            }

            if (Enemy(point)) //敵の駒なら取れる
            {
                Range.Add(Tuple.Create(row, col));
                return true; ; //それ以上進めないためforを抜ける
            }

            return true;
        }
    }
}
