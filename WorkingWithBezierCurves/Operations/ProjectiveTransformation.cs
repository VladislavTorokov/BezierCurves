using WorkingWithBezierCurves.Objects;

namespace WorkingWithBezierCurves.Operations
{
    public class ProjectiveTransformation : AffineTransformation
    {
        public void Execute(int index, double focus, Point[] points)
		{
            switch (index)
            {
                case 0:                             //X
                    basicMatrix.Elements[0, 3] = 1 / focus;
                    break;
                case 1:                             //Y
                    basicMatrix.Elements[1, 3] = 1 / focus;
                    break;
                case 2:                             //Z
                    basicMatrix.Elements[2, 3] = 1 / focus;
                    break;
                default:
                    break;
            }

            ChangePointValues(points);
        }
    }
}
