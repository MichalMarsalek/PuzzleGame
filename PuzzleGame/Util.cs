﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame
{
    public static class Util
    {
        public static Random Random = new Random();

        private static Matrix transform;

        public static void RotateAround(this Graphics g, Vector pos, float angle)
        {
            transform = g.Transform;
            g.TranslateTransform(pos.X, pos.Y);
            g.RotateTransform(angle);
            g.TranslateTransform(-pos.X, -pos.Y);
        }
        public static void PartialTransformReset(this Graphics g)
        {
            g.Transform = transform;
        }

        public static void DrawCircle(this Graphics g, Color color, Vector center, float radius)
        {
            g.DrawEllipse(new SolidBrush(color), center, radius, radius);
        }
        public static void DrawEllipse(this Graphics g, Color color, Vector center, float radius1, float radius2)
        {
            g.DrawEllipse(new SolidBrush(color), center, radius1, radius2);
        }
        public static void DrawEllipse(this Graphics g, Brush brush, Vector center, float radius1, float radius2)
        {
            g.FillEllipse(brush, new RectangleF((center - new Vector(radius1, radius2)).ToPointF(), new SizeF(2 * radius1, 2 * radius2)));
        }

        public static void DrawSquare(this Graphics g, Color color, Vector center, float a, float angle)
        {
            g.DrawRectangle(new SolidBrush(color), center, a, a, angle);
        }
        public static void DrawRectangle(this Graphics g, Color color, Vector center, float a, float b, float angle)
        {
            g.DrawRectangle(new SolidBrush(color), center, a, b, angle);
        }
        public static void DrawRectangle(this Graphics g, Brush brush, Vector center, float a, float b, float angle)
        {
            g.RotateAround(center, angle);
            g.FillRectangle(brush, new RectangleF((center - new Vector(a, b)).ToPointF(), new SizeF(2 * a, 2 * b)));
            g.PartialTransformReset();
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

        internal static Color ColorFromHsla(double h, double sl, double l, double a)
        {

            double v;
            double r, g, b;

            r = l;   // default to gray
            g = l;
            b = l;
            v = (l <= 0.5) ? (l * (1.0 + sl)) : (l + sl - l * sl);
            if (v > 0)
            {
                double m;
                double sv;
                int sextant;
                double fract, vsf, mid1, mid2;

                m = l + l - v;
                sv = (v - m) / v;
                h *= 6.0;
                sextant = (int)h;
                fract = h - sextant;
                vsf = v * sv * fract;
                mid1 = m + vsf;
                mid2 = v - vsf;
                switch (sextant)
                {
                    case 0:
                        r = v;
                        g = mid1;
                        b = m;
                        break;
                    case 1:
                        r = mid2;
                        g = v;
                        b = m;
                        break;
                    case 2:
                        r = m;
                        g = v;
                        b = mid1;
                        break;
                    case 3:
                        r = m;
                        g = mid2;
                        b = v;
                        break;
                    case 4:
                        r = mid1;
                        g = m;
                        b = v;
                        break;
                    case 5:
                        r = v;
                        g = m;
                        b = mid2;
                        break;
                }
            }
            return Color.FromArgb((int)(a * 255f), (int)(r * 255f), (int)(g * 255f), (int)(b * 255f));
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

        public static Color EdgeColor(Colors color, float dist)
        {
            Color res = Util.ChangeColorBrightness(Util.BaseColor(color), -0.2f);
            if (color == Colors.White)
            {
                res = Color.FromArgb(128 - (int)(Math.Min(3f, dist) / 3f * 50f), res);
            }
            return res;
        }
        public static Color EdgeColor(Colors color)
        {
            return Util.ChangeColorBrightness(Util.BaseColor(color), -0.2f);
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
            return Util.ChangeColorBrightness(Util.BaseColor(color), lighten);
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


        public static string ToShortString(this Type type)
        {
            return type.ToString().Replace("PuzzleGame.Language.", "").Replace("System.", "").Replace("Multival`1", "");
        }

        private static Dictionary<int, double> randomFunctionCache = new Dictionary<int, double>();

        public static double RandomFunction(int uid)
        {
            if (randomFunctionCache.ContainsKey(uid))
                return randomFunctionCache[uid];
            double res = Util.Random.NextDouble();
            randomFunctionCache[uid] = res;
            return res;
        }
    }
}