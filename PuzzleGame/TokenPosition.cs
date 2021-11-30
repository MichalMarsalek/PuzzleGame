using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzleGame
{
    public struct TokenPosition
    {
        public int Line { get; private set; }
        public int Column { get; private set; }

        public TokenPosition(int line, int column)
        {
            Line = line;
            Column = column;
        }

        public int ToAbsolutePosition(RichTextBox rtb)
        {
            return Column + rtb.Lines.Take(Line).Sum(i => i.Length) + Line;
        }

        public override string ToString() =>
            $"line {Line} column {Column}";
    }
}
