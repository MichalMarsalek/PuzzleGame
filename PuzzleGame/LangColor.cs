using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame
{
    public class LangColor : LangValue
    {
        public Colors Color { get; private set; }

        public LangColor(Colors color)
        {
            Color = color;
        }

        public LangBool opEquals(LangColor left)
        => new LangBool(left.Color == this.Color);

        public override string ToString() => Color.ToString();
    }
}
