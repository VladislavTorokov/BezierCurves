namespace WorkingWithBezierCurves.Objects
{
    public class Surface : Base
    {
        public static string BlockName => "Surface";

		private Point[] _controlPoints;
        private readonly Basis basisU;
        private readonly Basis basisV;

        public Surface()
        {
            basisU = new Basis();
            basisV = new Basis();
        }

        public void SetControlPoints(double[][] controlPoints)
        {
            var length = controlPoints.GetLength(0);
            if (controlPoints == null || length < 16 || length % 16 != 0)
                return;

            _controlPoints = new Point[length];
            for (int i = 0; i < length; i++)
                _controlPoints[i] = new Point(controlPoints[i]);
        }

        public void SetParameters(int paramU, int paramV)
        {
            if (_controlPoints == null)
                return;

            var numberOfPoints = (paramU + 1) * (paramV + 1);
            var numberOfEdges = numberOfPoints + paramU * paramV - 1;

            Points = new Point[numberOfPoints];
            Edges = new Edge[numberOfEdges];

            var edgeNumber = 0;
            for (int v = 0; v <= paramV; v++)
            {
                var basisParamV = basisV.GetBasis((double)v / paramV);
                for (int u = 0; u <= paramU; u++)
                {
                    Points[u + ((paramU + 1) * v)] = new Point(new[] { 0.0, 0, 0, 0 });
                    var basisParamU = basisU.GetBasis((double)u / paramU);
                    for (int k = 0; k < 4; k++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                Points[u + ((paramU + 1) * v)].Coordinates[i] += _controlPoints[(k * 4) + j].Coordinates[i] * basisParamU[j] * basisParamV[k];
                            }
                        }
                    }
                    Points[u + ((paramU + 1) * v)].Normalization();

                    if (u > 0)
                    {
                        Edges[edgeNumber++] = new Edge(Points[(u + (paramU + 1) * v) - 1], Points[u + ((paramU + 1) * v)]);
                    }
                    if (v > 0)
					{
                        Edges[edgeNumber++] = new Edge(Points[u + (paramU + 1) * (v - 1)], Points[u + ((paramU + 1) * v)]);
                    }
                }
            }

            // Заполняем ребра точками
            //for (int i = 0; i < Points.Length; i++)
            //{
            //    if (i % paramU != 0)
            //    {
            //        Edges[i] = new Edge( Points[i], Points[i + 1]);             //Горизонтальные линии
            //    }
            //    if (i < numberOfEdges / 2)
            //        Edges[i] = new Edge( Points[i + paramU - 1], Points[i]);    //Вертикальные линии
            //}
        }
    }
}
