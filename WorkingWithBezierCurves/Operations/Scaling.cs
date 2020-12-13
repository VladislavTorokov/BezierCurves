using WorkingWithBezierCurves.Objects;

namespace WorkingWithBezierCurves.Operations
{
    public class Scaling : AffineTransformation
    {
        public void Execute(double value, Point[] points)
		{
            basicMatrix.Elements[0, 0] = value;
            basicMatrix.Elements[1, 1] = value;
            basicMatrix.Elements[2, 2] = value;

            ChangePointValues(points);
        }
    }
}
