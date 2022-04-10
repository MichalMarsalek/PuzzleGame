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
                if(w != "" && "mod div".Contains(w))
                {
                    yield return new Token(TokenTypes.Operator, code.Length - chars.Remaining.Length, w.Length, w);
                    continue;
                }
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
                if (chars.Peek() == '.')
                {
                    w = chars.Read().ToString();
                }
                else
                {
                    w = Scan(chars, @"^[a-zA-Z0-9\s]$", false);
                }
                yield return new Token(TokenTypes.Operator, code.Length - chars.Remaining.Length, w.Length, w);

            }
        }
        public Node ParseRule(string code)
        {
            if (code.EndsWith("."))
                code = code.Substring(0, code.Length - 1);
            return ParseRule(GetTokens(code).ToList());
        }
        public Objective ParseObjective(string code)
        {
            var rules = code.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None)
                .Select(i => ParseRule(i)).ToList();
            Node finalObjective;
            if (rules.Last().ContainsQuery("_ rule is _"))
            {
                finalObjective = rules.Pop(rules.Count - 1);
                if (finalObjective.ContainsQuery("_ rule is _", false))
                {
                    throw new Language.Exception("Objective cannot query the grid directly, only trough the rules.");
                }
            }
            else
            {
                finalObjective = new Query(
                    new QueryName("_ rule is _"),
                    new List<QueryParam>() { CardinalParam.Each, new FullfillnessParam(true) }
                );
            }
            foreach(var rule in rules)
            {
                if (rule.ContainsQuery("_ rule is _"))
                {
                    throw new Language.Exception("Only the objective can query other rules.");
                }
            }
            return new Objective(rules, finalObjective);
        }
        
        private IEnumerable<Node> GetValueOperatorSeq(List<Token> tokens)
        {
            if (tokens.Count == 0)
            {
                throw new Language.Exception("Parsing error, unexpected end of sentence.", null);
            }
            bool prevIsValue = false;
            int i = 0;
            while(i < tokens.Count)
            {
                var tok = tokens[i];
                if (tok.Type == TokenTypes.Number)
                {
                    var n = new Atom(new Number(tok.Content), tok);
                    if (prevIsValue)
                    {
                        throw new Language.Exception("Parsing error, unexpected number.", tokens[i]);
                    }
                    else
                    {
                        yield return n;
                        prevIsValue = true;
                    }
                }
                else if (tok.Type == TokenTypes.Operator)
                {
                    if (!prevIsValue && tok.Content == "-")
                    {
                        yield return new Atom(new Number(0), tok);
                        prevIsValue = true;
                    }
                    else if (!prevIsValue && tok.Content == "√")
                    {
                        yield return new Atom(new Number(2), tok);
                        prevIsValue = true;
                    }
                    if (!prevIsValue)
                    {
                        throw new Language.Exception("Parsing error, unexpected operator.", tok);
                    }
                    else
                    {
                        yield return new Operator(tok.Content, null, null, tok);
                        prevIsValue = false;
                    }
                }
                else if (tok.Type == TokenTypes.Word)
                {
                    var words = new List<Token>() { tokens[i] };
                    var atStart = i == 0;
                    while (i + 1 < tokens.Count && tokens[i + 1].Type == TokenTypes.Word)
                    {
                        words.Add(tokens[i + 1]);
                        i++;
                    }
                    var q = Query.ParseQuery(words);
                    if (prevIsValue)
                    {
                        throw new Language.Exception("Parsing error, unexpected query.", tok);
                    }
                    else
                    {
                        yield return q;
                        prevIsValue = true;
                    }
                }
                i++;
            }
            if (!prevIsValue)
            {
                throw new Language.Exception("Parsing error, unexpected end of sentence.", tokens.Last());
            }
        }

        private Node ParsePrecedence(int prec, List<Node> seq)
        {
            if(seq.Count == 1)
            {
                return seq[0];
            }
            for(int i= 0; i < seq.Count; i++)
            {
                if(seq[i] is Operator && (seq[i] as Operator).Precedence == prec)
                {
                    var op = seq[i] as Operator;
                    op.Arg1 = ParsePrecedence(prec + 1, seq.Take(i).ToList());
                    op.Arg2 = ParsePrecedence(prec, seq.Skip(i+1).ToList());
                    return op;
                }
            }
            return ParsePrecedence(prec + 1, seq);
        }
        private Node ParseRule(List<Token> tokens) { //TODO include operator precedence.
            var seq = GetValueOperatorSeq(tokens).ToList();
            return ParsePrecedence(0, seq);
        }
    }
}
