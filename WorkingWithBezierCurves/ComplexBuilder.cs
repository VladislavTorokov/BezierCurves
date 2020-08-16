using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkingWithBezierCurves.Objects;

namespace WorkingWithBezierCurves
{
    public class ComplexBuilder
    {
        private Complex complex;

        public void ReadCoordinates(string[] pointsBlock, string[] linesBlock)
        {
            complex = new Complex();
            Scene scene;
            if ((pointsBlock.Length != 0) && (linesBlock.Length != 0))
                scene = new Scene();
            else
                throw new Exception();

            if (scene != null)
            {
                //Считывание координат точек
                for (int i = 0; i < pointsBlock.Length; i++)
                {
                    scene.points.Add(new Point());
                    scene.points.Last().Coordinates = pointsBlock[i].Split(' ').Select(n => double.Parse(n)).ToArray();
                }

                // Создание ребер
                var edgePoints = new int[linesBlock.Length, 2];
                int[][] arrayPoints = new int[linesBlock.Length][];
                for (int i = 0; i < linesBlock.Length; i++)
                    arrayPoints[i] = linesBlock[i].Split(' ').Select(n => int.Parse(n) - 1).ToArray();
                //Наполняем ребра точками
                scene.AddPoints(arrayPoints);
                complex.scenes.Add(scene);
            }
        }

        public void ReadCoordinates<T>(string[] pointsBlock)
        {
            complex = new Complex();

            int multiplicity;

            if (typeof(T).Equals(typeof(BezierCurve)))
            {
                multiplicity = 4;
            }
            else if (typeof(T).Equals(typeof(Surface)))
            {
                multiplicity = 16;
            }
            else
            {
                throw new Exception();
            }
            //Считывание координат точек

            Point[] points = GetNewArray(multiplicity);

            int i = 0;
            while (i < pointsBlock.Length)
            {
                points[i % multiplicity].Coordinates = pointsBlock[i].Split(' ').Select(n => double.Parse(n)).ToArray();

                if ((i + 1) % multiplicity == 0)
                {
                    if (multiplicity == 4)
                    {
                        var bezierCurve = new BezierCurve();
                        bezierCurve.SetPoints(points);
                        complex.bezierCurves.Add(bezierCurve);
                    }
                    else
                    {
                        var surface = new Surface();
                        surface.SetPoints(points);
                        complex.surfaces.Add(surface);
                    }
                    points = GetNewArray(multiplicity);
                }
                i++;
            }
        }

        private Point[] GetNewArray(int multiplicity)
        {
            var points = new Point[multiplicity];
            for (int j = 0; j < points.Length; j++)
                points[j] = new Point();
            return points;
        }

        public Complex GetComplex()
        {
            return complex;
        }
    }
}
