using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkingWithBezierCurves.Objects;

namespace WorkingWithBezierCurves.Operations
{
    public class Inscription
    {
        private readonly List<Base> roots;
        private readonly double width;
        private readonly double height;
        private double Xmax;
        private double Xmin;
        private double Ymax;
        private double Ymin;
        private double lengthX;
        private double lengthY;

        public Inscription(double width, double height, Complex complex)
        {
            this.width = width;
            this.height = height;

            if (complex != null)
            {
                roots = new List<Base>();
                roots.AddRange(complex.scenes);
                roots.AddRange(complex.bezierCurves);
                roots.AddRange(complex.surfaces);

                DoOperation(complex);
            }
        }

        private void DoOperation(Complex complex)
        {
            if (roots.Count > 0)
            {
                FindExtremePoints();
                CalculateLengthXY();
                var scalingCoefficient = GetScalingCoef();

                // Выравнивание
                var valueTransfer = new double[] { -Xmin, -Ymin, 0 };
                ParallelTransfer parallelTransfer = new ParallelTransfer(valueTransfer, complex);

                // Масштабирование
                Scaling scaling = new Scaling(scalingCoefficient, complex);
            }
        }

        //Находим максимальные и минимальные точки объектов по осям Х и Y
        private void FindExtremePoints()
        {
            Xmin = roots.Min(root => root.points.Min(point => point.Coordinates[0]));
            Xmax = roots.Max(root => root.points.Max(point => point.Coordinates[0]));
            Ymin = roots.Min(root => root.points.Min(point => point.Coordinates[1]));
            Ymax = roots.Max(root => root.points.Max(point => point.Coordinates[1]));
        }

        //Получаем максимальные длины объекта по осям Х и Y
        private void CalculateLengthXY()
        {
            lengthX = Xmax - Xmin;
            lengthY = Ymax - Ymin;
        }

        //Возвращаем масштабный коэффициент в зависимости от соотношения длин объекта по осям и габаритов picturebox
        private double GetScalingCoef()
        {
            if (width / lengthX < height / lengthY)
                return width / lengthX;
            else
                return height / lengthY;
        }
    }
}
