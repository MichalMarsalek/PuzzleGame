using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzleGame
{
    public enum TokenType { Name, Builtin, NL, DoubleNL, String, Number, Comment, Space, Bracket, Operator, Unexpected}
    public class LexToken
    {
        public string Value;
        public TokenType Type;
        public TokenPosition Position;

        public int Length { get
            {
                return Value.Length;
            }
        }

        public LexToken(TokenType type, string value, TokenPosition pos)
        {
            Type = type;
            Value = value;
            Position = pos;
        }

        public override string ToString()
        {
            if (Type == TokenType.NL || Type == TokenType.DoubleNL || Type == TokenType.Space)
                return $"{Type}";
            return $"{Type}({Value})";
        }

        public string ToShortString()
        {
            if (Type == TokenType.NL || Type == TokenType.DoubleNL || Type == TokenType.Space)
                return $"{Type}";
            return $"{Value}";
        }

        public bool IsOperatorLike()
        {
            return Type == TokenType.Operator || Type == TokenType.NL || Type == TokenType.DoubleNL;
        }

        public bool IsValueLike()
        {
            return Type == TokenType.Name || Type == TokenType.Builtin || Type == TokenType.String || Type == TokenType.Number;
        }

        public Color TokenColor()
        {
            if (Type == TokenType.String) return System.Drawing.Color.Gray;
            if (Type == TokenType.Comment) return System.Drawing.Color.LightGray;
            if (Value == "it") return System.Drawing.Color.Green;
            if (Type == TokenType.Name) return System.Drawing.Color.Black;
            if (Type == TokenType.Number) return System.Drawing.Color.Blue;
            if (Type == TokenType.Operator || Value == "if" || Value == "else") return System.Drawing.Color.Blue;
            return System.Drawing.Color.Black;
        }

        public Color TokenBackgroundColor()
        {
            if (Type != TokenType.Name) return Color.White;
            if (Value == "red") return Color.Red;
            if (Value == "blue") return Color.CornflowerBlue;
            if (Value == "green") return Color.Green;
            if (Value == "yellow") return Color.Yellow;
            return Color.White;
        }

    }
}
