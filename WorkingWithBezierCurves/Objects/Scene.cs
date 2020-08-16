using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithBezierCurves.Objects
{
    public class Scene : Base
    {
        public Scene()
        {
            points = new List<Point>();
            edges = new List<Edge>();
        }
        public void AddPoints(int[][] arrayPoints)
        {
            if ((arrayPoints != null) && (points != null))
                for (int i = 0; i < arrayPoints.Length; i++)
                    edges.Add(new Edge(points[arrayPoints[i][0]], points[arrayPoints[i][1]]));
        }
    }
}
