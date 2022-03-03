using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame
{
    public class LineSegment
    {
        public Dot A;
        public Dot B;
        public Line Line;

        public LineSegment(Dot a, Dot b, Line line = null)
        {
            A = a;
            B = b;
            Line = line;
        }

        public override bool Equals(object obj)
        {
            var segment = obj as LineSegment;
            return segment != null &&
                   (this.A == segment.A && this.B == segment.B
                || this.A == segment.B && this.B == segment.A);
        }

        public override int GetHashCode()
        {
            return A.Position.X.GetHashCode() ^ A.Position.Y.GetHashCode() ^ B.Position.X.GetHashCode() ^ B.Position.Y.GetHashCode();
        }

        internal void Paint(Graphics g)
        {
            Color edge = Util.EdgeColor(Line.Color);
            Color fill = Util.FillColor(Line.Color);
            g.DrawLine(new Pen(edge, 0.2f), A.Position, B.Position);
            g.DrawLine(new Pen(fill, 0.16f), A.Position, B.Position);
            Line.RepaintPreviousFill(g, A);
            Line.RepaintPreviousFill(g, B);

        }

        internal float DistanceTo(Dot dot_point)
        {
            //TODO refactor
            Vector a = this.A.Position;
            Vector b = this.B.Position;
            Vector d = dot_point.Position;
            var x = d.X;
            var y = d.Y;
            var x1 = a.X;
            var y1 = a.Y;
            var x2 = b.X;
            var y2 = b.Y;
            var A = x - x1;
            var B = y - y1;
            var C = x2 - x1;
            var D = y2 - y1;

            var dot = A * C + B * D;
            var len_sq = C * C + D * D;
            float param = -1;
            if (len_sq != 0) //in case of 0 length line
                param = dot / len_sq;

            float xx, yy;

            if (param < 0)
            {
                xx = x1;
                yy = y1;
            }
            else if (param > 1)
            {
                xx = x2;
                yy = y2;
            }
            else
            {
                xx = x1 + param * C;
                yy = y1 + param * D;
            }

            var dx = x - xx;
            var dy = y - yy;
            return (float)Math.Sqrt(dx * dx + dy * dy);            
        }
        /*
        public static bool operator ==(LineSegment segment1, LineSegment segment2)
        {
            return segment1.A == segment2.A && segment1.B == segment2.B
                || segment1.A == segment2.B && segment1.B == segment2.A;
        }

        public static bool operator !=(LineSegment segment1, LineSegment segment2)
        {
            return !(segment1 == segment2);
        }*/
    }
}
