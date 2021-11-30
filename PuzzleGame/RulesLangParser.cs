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
        public RulesLangLexer Lexer;
        public readonly Dictionary<string, string> bracketMap =
            new Dictionary<string, string>() { { "(", ")" }, { "[", "]" }, { "if", "else" }, { "SOF", "EOF"} };


        public RulesLangParser(string code)
        {
            Code = code;
            Lexer = new RulesLangLexer();
        }
        public RulesLangParser()
        {
            Lexer = new RulesLangLexer();
        }

        public ASTNode Parse(string code)
        {
            Code = code;
            return Parse();
        }
        public ASTNode Parse()
        {
            return GetGroups().ToAST();
        }

        //Removes comments, unnecesary spaces and checks that : is followed by a newline
        private List<LexToken> CleanTokens(IEnumerable<LexToken> tokens)
        {
            List<LexToken> result = new List<LexToken>();
            List<LexToken> toks1 = tokens.Where(i => i.Type != TokenType.Comment).ToList();
            List<LexToken> toks2 = new List<LexToken>();

            LexToken previousSpace = null;
            LexToken previousNL = null;
            int seenNLs = 0;
            foreach (LexToken token in toks1)
            {
                if(token.Type == TokenType.Space)
                {
                    previousSpace = token;
                }
                else if(token.Type == TokenType.NL)
                {
                    if (previousNL == null)
                    {
                        previousNL = token;
                    }
                    seenNLs++;
                }
                else
                {
                    if(seenNLs == 0 && previousSpace != null)
                    {
                        toks2.Add(previousSpace);
                    }
                    else if (seenNLs == 1)
                    {
                        toks2.Add(new LexToken(TokenType.NL, "\n", previousNL.Position));
                    }
                    else if (seenNLs >= 2)
                    {
                        toks2.Add(new LexToken(TokenType.DoubleNL, "\n\n", previousNL.Position));
                    }
                    toks2.Add(token);
                    seenNLs = 0;
                    previousNL = null;
                    previousSpace = null;
                    continue;
                }
            }
            List<LexToken> toks3 = new List<LexToken>(); //removes a newline after else
            for (int i = 0; i < toks2.Count; i++)
            {
                toks3.Add(toks2[i]);
                if (i + 1 < toks2.Count && toks2[i].Value == "else" && toks2[i+1].Type == TokenType.NL)
                {
                    i++;
                }
            }
            List<LexToken> toks4 = new List<LexToken>(); //replaces DoubleNL with NL, DoubleNL, NL so that lines can be split by NL
            foreach(LexToken token in toks3)
            {
                if(token.Type == TokenType.DoubleNL)
                {
                    toks4.Add(new LexToken(TokenType.NL, "\n", token.Position));
                    toks4.Add(token);
                    toks4.Add(new LexToken(TokenType.NL, "\n", token.Position));
                }
                else
                {
                    toks4.Add(token);
                }
            }
            for (int i = 1; i < toks4.Count; i++) //asserts : is followed by NL
            {
                if(toks4[i-1].Value == ":" && toks4[i].Type != TokenType.NL)
                {
                    throw new ParsingException(toks4[i], "Expected a newline.");
                }
            }
            return toks4;
        }

        public ALTNode GetGroups()
        {
            var temp = GetGroups(CleanTokens(Lexer.GetTokens(Code)));
            return temp;
        }

        private ALTNode GetGroups(List<LexToken> tokens)
        {
            return GetGroups(new Stack<LexToken>(tokens.AsEnumerable().Reverse()),
                new LexToken(TokenType.Bracket, "SOF", new TokenPosition(0,0)), "EOF");
        }

        private ALTNode GetGroups(Stack<LexToken> tokens, LexToken init, string end)
        {
            ALTGroup result = new ALTGroup(init, end);
            while (tokens.Any())
            {
                LexToken token = tokens.Pop();
                if (token.Type == TokenType.Bracket)
                {
                    if(token.Value == end) //correct closing bracket
                    {
                        result.ResolveOperators();
                        if (Operators.Ops.ContainsKey(end))
                        {
                            return new ALTOperator(token, end, result);
                        }
                        return result;
                    }
                    else if(bracketMap.ContainsValue(token.Value)) //wrong closing bracket
                    {
                        throw new ParsingException(token, $"Wrong closing bracket, expected {end}.");
                    }
                    else //opening bracket
                    {
                        result.Nodes.Add(GetGroups(tokens, token, bracketMap[token.Value]));
                    }
                }
                else if(token.Type == TokenType.Operator)
                {
                    bool unaryMinus = result.Nodes.Count == 0 || result.Nodes.Last() is ALTOperator || (result.Nodes.Last() is ALTAtom && (result.Nodes.Last() as ALTAtom).LexToken.Type == TokenType.Space);
                    unaryMinus = unaryMinus && token.Value == "-";
                    result.Nodes.Add(new ALTOperator(token, (unaryMinus ? "u" : "") + token.Value));
                }
                else if(token.Type == TokenType.NL)
                {
                    result.Nodes.Add(new ALTOperator(token, "§NL§"));
                }
                else
                {
                    result.Nodes.Add(new ALTAtom(token));
                }
            }
            throw new ParsingException(new LexToken(TokenType.Unexpected, "", new TokenPosition(0,0)), "something is very wrong");
        }
    }
}
    
