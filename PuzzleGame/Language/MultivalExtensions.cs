using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Language
{
    public static class MultivalExtensions
    {
        public static Multival<T> ToMultival<T>(this List<T> data, CardinalParam card)
        {
            return new Multival<T>(data.ToDictionary(i => i.ToString(), i => i), card);
        }
        public static Multival<T> ToMultival<T>(this List<T> data)
        {
            return data.ToMultival(CardinalParam.Each);
        }
        public static Multival<T> ToMultival<T, T2>(this Dictionary<T2, T> data, CardinalParam card)
        {
            return new Multival<T>(data.ToDictionary(i => i.Key.ToString(), i => i.Value), card);
        }
        public static Multival<T> ToMultival<T, T2>(this Dictionary<T2, T> data)
        {
            return data.ToMultival(CardinalParam.Each);
        }

        public static bool Id(bool x) => x;
        
        public static object ReduceIfBool<T>(this Multival<T> a)
        {
            if (a.Values.Values.First().GetType() == typeof(bool))
            {
                int target = a.Cardinal.IsEach ? a.Values.Count() : a.Cardinal.Amount;
                bool exact = a.Cardinal.IsExact;
                int sofar = 0;
                foreach (var val in a.Values.Values)
                {
                    //TODO avoid this hack
                    bool casted = (bool)typeof(MultivalExtensions).GetMethod("Id").Invoke(null, new object[] { val });
                    if (casted) sofar++;
                    if (sofar > target) break;
                }
                if (exact)
                {
                    return sofar == target;
                }
                else
                {
                    return sofar >= target;
                }
            }
            return a;
        }
    }
}
