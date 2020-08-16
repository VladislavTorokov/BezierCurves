using System;

namespace WorkingWithBezierCurves.Objects
{
    public class Basis
    {
        private double[] g;

        public Basis()
        {
            g = new double[4];
        }

        public double[] GetBasis(double t)
        {
            g[0] = (1 - t) * (1 - t);
            g[1] = 2 * t * (1 - t) * (1 - t);
            g[2] = 2 * (1 - t) * t * t;
            g[3] = t * t;
            return g;
        }
    }
}
