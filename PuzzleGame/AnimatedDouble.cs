using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame
{
    public class AnimatedDouble
    {
        public double Base { get; private set; }
        public double Variation { get; private set; }
        public double Speed { get; private set; }
        public bool Sine { get; private set; }
        public bool IsRandom { get; private set; }
        public bool IsConstant { get; private set; }

        public AnimatedDouble(double bas, double variation, double speed, bool sine, bool random = false)
        {
            Base = bas;
            Variation = variation;
            Speed = speed;
            Sine = sine;
            IsRandom = random;
            IsConstant = speed == 0;
        }
        public AnimatedDouble(double bas)
        {
            Base = bas;
            IsConstant = true;
        }

        public double Get(int uid=0)
        {
            if (IsConstant) return Base;
            double s = (DateTime.Now - new DateTime(2022, 1, 1)).TotalMilliseconds / 1000.0;
            if (Sine)
            {
                return Base + Variation * Math.Sin(Speed * s + Util.RandomFunction(uid) * Math.PI*2);
            }
            return Base + ((Variation * s * Speed + Util.RandomFunction(uid) * Variation) % Variation);
        }
    }
}
