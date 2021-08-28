using System;
using System.Collections.Generic;
using static neko_chess.Items.ChessItem;

namespace neko_chess.Pieces
{
    public class Knight : Piece
    {
        public Knight(int row, int col)
        {
            Range = new List<Tuple<int, int>>();

            //①上２右１のマス
            CheckPoint(row - 2, col + 1);

            //②上１右２のマス
            CheckPoint(row - 1, col + 2);

            //③下１右２のマス
            CheckPoint(row + 1, col + 2);

            //④下２右１のマス
            CheckPoint(row + 2, col + 1);

            //⑤下２左１のマス
            CheckPoint(row + 2, col - 1);

            //⑥下１左２のマス
            CheckPoint(row + 1, col - 2);

            //⑦上１左２のマス
            CheckPoint(row - 1, col - 2);

            //⑧上２左１のマス
            CheckPoint(row - 2, col - 1);
        }

        private void CheckPoint(int row, int col)
        {
            //盤面外なら進めない
            if (!CheckIndex(row, col))
            {
                return;
            }

            var point = Board[row, col];
            if (Empty(point)) //空きマスなら取れる
            {
                Range.Add(Tuple.Create(row, col));
                return;
            }

            if (Friend(point)) //味方の駒なら取れない
            {
                return;
            }

            if (Enemy(point)) //敵の駒なら取れる
            {
                Range.Add(Tuple.Create(row, col));
                return;
            }

            return;
        }
    }
}
