using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkingWithBezierCurves.Objects;

namespace WorkingWithBezierCurves.Operations
{
    public abstract class AffineTransformation
    {
        protected Matrix basicMatrix;

        protected void ChangeComplex(Complex complex)
        {
            foreach (Scene scene in complex.scenes)
                DoOperation(scene);

            foreach (BezierCurve bezierCurve in complex.bezierCurves)
                DoOperation(bezierCurve);

            foreach (Surface surface in complex.surfaces)
                DoOperation(surface);
        }

        protected void DoOperation(Base root)
        {
            for (int j = 0; j < root.points.Count; j++)
            {
                root.points[j].Coordinates = basicMatrix.GetMultiplication(root.points[j].Coordinates);
                root.points[j].Normalization();
            }
        }
    }
}
