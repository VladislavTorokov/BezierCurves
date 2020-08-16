using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkingWithBezierCurves.Objects;

namespace WorkingWithBezierCurves.Operations
{
    public class ObliqueShift : AffineTransformation
    {
        public ObliqueShift(int index, double coefficient, Complex complex)
        {
            basicMatrix = new Matrix();
            switch (index)
            {
                case 0:                             //X->Y
                    basicMatrix.elements[1, 0] = coefficient;
                    break;
                case 1:                             //X->Z
                    basicMatrix.elements[2, 0] = coefficient;
                    break;
                case 2:                             //Y->X
                    basicMatrix.elements[0, 1] = coefficient;
                    break;
                case 3:                             //Y->Z
                    basicMatrix.elements[2, 1] = coefficient;
                    break;
                case 4:                             //Z->X
                    basicMatrix.elements[0, 2] = coefficient;
                    break;
                case 5:                             //Z->Y
                    basicMatrix.elements[1, 2] = coefficient;
                    break;
                default:
                    break;
            }
            ChangeComplex(complex);
        }
    }
}
