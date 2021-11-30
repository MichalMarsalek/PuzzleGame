using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame
{
    public class ALTGroup : ALTNode
    {
        public string Type { get; protected set; }
        public List<ALTNode> Nodes { get; protected set; }
        public int Precedence { get; protected set; }

        public ALTGroup(LexToken token, string end, int precedence = -2)
        {
            Token = token;
            Type = end;
            Nodes = new List<ALTNode>();
            Precedence = precedence;
        }

        public override string ToString()
        {
            return $"Group[{Type}](\n" + String.Join(", ", Nodes.Select(i => i.ToString())) + "\n)";
        }

        public void ResolveOperators() //adds empty operators, removes spaces and sets precedence
        {
            var temp = new List<ALTNode>();
            for(int i = 0; i < Nodes.Count; i++)
            {
                bool prevIsSpace = i > 0 && (Nodes[i - 1] is ALTAtom) && (Nodes[i - 1] as ALTAtom).LexToken.Type == TokenType.Space;
                if (i > 0 && !(Nodes[i-1] is ALTOperator) && !prevIsSpace && Nodes[i] is ALTGroup && (Nodes[i] as ALTGroup).Type == ")")
                {
                    temp.Add(new ALTOperator(Nodes[i].Token, "§priorityEmpty§"));
                }
                temp.Add(Nodes[i]);
            }
            temp = temp.Where(i => !(i is ALTAtom) || (i as ALTAtom).LexToken.Type != TokenType.Space).ToList();
            Nodes.Clear();
            for (int i = 0; i < temp.Count; i++)
            {
                if (i > 0 && !(temp[i - 1] is ALTOperator) && !(temp[i] is ALTOperator))
                {
                    Nodes.Add(new ALTOperator(temp[i].Token, "§empty§"));
                }
                Nodes.Add(temp[i]);
            }
            if(Nodes.Count > 0 && (Nodes[0] is ALTOperator) && (Nodes[0] as ALTOperator).Operator == "§NL§")
            {
                Nodes.RemoveAt(0);
            }
            if (Nodes.Count > 0 && (Nodes.Last() is ALTOperator) && (Nodes.Last() as ALTOperator).Operator == "§NL§")
            {
                Nodes.RemoveAt(Nodes.Count-1);
            }
            ResolvePrecedence();
        }

        private void ResolvePrecedence() //finds and stores the minimum precedence present
        {
            try
            {
                Precedence = Nodes.Where(i => i is ALTOperator).Min(i => (i as ALTOperator).Prototype.Precedence);
            }
            catch
            {
                
            }
        }

        public ALTGroup SplitAtPrecedence(int prec)
        {
            ALTGroup res = new ALTGroup(Token, Type, prec);
            ALTGroup temp = new ALTGroup(Token, prec.ToString(), prec+1);
            foreach(ALTNode node in Nodes)
            {
                if(node is ALTOperator && (node as ALTOperator).Prototype.Precedence == prec)
                {
                    if (temp.Nodes.Count == 1 && !(temp.Nodes[0] is ALTOperator))
                    {
                        res.Nodes.Add(temp.Nodes[0]);
                    }
                    else
                    {
                        res.Nodes.Add(temp);
                    }
                    temp = new ALTGroup(node.Token, prec.ToString(), prec+1);
                    res.Nodes.Add(node);
                }
                else
                {
                    temp.Nodes.Add(node);
                }
            }
            if (temp.Nodes.Count == 1 && !(temp.Nodes[0] is ALTOperator))
            {
                res.Nodes.Add(temp.Nodes[0]);
            }
            else
            {
                res.Nodes.Add(temp);
            }
            return res;
        }

        public override ASTNode ToAST() //wraps contents in list if needed
        {
            if (Type == "]")
            {
                if(Nodes.Count == 0)
                {
                    return new ASTSeq(Token, SeqType.List, new List<ASTNode>());
                }
                bool singleParen = Nodes.Count == 1 && Nodes[0] is ALTGroup && (Nodes[0] as ALTGroup).Type == ")";
                ASTNode inner = ToInnerAST();
                if(inner is ASTSeq && (inner as ASTSeq).Type == SeqType.Tuple && !singleParen)
                {
                    if((inner as ASTSeq).Items.Any(i => i.IsSpaceLeaf()))
                    {
                        throw new ParsingException(inner.Token, $"Operator [] does not accept empty arguments."); //TODO token, position
                    }
                    return new ASTSeq(Token, SeqType.List, (inner as ASTSeq).Items);
                }
                return new ASTSeq(Token, SeqType.List, new List<ASTNode>() { inner });
            }
            return ToInnerAST();
        }

        public ASTNode ToInnerAST() //converts contents to AST, creates lambda function if needed
        {
            ResolvePrecedence();
            if (Nodes.Count == 0)
            {
                return new ASTLeaf(new LexToken(TokenType.Space, "", Token.Position));
            }
            if (Precedence >= Operators.LambdaPrec && (new string[] { "EOF", ")","2", "1", "0", "-1", "-2"}.Contains(Type)))
            {
                return ToLambdaAST();
            }
            return ToSimpleAST();
        }

        public ASTNode ToLambdaAST()
        {
            bool leftSlice = Nodes[0] is ALTOperator && (Nodes[0] as ALTOperator).Prototype.Arity != OperatorArity.Prefix;
            bool rightSlice = Nodes.Last() is ALTOperator && (Nodes.Last() as ALTOperator).Prototype.Arity != OperatorArity.Postfix;
            bool it = Nodes.Any(i => i is ALTAtom && (i as ALTAtom).LexToken.Value == "it");
            int uid = Operators.UID;
            List<string> args = new List<string>();
            if (leftSlice)
            {
                Nodes.Insert(0, new ALTAtom(new LexToken(TokenType.Name, $"§left{uid}§", Token.Position))); //TODO position + uid of slice
                args.Add($"§left{uid}§");
            }
            if (it){
                for (int i = 0; i < Nodes.Count; i++)
                {
                    if (Nodes[i] is ALTAtom && (Nodes[i] as ALTAtom).LexToken.Value == "it")
                    {
                        Nodes[i] = new ALTAtom(new LexToken(TokenType.Name, $"§it{uid}§", (Nodes[i] as ALTAtom).LexToken.Position));
                    }
                }
                args.Add($"§it{uid}§");
            }
            if (rightSlice) { 
                Nodes.Add(new ALTAtom(new LexToken(TokenType.Name, $"§right{uid}§", Token.Position))); //TODO position + uid of slice
                args.Add($"§right{uid}§");
            }
            if(args.Count == 0)
                return ToSimpleAST();
            return new ASTLambda(Token, args, ToSimpleAST());
        }

        public ASTNode ToSimpleAST() { //converts contents to AST, doesn't create lambda functions
            ResolvePrecedence();
            var grouped = SplitAtPrecedence(Precedence);
            if (grouped.Nodes.Count == 1)
                return grouped.Nodes[0].ToAST();
            var operators = Enumerable.Range(0, grouped.Nodes.Count / 2).Select(i => grouped.Nodes[2 * i+1] as ALTOperator).ToList<ALTOperator>();
            var operands = Enumerable.Range(0, grouped.Nodes.Count / 2 + 1).Select(i => grouped.Nodes[2 * i]).ToList();
            if(grouped.Nodes.Count == 1)
                return grouped.Nodes[0].ToAST();
            if (operators[0].Prototype.Arity == OperatorArity.Group)
                return ToGroupAST(operands, operators);
            if (operators[0].Prototype.Arity == OperatorArity.Prefix)
                return ToUnaryAST(operands[1], operators[0]);
            if (operators[0].Prototype.Arity == OperatorArity.Postfix)
                return ToUnaryAST(operands[0], operators[0]);
            if (operators[0].Prototype.Arity == OperatorArity.Infix)
                return ToBinaryAST(operands, operators);
            if (operators[0].Prototype.Arity == OperatorArity.Ternary)
                return ToTernaryAST(operands, operators);
            return null;
        }

        public ASTNode ToGroupAST(List<ALTNode> operands, List<ALTOperator> operators)
        {
            var unmachingOps = operators.Where(i => i.Operator != operators[0].Operator);
            if (unmachingOps.Any())
            {
                throw new ParsingException(unmachingOps.First().Token, "Group operators must all be the same."); //TODO position
            }
            SeqType t = new Dictionary<string, SeqType>() { { ",", SeqType.Tuple }, { "×", SeqType.Product }, { "§NL§", SeqType.Lines } }[operators[0].Operator];
            return new ASTSeq(operands.First().Token, t, operands.Select(i => i.ToAST()).ToList());
        }

        public ASTNode ToUnaryAST(ALTNode operand, ALTOperator op)
        {
            return new ASTUnary(op.Token, operand.ToAST(), op.Operator);
        }

        public ASTNode ToTernaryAST(List<ALTNode> operands, List<ALTOperator> operators)
        {
            ASTNode result;
            OperatorAssociativity assoc = operators[0].Prototype.Associativity;
            if (assoc == OperatorAssociativity.Left)
            {
                result = new ASTTernary(operators[0].Token, operands[0].ToAST(), operators[0].Data.ToAST(), operands[1].ToAST(), operators[0].Operator);
                for (int i = 1; i < operators.Count; i++)
                {
                    result = new ASTTernary(operators[i].Token, result, operators[i].Data.ToAST(), operands[i + 1].ToAST(), operators[i].Operator);
                }
                return result;
            }
            int n = operands.Count;
            result = new ASTTernary(operators[n - 2].Token, operands[n - 2].ToAST(), operators[n - 2].Data.ToAST(), operands[n - 1].ToAST(), operators[n - 2].Operator);
            for (int i = n - 3; i >= 0; i--)
            {
                result = new ASTTernary(operators[i].Token, operands[i].ToAST(), operators[i].Data.ToAST(), result, operators[i].Operator);
            }
            return result;
        }

        public ASTNode ToBinaryAST(List<ALTNode> operands, List<ALTOperator> operators)
        {
            OperatorAssociativity assoc = operators[0].Prototype.Associativity;
            if (assoc == OperatorAssociativity.Chain)
            {
                if(operators.Count > 1)
                {
                    var inner = new ASTBinary(operators[0].Token, operands[0].ToAST(), operands[1].ToAST(), operators[0].Operator);
                    var rest = ToBinaryAST(operands.Skip(1).ToList(), operators.Skip(1).ToList());
                    return new ASTBinary(rest.Token, inner, rest, "and");
                }
            }
            if (assoc == OperatorAssociativity.Forbidden && operators.Count > 1)
            {
                throw new ParsingException(operators[1].Token, "Only 2 operands supported."); //TODO position
            }
            ASTNode result;
            if (assoc == OperatorAssociativity.Left)
            {
                result = new ASTBinary(operators[0].Token, operands[0].ToAST(), operands[1].ToAST(), operators[0].Operator);
                for(int i = 1; i < operators.Count; i++)
                {
                    result = new ASTBinary(operators[i].Token, result, operands[i + 1].ToAST(), operators[i].Operator);
                }
                return result;
            }
            int n = operands.Count;
            result = new ASTBinary(operators[n-2].Token, operands[n-2].ToAST(), operands[n-1].ToAST(), operators[n-2].Operator);
            for (int i = n-3; i >= 0; i--)
            {
                result = new ASTBinary(operators[i].Token, operands[i].ToAST(), result, operators[i].Operator);
            }
            return result;
        }

    }
}
