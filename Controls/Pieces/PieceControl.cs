using neko_chess.Controls;
using neko_chess.Controls.Boards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static neko_chess.Items.ChessItem;

namespace neko_chess.Controls.Pieces
{
    public class PieceControl
    {
        private Panel _panel;
        private Tuple<int, int> _tag;

        public PieceControl(Panel panel, Tuple<int, int> tag)
        {
            _panel = panel;
            _tag = tag;
        }

        public void CheckRange()
        {
            //移動可能範囲を取得
            MoveRange = PieceRange.Get(_tag);

            //移動可能なマスがあれば、駒を選択したものとする
            if (MoveRange.Any())
            {
                Selecter = Tuple.Create<int, int>(_tag.Item1, _tag.Item2);
            }

            //盤面の移動可能なマス、または、選択中のマスを枠線で囲む
            BoardControl.MoveRangePaint(_panel, MoveRange);
        }

        public bool Move()
        {
            var isMove = false;

            //移動先のTag
            if (MoveRange.Contains(_tag))
            {
                //移動前のマスの駒番号
                var pieceNumber = Board[Selecter.Item1, Selecter.Item2];
                //選択範囲なので動く
                Board[_tag.Item1, _tag.Item2] = pieceNumber;
                //移動前のマスは空白にする
                Board[Selecter.Item1, Selecter.Item2] = 0;
                isMove = true;

                //ポーンが最終行まで到達したら成る必要がある
                var blackPawn = pieceNumber == (int)PieceEnum.BlackPawn && _tag.Item1 == 7;
                var whitePawn = pieceNumber == (int)PieceEnum.WhitePawn && _tag.Item1 == 0;
                if (blackPawn || whitePawn)
                {
                    var form = new ChangePiece();
                    form.ShowDialog();
                    Board[_tag.Item1, _tag.Item2] = form.SelectPiece;
                    form.Dispose();
                }
            }

            //選択マスを消去
            Selecter = null;
            MoveRange = null;
            return isMove;
        }
    }
}
