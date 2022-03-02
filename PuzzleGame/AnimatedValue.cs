using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame
{
    public class AnimatedValue
    {
        public double Base { get; private set; }
        public double Variation { get; private set; }
        public double Speed { get; private set; }
        public bool Sine { get; private set; }

        public AnimatedValue(double bas, double variation, double speed, bool sine)
        {
            Base = bas;
            Variation = variation;
            Speed = speed;
            Sine = sine;
        }

        public double GetValue()
        {
            double s = (DateTime.Now - new DateTime(2022, 1, 1)).TotalMilliseconds / 1000.0;
            if (Sine)
            {
                return Base + Variation * Math.Sin(Speed * s);
            }
            return Base + (Variation * s * Speed % Variation);
        }
    }
}
