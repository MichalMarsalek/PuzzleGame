using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame
{
    public class ALTAtom : ALTNode
    {
        public LexToken LexToken { get; set; }
        public ALTAtom(LexToken token)
        {
            LexToken = token;
        }

        public override string ToString()
        {
            return LexToken.ToString();
        }

        public override ASTNode ToAST()
        {
            if(LexToken.Value == "it")
            {
                var tok = new LexToken(TokenType.Name, $"§it{Operators.UID}§", LexToken.Position);
                return new ASTLambda(tok, new List<string>() { tok.Value}, new ASTLeaf(tok));
            }
            return new ASTLeaf(LexToken);
        }
    }
}
