using System;
using System.Collections.Generic;
using System.Text;

namespace ClassAndStructure
{
	public class ClassEdge
	{
		public ClassPoint PointStart { get; set; }
		public ClassPoint PointEnd { get; set; }
		public ClassEdge(ClassPoint start, ClassPoint end)
		{
			PointStart = start;
			PointEnd = end;
		}
	}
}
