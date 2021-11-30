using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PuzzleGame
{
    public class RulesLangLexer
    {
        public RulesLangLexer()
        {
            
        }

        private string ScanOperator(CharacterStream chars)
        {
            OperatorPrototype proto = Operators.GetPrototype(chars.Remaining);
            if(proto == null)
            {
                return "";
            }
            else
            {
                for (int i = 0; i < proto.Name.Length; i++)
                {
                    chars.Read();
                }
            }
            string res = proto.Name;
            if (proto.Extendable)
            {
                res += Scan(chars, "^["+ Regex.Escape("-@+*/@?><=^#%°:.") +"]$");                
            }
            return res;
        }

        private string Scan(CharacterStream chars, string regex)
        {
            Regex rx = new Regex(regex);
            string result = "";
            while (chars.Any())
            {
                if (rx.IsMatch(chars.Peek().ToString()))
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

        private string ScanComment(CharacterStream chars)
        {
            string result = "";
            //count starting dollars
            int dollarCount = 0;
            while (chars.Any())
            {
                char c = chars.Peek();
                if (c == '$')
                {
                    result += chars.Read();
                    dollarCount++;
                }
                else break;
            }

            // line comment
            if(dollarCount == 1)
            {
                while (chars.Any())
                {
                    char c = chars.Peek();
                    if (c == '\n')
                    {
                        return result;
                    }
                    result += chars.Read();
                }
                return result;
            }

            // block comment
            int dollarsSeen = 0;
            while (chars.Any())
            {
                char c = chars.Read();
                result += c;
                if (c == '$')
                {
                    dollarsSeen++;
                    if (dollarsSeen == dollarCount)
                    {
                        return result;
                    }
                }
                else
                {
                    dollarsSeen = 0;
                };
            }
            return result;
        }

        private string ScanString(CharacterStream chars)
        {
            string result = chars.Read().ToString();
            while (chars.Any())
            {
                char c = chars.Read();
                result += c;
                if (c == '\\')
                {
                    if (chars.Any())
                    {
                        result += chars.Read();
                    }
                }
                else if (c == result[0])
                {
                    return result;
                }
            }
            return result;
        }

        private string ScanBuiltin(CharacterStream chars)
        {
            string result = chars.Read().ToString();
            while (chars.Any())
            {
                char c = chars.Read();
                result += c;
                if (c == '§')
                {
                    return result;
                }
            }
            return result;
        }

        public IEnumerable<LexToken> GetTokens(string code)
        {
            CharacterStream chars = new CharacterStream(code);
            while (chars.Any())
            {
                char c = chars.Peek();
                if (c == '§')
                {
                    string res = ScanBuiltin(chars);
                    yield return new LexToken(TokenType.Builtin, res, chars.PrevPosition);
                    continue;
                }
                if (c == '\n')
                {
                    chars.Read();
                    yield return new LexToken(TokenType.NL, "\n", chars.PrevPosition);
                    continue;
                }
                if (c == '$')
                {
                    string res = ScanComment(chars);
                    yield return new LexToken(TokenType.Comment, res, chars.PrevPosition);
                    continue;
                }
                if ("'\"".Contains(c))
                {
                    string res = ScanString(chars);
                    yield return new LexToken(TokenType.String, res, chars.PrevPosition);
                    continue;
                }
                if ("\t ".Contains(c))
                {
                    string res = Scan(chars, @"^[\t ]$");
                    yield return new LexToken(TokenType.Space, res, chars.PrevPosition);
                    continue;
                }
                if ("()[]".Contains(c))
                {
                    chars.Read();
                    yield return new LexToken(TokenType.Bracket, c.ToString(), chars.PrevPosition);
                    continue;
                }
                if (c != '.')
                {
                    string number = ScanNumber(chars);
                    if (number != "")
                    {
                        yield return new LexToken(TokenType.Number, number, chars.PrevPosition);
                        continue;
                    }
                }
                string name = Scan(chars, @"^\w$"); //consider not allowing digits
                if (name != "")
                {
                    if (name == "if" || name == "else")
                    {
                        yield return new LexToken(TokenType.Bracket, name, chars.PrevPosition);
                        continue;
                    }
                    yield return new LexToken(Operators.Ops.ContainsKey(name) ? TokenType.Operator : TokenType.Name, name, chars.PrevPosition);
                    continue;
                }
                string op = ScanOperator(chars);
                if (op != "")
                {
                    if (op == "if" || op == "else")
                    {
                        yield return new LexToken(TokenType.Bracket, op, chars.PrevPosition);
                        continue;
                    }
                    yield return new LexToken(TokenType.Operator, op, chars.PrevPosition);
                    continue;
                }
                yield return new LexToken(TokenType.Unexpected, chars.Remaining, chars.PrevPosition);
                yield break;
            }
            yield return new LexToken(TokenType.Bracket, "EOF", chars.PrevPosition);
        }
    }
}
