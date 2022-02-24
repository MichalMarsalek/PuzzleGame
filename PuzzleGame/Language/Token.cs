using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Language
{
    public class Token
    {
        public int Start { get; private set; }
        public int Length { get; private set; }
        public string Content { get; private set; }

        public Token(int start, int length, string content = "")
        {
            Start = start;
            Length = length;
            Content = content;
        }

        public Token Subtoken(int start, int length)
        {
            try
            {
                return new Token(Start + start, length, Content.Substring(start, length));
            }
            catch
            {
                return new Token(Start + start, length, "");
            }
        }

        public static Token Between(Token a, Token b, string content = "")
            => new Token(a.Start, b.Start + b.Length - a.Start, content);

        public override string ToString()
            => Content;
    }
}
