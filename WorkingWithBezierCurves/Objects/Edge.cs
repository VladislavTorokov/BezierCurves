using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithBezierCurves.Objects
{
    public class Edge
    {
        public Point[] _points { get; }

        public Edge(Point pointBegin, Point pointEnd)
        {
            _points = new Point[2];
            _points[0] = pointBegin;
            _points[1] = pointEnd;
        }
    }
}
