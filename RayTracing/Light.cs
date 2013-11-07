using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RayTracing
{
    abstract class Light
    {
        public abstract Illuminance Spotlight(World World, Vector3 Spot);

    }
}
