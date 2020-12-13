using Microsoft.Win32;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WorkingWithBezierCurves.Objects;
using System.IO;
using WorkingWithBezierCurves.Operations;
using System.Collections.Generic;

namespace WorkingWithBezierCurves
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		readonly Drawing drawing = new Drawing();
		readonly Scaling scaling = new Scaling();
		readonly Rotation rotation = new Rotation();
		readonly Inscription inscription = new Inscription();
		readonly ObliqueShift obliqueShift = new ObliqueShift();
		readonly ParallelTransfer parallelTransfer = new ParallelTransfer();
		readonly ProjectiveTransformation projectiveTransformation = new ProjectiveTransformation();
		Scene scene;
		BezierCurve bezierCurve;
		Surface surface;
		Base[] _objects;
		float x0, y0;

		public MainWindow()
		{
			InitializeComponent();

			//picture = new Drawing();
			drawing = new Drawing();
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
			if (result != true)
				MessageBox.Show("не удалось открыть файл", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);

			scene = null;
			bezierCurve = null;
			surface = null;
			_objects = null;
			// Считываение текста
			string text = File.ReadAllText(openFile.FileName);

			// Обработка текста и передача координат
			TextProcessor textProcessor = new TextProcessor(text);


			var objects = new List<Base>();

			if (textProcessor.CheckBlockExists(Scene.BlockName))
			{
				scene = new Scene();
				scene.SetPoints(textProcessor.ReadDataFromBlock("Points"));
				scene.SetEdges(textProcessor.ReadDataFromBlock("Lines"));
				objects.Add(scene);
			}
			if(textProcessor.CheckBlockExists(BezierCurve.BlockName))
			{
				bezierCurve = new BezierCurve();
				bezierCurve.SetControlPoints(textProcessor.ReadDataFromBlock("BezierCurves"));
				var parameterT = CheckParameter(textBoxT.Text);
				bezierCurve.SetAccuracy(parameterT);
				objects.Add(bezierCurve);
			}
			if (textProcessor.CheckBlockExists(Surface.BlockName))
			{
				surface = new Surface();
				surface.SetControlPoints(textProcessor.ReadDataFromBlock("Surfaces"));
				var parameterU = CheckParameter(textBoxU.Text);
				var parameterV = CheckParameter(textBoxV.Text);
				surface.SetParameters(parameterU, parameterV);
				objects.Add(surface);
			}

			if (objects.Count < 1)
				return;

			_objects = objects.ToArray();

			DrawPicture();
		}

		private void ParallelTransfer_Click(object sender, RoutedEventArgs e)
		{
			var valueXYZ = new double[3];
			valueXYZ[0] = double.Parse(textBoxPTX.Text);
			valueXYZ[1] = double.Parse(textBoxPTY.Text);
			valueXYZ[2] = double.Parse(textBoxPTZ.Text);

			foreach (var root in _objects)
			{
				parallelTransfer.Execute(valueXYZ, root.Points);
			}

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

					foreach (var root in _objects)
					{
						rotation.Execute(index, angle, root.Points);
					}
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

					foreach (var root in _objects)
					{
						projectiveTransformation.Execute(index, coefficient, root.Points);
					}
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

					foreach (var root in _objects)
					{
						obliqueShift.Execute(index, coefficient, root.Points);
					}
				}
			}

			DrawPicture();
		}

		private void Scaling_Click(object sender, RoutedEventArgs e)
		{
			var valueScaling = double.Parse(tbCoefficientScaling.Text);

			foreach (var root in _objects)
			{
				scaling.Execute(valueScaling, root.Points);
			}

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

				inscription.Execute(width, height, _objects);
			}

			DrawPicture();
		}

		private void DrawPicture()
		{
			picture.Children.Clear();

			drawing.Draw(picture, _objects, x0, y0);
		}

		private int CheckParameter(string parameter)
		{
			var result = int.TryParse(parameter, out var value);

			if (!result)
				MessageBox.Show("введите параметры U и V", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);

			return value;
		}
	}
}
