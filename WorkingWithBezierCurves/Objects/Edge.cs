namespace WorkingWithBezierCurves.Objects
{
    public class Edge
    {
        public Point[] Points { get; }

        public Edge(Point pointBegin,Point pointEnd)
        {
            Points = new Point[2];
            Points[0] = pointBegin;
            Points[1] = pointEnd;
        }
	}
}
