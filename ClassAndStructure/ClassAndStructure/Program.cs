using System;

namespace ClassAndStructure
{
	class Program
	{
		static void Main(string[] args)
		{
			ClassPoint classPointStart = new ClassPoint(new[] { 1.0, 2, 3, 4 });
			ClassPoint classPointEnd = new ClassPoint(new[] { 10.0, 11, 12, 13 });
			ClassEdge classEdge = new ClassEdge(classPointStart,classPointEnd);
			classEdge.PointStart.Print();
			classEdge.PointEnd.Print();


			StructPoint structPointStart = new StructPoint(new[] { 1.0, 2, 3, 4 });
			StructPoint structPointEnd = new StructPoint(new[] { 10.0, 11, 12, 13 });
			StructEdge structEdge = new StructEdge(structPointStart, structPointEnd);
			structEdge.PointStart.Print();
			structEdge.PointEnd.Print();

			classEdge.PointStart.Points = PointChanger.ChangePoints(classEdge.PointStart.Points);
			classEdge.PointEnd.Points = PointChanger.ChangePoints(classEdge.PointEnd.Points);
			structEdge.PointStart.Points = PointChanger.ChangePoints(structEdge.PointStart.Points);
			structEdge.PointEnd.Points = PointChanger.ChangePoints(structEdge.PointEnd.Points);

			classEdge.PointStart.Print();
			classEdge.PointEnd.Print();
			structEdge.PointStart.Print();
			structEdge.PointEnd.Print();
		}
	}
}
