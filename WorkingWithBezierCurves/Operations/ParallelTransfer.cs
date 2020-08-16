using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkingWithBezierCurves.Objects;

namespace WorkingWithBezierCurves.Operations
{
    public class ParallelTransfer : AffineTransformation
    {
        public ParallelTransfer(double[] coordinatesValue, Complex complex)
        {
            basicMatrix = new Matrix();
            basicMatrix.elements[3, 0] = coordinatesValue[0];
            basicMatrix.elements[3, 1] = coordinatesValue[1];
            basicMatrix.elements[3, 2] = coordinatesValue[2];

            ChangeComplex(complex);
        }
    }
}
