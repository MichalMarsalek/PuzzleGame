using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PuzzleGame
{
    public class Line
    {
        public List<Dot> Dots { get; private set; }
        public Vector TemporaryEnd;
        public Colors Color;

        public Line(Colors color)
        {
            Color = color;
            Dots = new List<Dot>();
        }

        internal void Paint(Graphics g)
        {
            Color edge = ExtensionMethods.EdgeColor(Color);
            Color fill = ExtensionMethods.FillColor(Color);
            int len = Dots.Count;
            g.FillCircle(edge, Dots[0].Position, 0.2f);
            if (!(TemporaryEnd is null))
            {
                g.DrawLine(new Pen(edge, 0.2f), Dots[len - 1].Position, TemporaryEnd);
                g.DrawLine(new Pen(fill, 0.16f), Dots[len - 1].Position, TemporaryEnd);
                RepaintPreviousFill(g, Dots[len - 1]);
            }
            g.FillCircle(fill, Dots[0].Position, 0.18f);
        }

        internal void RepaintPreviousFill(Graphics g, Dot dot)
        {
            if (Dots.Count > 1)
            {
                Color edge = ExtensionMethods.EdgeColor(Color);
                Color fill = ExtensionMethods.FillColor(Color);
                for(int i = 0; i < Dots.Count-1; i++)
                {
                    if(Dots[i+1] == dot)
                    {
                        Dot previous = Dots[i];
                        Vector vec = (dot.Position - previous.Position).Normalise() * 0.2f;
                        g.DrawLine(new Pen(fill, 0.16f), dot.Position, dot.Position - vec);
                    }
                }
            }
        }

        internal bool EndsAt(Dot dot)
        {
            if (Dots.Count > 0)
            {
                /*if (Dots[0] == dot)
                {
                    Dots.Reverse();
                    return true;
                }*/
                if (Dots[Dots.Count - 1] == dot)
                {
                    return true;
                }
            }
            return false;

        }
    }
}
