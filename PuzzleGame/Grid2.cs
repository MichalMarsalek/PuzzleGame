using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace PuzzleGame
{
    public partial class Grid2 : UserControl
    {

        public List<Dot> Dots { get; private set; }
        public Line[] Lines { get; private set; }
        public List<LineSegment> LineSegments{get; private set;}
        public Line ActiveLine { get; private set; }
        public Color BackgroundColor { get; set; }
        private List<BackgroundLayer> Backgrounds;

        public float snap = 0.2f;
        private bool activeLineJustCreated;

        private Point downScreenCoords;
        private Vector downCanvasCoords;
        private PointF downCanvasOrigin;

        public Vector MouseLocation
        {
            get
            {
                return new Vector(canvas.MouseLocation);
            }
        }

        internal void SetGrid(GridSetupCode gridSetupCode)
        {
            ClearLines();
            Dots = gridSetupCode.Result;
            if (Dots != null && Dots.Count > 0)
            {
                float minX = Dots.Min(i => i.Position.X);
                float maxX = Dots.Max(i => i.Position.X);
                float minY = Dots.Min(i => i.Position.Y);
                float maxY = Dots.Max(i => i.Position.Y);
                canvas.Dimensions = new SizeF(maxX - minX + 1, maxY - minY + 1);
                canvas.Origin = new PointF(+minX - 0.5f, +minY-0.5f);
                canvas.Refresh();
            }
        }

        public Grid2() : base()
        {
            Dots = new List<Dot>();
            Lines = new Line[Enum.GetNames(typeof(Colors)).Length - 1];
            LineSegments = new List<LineSegment>();
            BackgroundColor = Color.Red;
            Backgrounds = new List<BackgroundLayer>()
            {
                new BackgroundLayer(new AnimatedColor(
                    new AnimatedDouble(0,1,0.1,false),
                    new AnimatedDouble(0), //1
                    new AnimatedDouble(0.5),
                    new AnimatedDouble(0.5)
                ))
            };
            ShapeBackgroundLayer square = new ShapeBackgroundLayer(BackgroundShapes.Square,
                new AnimatedColor(
                    new AnimatedDouble(0.333),
                    new AnimatedDouble(0),
                    new AnimatedDouble(0.5),
                    new AnimatedDouble(0.1, 0.1, 1, true)
                )
            );
            square.Scale = new AnimatedDouble(0.2, 0.05, 1, true, true);
            square.TransX = new AnimatedDouble(0, 0.2, 1, true, true);
            square.TransY = new AnimatedDouble(-0.5, 11, 0.02, false, true);
            Backgrounds.Add(square);

            InitializeComponent();
        }

        private void ClearLines()
        {
            for(int i = 0; i < Enum.GetNames(typeof(Colors)).Length - 1; i++)
            {
                Lines[i] = null;
            }
            LineSegments.Clear();
        }

        public void SetGrid(int width, int heigth)
        {
            Dots.Clear();
            ClearLines();
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < width; y++)
                {
                    Dots.Add(new Dot(new Vector(x, y), Colors.White));
                }
            }
            canvas.Dimensions = new SizeF(width, heigth);
            canvas.Refresh();
        }

        private Dot GetClosestDot(Vector v, float limit = 100000000f)
        {
            if (Dots.Count == 0) return null;
            Dot result = Dots.OrderBy(i => i.Position.Dist2(v)).First();
            if (result.Position.Dist1(v) > limit)
            {
                return null;
            }
            return result;
        }

        public Vector GetClosestDotOrNew(Vector v, float limit = 100000000f)
        {
            if (Dots.Count == 0) return v;
            Dot result = Dots.OrderBy(i => i.Position.Dist1(v)).First();
            if (result.Position.Dist1(v) > limit)
            {
                return v;
            }
            return result.Position;
        }

        private Colors NewLineColor()
        {
            for (int i = 1; i < Enum.GetNames(typeof(Colors)).Length-1; i++)
            {
                if (Lines[i] == null)
                {
                    return (Colors)i;
                }
            }
            return Colors.None;
        }

        private Line GetLineOfClosestDot(Vector v, float limit = 100000000f)
        {
            Dot dot = GetClosestDot(v, limit);
            if (dot == null) return null;
            foreach (Line line in Lines)
            {
                if (line != null && line.EndsAt(dot))
                {
                    return line;
                }
            }
            return null;
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            foreach(var bg in Backgrounds)
            {
                bg.Paint(g);
            }
            foreach (Dot dot in Dots)
            {
                if (dot.Color == Colors.White)
                {
                    Color res = BackgroundColor;
                    float dist = (MouseLocation - dot.Position).Norm2();
                    res = Color.FromArgb(64 - (int)(Math.Min(3f, dist) / 3f * 64), res);
                    dot.Paint(g, res);
                }
            }
            foreach (LineSegment seg in LineSegments)
            {
                seg.Paint(g);
            }
            foreach (Line line in Lines)
            {
                line?.Paint(g);
            }
            foreach (Dot dot in Dots)
            {
                if (dot.Color != Colors.White)
                {
                    dot.Paint(g);
                }
            }
        }
        
        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Vector v = new Vector(canvas.MouseLocation);
                ActiveLine = GetLineOfClosestDot(v, 0.2f);
                if (ActiveLine != null)
                {
                    ActiveLine.TemporaryEnd = v;
                }
                else
                {
                    Dot dot = GetClosestDot(v, snap);
                    Colors color = NewLineColor();
                    if (dot != null && color != Colors.None)
                    {
                        ActiveLine = new Line(color);
                        Lines[(int)color] = ActiveLine;
                        ActiveLine.Dots.Add(dot);
                        activeLineJustCreated = true;
                    }
                }
                canvas.Refresh();
                downScreenCoords = MousePosition;
                downCanvasOrigin = canvas.Origin;
                if(ActiveLine != null)
                {
                    Cursor.Hide();
                }
            }
        }

        private bool canvasFrozen = false;

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (MousePosition == downScreenCoords || canvasFrozen)
            {
                return;
            }
            if (ActiveLine != null)
            {
                //TODO bg movement
                /*canvasFrozen = true;
                var temp = MousePosition;
                //this.Cursor = new Cursor(Cursor.Current.Handle);
                Cursor.Position = downScreenCoords;
                var screenDiff = new Vector(temp) - new Vector(downScreenCoords);
                canvas.Origin = (new Vector(downCanvasOrigin) + 1/canvas.scaleQ*screenDiff).ToPointF();
                Debug.WriteLine(downScreenCoords.ToString());
                downCanvasOrigin = canvas.Origin;
                Debug.WriteLine(temp.ToString());
                Debug.WriteLine(screenDiff.ToString());
                canvasFrozen = false;*/

                Vector v = new Vector(canvas.MouseLocation);
                ActiveLine.TemporaryEnd = v;
                Dot dot = GetClosestDot(v, snap);
                if (dot != null)
                {
                    int len = ActiveLine.Dots.Count;
                    if (len >= 2 && ActiveLine.Dots[len - 2] == dot)
                    {
                        LineSegments.RemoveAll(i => i.Equals(new LineSegment(ActiveLine.Dots[len - 1], dot)));
                        ActiveLine.Dots.RemoveAt(len - 1);
                    }
                    len = ActiveLine.Dots.Count;
                    if (len > 0 && ActiveLine.Dots[len - 1] != dot)
                    {
                        LineSegment seg = new LineSegment(ActiveLine.Dots[len - 1], dot, ActiveLine);
                        if(Dots.All(i => i == seg.A || i == seg.B || seg.DistanceTo(i) > snap))
                        {
                            if (LineSegments.All(i => i.Line != seg.Line || !i.Equals(seg)))
                            {
                                ActiveLine.Dots.Add(dot);
                                LineSegments.Add(seg);
                            }
                        }
                    }
                }
            }
            canvas.Refresh();
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (ActiveLine == null)
            {
                return;
            }
            ActiveLine.TemporaryEnd = null;
            if (ActiveLine.Dots.Count == 1 && !activeLineJustCreated)
            {
                Lines[(int)ActiveLine.Color] = null;
            }
            else
            {
                activeLineJustCreated = false;
            }
            ActiveLine = null;
            canvas.Refresh();
            Cursor.Show();
            //this.OnMouseUp(e);
        }

        private void canvas_Resize(object sender, EventArgs e)
        {
            canvas.Refresh();
        }
    }
}
