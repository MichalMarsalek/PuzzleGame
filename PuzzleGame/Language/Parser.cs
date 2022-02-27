using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PuzzleGame.Language
{

    public class Parser
    {
        public List<List<string>> Functions =
            "length of _ line".Split('\n').Select(i => i.Split(' ').ToList()).ToList();


        private string Scan(CharacterStream chars, string regex, bool include = true)
        {
            Regex rx = new Regex(regex);
            string result = "";
            while (chars.Any())
            {
                if (rx.IsMatch(chars.Peek().ToString()) == include)
                {
                    result += chars.Read();
                }
                else
                {
                    break;
                }
            }
            return result;
        }

        private string ScanNumber(CharacterStream chars)
        {
            string result = "";
            string allowed = ".0123456789";
            while (chars.Any())
            {
                char c = chars.Peek();
                if (allowed.Contains(c))
                {
                    chars.Read();
                    result += c;
                    if (c == '.')
                    {
                        allowed = allowed.Substring(1);
                    }
                }
                else
                {
                    break;
                }
            }
            if (result != "" && result.Last() == '.')
            {
                result = result.Substring(0, result.Length - 1);
                chars.Push('.');
            }
            return result;
        }

        public IEnumerable<Token> GetTokens(string code)
        {
            var chars = new CharacterStream(code);
            while (chars.Any())
            {
                string w = Scan(chars, @"^\s$"); if (w != "")
                {
                    continue;
                }
                w = Scan(chars, @"^[a-zA-Z]$");
                if (w != "")
                {
                    if (chars.Any() && chars.Peek() == ',')
                        w += chars.Read();
                    yield return new Token(TokenTypes.Word, code.Length - chars.Remaining.Length, w.Length, w);
                    continue;
                }
                w = ScanNumber(chars);
                if (w != "")
                {
                    yield return new Token(TokenTypes.Number, code.Length - chars.Remaining.Length, w.Length, w);
                    continue;
                }
                w = Scan(chars, @"^[a-zA-Z0-9\s]$", false);
                yield return new Token(TokenTypes.Operator, code.Length - chars.Remaining.Length, w.Length, w);

            }
        }
        public LangNode ParseRule(string code)
        {
            return ParseRule(GetTokens(code).ToList());
        }

        private LangNode ParseRule(List<Token> tokens) { //TODO include operator precedence.
            int i = 0;
            LangNode prevValue = null;
            string prevOp = null;
            Token prevOpToken = null;
            while (i < tokens.Count)
            {
                if(tokens[i].Type == TokenTypes.Number)
                {
                    var n = new Atom(new Number(tokens[i].Content), tokens[i]);
                    if (i == 0)
                    {
                        prevValue = n;
                    }
                    else if(prevOp is null)
                    {
                        throw new Language.Exception("Parsing error, unexpected number.", tokens[i]);
                    }
                    else
                    {
                        prevValue = new BinaryOperation(prevOp, prevValue, n, prevOpToken);
                        prevOp = null;
                    }
                }
                else if(tokens[i].Type == TokenTypes.Operator)
                {
                    if(i == 0 || !(prevOp is null))
                    {
                        if(tokens[i].Content == "-")
                        {
                            tokens.Insert(i, new Token(TokenTypes.Operator, tokens[i].Start, 1, "-"));
                            continue;
                        }
                        else
                        {
                            throw new Language.Exception("Parsing error, unexpected operator.", tokens[i]);
                        }
                    }
                    else
                    {
                        prevOp = tokens[i].Content;
                        prevOpToken = tokens[i];
                    }
                }
                else if(tokens[i].Type == TokenTypes.Word)
                {
                    var words = new List<Token>() { tokens[i] };
                    var atStart = i == 0;
                    while(i+1 < tokens.Count && tokens[i+1].Type == TokenTypes.Word)
                    {
                        words.Add(tokens[i + 1]);
                        i++;
                    }
                    var q = ParseQuery(words);
                    if (atStart)
                    {
                        prevValue = q;
                    }
                    else if (prevOp is null)
                    {
                        throw new Language.Exception("Parsing error, unexpected query.", tokens[i]);
                    }
                    else
                    {
                        prevValue = new BinaryOperation(prevOp, prevValue, q, prevOpToken);
                        prevOp = null;
                    }
                }
                i++;
            }
            if(!(prevOp is null))
            {
                throw new Language.Exception("Parsing error, unexpected end of sentence.", tokens.Last());
            }
            return prevValue;
        }

        private LangQuery ParseQuery(List<Token> words)
        {
            var colors = new List<Colors>();
            if (words.Select(i => i.Content).Contains("red")) colors.Add(Colors.Red);
            if (words.Select(i => i.Content).Contains("blue")) colors.Add(Colors.Blue);
            return new LangQuery("LengthOf_Line", new List<QueryParam>() { new ColorParam(colors) }, words[0]);
        }
    }
}
