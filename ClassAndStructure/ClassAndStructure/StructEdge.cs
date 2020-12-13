using System;
using System.Collections.Generic;
using System.Text;

namespace ClassAndStructure
{
	public class StructEdge
	{
		public StructPoint PointStart { get; set; }
		public StructPoint PointEnd { get; set; }

		public StructEdge(StructPoint start, StructPoint end)
		{
			PointStart = start;
			PointEnd = end;
		}
	}
}
