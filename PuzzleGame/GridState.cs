using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame
{
    public class GridState
    {
        public List<Dot> Dots { get; private set; }
        public Dictionary<Colors, Line> Lines { get; private set; }
        public Dictionary<Colors, Line> Polygons { get; private set; }
        

    }
}
