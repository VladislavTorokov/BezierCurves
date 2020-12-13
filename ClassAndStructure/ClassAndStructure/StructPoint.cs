using System;
using System.Collections.Generic;
using System.Text;

namespace ClassAndStructure
{
	public struct StructPoint
	{
		public double[] Points { get; set; }

		public StructPoint(double[] points)
		{
			Points = points;
		}

		public void Print()
		{
			if (Points == null)
				return;

			Console.Write("StructPoint:");
			foreach (var point in Points)
			{
				Console.Write(" " + point);
			}
			Console.WriteLine();
		}
	}
}
