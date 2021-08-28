using neko_chess.Enums;
using System;
using System.Collections.Generic;
using static neko_chess.Items.ChessItem;

namespace neko_chess.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(int row, int col)
        {
            int move;
            int startPosition;
            if (Turn == TurnEnum.White)
            {
                move = -1;
                startPosition = 6;
            }
            else
            {
                move = 1;
                startPosition = 1;
            }

            Range = new List<Tuple<int, int>>();

            //①前方１マスに動けるか確認
            var r = row + move;
            var c = col;
            if (CheckIndex(r, c)) //選択範囲が盤面内ならtrue
            {
                var point = Board[r, c]; //目的のマスの駒を取得
                if (Empty(Board[r, c])) //空きマスならtrue、敵の駒は取れない。たぶん
                {
                    Range.Add(Tuple.Create(r, c));
                }
            }

            //②スタート地点の場合のみ、前方２マス動ける
            if (row == startPosition)
            {
                //前方２マス目に何もないか確認
                r = row + (move * 2);
                c = col;
                if (CheckIndex(r, c)) //選択範囲が盤面内ならtrue
                {
                    var point = Board[r, c]; //目的のマスの駒を取得
                    if (EnemyOrEmpty(Board[r, c])) //敵の駒、または、空きマスならtrue
                    {
                        Range.Add(Tuple.Create(r, c));
                    }
                }
            }

            //③左斜め前方に敵の駒があれば取れる
            r = row + move;
            c = col + move;

            if (CheckIndex(r, c)) //選択範囲が盤面内ならtrue
            {
                var point = Board[r, c]; //目的のマスの駒を取得
                if (Enemy(point)) //敵の駒ならtrue
                {
                    //黒であるなら、取れるため選択範囲に含む
                    Range.Add(Tuple.Create(r, c));
                }
            }

            //④右斜め前方も同様に判定する
            r = row + move;
            c = col - move;

            if (CheckIndex(r, c)) //選択範囲が盤面内ならtrue
            {
                var point = Board[r, c]; //目的のマスの駒を取得
                if (Enemy(point)) //敵の駒ならtrue
                {
                    //黒であるなら、取れるため選択範囲に含む
                    Range.Add(Tuple.Create(r, c));
                }
            }
        }
    }
}
