namespace WorkingWithBezierCurves.Objects
{
    public class Matrix
    {
        /// <summary>
        /// Matrix elements
        /// </summary>
        public double[,] Elements { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Matrix()
        {
            Elements = new double[4, 4];
            for (int j = 0; j < 4; j++)
                for (int i = 0; i < 4; i++)
                {
                    if (i == j)
                        Elements[i, j] = 1;
                }
        }

        /// <summary>
        /// multiplication of inner matrix by <paramref name="matrix"/>
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public double[] Multiply(double[] matrix)
        {
            double[] resultMatrix = new double[4];

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                    resultMatrix[i] += matrix[j] * Elements[j, i];
            }
            return resultMatrix;
        }
    }
}
