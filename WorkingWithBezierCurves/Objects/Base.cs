using System;

namespace WorkingWithBezierCurves.Objects
{
	public abstract class Base: IDisposable
	{
		public Point[] Points { get; set; }
		public Edge[] Edges { get; set; }

		public virtual void Dispose()
		{
			Points = null;
			Edges = null;
		}
	}
}