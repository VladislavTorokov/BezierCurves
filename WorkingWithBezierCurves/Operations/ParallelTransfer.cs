using WorkingWithBezierCurves.Objects;

namespace WorkingWithBezierCurves.Operations
{
    public class ParallelTransfer : AffineTransformation
    {
        public void Execute(double[] coordinatesValue, Point[] points)
        {
            basicMatrix.Elements[3, 0] = coordinatesValue[0];
            basicMatrix.Elements[3, 1] = coordinatesValue[1];
            basicMatrix.Elements[3, 2] = coordinatesValue[2];

            ChangePointValues(points);
        }
    }
}
