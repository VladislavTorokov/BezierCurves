using System;
using System.Collections.Generic;
using System.Text;

namespace ClassAndStructure
{
	public static class PointChanger
	{
		private static readonly int value = 1;

		public static double[] ChangePoints(double[] points)
		{
			if (points == null)
				return null;

			double[] result = new double[4];

			for (int i = 0; i < points.Length; i++)
			{
				result[i] += points[i] + value;
			}

			return result;
		}
	}
}
