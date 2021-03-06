﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    class Material 
    {
        Illuminance arc, drc, src, fsrc;
        double shininess;

        /// <summary>
        /// ambient reflection coefficient
        /// 環境反射係数
        /// </summary>
        public Illuminance ARC
        {
            get { return arc; }
            set { arc = value; }
        }

        /// <summary>
        /// diffuse reflection constant
        /// 拡散反射係数
        /// </summary>
        public Illuminance DRC
        {
            get { return drc; }
            set { drc = value; }
        }

        /// <summary>
        /// specular reflection constant
        /// 鏡面反射係数
        /// </summary>
        public Illuminance SRC
        {
            get { return src; }
            set { src = value; }
        }

        /// <summary>
        /// full specular reflection constant
        /// 完全鏡面反射係数
        /// </summary>
        public Illuminance FSRC
        {
            get { return fsrc; }
            set { fsrc = value; }
        }

        public double Shininess
        {
            get { return shininess; }
            set { shininess = value; }
        }

        public Material(Illuminance ARC, Illuminance DRC, Illuminance SRC, double Shininess)
        {
            arc = ARC;
            drc = DRC;
            src = SRC;
            fsrc = Illuminance.Black;
            shininess = Shininess;
        }

        public Material(Illuminance ARC, Illuminance DRC, Illuminance SRC, Illuminance FSRC, double Shininess)
        {
            arc = ARC;
            drc = DRC;
            src = SRC;
            fsrc = FSRC;
            shininess = Shininess;
        }

        public Material ChangeColor(Illuminance Illuminance)
        {
            return new Material(ARC.Mul(Illuminance), DRC.Mul(Illuminance), SRC.Mul(Illuminance), Shininess);
        }

        public static Material Concrete
        {
            get { return new Material(new Illuminance(0.01), new Illuminance(0.69), new Illuminance(0.3), Illuminance.Black, 8.0); }
        }

        public static Material Vinyl
        {
            get { return new Material(Illuminance.Black, Illuminance.White, Illuminance.Black, Illuminance.Black, 0.0); }
        }

        public static Material Mirror
        {
            get { return new Material(Illuminance.Black, Illuminance.Black, Illuminance.Black, Illuminance.White, 0.0); }
        }
    }
}
