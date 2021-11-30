using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame
{
    public abstract class ASTNode
    {
        public abstract LangValue Evaluate(NameDomain domain);

        public ALTGroup Group { get; set; }

        public LexToken Token { get; protected set; }

        public TokenPosition Position { get { return Token.Position; } }

        public abstract string ToString(int offset);

        public bool IsLeaf()
        {
            return this is ASTLeaf;
        }

        public bool IsLeaf(TokenType type)
        {
            return this is ASTLeaf && (this as ASTLeaf).Value.Type == type;
        }

        public bool IsNameLeaf()
        {
            return IsLeaf(TokenType.Name);
        }

        public bool IsSpaceLeaf()
        {
            return IsLeaf(TokenType.Space);
        }
    }
}
