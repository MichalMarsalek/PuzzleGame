using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame
{
    public class HalfSineDouble : AnimatedDouble
    {
        public HalfSineDouble(double bas, double variation, double over, double wait=0, int randomGroup = 0, bool synced = true)
        {
            Base = bas;
            Variation = variation;
            Over = over;
            Wait = wait;
            RandomGroup = randomGroup;
            IsSynced = synced;
        }

        protected override double CalcShift(double x) => Math.Sin(Math.PI * x);
    }
}
