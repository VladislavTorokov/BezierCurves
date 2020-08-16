using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkingWithBezierCurves.Objects;

namespace WorkingWithBezierCurves.Operations
{
    public class Rotation : AffineTransformation
    {
        public Rotation(int indexOfAxis, double angle, Complex complex)
        {
            basicMatrix = new Matrix();

            if (indexOfAxis == 0)
            {
                SetXBasis(angle);
            }

            if (indexOfAxis == 1)
            {
                SetYBasis(angle);
            }

            if (indexOfAxis == 2)
            {
                SetZBasis(angle);
            }

            ChangeComplex(complex);
        }

        private void SetXBasis(double angle)
        {
            basicMatrix.elements[1, 1] = Math.Cos(angle);
            basicMatrix.elements[1, 2] = Math.Sin(angle);
            basicMatrix.elements[2, 1] = -Math.Sin(angle);
            basicMatrix.elements[2, 2] = Math.Cos(angle);
        }

        private void SetYBasis(double angle)
        {
            basicMatrix.elements[0, 0] = Math.Cos(angle);
            basicMatrix.elements[0, 2] = -Math.Sin(angle);
            basicMatrix.elements[2, 0] = Math.Sin(angle);
            basicMatrix.elements[2, 2] = Math.Cos(angle);
        }

        private void SetZBasis(double angle)
        {
            basicMatrix.elements[0, 0] = Math.Cos(angle);
            basicMatrix.elements[0, 1] = Math.Sin(angle);
            basicMatrix.elements[1, 0] = -Math.Sin(angle);
            basicMatrix.elements[1, 1] = Math.Cos(angle);
        }
    }
}
