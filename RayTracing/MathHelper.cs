using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    static class MathHelper
    {
        const double epsilon = 1.0/512.0;
        public static double Epsilon
        {
            get { return epsilon; }
        }
    }
}
