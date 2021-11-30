using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame
{
    public enum SeqType { Lines, Tuple, List, Product }

    public class ASTSeq : ASTNode
    {
        public SeqType Type { get; protected set; }
        public List<ASTNode> Items { get; protected set; }

        public ASTSeq(LexToken token, SeqType type, List<ASTNode> items)
        {
            Token = token;
            Type = type;
            Items = items;
            if (Items.Any(arg => arg.IsSpaceLeaf()) && Type == SeqType.Product)
            {
                throw new ParsingException(Token, $"Operator × does not accept empty arguments."); //TODO token, position
            }
        }

        public override LangValue Evaluate(NameDomain domain)
        {
            throw new NotImplementedException();
        }

        public override string ToString() => ToString(0);

        public override string ToString(int offset)
        {
            if (Items.Sum(i => i.ToString().Length) < 50)
            {
                string niceType = $" {Type} ";
                if (Type == SeqType.Lines) niceType = " NL ";
                if (Type == SeqType.Product) niceType = " × ";
                if (Type == SeqType.Tuple) niceType = " , ";
                if (Type == SeqType.List) niceType = " , ";
                string result = new String(' ', 4 * offset) + (Type == SeqType.List ? "[" : "(");
                result += String.Join(niceType, Items.Select(i => i.ToString()));
                return result + (Type == SeqType.List ? "]" : ")");
            }
            else
            {
                string result = new String(' ', 4 * offset) + $"({Type}\n";
                result += String.Join("\n", Items.Select(i => i.ToString(offset+1))) + "\n";
                return result + new String(' ', 4 * offset) + ")";
            }
        }
    }
}
