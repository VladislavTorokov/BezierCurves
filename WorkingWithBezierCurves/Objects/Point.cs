using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithBezierCurves.Objects
{
    public class Point
    {
        public double[] Coordinates { get; set; }

        public Point()
        {
            Coordinates = new double[4];
            for (int i = 0; i < Coordinates.Length; i++)
                Coordinates[i] = 0;
        }

        public void Normalization()
        {
            Coordinates[0] = Coordinates[0] / Coordinates[3];
            Coordinates[1] = Coordinates[1] / Coordinates[3];
            Coordinates[2] = Coordinates[2] / Coordinates[3];
            Coordinates[3] = 1.0;
        }
    }
}
