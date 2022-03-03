using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame
{
    public enum BackgroundShapes { Square, Triangle, Hexagon, Circle }
    public class ShapeBackgroundLayer : BackgroundLayer
    {
        public BackgroundShapes Shape { get; set; }
        public AnimatedDouble DistX { get; set; }
        public AnimatedDouble DistY { get; set; }
        public AnimatedDouble Dist { set => DistX = DistY = value; }
        public AnimatedDouble ScaleX { get; set; }
        public AnimatedDouble ScaleY { get; set; }
        public AnimatedDouble Scale { set => ScaleX = ScaleY = value; }
        public AnimatedDouble TransX { get; set; }
        public AnimatedDouble TransY { get; set; }
        public AnimatedDouble Rotation { get; set; }

        public ShapeBackgroundLayer(BackgroundShapes shape, AnimatedColor color) : base(color)
        {
            Shape = shape;
            Dist = new AnimatedDouble(1);
            Scale = new AnimatedDouble(1);
            Rotation = new AnimatedDouble(0);
            TransX = new AnimatedDouble(0);
            TransY = new AnimatedDouble(0);
        }

        public override void Paint(Graphics g)
        {
            for(int x = -20; x < 20; x++)
            {
                for(int y = -20; y < 20; y++)
                {
                    int uid = (x << 8) + (y << 16);
                    Vector pos = new Vector(x * DistX.Get(uid) + TransX.Get(uid+1), y * DistY.Get(uid+2) + TransY.Get(uid+3));
                    g.FillCircle(Color.Get(uid+4), pos, (float)ScaleX.Get(uid+5));
                }
            }
        }
    }
}
