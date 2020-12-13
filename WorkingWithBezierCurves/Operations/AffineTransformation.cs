using System.Collections.Generic;
using WorkingWithBezierCurves.Objects;

namespace WorkingWithBezierCurves.Operations
{
    public abstract class AffineTransformation
    {
        public AffineTransformation()
		{
            basicMatrix = new Matrix();
        }

        protected Matrix basicMatrix;

        protected void ChangePointValues(Point[] points)
        {
            for (int i = 0; i < points.Length; i++)
            {
                points[i].Coordinates = basicMatrix.Multiply(points[i].Coordinates);
                points[i].Normalization();
            }
        }
    }
}
