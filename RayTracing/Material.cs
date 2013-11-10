using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    class Material 
    {

        Color color;
        double arc, drc, src;
        double gloss;

        /// <summary>
        /// ambient reflection coefficient
        /// 環境反射係数
        /// </summary>
        public double ARC
        {
            get { return arc; }
            set { arc = value; }
        }

        /// <summary>
        /// diffuse reflection constant
        /// 拡散反射係数
        /// </summary>
        public double DRC
        {
            get { return drc; }
            set { drc = value; }
        }

        /// <summary>
        /// specular reflection constant
        /// 鏡面反射係数
        /// </summary>
        public double SRC
        {
            get { return src; }
            set { src = value; }
        }

        public double Gloss
        {
            get { return gloss; }
            set { src = value; }
        }

        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        public Material(Color Color)
        {
            color = Color;
            arc = 0.01;
            drc = 0.69;
            src = 0.30;
            gloss = 8.0;
        }


        public static Material Concrete
        {
            get { return new Material(Color.White); }
        }
    }
}
