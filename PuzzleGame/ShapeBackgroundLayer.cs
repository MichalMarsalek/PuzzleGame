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
            Dist = new ConstantDouble(1);
            Scale = new ConstantDouble(1);
            Rotation = new ConstantDouble(0);
            TransX = new ConstantDouble(0);
            TransY = new ConstantDouble(0);
        }

        public override void Paint(Graphics g)
        {
            double distX = DistX.Get();
            double distY = DistY.Get();
            double transX = TransX.Get();
            double transY = TransY.Get();
            double scaleX = ScaleX.Get();
            double scaleY = ScaleY.Get();
            double rotation = Rotation.Get();
            Color color = Color.Get();
            for (int x = -20; x < 20; x++)
            {
                for(int y = -20; y < 20; y++)
                {
                    int uid = (x << 8) + (y << 16);
                    double tx = TransX.IsSynced ? transX : TransX.Get(uid);
                    double ty = TransY.IsSynced ? transY : TransY.Get(uid);
                    Vector pos = new Vector(x * distX + tx, y * distY + ty);
                    double rot = Rotation.IsSynced ? rotation : Rotation.Get(uid);
                    Color col = Color.IsSynced ? color : Color.Get(uid);
                    double sx = ScaleX.IsSynced ? scaleX : ScaleX.Get(uid);
                    double sy = ScaleY.IsSynced ? scaleY : ScaleY.Get(uid);
                    if (Shape == BackgroundShapes.Circle)
                        g.DrawCircle(col, pos, (float)sx/2);
                    else if (Shape == BackgroundShapes.Square)
                        g.DrawRectangle(col, pos, (float)sx/2, (float)sy/2, (float)rot);
                }
            }
        }
    }
}
