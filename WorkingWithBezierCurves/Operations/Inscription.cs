using System.Linq;
using WorkingWithBezierCurves.Objects;

namespace WorkingWithBezierCurves.Operations
{
    public class Inscription
    {
        private Base[] _roots;
        private double _width;
        private double _height;
        private double _xMax;
        private double _xMin;
        private double _yMax;
        private double _yMin;
        private double _lengthX;
        private double _lengthY;

        public void Execute(double width, double height, Base[] roots)
        {
            _width = width;
            _height = height;

            if (roots == null)
                return;

            roots.Select(r => r != null && r.Points != null);
            _roots = roots;

            if (_roots.Length < 1)
				return;

			FindExtremePoints();
			GetLengthByAxes();
			var scalingCoefficient = GetScalingСoefficient();

			var valueTransfer = new double[] { -_xMin, -_yMin, 0 };
			foreach (var scene in roots)
			{
                // Выравнивание
                new ParallelTransfer().Execute(valueTransfer, scene.Points);

				// Масштабирование
				new Scaling().Execute(scalingCoefficient, scene.Points);
			}
		}

		//Находим максимальные и минимальные точки объектов по осям Х и Y
		private void FindExtremePoints()
        {
            _xMin = _roots.Min(root => root.Points.Min(point => point.Coordinates[0]));
            _xMax = _roots.Max(root => root.Points.Max(point => point.Coordinates[0]));
            _yMin = _roots.Min(root => root.Points.Min(point => point.Coordinates[1]));
            _yMax = _roots.Max(root => root.Points.Max(point => point.Coordinates[1]));
        }

        //Получаем максимальные длины объекта по осям Х и Y
        private void GetLengthByAxes()
        {
            _lengthX = _xMax - _xMin;
            _lengthY = _yMax - _yMin;
        }

        //Возвращаем масштабный коэффициент в зависимости от соотношения длин объекта по осям и габаритов picturebox
        private double GetScalingСoefficient()
        {
            var xRatio = _width / _lengthX;
            var yRatio = _height / _lengthY;
            return (xRatio < yRatio) ? xRatio : yRatio;
        }
    }
}
