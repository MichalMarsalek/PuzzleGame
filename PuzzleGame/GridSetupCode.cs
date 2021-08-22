using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzleGame
{
    public class GridSetupCode
    {
        public string[] Lines
        {
            get
            {
                return textBox.Lines;
            }
        }

        public List<Dot> Result { get; private set; }
        public Vector Base1 { get; private set; }
        public Vector Base2 { get; private set; }

        private RichTextBox textBox;

        public GridSetupCode(RichTextBox textBox)
        {
            this.textBox = textBox;
            Base1 = new Vector(1, 0);
            Base2 = new Vector(0, 1);
            Result = new List<Dot>();
            this.textBox.TextChanged += TextBox_TextChanged;
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            Result = new List<Dot>();
            Base1 = new Vector(1, 0);
            Base2 = new Vector(0, 1);
            for (int i = 0; i < Lines.Length; i++)
            {
                Color color = ProccesLine(i) ? Color.Black : Color.Red;
                int selStart = textBox.SelectionStart;
                int selLen = textBox.SelectionLength;
                textBox.Select(textBox.GetFirstCharIndexFromLine(i), Lines[i].Length);
                textBox.SelectionColor = color;
                textBox.Select(selStart, selLen);
            }
        }

        private bool PlaceDot(Dot dot)
        {
            Dot ex = Result.Find(i => (i.Position - dot.Position).AlmostZero(0.001f));
            if (ex == null)
            {
                if (dot.Color != Colors.None)
                    Result.Add(dot);
                return false;
            }
            if (dot.Color != Colors.None)
                ex.Color = dot.Color;
            else
            {
                Result.Remove(ex);
            }
            return true;
        }

        private bool ProccesLine(int i)
        {
            try
            {
                var parts = Lines[i].Replace(", ", ",").Split(' ');
                if (parts[0] == "base")
                {
                    Base1 = Vector.FromCoordinateString(parts[1]);
                    Base2 = Vector.FromCoordinateString(parts[2]);
                }
                else
                {
                    Colors color = (Colors)Enum.Parse(typeof(Colors), parts[0], true);
                    if (parts[1] == "lattice")
                    {
                        Vector v1 = Vector.FromCoordinateString(parts[2]);
                        Vector v2 = new Vector(0, 0);
                        if (parts.Length > 3)
                        {
                            v2 = Vector.FromCoordinateString(parts[3]);
                        }
                        for (int x = 0; x < (int)v1.X; x++)
                        {
                            for (int y = 0; y < (int)v1.Y; y++)
                            {
                                PlaceDot(new Dot((x + v2.X) * Base1 + (y + v2.Y) * Base2, color));
                            }
                        }
                    }
                    else
                    {
                        for (int j = 1; j < parts.Length; j++)
                        {
                            Vector v = Vector.FromCoordinateString(parts[j]);
                            v = v.X * Base1 + v.Y * Base2;
                            PlaceDot(new Dot(v, color));
                        }
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Vector ToCurrentCoordinates(Vector v)
        {
            float det = Base1.X * Base2.Y - Base1.Y * Base2.X;
            Vector result = v.X * new Vector(Base2.Y, -Base1.Y) + v.Y * new Vector(-Base2.X, Base1.X);
            result = 1 / det * result;
            result.X = (float)Math.Round(1024 * 32 * result.X) / 1024f / 32f;
            result.Y = (float)Math.Round(1024 * 32 * result.Y) / 1024f / 32f;
            return result;
        }
    }
}
