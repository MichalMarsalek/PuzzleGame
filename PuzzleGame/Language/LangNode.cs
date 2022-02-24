using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame
{
    public enum LangType { Number, Coordinates, Angle, Bool }

    public class LangNode
    {
        public LangType Type;
    }
}
