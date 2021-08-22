using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame
{
    public class Vector
    {
        public float X;
        public float Y;

        public Vector(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Vector(float x, float y)
        {
            X = x;
            Y = y;
        }

        public Vector(double x, double y)
        {
            X = (float)x;
            Y = (float)y;
        }

        public Vector(Point p)
        {
            X = p.X;
            Y = p.Y;
        }

        public Vector(PointF p)
        {
            X = p.X;
            Y = p.Y;
        }

        public Vector Cell()
        {
            return new Vector(Math.Round(X), Math.Round(Y));
        }

        public Vector MidCells()
        {
            var round = this.Lattice();
            return this - Vector.Min(
                new Vector(X - Math.Floor(X), Y - round.Y),
                new Vector(X - Math.Ceiling(X), Y - round.Y),
                new Vector(X - round.X, Y - Math.Floor(Y)),
                new Vector(X - round.X, Y - Math.Ceiling(Y))
            );
        }

        public Vector Lattice()
        {
            return (this + new Vector(0.5, 0.5)).Cell() - new Vector(0.5, 0.5);
        }

        public Vector TopLeftCorner()
        {
            return this.Cell() - new Vector(0.5, 0.5);
        }

        public Point ToPoint()
        {
            return new Point((int)X, (int)Y);
        }

        public PointF ToPointF()
        {
            return new PointF(X, Y);
        }

        public float NormMax()
        {
            return Math.Max(Math.Abs(X), Math.Abs(Y));
        }

        public float Norm1()
        {
            return Math.Abs(X) + Math.Abs(Y);
        }

        public float Norm2()
        {
            return (float)Math.Sqrt(X * X + Y * Y);
        }

        public float DistMax(Vector b)
        {
            return (this - b).NormMax();
        }

        public float Dist1(Vector b)
        {
            return (this - b).Norm1();
        }

        public float Dist2(Vector b)
        {
            return (this - b).Norm2();
        }

        public bool Nonzero()
        {
            return X != 0 || Y != 0;
        }

        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.X + b.X, a.Y + b.Y);
        }

        public static Vector operator *(Vector a, float s)
        {
            return new Vector(s * a.X, s * a.Y);
        }

        public static Vector operator *(Vector a, int s)
        {
            return new Vector(s * a.X, s * a.Y);
        }

        public static Vector operator *(float s, Vector a)
        {
            return a * s;
        }

        public static Vector operator *(int s, Vector a)
        {
            return a * s;
        }

        public static Vector operator -(Vector a)
        {
            return (-1) * a;
        }

        public static Vector operator -(Vector a, Vector b)
        {
            return a + (-b);
        }

        public static bool operator ==(Vector vector1, Vector vector2)
        {
            return vector1.Equals(vector2);
        }

        public static bool operator !=(Vector vector1, Vector vector2)
        {
            return !(vector1 == vector2);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Vector))
            {
                return false;
            }

            var vector = (Vector)obj;
            return X == vector.X &&
                   Y == vector.Y;
        }

        public override int GetHashCode()
        {
            var hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }

        public Vector Rotate()
        {
            return new Vector(Y, -X);
        }

        public static Vector Min(params Vector[] args)
        {
            if (args.Length < 2)
            {
                return args[0];
            }
            if (args.Length == 2)
            {
                return args[0].NormMax() < args[1].NormMax() ? args[0] : args[1];
            }
            return Vector.Min(args[0], Vector.Min(args.Skip(1).ToArray()));
        }

        public override string ToString()
        {
            return $"[{X}, {Y}]";
        }

        public Vector Normalise()
        {
            return (1f / this.Norm2()) * this;
        }

        public static Vector FromCoordinateString(string s)
        {
            var parts = s.Substring(1, s.Length - 2).Split(',');
            return new Vector(float.Parse(parts[0]), float.Parse(parts[1]));
        }

        public bool AlmostZero(float tolerance = 0.00000001f)
        {
            return this.Norm1() < tolerance;
        }
    }
}
