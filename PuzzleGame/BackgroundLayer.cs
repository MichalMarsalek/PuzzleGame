using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame
{
    public class BackgroundLayer
    {
        public AnimatedColor Color { get; set; }

        public BackgroundLayer() { }

        public BackgroundLayer(AnimatedColor color)
        {
            Color = color;
        }

        public virtual void Paint(Graphics g)
        {
            g.FillRegion(new SolidBrush(Color.Get()), g.Clip);
        }
    }
}
