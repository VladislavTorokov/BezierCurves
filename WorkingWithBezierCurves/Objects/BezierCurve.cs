namespace WorkingWithBezierCurves.Objects
{
    public class BezierCurve : Base
    {
		public static string BlockName => "BezierCurve";

		private Point[] _controlPoints;
        private readonly Basis basis;

        public BezierCurve()
        {
            basis = new Basis();
        }

        public void SetControlPoints(double[][] controlPoints)
        {
            var length = controlPoints.GetLength(0);
            if (controlPoints == null || length < 4 || length % 4 != 0)
                return;

            _controlPoints = new Point[length];
            for (int i = 0; i < length; i++)
                _controlPoints[i] = new Point(controlPoints[i]);
        }

        public void SetAccuracy(int parameter)
        { 
            Points = new Point[parameter+1];
            Edges = new Edge[parameter];

            for (int t = 0; t <= parameter; t++)
            {
                Points[t] = new Point(new[] { 0.0, 0, 0, 0 });
                var basis = this.basis.GetBasis((double)t / parameter);
                for (int j = 0; j < 4; j++)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        Points[t].Coordinates[i] += _controlPoints[j].Coordinates[i] * basis[j];
                    }
                }
                Points[t].Normalization();
                if (t > 0)
                {
                    Edges[t - 1] = new Edge(Points[t - 1],Points[t]);
                }
            }
        }
    }
}
