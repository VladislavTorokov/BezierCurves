using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WorkingWithBezierCurves.Objects;
using System.IO;
using WorkingWithBezierCurves.Operations;

namespace WorkingWithBezierCurves
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Complex complex;
        Operations.Drawing drawing;
        float x0, y0;

        public MainWindow()
        {
            InitializeComponent();

            //picture = new Drawing();
            complex = new Complex();
            drawing = new Operations.Drawing();
            x0 = 0;
            y0 = 0;
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            if (picture.ActualWidth != 0 && picture.ActualHeight != 0)
            {
                x0 = (float)picture.ActualWidth / 2;
                y0 = (float)picture.ActualHeight / 2;
            }

            OpenFileDialog openFile = new OpenFileDialog();
            bool? result = openFile.ShowDialog();
            if (result == true)
            {
                // Считываение текста
                string text = File.ReadAllText(openFile.FileName);

                // Обработка текста и передача координат
                TextProcessor textProcessor = new TextProcessor(text);
                complex = textProcessor.GetComplex();

                if (complex.bezierCurves != null)
                {
                    SetAccuracy();
                }

                if (complex.surfaces != null)
                {
                    SetParametersUV();
                }

                DrawPicture();
            }
        }

        private void ParallelTransfer_Click(object sender, RoutedEventArgs e)
        {
            var valueXYZ = new double[3];
            valueXYZ[0] = double.Parse(textBoxPTX.Text);
            valueXYZ[1] = double.Parse(textBoxPTY.Text);
            valueXYZ[2] = double.Parse(textBoxPTZ.Text);

            ParallelTransfer parallelTransfer = new ParallelTransfer(valueXYZ, complex);

            DrawPicture();
        }


        private void Rotate_Click(object sender, RoutedEventArgs e)
        {
            var angle = double.Parse(tbAngleRotate.Text) * Math.PI / 180;
            
            var radioButtons = listBoxRotate.Children.OfType<RadioButton>();
            foreach (var radioButton in radioButtons)
            {
                if (radioButton.IsChecked ?? false)
                {
                    var index = radioButtons.ToList().IndexOf(radioButton);

                    Operations.Rotation rotation = new Operations.Rotation(index, angle, complex);
                }
            }

            DrawPicture();
        }

        private void ProjectiveTransformation_Click(object sender, RoutedEventArgs e)
        {
            var radioButtons = listBoxProjectiveTransformation.Children.OfType<RadioButton>();
            foreach (var radioButton in radioButtons)
            {
                if (radioButton.IsChecked ?? false)
                {
                    var index = radioButtons.ToList().IndexOf(radioButton);

                    var coefficient = double.Parse(tbFocusDistance.Text);

                    ProjectiveTransformation projectiveTransformation = new ProjectiveTransformation(index, coefficient, complex);
                }
            }

            DrawPicture();
        }

        private void ObliqueShift_Click(object sender, RoutedEventArgs e)
        {
            var radioButtons = listBoxObliqueShift.Children.OfType<RadioButton>();
            foreach (var radioButton in radioButtons)
            {
                if (radioButton.IsChecked ?? false)
                {
                    var index = radioButtons.ToList().IndexOf(radioButton);

                    var coefficient = double.Parse(tbObliqueShiftCoefficient.Text);

                    ObliqueShift obliqueShift = new ObliqueShift(index, coefficient, complex);
                }
            }

            DrawPicture();
        }

        private void Scaling_Click(object sender, RoutedEventArgs e)
        {
            var valueScaling = double.Parse(tbCoefficientScaling.Text);

            Scaling scaling = new Scaling(valueScaling, complex);

            DrawPicture();
        }

        private void Inscription_Click(object sender, RoutedEventArgs e)
        {
            x0 = 0;
            y0 = 0;
            if (picture.ActualWidth != 0 && picture.ActualHeight != 0)
            {
                var width = picture.ActualWidth;
                var height = picture.ActualHeight;

                Inscription inscription = new Inscription(width, height, complex);
            }

            DrawPicture();
        }

        private void DrawPicture()
        {

            drawing.Clear(picture);

            drawing.Draw(picture, complex.scenes.ToArray(), x0, y0);
            drawing.Draw(picture, complex.bezierCurves.ToArray(), x0, y0);
            drawing.Draw(picture, complex.surfaces.ToArray(), x0, y0);
        }

        private void SetAccuracy()
        {
            if (textBoxT.Text == "")
                MessageBox.Show("Введите параметр t");
            else
            {
                var accuracy = int.Parse(textBoxT.Text);

                foreach (BezierCurve bezierCurve in complex.bezierCurves)
                    bezierCurve.SetAccuracy(accuracy);
            }
        }

        private void SetParametersUV()
        {
            if ((textBoxU.Text == "") || (textBoxV.Text == ""))
                MessageBox.Show("Введите параметры u и v");
            else
            {
                int parameterU = int.Parse(textBoxU.Text);
                int parameterV = int.Parse(textBoxV.Text);

                foreach (Surface surface in complex.surfaces)
                    surface.SetParameters(parameterU, parameterV);
            }
        }
    }
}
