using System.Linq;

namespace WorkingWithBezierCurves
{
	public class TextProcessor
	{
		#region data
		private readonly string[] _pointData;
		private const string _endBlock = "End";
		#endregion data

		public TextProcessor(string pointData)
		{
			if (pointData == null)
				return;

			pointData = pointData.Replace('.', ',');	 //точки меняем на запятые
			_pointData = pointData.Split('\n');			 //Разделение по строкам
		}

		public bool CheckBlockExists(string BlockName)
		{
			return _pointData.Any(s => s.Contains(BlockName));
		}

		public double[][] ReadDataFromBlock(string BlockName)
		{
			var blockBoundaries = FindBlockBoundaries(BlockName);

			if (blockBoundaries == null || blockBoundaries.Length != 2)
				return null;

			var begin = blockBoundaries[0];
			var end = blockBoundaries[1];
			var coordinates = new double[end - begin][];

			for (int i = begin; i < end; i++)
			{
				coordinates[i-begin] = _pointData[i].Split(' ').Select(n => double.Parse(n)).ToArray();
			}

			return coordinates;
		}

		private int[] FindBlockBoundaries(string BlockName)
		{
			var beginBlock = Enumerable.Range(0, _pointData.Length).FirstOrDefault(j => _pointData[j].Contains(BlockName)) + 1;
			if (beginBlock == default)
				return null;
			var endBlock = Enumerable.Range(beginBlock, _pointData.Length).FirstOrDefault(j => _pointData[j].Contains(_endBlock));
			if (endBlock == default)
				return null;

			return new[] { beginBlock, endBlock };
		}
	}
}
