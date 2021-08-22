using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame
{
    public class ParsingException : Exception
    {
        public string Token { get; private set; }
        public int Start { get; private set; }
        public string Comment { get; private set; }

        public ParsingException(string token, int start, string comment="")
        {
            Token = token;
            Start = start;
            Comment = comment;
        }

        public override string Message => $"Unexpected token '{Token}' at position {Start}" + (Comment != "" ? ", " : "") + Comment;
    }
}
