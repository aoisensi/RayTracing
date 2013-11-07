using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    struct Ray
    {
        Vector3 origin, direction;

        internal Vector3 Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        internal Vector3 Origin
        {
            get { return origin; }
            set { origin = value; }
        }

        public Ray(Vector3 Origin, Vector3 Direction)
        {
            origin = Origin;
            Direction.Normalize();
            direction = Direction;
        }

        public Vector3 Away(double Distance)
        {
            return Origin.Add(Direction.Mul(Distance));
        }
    }
}
