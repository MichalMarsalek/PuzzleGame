using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame
{
    public class ConstantDouble : AnimatedDouble
    {
        public ConstantDouble(double bas, double variation=0, int randomGroup = 0, bool synced = true)
        {
            Base = bas;
            Variation = variation;
            RandomGroup = randomGroup;
            IsSynced = synced;
        }

        public override double Get(int uid = 0)
             => Base + Variation * Util.RandomFunction(RandomGroup + uid);

        protected override double CalcShift(double x) => 0;

        public static implicit operator ConstantDouble(double a)
            => new ConstantDouble(a);
    }
}
