using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    class World
    {
        const int MAX_RECURSION = 100;

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
            return ShootRay(Ray, MAX_RECURSION);
        }

        private Illuminance ShootRay(Ray Ray, int loop)
        {
            if (loop == 0) return Illuminance.Black;
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
            var Intersection = Ray.Away(distance);
            var Normal = shape.NormalVector(Intersection);

            foreach(var l in lightes) {
                Illuminance light = l.Spotlight(this, shape, Intersection, Ray, Normal);
                result = result.Add(light);
            }

            if (!shape.Material.FSRC.IsDark()) //鏡
            {
                var v = Ray.Direction.Reversed();
                var d = Normal.Dot(v);
                if(d > 0.0)
                {
                    var r = Normal.Mul(2 * v.Dot(Normal)).Sub(v);
                    var ray = new Ray(Intersection.Add(r.Mul(MathHelper.Epsilon)), r);
                    result = result.Add(ShootRay(ray, loop - 1));
                }
            }
            return result;
        }
    }
}
