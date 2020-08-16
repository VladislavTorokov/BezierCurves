using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithBezierCurves.Objects
{
    public abstract class Base
    {
        public List<Point> points { get; set; }
        public List<Edge> edges { get; set; }
    }
}
