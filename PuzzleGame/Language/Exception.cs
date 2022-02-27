using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Language
{
    public class Exception : System.Exception
    {
        public Token Token { get; private set; }

        public Exception(string message, Token token = null) : base(message)
        {

        }
    }
}
