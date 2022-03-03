using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame
{
    public class AnimatedColor
    {
        public AnimatedDouble Hue { get; private set; }
        public AnimatedDouble Saturation { get; private set; }
        public AnimatedDouble Lightness { get; private set; }
        public AnimatedDouble Alpha { get; private set; }
        private bool isConstant;
        private Color constantColor;

        public AnimatedColor(AnimatedDouble hue, AnimatedDouble saturation, AnimatedDouble lightness, AnimatedDouble alpha)
        {
            Hue = hue;
            Saturation = saturation;
            Lightness = lightness;
            Alpha = alpha;
            isConstant = hue.IsConstant && saturation.IsConstant && lightness.IsConstant && alpha.IsConstant;
            if (isConstant)
                constantColor = Util.ColorFromHsla(hue.Get(), saturation.Get(), lightness.Get(), alpha.Get());
        }

        public Color Get(int uid=0)
        {
            if (isConstant) return constantColor;
            return Util.ColorFromHsla(Hue.Get(uid), Saturation.Get(uid), Lightness.Get(uid), Alpha.Get(uid));
        }
    }
}
