using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    class World
    {
        LinkedList<Shape> shapes = new LinkedList<Shape>();

        internal LinkedList<Shape> Shapes
        {
            get { return shapes; }
            set { shapes = value; }
        }
        LinkedList<Light> lightes = new LinkedList<Light>();
        Illuminance sky;

        public World(Color SkyColor) { sky = new Illuminance(SkyColor); }

        public void AddShape(Shape Shape)
        {
            shapes.AddLast(Shape);
        }

        public void AddLight(Light Light)
        {
            lightes.AddLast(Light);
        }

        public Illuminance ShootRay(Ray Ray)
        {
            Shape shape = null;
            var distance = double.PositiveInfinity;
            foreach (var s in shapes)
            {
                var t = s.Intersection(Ray);
                if (!t.IsPositive()) continue;
                if (distance < t) continue;
                shape = s;
                distance = t;
            }
            if (shape == null) return sky;
            var result = new Illuminance();
            foreach(var l in lightes) {
                Vector3 Intersection = Ray.Away(distance);
                Illuminance light = l.Spotlight(this, shape, Intersection, Ray);
                result = result.Add(light);
            }
            return result;
        }
    }
}
