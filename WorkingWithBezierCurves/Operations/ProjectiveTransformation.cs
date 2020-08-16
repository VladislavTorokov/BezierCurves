using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkingWithBezierCurves.Objects;

namespace WorkingWithBezierCurves.Operations
{
    public class ProjectiveTransformation : AffineTransformation
    {
        public ProjectiveTransformation(int index, double focus, Complex complex)
        {
            basicMatrix = new Matrix();
            switch (index)
            {
                case 0:                             //X
                    basicMatrix.elements[0, 3] = 1 / focus;
                    break;
                case 1:                             //Y
                    basicMatrix.elements[1, 3] = 1 / focus;
                    break;
                case 2:                             //Z
                    basicMatrix.elements[2, 3] = 1 / focus;
                    break;
                default:
                    break;
            }

            ChangeComplex(complex);
        }
    }
}
