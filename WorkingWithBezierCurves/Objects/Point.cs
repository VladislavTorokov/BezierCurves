namespace WorkingWithBezierCurves.Objects
{
	public class Point
	{
		/// <summary>
		/// Coordinates x, y, z, h
		/// </summary>
		public double[] Coordinates { get; set; }

		public Point(double[] coordinates)
		{
			if (coordinates.Length == 4)
				Coordinates = coordinates;
			else
				Coordinates = new[] { 0.0, 0.0, 0.0, 0.0 };
		}

		public void Normalization()
		{
			Coordinates[0] = Coordinates[0] / Coordinates[3];
			Coordinates[1] = Coordinates[1] / Coordinates[3];
			Coordinates[2] = Coordinates[2] / Coordinates[3];
			Coordinates[3] = 1.0;
		}
	}
}
