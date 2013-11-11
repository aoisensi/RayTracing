using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    struct Vector3
    {
        double x, y, z;
        bool unit;

        public double X
        {
            get { return x; }
            set { x = value; }
        }

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        public double Z
        {
            get { return z; }
            set { z = value; }
        }

        public Vector3(double X, double Y, double Z)
            : this(X, Y, Z, false)
        {

        }

        private Vector3(double X, double Y, double Z, bool Unit)
        {
            x = X;
            y = Y;
            z = Z;
            unit = Unit;
        }

        public Vector3 Add(Vector3 Value)
        {
            return new Vector3(X + Value.X, Y + Value.Y, Z + Value.Z);
        }

        public Vector3 Sub(Vector3 Value)
        {
            return new Vector3(X - Value.X, Y - Value.Y, Z - Value.Z);
        }

        public Vector3 Mul(double Value)
        {
            return new Vector3(X * Value, Y * Value, Z * Value);
        }

        public double Dot(Vector3 Value)
        {
            return X * Value.X + Y * Value.Y + Z * Value.Z;
        }

        public Vector3 Cross(Vector3 Value)
        {
            return new Vector3(
                Y * Value.Z - Value.Y * Z,
                Z * Value.X - Value.Z * X,
                X * Value.Y - Value.X * Y);
        }

        public double SquaredNorm()
        {
            return X * X + Y * Y + Z * Z;
        }

        public double Norm()
        {
            return Math.Sqrt(SquaredNorm());
        }

        public double Normalize()
        {
            double norm = Norm();
            double rnorm = 1.0 / norm;
            X *= rnorm;
            Y *= rnorm;
            Z *= rnorm;
            unit = true;
            return norm;
        }

        public Vector3 Normalized()
        {
            if (unit) return this;
            double norm = Norm();
            double rnorm = 1.0 / norm;
            Vector3 result = this.Mul(rnorm);
            result.unit = true;
            return result;
        }

        /// <summary>
        /// 単位ベクトルかどうか
        /// </summary>
        /// <returns>単位ベクトルならtrue</returns>
        public bool IsUnit()
        {
            return unit;
        }

        public override string ToString()
        {
            return string.Format("({0}, {1}, {2})", X, Y, Z);
        }

        public Vector3 Reversed()
        {
            return new Vector3(-X, -Y, -Z, unit);
        }
    }
}
