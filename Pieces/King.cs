using System;
using System.Collections.Generic;
using static neko_chess.Items.ChessItem;

namespace neko_chess.Pieces
{
    public class King : Piece
    {
        public King(int row, int col)
        {
            //①上のマス
            CheckPoint(row - 1, col);

            //②右上のマス
            CheckPoint(row - 1, col + 1);

            //③右のマス
            CheckPoint(row, col + 1);

            //④右下のマス
            CheckPoint(row + 1, col + 1);

            //⑤下のマス
            CheckPoint(row + 1, col);

            //⑥左下のマス
            CheckPoint(row + 1, col - 1);

            //⑦左のマス
            CheckPoint(row, col - 1);

            //⑧左上のマス
            CheckPoint(row - 1, col - 1);
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
