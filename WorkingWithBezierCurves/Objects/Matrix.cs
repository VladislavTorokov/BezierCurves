using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithBezierCurves.Objects
{
    public class Matrix
    {
        public double[,] elements { get; }

        public Matrix()
        {
            elements = new double[4, 4];
            for (int j = 0; j < 4; j++)
                for (int i = 0; i < 4; i++)
                {
                    if (i == j)
                        elements[i, j] = 1;
                }
        }

        public double[] GetMultiplication(double[] matrix)
        {
            double[] resultMatrix = new double[4];

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                    resultMatrix[i] += matrix[j] * elements[j, i];
            }
            return resultMatrix;
        }
    }
}
