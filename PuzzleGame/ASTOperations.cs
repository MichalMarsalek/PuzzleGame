using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame
{
    public class ASTOperations : ASTNode
    {
        public List<string> Operators { get; private set; }
        public List<ASTNode> Operands { get; private set; }

        public ASTOperations(List<string> ops, List<ASTNode> operands)
        {
            Operands = operands;
            Operators = ops;
            Enhance();
        }

        public void Enhance()
        { 
            if (Operators.Last() == "call")
            {
                Operators = Operators.Select(i => ".").ToList();
                Operators[0] = "";
                Operands.Reverse();
            }
            if (Operators.Last() == "^")
            {
                Operators = Operators.Select(i => "left^").ToList();
                Operators[0] = "";
                Operands.Reverse();
            }
            for (int i=0; i < Operators.Count-1; i++)
            {
                if(Operands[i] is ASTLeaf 
                    && (Operands[i] as ASTLeaf).Value.Type == "Name"
                    && OperatorsData.MagicFunctions.Contains((Operands[i] as ASTLeaf).Value.Value))
                {
                        if(Operators[i+1] == ".")
                        {
                            Operators[i + 1] = "magic.";
                        }
                        else
                        {
                            throw new ParsingException("", -1, "magic functions need to be called");
                        }
                }
            }
            if(Operands.Count > 2 && Operators[1] == ":=")
            {
                throw new ParsingException("", -1, "Chained assignment not supported");
            }
        }

        public ASTOperations()
        {

        }

        public override LangValue Evaluate(NameDomain domain)
        {
            if (Operators[0] == "ulist1")
                return new LangList(Operands[0].Evaluate(domain));
            if (Operators[0] == "ulistreplace")
            {
                var temp = Operands[0].Evaluate(domain) as LangTuple;
                return new LangList(temp.Values);
            }
            if (Operators[0] != "")
                return EvaluateUnary(domain);
            if (Operators[1] == "if")
            {
                return EvaluateTernary(domain);
            }
            if (Operators[1] == ",")
                return EvaluateCommas(domain);
            if (Operators[1] == ":=")
                return EvaluateAssign(domain);
            if (OperatorsData.Precedence[Operators[1]] == OperatorsData.Precedence["="])
                return EvaluateChain(domain);
            return EvaluateReduce(domain);
        }

        public bool IsCommaOperations()
        {
            return (Operators.Count >= 2 && Operators[1] == ",");
        }

        private LangBool EvaluateChain(NameDomain domain)
        {
            for (int i = 1; i < Operands.Count; i++)
            {
                string op = Operators[i];
                LangValue left = Operands[i - 1].Evaluate(domain);
                LangValue right = Operands[i].Evaluate(domain);

                if (!(EvaluateBinary(op, left, right) as LangBool).Value)
                    return new LangBool(false);
            }
            return new LangBool(true);
        }

        private LangValue EvaluateReduce(NameDomain domain)
        {
            LangValue result = EvaluateBinary(Operators[1], Operands[0].Evaluate(domain), Operands[1].Evaluate(domain));
            for(int i = 2; i < Operands.Count; i++)
            {
                result = EvaluateBinary(Operators[i], result, Operands[i].Evaluate(domain));
            }
            return result;
        }

        private LangValue EvaluateAssign(NameDomain domain)
        {
            
            if(Operands[0].IsNameLeaf())
            {
                domain[(Operands[0] as ASTLeaf).Value.Value] = Operands[1].Evaluate(domain);
                return new LangNone();
            }
            if (Operands[0].IsSingleCall())
            {
                var left = (Operands[0] as ASTOperations);
                var function = LangFunction.FromAST(domain, left.Operands[0], Operands[1]);
                domain[(left.Operands[1] as ASTLeaf).Value.Value] = function;
            }
            return new LangNone();
        }

        private LangValue EvaluateBinary(string op, LangValue left, LangValue right)
        {
            var type1 = left.GetType();
            var type2 = right.GetType();
            MethodInfo theMethod = type1.GetMethod(OperatorsData.Map[op], new Type[] { type2 });
            if(theMethod == null)
            {
                theMethod = type2.GetMethod("rev" + OperatorsData.Map[op], new Type[]{ type1 });
                if (theMethod == null)
                {
                    string typeName1 = type1.Name.Replace("Lang", "");
                    string typeName2 = type2.Name.Replace("Lang", "");
                    throw new ExecutionException($"Operation {typeName1} {op} {typeName2} not defined.");
                }
                try
                {
                    return (LangValue)theMethod.Invoke(right, new object[] { left });
                }
                catch(TargetInvocationException ex)
                {
                    throw ex.InnerException;
                }
            }
            try
            {
                return (LangValue)theMethod.Invoke(left, new object[] { right });
            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException;
            }
        }

        private LangValue EvaluateUnary(NameDomain domain)
        {
            LangValue arg = Operands[0].Evaluate(domain);
            string op = Operators[0];
            MethodInfo theMethod = arg.GetType().GetMethod(OperatorsData.Map[op], new Type[] { });
            if(theMethod == null)
            {
                string typeName = arg.GetType().Name.Replace("Lang", "");
                throw new ExecutionException($"Operation {op} {typeName} not defined.");
            }
            return (LangValue)theMethod.Invoke(arg, new object[]{ });
        }

        private LangValue EvaluateCommas(NameDomain domain)
        {
            return new LangTuple(Operands.Select(i => i.Evaluate(domain)).ToList());
        }

        private LangValue EvaluateTernary(NameDomain domain)
        {
            LangValue cond = Operands[1].Evaluate(domain);
            if(cond is LangBool)
            {
                if((cond as LangBool).Value)
                    return Operands[0].Evaluate(domain);
                return Operands[2].Evaluate(domain);
            }
            throw new ExecutionException("Ifelse condition must evaluate to true/false.");
        }

        public override string ToString() => ToString(0);

        public override string ToString(int offset)
        {
            if (Operands.All(i => i is ASTLeaf))
            {
                string result = new String(' ', 4 * offset) + "(";
                for (int i = 0; i < Operators.Count(); i++)
                {
                    if (Operators[i] != "")
                    {
                        result += Operators[i];
                    }
                    result += " " + Operands[i].ToString() + " ";
                }
                return result + ")";
            }
            else
            {
                string result = new String(' ', 4 * offset) + "(\n";
                for (int i = 0; i < Operators.Count(); i++)
                {
                    if (Operators[i] != "")
                        result += new String(' ', 4 * offset + 4) + Operators[i] + "\n";
                    if(Operands[i] != null)
                        result += Operands[i].ToString(offset + 1) + "\n";
                }
                return result + new String(' ', 4 * offset) + ")";
            }
        }
    }
}
