using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using WorkingWithBezierCurves.Objects;

namespace WorkingWithBezierCurves.Operations
{
	public class Drawing
	{
		public void Draw(Canvas picture, Base[] roots, float x0, float y0)
		{
			var emptyPoint = new Point(new[] { 0.0, 0.0, 0.0, 0.0 });
			var emptyEdge = new Edge(emptyPoint, emptyPoint); 

			if (roots == null)
				return;

			foreach (Base root in roots)
			{
				for (int i = 0; i < root.Edges.Length; i++)
				{
					if (root.Edges[i].Equals(emptyEdge) || (root.Edges[i].Points == null) || root == null)
						continue;

					Line line = new Line()
					{
						Stroke = Brushes.Black,
						StrokeThickness = 2,
						X1 = x0 + (float)root.Edges[i].Points[0].Coordinates[0],
						Y1 = y0 + (float)root.Edges[i].Points[0].Coordinates[1],
						X2 = x0 + (float)root.Edges[i].Points[1].Coordinates[0],
						Y2 = y0 + (float)root.Edges[i].Points[1].Coordinates[1],
					};
					picture.Children.Add(line);
				}
			}
		}
	}
}
