using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PuzzleGame
{
    public class LangLexer
    {
        public LangLexer()
        {
            
        }

        private string ScanOperator(Stack<char> chars)
        {
            string result = "";
            string temp = "";
            while (chars.Any())
            {
                if (OperatorsData.Operators.Contains(temp))
                {
                    result = temp;
                }
                temp += chars.Pop();
                var currentMatches = OperatorsData.Operators.Where(i => i.StartsWith(temp));                
                if (currentMatches.Count() == 0)
                {
                    break;
                }
            }
            string dept = temp.Substring(result.Length);
            foreach(char c in dept.Reverse())
            {
                chars.Push(c);
            }
            return result;
        }

        private string Scan(Stack<char> chars, string regex)
        {
            Regex rx = new Regex(regex);
            string result = "";
            while (chars.Any())
            {
                if (rx.IsMatch(chars.Peek().ToString()))
                {
                    result += chars.Pop();
                }
                else
                {
                    break;
                }
            }
            return result;
        }

        private string ScanNumber(Stack<char> chars)
        {
            string result = "";
            string allowed = ".0123456789";
            while (chars.Any())
            {
                char c = chars.Peek();
                if (allowed.Contains(c))
                {
                    chars.Pop();
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

        public IEnumerable<LexToken> GetTokens(string line)
        {
            Stack<char> chars = new Stack<char>(line.Reverse());
            while (chars.Any())
            {
                char c = chars.Peek();
                if (c == '$')
                {
                    break;
                }
                if ("\t ".Contains(c))
                {
                    chars.Pop();
                    continue;
                }
                if ("()[]".Contains(c))
                {
                    chars.Pop();
                    yield return new LexToken("Bracket", c.ToString(), line.Length - chars.Count);
                    continue;
                }
                if (c != '.')
                {
                    string number = ScanNumber(chars);
                    if (number != "")
                    {
                        yield return new LexToken("Number", number, line.Length - chars.Count);
                        continue;
                    }
                }
                string name = Scan(chars, @"^\w$"); //consider not allowing digits
                if (name != "")
                {
                    if (name == "if" || name == "else")
                    {
                        yield return new LexToken("Bracket", name, line.Length - chars.Count);
                        continue;
                    }
                    yield return new LexToken(OperatorsData.Operators.Contains(name) ? "Operator" : "Name", name, line.Length - chars.Count);
                    continue;
                }
                string op = ScanOperator(chars);
                if (op != "")
                {
                    if (op == "if" || op == "else")
                    {
                        yield return new LexToken("Bracket", op, line.Length - chars.Count);
                        continue;
                    }
                    yield return new LexToken("Operator", op, line.Length - chars.Count);
                    continue;
                }
                throw new ParsingException(c.ToString(), line.Length - chars.Count);
            }
            yield return new LexToken("Bracket", "EOL", line.Length);
        }
    }
}
