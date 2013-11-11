using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RayTracing
{
    abstract class Light
    {
        Illuminance l;

        public Illuminance Illuminance
        {
            get { return l; }
            set { l = value; }
        }

        public Light(Illuminance Illuminance)
        {
            l = Illuminance;
        }

        public abstract Illuminance Spotlight(World World, Shape Shape, Vector3 Spot, Ray Ray, Vector3 Normal);

    }
}
