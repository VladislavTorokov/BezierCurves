using System;
using System.Linq;

namespace WorkingWithBezierCurves.Objects
{
	public class Scene : Base
	{
		public static string BlockName => "Scene";
		public static string AdditionalBlockName => "Lines";

		public void SetPoints(double[][] points)
		{
			if (points == null)
				return;

			Points = new Point[points.GetLength(0)];
			for (int i = 0; i < points.GetLength(0); i++)
				Points[i] = new Point(points[i]);
		}

		public void SetEdges(double[][] edges)
		{
			var maxIndex = edges.Max(e => e.Max());
			if (edges == null || Points == null || maxIndex > Points.Length)
				return;

			Edges = new Edge[edges.GetLength(0)];
			for (int i = 0; i < edges.GetLength(0); i++)
				Edges[i] = new Edge( Points[(int)edges[i][0] - 1], Points[(int)edges[i][1] - 1]);
		}
	}
}
