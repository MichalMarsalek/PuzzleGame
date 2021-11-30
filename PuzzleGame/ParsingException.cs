using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame
{
    public class ParsingException : Exception
    {
        public LexToken Token { get; private set; }
        public string Comment { get; private set; }

        public ParsingException(LexToken token, string comment="")
        {
            Token = token;
            Comment = comment;
        }

        public override string Message => $"Unexpected token '{Token.Value}' at {Token.Position}" + (Comment != "" ? ", " : "") + Comment;
    }
}
