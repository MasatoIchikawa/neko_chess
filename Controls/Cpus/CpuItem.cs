using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neko_chess.Controls.Cpus
{
    public class CpuItem
    {
        public Tuple<int, int> Board { get; set; }
        public List<Tuple<int, int>> MoveRange { get; set; }
        public List<Tuple<int, int, int>> GetRange { get; set; } //Item1 = row, Item2 = col, Item3 = PieceNumber
    }
}
