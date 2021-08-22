using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PuzzleGame
{
    public class RulesLangParser
    {
        public string Code;
        public LangLexer Lexer;
        public readonly Dictionary<string, string> bracketMap =
            new Dictionary<string, string>() { { "(", ")" }, { "[", "]" }, { "if", "else" } };


        public RulesLangParser(string code)
        {
            Code = code;
            Lexer = new LangLexer();
        }
        public RulesLangParser()
        {
            Lexer = new LangLexer();
        }

        public List<ASTNode> Parse(string code)
        {
            Code = code;
            return Parse();
        }
        public List<ASTNode> Parse()
        {
            return Code.Split('\n').Where(i => i != "").Select(i => ParseLine(i)).ToList();
        }

        private ASTNode ParseLine(string line)
        {
            var tokens = ResolveBrackets(new Queue<LexToken>(Lexer.GetTokens(line))) as ALTGroup;
            var res = tokens.ToAST();
            return res;
        }

        //Processes a bracket, returns true if it is (correct) closing one
        private bool ProcessBracket(Queue<LexToken> tokens, LexToken token, ALTGroup result, string bracket)
        {
            if (bracketMap.ContainsKey(token.Value))
            {
                if(token.Value == "if" && result.Nodes.Count() == 0)
                {
                    throw new ParsingException(token.Value, token.Position, $"expected an operand");
                }
                result.Nodes.Add(ResolveBrackets(tokens, bracketMap[token.Value]));
            }
            else if (token.Value == bracket)
            {
                bool expectedOp = false;
                expectedOp = bracket == "]" && result.Nodes.Any() && result.Nodes.Last() is ALTOperator;
                expectedOp = expectedOp || bracket != "]" && (result.Nodes.Count() == 0 || result.Nodes.Last() is ALTOperator);
                if (expectedOp){
                    throw new ParsingException(token.Value, token.Position, $"expected an operand");
                }
                return true;
            }
            else
            {
                throw new ParsingException(token.Value, token.Position, $"expected bracket {bracket}");
            }
            return false;
        }

        public ALTNode ResolveBrackets(Queue<LexToken> tokens, string bracket = "EOL")
        {
            ALTGroup result = new ALTGroup(bracket);
            while (tokens.Any())
            {
                LexToken token = tokens.Dequeue();
                if(token.Type == "Bracket")
                {
                    if (ProcessBracket(tokens, token, result, bracket))
                    {
                        if(bracket == "else")
                        {
                            return new ALTOperator("ifelse", result);
                        }
                        return result;
                    }
                }
                else
                {
                    if(token.Type == "Operator")
                    {
                        if (result.Nodes.Count == 0 || result.Nodes.Last() is ALTOperator)
                        {
                            if (token.Value == "+" | token.Value == "-")
                            {
                                token.Value = "u" + token.Value;
                                result.Nodes.Add(new ALTOperator(token.Value));
                            }
                            else
                            {
                                throw new ParsingException(token.Value, token.Position, $"not unary operator");
                            }
                        }
                        else
                        {
                            result.Nodes.Add(new ALTOperator(token.Value));
                        }
                    }
                    else
                    {
                        result.Nodes.Add(new ALTAtom(token));
                    }
                }
                if(token.Value == "EOL")
                {
                    throw new ParsingException("EOL", token.Position, $"expected bracket {bracket}");
                }
            }
            throw new ParsingException("EOL", -1, $"expected bracket {bracket}");
        }
    }
}
    
