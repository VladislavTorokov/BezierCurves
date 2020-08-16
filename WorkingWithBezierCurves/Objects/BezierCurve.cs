using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithBezierCurves.Objects
{
    public class BezierCurve : Base
    {
        public Point[] _controlPoints { get; set; }
        private readonly Basis basis;

        public BezierCurve()
        {
            _controlPoints = new Point[4];
            for (int i = 0; i < _controlPoints.Length; i++)
                _controlPoints[i] = new Point();

            points = new List<Point>();
            edges = new List<Edge>();

            basis = new Basis();
        }

        public void SetPoints(Point[] points)
        {
            _controlPoints = points;
        }

        public void SetAccuracy(int parameter)
        {
            double[] basis = new double[4];

            for (int t = 0; t <= parameter; t++)
            {
                points.Add(new Point());
                basis = this.basis.GetBasis((double)t / parameter);
                for (int j = 0; j < 4; j++)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        points[t].Coordinates[i] += _controlPoints[j].Coordinates[i] * basis[j];
                    }
                }
                points[t].Normalization();
                if (t > 0)
                {
                    edges.Add(new Edge(points[t - 1], points[t]));
                }
            }
        }
    }
}
