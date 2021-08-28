using neko_chess.Controls;
using neko_chess.Controls.Judgs;
using neko_chess.Controls.Pieces;
using neko_chess.Enums;
using neko_chess.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static neko_chess.Items.ChessItem;

namespace neko_chess.Controls.Cpus
{
    public class Cpu
    {
        private CpuItem _item;

        public Tuple<int, int> Get()
        {
            if (_item == null)
            {
                //移動範囲をチェック
                return Range();
            }
            else
            {
                //移動場所をreturnで返す
                var move = Move();
                _item = null;
                return move;
            }
        }

        private Tuple<int, int> Range()
        {
            //黒の駒のみ取得
            var black = new List<Tuple<int, int>>();
            for (var row = 0; row <= 7; row++)
            {
                for (var col = 0; col <= 7; col++)
                {
                    var pieceNumber = ChessItem.Board[row, col];
                    if (pieceNumber == (int)PieceEnum.Nothing) continue;
                    if (PieceColorJudg.IsWhite(pieceNumber)) continue;

                    black.Add(Tuple.Create(row, col));
                }
            }

            //黒の駒のうち、移動できる駒のみを取得
            //ついでにMoveRangeへ移動可能なマスも取得
            var list = new List<CpuItem>();
            foreach (var i in black)
            {
                var range = PieceRange.Get(i);
                if (!range.Any()) continue;

                //白の駒を取れそうであれば、getRangeへ格納する
                var getRange = new List<Tuple<int, int, int>>();
                foreach (var g in range)
                {
                    var piece = Board[g.Item1, g.Item2];
                    if (PieceColorJudg.IsWhite(piece))
                    {
                        getRange.Add(Tuple.Create(g.Item1, g.Item2, piece));
                    }
                }

                var item = new CpuItem();
                item.Board = i;
                item.MoveRange = range;
                item.GetRange = getRange;
                list.Add(item);
            }

            if (!list.Any()) return null;

            switch (CpuLevel)
            {
                case (int)CpuLevelEnum.Level1:
                    //動かす駒は完全にランダム
                    break;
                case (int)CpuLevelEnum.Level2:
                    //取れそうな駒があれば、それを動かす
                    var getRangeList = list.Where(a => a.GetRange.Any()).ToList();
                    if (getRangeList.Any())
                    {
                        list = getRangeList;
                    }
                    break;
                case (int)CpuLevelEnum.Level3:
                    var level3List = list.Where(a => a.GetRange.Any()).ToList();
                    if (level3List.Any())
                    {
                        list = level3List.OrderByDescending(a => a.GetRange.Max(b => b.Item3)).ToList();
                        _item = list.First();
                        return _item.Board;
                    }
                    break;
            }
            //移動する駒をランダム関数で決定する
            var num = new Random().Next(list.Count - 1);
            _item = list[num];

            return _item.Board;
        }

        private Tuple<int, int> Move()
        {
            //MoveRangeへ入れているのは、移動可能範囲を盤面に表示するため
            MoveRange = _item.MoveRange;
            int num;
            switch (CpuLevel)
            {
                case (int)CpuLevelEnum.Level2:
                    if (_item.GetRange.Any())
                    {
                        //取れそうな駒があれば、それを動かす
                        num = new Random().Next(_item.GetRange.Count - 1);
                        var t = _item.GetRange[num];
                        return Tuple.Create(t.Item1, t.Item2);
                    }
                    else
                    {
                        //取れる駒がなければランダムに決定する
                        num = new Random().Next(_item.MoveRange.Count - 1);
                        return _item.MoveRange[num];
                    }
                case (int)CpuLevelEnum.Level3:
                    if (_item.GetRange.Any())
                    {
                        //取れそうな駒があれば、それを動かす
                        //強い駒を優先的に取る
                        var t = _item.GetRange.OrderByDescending(a => a.Item3).ToList().First();
                        return Tuple.Create(t.Item1, t.Item2);
                    }
                    else
                    {
                        //取れる駒がなければランダムに決定する
                        num = new Random().Next(_item.MoveRange.Count - 1);
                        return _item.MoveRange[num];
                    }
                default:
                    //移動場所をランダム関数で決定する
                    num = new Random().Next(_item.MoveRange.Count - 1);
                    return _item.MoveRange[num];
            }
        }
    }
}
