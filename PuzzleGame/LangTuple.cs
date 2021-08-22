using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame
{
    public class LangTuple : LangValue
    {
        public List<LangValue> Values { get; private set; }

        public LangTuple()
        {
            Values = new List<LangValue>();
        }

        public LangTuple(LangValue val)
        {
            Values = new List<LangValue>() { val };
        }

        public LangTuple(List<LangValue> vals)
        {
            Values = new List<LangValue>(vals);
        }

        //TODO refactor this using map
        public LangTuple opTimes(LangNumber s)
        {
            var res = new LangTuple();
            foreach (LangValue x in this.Values) { 
                MethodInfo theMethod = x.GetType().GetMethod("opTimes");
                if (theMethod == null)
                {
                    throw new ExecutionException("Arguments not compatible with operator");
                }
                res.Values.Add((LangValue)theMethod.Invoke(x, new object[] { s }));
            }
            return res;
        }

        public LangTuple opUnMinus()
        {
            var res = new LangTuple();
            foreach (LangValue x in this.Values)
            {
                MethodInfo theMethod = x.GetType().GetMethod("opUnMinus");
                if (theMethod == null)
                {
                    throw new ExecutionException("Arguments not compatible with operator");
                }
                res.Values.Add((LangValue)theMethod.Invoke(x, new object[] {}));
            }
            return res;
        }

        public LangNumber opTimes(LangTuple left)
        {
            int len = Math.Min(left.Values.Count, this.Values.Count);
            LangNumber result = new LangNumber(0,1);
            for(int i = 0; i < len; i++)
            {
                if(left.Values[i] is LangNumber && this.Values[i] is LangNumber)
                {
                    result += (LangNumber)left.Values[i] + (LangNumber)this.Values[i];
                }
                else
                {
                    throw new ExecutionException("Dot product only available between vectors of numbers.");
                }
            }
            return result;
        }

        public LangTuple opUnPlus() => this;

        public override string ToString()
        {
            return "(" + String.Join(", ", Values.Select(i => i.ToString())) + ")";
        }
    }
}
