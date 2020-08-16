using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithBezierCurves.Objects
{
    public class Surface : Base
    {
        public Point[] _controlPoints { get; set; }
        private Basis basisU;
        private Basis basisV;

        public Surface()
        {
            points = new List<Point>();
            edges = new List<Edge>();

            _controlPoints = new Point[16];

            for (int i = 0; i < 16; i++)
                _controlPoints[i] = new Point();

            basisU = new Basis();
            basisV = new Basis();
        }

        public void SetPoints(Point[] points)
        {
            _controlPoints = points;
        }

        public void SetParameters(int paramU, int paramV)
        {
            double[] basisParamU = new double[4];
            double[] basisParamV = new double[4];
            int quantityEdges = 2 * (paramU) * (paramV + 1);

            for (int v = 0; v <= paramV; v++)
            {
                basisParamV = basisV.GetBasis((double)v / paramV);
                for (int u = 0; u <= paramU; u++)
                {
                    points.Add(new Point());
                    basisParamU = basisU.GetBasis((double)u / paramU);
                    for (int k = 0; k < 4; k++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                points[u + ((paramU + 1) * v)].Coordinates[i] += _controlPoints[(k * 4) + j].Coordinates[i] * basisParamU[j] * basisParamV[k];
                            }
                        }
                    }
                    points[u + ((paramU + 1) * v)].Normalization();
                }
            }

            // Заполняем ребра точками
            for (int i = 0; i < points.Count; i++)
            {
                if ((i + 1) % (paramU + 1) != 0)
                {
                    edges.Add(new Edge(points[i], points[i + 1]));             //Горизонтальные линии
                }
                if (i < quantityEdges / 2)
                    edges.Add(new Edge(points[i], points[i + paramU + 1]));    //Вертикальные линии
            }
        }
    }
}
