using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame
{
    public class LexToken
    {
        public string Value;
        public string Type;
        public int Position;

        public int Length { get
            {
                return Value.Length;
            }
        }

        public LexToken(string type, string value, int pos)
        {
            Type = type;
            Value = value;
            Position = pos;
        }

        public override string ToString()
        {
            return $"{Type}({Value})";
        }

    }
}
