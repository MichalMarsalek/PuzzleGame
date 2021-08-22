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

        public ALTGroup(string end)
        {
            Type = end;
            Nodes = new List<ALTNode>();
        }

        public ALTGroup()
        {
        }

        public override string ToString()
        {
            return $"Group[{Type}](\n" + String.Join(", ", Nodes.Select(i => i.ToString())) + "\n)";
        }

        public ASTNode ToAST()
        {
            return ToAST(Nodes);
        }

        private void FillCall(Stack<ALTNode> nodes) {
            if(nodes.Count >= 1)
            {
                ALTNode node = nodes.Peek();
                if(!(node is ALTOperator) )
                {
                    nodes.Push(new ALTOperator("call"));
                }
            }
        }

        private bool PrecedenceDrops(ALTOperator current, Stack<ALTOperator> operators)
        {
            if (operators.Count == 0)
                return false;
            string op1 = operators.Peek().Operator;
            string op2 = current.Operator;
            return OperatorsData.Precedence[op2] < OperatorsData.Precedence[op1];
        }

        private ASTNode ToAST(List<ALTNode> _nodes)
        {
            Stack<ASTNode> operands = new Stack<ASTNode>();
            Stack<ALTOperator> operators = new Stack<ALTOperator>();
            var nodes = new Stack<ALTNode>(_nodes.AsEnumerable().Reverse());
            bool lastOp = false;
            while (nodes.Any())
            {
                ALTNode node = nodes.Pop();
                if (node is ALTOperator)
                {
                    if (!lastOp && PrecedenceDrops(node as ALTOperator, operators))
                    {
                        ProcessOperator(operands, operators);
                        nodes.Push(node);
                        continue;
                    }
                    operators.Push(node as ALTOperator);
                    lastOp = true;
                }
                else {
                    FillCall(nodes);
                    if (node is ALTAtom)
                    {
                        operands.Push(new ASTLeaf((node as ALTAtom).LexToken));

                    }
                    else if (node is ALTGroup)
                    {
                        operands.Push(ProcessInnerGroup(node as ALTGroup));
                    }
                    lastOp = false;
                }
            }
            while (operators.Any())
            {
                ProcessOperator(operands, operators);
            }
            if (operands.Count == 1)
            {
                return operands.Pop();
            }
            throw new ParsingException("", -1, "leftover operands - unable to build AST"); //TODO replace "" and -1
        }

        private ASTNode ProcessInnerGroup(ALTGroup inner)
        {
            if (inner.Type == "]")
            {
                if(inner.Nodes.Count == 0)
                {
                    return new ASTLeaf(new LexToken("Name", "[]",-1));
                }
                var innerAST = inner.ToAST();
                string listOp = "ulist1";
                if (inner.Nodes.Count > 1 && inner.Nodes[1] is ALTOperator && (inner.Nodes[1] as ALTOperator).Operator == ",")
                    listOp = "ulistreplace";

                return new ASTOperations(new List<string>() { listOp }, new List<ASTNode>() { innerAST });
            }
            return inner.ToAST();

        }

        private void ProcessOperator(Stack<ASTNode> operands, Stack<ALTOperator> operators)
        {
            List<ASTNode> args = new List<ASTNode>();
            List<string> ops = new List<string>();
            int prec = OperatorsData.Precedence[operators.Peek().Operator];
            args.Add(operands.Pop());
            while (operators.Any())
            {
                ALTOperator op = operators.Peek();
                if(OperatorsData.Precedence[op.Operator] != prec)
                {
                    ops.Insert(0, "");
                    operands.Push(new ASTOperations(ops, args));
                    return;
                }
                operators.Pop();
                if (op.IsTernary)
                {
                    args.Insert(0, op.Data.ToAST());
                    args.Insert(0, operands.Pop());
                    ops.Add("if");
                    ops.Add("else");
                    ops.Insert(0, "");
                    operands.Push(new ASTOperations(ops, args));
                    return;
                }
                if (op.IsUnary)
                {
                    ops.Insert(0, op.Operator);
                    operands.Push(new ASTOperations(ops, args));
                    return;
                }
                ops.Insert(0, op.Operator);
                args.Insert(0, operands.Pop());
            }
            ops.Insert(0, "");
            operands.Push(new ASTOperations(ops, args));
        }

    }
}
