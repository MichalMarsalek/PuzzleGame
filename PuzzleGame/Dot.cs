using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PuzzleGame
{
    public enum Colors
    {
        None = -1, White, Red, Green, Blue, Yellow, Orange, Cyan, Magenta, Gray, Black, Pink, Teal, Lavender, Brown, Beige, Maroon, Mint, Navy
    }

    public class Dot
    {
        public Colors Color;
        public Vector Position;

        public Dot(Vector pos, Colors color)
        {
            Position = pos;
            Color = color;
        }

        internal void Paint(Graphics g, Color overrideEdge)
        {
            //Color edge = Extensions.EdgeColor(Color);
            //Color fill = Extensions.FillColor(Color);
            float size = Color == Colors.White ? 0.05f : 0.1f;
            g.FillCircle(overrideEdge, Position, size);
            //g.FillCircle(fill, Position, size - 0.01f);
        }
        internal void Paint(Graphics g)
        {
            Color edge = Util.EdgeColor(Color);
            Paint(g, edge);
        }
    }
}
