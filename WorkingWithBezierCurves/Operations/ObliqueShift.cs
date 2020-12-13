using WorkingWithBezierCurves.Objects;

namespace WorkingWithBezierCurves.Operations
{
    public class ObliqueShift : AffineTransformation
    {
		public void Execute(int index, double coefficient, Point[] points)
		{
            switch (index)
            {
                case 0:                             //X->Y
                    basicMatrix.Elements[1, 0] = coefficient;
                    break;
                case 1:                             //X->Z
                    basicMatrix.Elements[2, 0] = coefficient;
                    break;
                case 2:                             //Y->X
                    basicMatrix.Elements[0, 1] = coefficient;
                    break;
                case 3:                             //Y->Z
                    basicMatrix.Elements[2, 1] = coefficient;
                    break;
                case 4:                             //Z->X
                    basicMatrix.Elements[0, 2] = coefficient;
                    break;
                case 5:                             //Z->Y
                    basicMatrix.Elements[1, 2] = coefficient;
                    break;
                default:
                    break;
            }
            ChangePointValues(points);
        }
	}
}
