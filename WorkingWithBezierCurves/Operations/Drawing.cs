using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using WorkingWithBezierCurves.Objects;

namespace WorkingWithBezierCurves.Operations
{
    public class Drawing
    {
        public void Draw(Canvas picture, Base[] scenes, float x0, float y0)
        {
            if (scenes != null)
            {
                foreach (Base scene in scenes)
                {
                    for (int i = 0; i < scene.edges.Count; i++)
                        if ((scene.edges[i] != null) && (scene.edges[i]._points != null))
                        {
                            Line line = new Line() {
                                Stroke = Brushes.Black,
                                StrokeThickness = 2,
                                X1 = x0 + (float)scene.edges[i]._points[0].Coordinates[0],
                                Y1 = y0 + (float)scene.edges[i]._points[0].Coordinates[1],
                                X2 = x0 + (float)scene.edges[i]._points[1].Coordinates[0],
                                Y2 = y0 + (float)scene.edges[i]._points[1].Coordinates[1]
                        };
                            picture.Children.Add(line);
                        }
                }
            }
        }

        public void Clear(Canvas picture)
        {
           picture.Children.Clear();
        }
    }
}
