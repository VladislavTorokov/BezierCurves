using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkingWithBezierCurves.Objects;

namespace WorkingWithBezierCurves.Operations
{
    public class Scaling : AffineTransformation
    {
        public Scaling(double value, Complex complex)
        {
            basicMatrix = new Matrix();
            basicMatrix.elements[0, 0] = value;
            basicMatrix.elements[1, 1] = value;
            basicMatrix.elements[2, 2] = value;

            ChangeComplex(complex);
        }
    }
}
