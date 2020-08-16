using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithBezierCurves.Objects
{
    public class Complex
    {
        public List<Scene> scenes { get; set; }
        public List<BezierCurve> bezierCurves { get; set; }
        public List<Surface> surfaces { get; set; }

        public Complex()
        {
            scenes = new List<Scene>();
            bezierCurves = new List<BezierCurve>();
            surfaces = new List<Surface>();
        }
    }
}
