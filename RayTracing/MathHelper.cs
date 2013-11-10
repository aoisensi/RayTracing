using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    static class MathHelper
    {
        const double epsilon = 1.0/1024.0;
        public static double Epsilon
        {
            get { return epsilon; }
        }

        public static bool IsZero(this double Value)
        {
            if (Value > Epsilon) return false;
            if (Value < -Epsilon) return false;
            return true;
        }

        public static bool IsPositive(this double Value)
        {
            return Value > 0.0 && !double.IsNaN(Value);
        }
    }
}
