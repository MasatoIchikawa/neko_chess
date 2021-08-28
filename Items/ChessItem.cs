using neko_chess.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace neko_chess.Items
{
    public static class ChessItem
    {
        //盤面の配列
        public static int[,] Board;
        //選択中のマス
        public static Tuple<int, int> Selecter;
        //移動可能範囲
        public static List<Tuple<int, int>> MoveRange;
        //白、または、黒の番かを保存
        public static TurnEnum Turn;
        public static int CpuLevel;
    }
}
