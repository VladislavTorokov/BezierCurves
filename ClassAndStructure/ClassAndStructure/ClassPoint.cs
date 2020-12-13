using System;
using System.Collections.Generic;
using System.Text;

namespace ClassAndStructure
{
	public class ClassPoint
	{
		public double[] Points { get; set; }

		public ClassPoint(double[] points)
		{
			Points = points;
		}

		public void Print()
		{
			if (Points == null)
				return;

			Console.Write("ClassPoint:");
			foreach (var point in Points)
			{
				Console.Write(" " + point);
			}
			Console.WriteLine();
		}
	}
}
