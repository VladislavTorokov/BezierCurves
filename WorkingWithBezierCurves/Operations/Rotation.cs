using System;
using WorkingWithBezierCurves.Objects;

namespace WorkingWithBezierCurves.Operations
{
    public class Rotation : AffineTransformation
    {
        public void Execute(int indexOfAxis, double angle, Point[] points)
		{
            switch (indexOfAxis)
            {
                case 0: SetXBasis(angle); break;
                case 1: SetYBasis(angle); break;
                case 2: SetZBasis(angle); break;
            }
            ChangePointValues(points);
        }

        private void SetXBasis(double angle)
        {
            basicMatrix.Elements[1, 1] = Math.Cos(angle);
            basicMatrix.Elements[1, 2] = Math.Sin(angle);
            basicMatrix.Elements[2, 1] = -Math.Sin(angle);
            basicMatrix.Elements[2, 2] = Math.Cos(angle);
        }

        private void SetYBasis(double angle)
        {
            basicMatrix.Elements[0, 0] = Math.Cos(angle);
            basicMatrix.Elements[0, 2] = -Math.Sin(angle);
            basicMatrix.Elements[2, 0] = Math.Sin(angle);
            basicMatrix.Elements[2, 2] = Math.Cos(angle);
        }

        private void SetZBasis(double angle)
        {
            basicMatrix.Elements[0, 0] = Math.Cos(angle);
            basicMatrix.Elements[0, 1] = Math.Sin(angle);
            basicMatrix.Elements[1, 0] = -Math.Sin(angle);
            basicMatrix.Elements[1, 1] = Math.Cos(angle);
        }
    }
}
