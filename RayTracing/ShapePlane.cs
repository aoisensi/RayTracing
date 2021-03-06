﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    class ShapePlane : Shape
    {
        Vector3 p, n;

        public Vector3 Normal
        {
            get { return n; }
            set { n = value.Normalized(); }
        }

        public Vector3 Point
        {
            get { return p; }
            set { p = value; }
        }

        /// <summary>
        /// 無限平面
        /// </summary>
        /// <param name="Point">通過点</param>
        /// <param name="Normal">法線ベクトル</param>
        public ShapePlane(Material Material, Vector3 Point, Vector3 Normal) : base(Material)
        {
            p = Point;
            n = Normal.Normalized();
        }

        public override double Intersection(Ray Ray)
        {
            double m = Ray.Direction.Dot(Normal);
            if (m < 0.0)
            {
                return -(Ray.Origin.Sub(Point).Dot(Normal) / m);
            }
            return double.NaN;
        }

        public override Vector3 NormalVector(Vector3 Intersection)
        {
            return Normal;
        }
    }
}
