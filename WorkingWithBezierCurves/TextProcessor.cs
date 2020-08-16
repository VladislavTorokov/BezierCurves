using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkingWithBezierCurves.Objects;

namespace WorkingWithBezierCurves
{
    public class TextProcessor
    {
        private ComplexBuilder complexBuilder;

        public TextProcessor(string text)
        {
            complexBuilder = new ComplexBuilder();
            if (text != null)
            {
                // Обработка текста
                text = text.Replace('.', ',');       //точки меняем на запятые
                var str = text.Split('\n');          //Разделение по строкам

                int numberOfString = 0;
                while (numberOfString < str.Length)
                {
                    if ((str[numberOfString] == "Points\r") || (str[numberOfString] == "Points"))
                    {
                        var endPointsBlock = FindBlockEnd(str, numberOfString);
                        var beginPointsBlock = numberOfString + 1;
                        string[] pointsBlock = PartCopy(str, beginPointsBlock, endPointsBlock);
                        var beginLinesBlock = endPointsBlock + 1;

                        if ((str[beginLinesBlock] == "Lines\r") || (str[beginLinesBlock] == "Lines"))
                        {
                            var endLinesBlock = FindBlockEnd(str, beginLinesBlock);
                            string[] linesBlock = PartCopy(str, beginLinesBlock + 1, endLinesBlock);

                            complexBuilder.ReadCoordinates(pointsBlock, linesBlock);

                            numberOfString = endLinesBlock;
                        }
                    }

                    if ((str[numberOfString] == "ControlPoints\r") || (str[numberOfString] == "ControlPoints"))
                    {
                        var endPointsBlock = FindBlockEnd(str, numberOfString);

                        TransferBlock<BezierCurve>(str, numberOfString + 1, endPointsBlock);

                        numberOfString = endPointsBlock;
                    }

                    if ((str[numberOfString] == "Surface\r") || (str[numberOfString] == "Surface"))
                    {
                        var endPointsBlock = FindBlockEnd(str, numberOfString);

                        TransferBlock<Surface>(str, numberOfString + 1, endPointsBlock);

                        numberOfString = endPointsBlock;
                    }
                    numberOfString++;
                }
            }
        }

        private void TransferBlock<T>(string[] stringFile, int begin, int end)
        {
            string[] pointsBlock = PartCopy(stringFile, begin, end);

            complexBuilder.ReadCoordinates<T>(pointsBlock);
        }

        private int FindBlockEnd(string[] block, int begin)
        {
            for (int i = begin; i < block.Length; i++)
            {
                if ((block[i] == "End\r") || (block[i] == "End") || (block[i] == "end") || (block[i] == "end\r"))
                    return i;
            }
            throw new Exception("не найден End для блока " + block[0]);
        }

        private string[] PartCopy(string[] text, int begin, int end)
        {
            int textLength = end - begin;
            string[] copy = new string[textLength];

            for (int i = 0; i < textLength; i++)
            {
                copy[i] = text[i + begin];
            }
            return copy;
        }

        public Complex GetComplex()
        {
            return complexBuilder.GetComplex();
        }
    }
}
