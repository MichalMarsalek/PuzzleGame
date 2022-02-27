using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame
{
    public static class Extensions
    {
        public static void FillCircle(this Graphics g, Color color, Vector center, float radius)
        {
            g.DrawCircle(new SolidBrush(color), center, radius);
        }
        public static void DrawCircle(this Graphics g, Brush brush, Vector center, float radius)
        {
            g.FillEllipse(brush, new RectangleF((center - new Vector(radius, radius)).ToPointF(), new SizeF(2 * radius, 2 * radius)));
        }

        public static void DrawLine(this Graphics g, Pen pen, Vector start, Vector end, bool round = true)
        {
            g.DrawLine(pen, new List<Vector>() { start, end }, round);
        }

        public static void DrawLine(this Graphics g, Pen pen, IEnumerable<Vector> points, bool round = true)
        {
            if (round)
            {
                pen = (Pen)pen.Clone();
                pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            }
            var points2 = points.ToList();
            if (points2.Count > 1)
            {
                for (int i = 0; i < points2.Count - 1; i++)
                {
                    g.DrawLine(pen, points2[i].ToPointF(), points2[i + 1].ToPointF());
                }
            }
        }

        public static void DrawString(this Graphics g, Vector p, string s, Font font, Brush b = null)
        {
            b = b ?? Brushes.Black;
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            g.DrawString(s, font, b, p.ToPointF(), stringFormat);
        }

        public static Color ChangeColorBrightness(Color color, float correctionFactor)
        {
            float red = (float)color.R;
            float green = (float)color.G;
            float blue = (float)color.B;

            if (correctionFactor < 0)
            {
                correctionFactor = 1 + correctionFactor;
                red *= correctionFactor;
                green *= correctionFactor;
                blue *= correctionFactor;
            }
            else
            {
                red = (255 - red) * correctionFactor + red;
                green = (255 - green) * correctionFactor + green;
                blue = (255 - blue) * correctionFactor + blue;
            }

            return Color.FromArgb(color.A, (int)red, (int)green, (int)blue);
        }

        public static Color BaseColor(Colors color)
        {
            return new Dictionary<Colors, Color>()
            {//Grey, Black, Pink, Teal, Lavender, Brown, Beige, Maroon, Mint, Navy
                { Colors.White,     Color.FromArgb(220, 220, 220) },
                { Colors.Red,       Color.FromArgb(230, 25, 75) },
                { Colors.Green,     Color.FromArgb(50, 160, 65) },
                { Colors.Blue,      Color.FromArgb(0, 130, 200) },
                { Colors.Yellow,    Color.FromArgb(215, 245, 23) },
                { Colors.Orange,    Color.FromArgb(245, 130, 48) },
                { Colors.Cyan,      Color.FromArgb(70, 240, 240) },
                { Colors.Magenta,   Color.FromArgb(240, 50, 230) },
                { Colors.Gray,      Color.FromArgb(128, 128, 128) },
                { Colors.Black,     Color.FromArgb(50, 50, 50) },
                { Colors.Pink,      Color.FromArgb(230, 170, 200) },
                { Colors.Teal,      Color.FromArgb(0, 128, 128) },
                { Colors.Lavender,  Color.FromArgb(220, 190, 255) },
                { Colors.Brown,     Color.FromArgb(170, 110, 40) },
                { Colors.Beige,     Color.FromArgb(225, 250, 200) },
                { Colors.Maroon,    Color.FromArgb(128, 0, 0) },
                { Colors.Mint,      Color.FromArgb(170, 255, 195) },
                { Colors.Navy,      Color.FromArgb(0, 0, 128) }
            }[color];
        }

        public static Color EdgeColor(Colors color)
        {
            return Extensions.ChangeColorBrightness(Extensions.BaseColor(color), -0.2f);
        }

        public static Color FillColor(Colors color)
        {
            float lighten = 0.7f;
            if (color == Colors.Black)
            {
                lighten = 0.3f;
            }
            if (color == Colors.Pink || color == Colors.Beige || color == Colors.Mint || color == Colors.Lavender)
            {
                lighten = 0.5f;
            }
            return Extensions.ChangeColorBrightness(Extensions.BaseColor(color), lighten);
        }

        public static T Pop<T>(this List<T> list, int index = 0)
        {
            var result = list[index];
            list.RemoveAt(index);
            return result;
        }

        public static IEnumerable<T> Get<T>()
            => ((T[])Enum.GetValues(typeof(T)));

        public static string FirstLetterToUpper(this string str)
        {
            if (str == null)
                return null;

            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1);

            return str.ToUpper();
        }
    }
}