using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame
{
    public abstract class AnimatedDouble
    {
        public double Base { get; protected set; }
        public double Variation { get; protected set; }
        public double Over { get; protected set; }
        public double Wait { get; protected set; }
        public int RandomGroup { get; protected set; }
        public bool IsSynced { get; protected set; }
        public double Secs { get => (DateTime.Now - new DateTime(2022, 1, 1)).TotalMilliseconds / 1000.0; }

        public virtual double Get(int uid=0)
        {
            double globalPeriod = Over + Wait;
            double globalPhase = (Secs + Util.RandomFunction(RandomGroup + uid) * globalPeriod) % globalPeriod;
            if (globalPhase > Over)
                return Base;
            return Base + Variation * CalcShift(globalPhase / Over);
        }
        protected abstract double CalcShift(double phase);


        public static implicit operator AnimatedDouble(double a)
            => new ConstantDouble(a);
    }
}
