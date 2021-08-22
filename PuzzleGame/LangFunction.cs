using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame
{
    public class LangFunction : LangValue
    {
        public List<string> ArgumentsNames { get; private set; }
        public List<LangValue> PresetArgs { get; private set; }
        public NameDomain Context { get; private set; }
        public ASTNode Value { get; private set; }
        public int SetArgs
        {
            get
            {
                return PresetArgs.Count;
            }
        }
        public int TotalArgs
        {
            get
            {
                return ArgumentsNames.Count;
            }
        }
        public int MissingArgs
        {
            get
            {
                return TotalArgs-SetArgs;
            }
        }

        public static LangFunction FromAST(NameDomain context, ASTNode left, ASTNode right)
        {
            List<string> argNames = null;
            if (left.IsNameLeaf())
            {
                argNames = new List<string>() { (left as ASTLeaf).Value.Value };
            }
            else if(left is ASTOperations && (left as ASTOperations).IsCommaOperations())
            {
                var args = (left as ASTOperations).Operands;
                if(args.All(i => i.IsNameLeaf()))
                {
                    argNames = args.Select(i => (i as ASTLeaf).Value.Value).ToList();
                }
            }
            if(argNames == null)
            {
                throw new ExecutionException("Can only assign to constants or parametrized functions.");
            }
            return new LangFunction(context, argNames, right);
        }

        public LangFunction(NameDomain context, List<string> names, ASTNode value, List<LangValue> preset = null)
        {
            Context = context;
            ArgumentsNames = names;
            Value = value;
            if(preset == null)
            {
                preset = new List<LangValue>();
            }
            PresetArgs = preset;
        }

        public LangValue revopCall(LangValue left)
        {
            List<LangValue> arguments = new List<LangValue>() { left };
            if (left is LangTuple)
            {
                arguments = (left as LangTuple).Values;
            }
            LangFunction result = new LangFunction(Context, ArgumentsNames, Value, PresetArgs.ToList());
            if(arguments.Count > MissingArgs)
            {
                var rest = arguments.Skip(MissingArgs - 1).ToList();
                arguments = arguments.Take(MissingArgs - 1).ToList();
                arguments.Add(new LangTuple(rest));
            }
            foreach(LangValue arg in arguments)
            {
                result.ApplyValue(arg);
            }
            if(result.SetArgs == result.TotalArgs)
            {
                return result.FinalEvaluation();
            }
            return result;
        }

        public void ApplyValue(LangValue val)
        {
            PresetArgs.Add(val);
        }

        public LangValue FinalEvaluation()
        {
            NameDomain context = new NameDomain(Context);
            for (int i = 0; i < TotalArgs; i++)
            {
                context[ArgumentsNames[i]] = PresetArgs[i];
            }
            return Value.Evaluate(context);
        }

        public override string ToString()
        {
            return $"Function with {SetArgs}/{TotalArgs} arguments applied.";
        }
    }
}
