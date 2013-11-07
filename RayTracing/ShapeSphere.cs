using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    class ShapeSphere : Shape
    {
        double r;
        Vector3 p;

        internal Vector3 Point
        {
            get { return p; }
            set { p = value; }
        }
        public ShapeSphere(Vector3 Point, double Radius)
        {
            r = Radius;
            p = Point;
        }

        public override double Intersection(Ray Ray)
        {
            double A = Ray.Direction.SquaredNorm();
            double B = 2.0 * ((Ray.Origin.Sub(p).Dot(Ray.Direction)));
            double C = Ray.Origin.Sub(p).SquaredNorm() - Math.Pow(r, 2.0);
            double D = Math.Pow(B, 2.0) - 4 * A * C;
            if (D == 0)
            {
                return -B / (2 * A);
            }
            else if (D > 0.0)
            {
                double t1 = (-B + Math.Sqrt(D)) / (2 * A);
                double t2 = (-B - Math.Sqrt(D)) / (2 * A);
                if (t1 < 0.0)
                    if (t2 < 0.0)
                        return double.NaN;
                    else
                        return t2;
                if (t2 < 0.0)
                    return t1;
                return t1 < t2 ? t1 : t2;
            }
            else
            {
                return double.NaN;
            }
        }

        public override Vector3 NormalVector(Vector3 Intersection)
        {
            return Intersection.Sub(Point);
        }
    }
}
