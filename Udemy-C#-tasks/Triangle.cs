using System;

namespace Udemy_Unit5__tasks
{
    class Triangle
    {
        public double CalcTriangleSquare(double ab, double ac, double cb)
        {
            double p = (ab+ac+cb)/2;
            return Math.Sqrt(p * (p - ab) * (p - ac) * (p - cb));
        }

        public double CalcTriangleSquare(double b, double h)
        {
            return 0.5 * b * h;
        }

        public double CalcTriangleSquare(double ab, double ac, int alpha)
        {
            double rads = alpha * Math.PI / 180;
            return 0.5 * ab * ac * Math.Sin(rads);
        }
    }
}