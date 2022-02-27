using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Language
{
    public enum TokenTypes { Word, Number, Operator }
    public class Token
    {
        public int Start { get; private set; }
        public int Length { get; private set; }
        public string Content { get; private set; }
        public TokenTypes Type { get; private set; }

        public Token(TokenTypes type, int start, int length, string content = "")
        {
            Type = type;
            Start = start;
            Length = length;
            Content = content;
        }

        public Token Subtoken(int start, int length)
        {
            try
            {
                return new Token(Type, Start + start, length, Content.Substring(start, length));
            }
            catch
            {
                return new Token(Type, Start + start, length, "");
            }
        }

        public static Token Between(Token a, Token b, string content = "")
            => new Token(a.Type, a.Start, b.Start + b.Length - a.Start, content);

        public override string ToString() => Content;
    }
}
