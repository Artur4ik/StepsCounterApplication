using StepsCounterApplication.Model;
using StepsCounterApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace StepsCounterApplication.ViewModel
{
    internal class DataManagerClass
    {
        private StepsDataClass Data;

        public DataManagerClass(int days)
        {
            Data = new StepsDataClass(days);
        }
        public void AddDataToGrid(ref DataGrid gr)
        {
            gr.ItemsSource = Data.GetTableData(); 
        }
        public void RecognizeTable(ref DataGrid gr)
        {
            gr.Columns.RemoveAt(1);
            gr.Columns.RemoveAt(1);
            gr.Columns[0].Header = "Фамилия и имя";
            gr.Columns[1].Header = "Шаги (среднее)";
            gr.Columns[2].Header = "Шаги (лучшее)";
            gr.Columns[3].Header = "Шаги (худшее)";
        }
        
        public void SelectBests(TableUserDataClass person, ref DataGridRowEventArgs e)
        {
            e.Row.Background = new SolidColorBrush(Colors.White);
            if ((double)person.StepsAvg / person.StepsBest < 0.8) e.Row.Background = new SolidColorBrush(Colors.Green);
            if ((double)person.StepsWorse / person.StepsAvg < 0.8) e.Row.Background = new SolidColorBrush(Colors.Red);
            if (((double)person.StepsWorse / person.StepsAvg < 0.8) && ((double)person.StepsAvg / person.StepsBest < 0.8)) e.Row.Background = new SolidColorBrush(Colors.Yellow);
        }
        public void DrawCoordsSystem(ref Canvas plot)
        {
            plot.Children.Clear();
            DrawLine(0, 0, 0, 300, Brushes.Black, 2, ref plot);
            DrawLine(0, 300, 5, 295, Brushes.Black, 2, ref plot);
            DrawLine(0, 0, 300, 0, Brushes.Black, 2, ref plot);
            DrawLine(300, 0, 295, 5, Brushes.Black, 2, ref plot);
        }
        public void DrawPlotForUser(ref Canvas plot, ref Label LabelSteps, ref Label LabelDays, string user)
        {
            DrawCoordsSystem(ref plot);
            List<(int, int)> points = Data.GetDataForPlot(user);
            int max = 0, min = 2147483647;
            for(int i = 0; i<points.Count; i++)
            {
                if(points[i].Item2 > max) max = points[i].Item2;
                if(points[i].Item2 < min) min = points[i].Item2;
            }
            LabelSteps.Content = max.ToString();
            LabelDays.Content = (30).ToString();
            for(int i = 1; i<points.Count; i++)
            {
                if(points[i].Item2 == max)
                {
                    DrawLine(points[i].Item1-2, (points[i].Item2 * 300) / max, points[i].Item1+2, (points[i].Item2 * 300) / max, Brushes.Green, 4, ref plot);
                }
                if (points[i].Item2 == min)
                {
                    DrawLine(points[i].Item1 - 2, (points[i].Item2 * 300) / max, points[i].Item1 + 2, (points[i].Item2 * 300) / max, Brushes.Red, 4, ref plot);
                }

                DrawLine(points[i - 1].Item1, (points[i - 1].Item2 * 300) / max, points[i].Item1, (points[i].Item2 * 300) / max, Brushes.Black, 1, ref plot);
            }

        }

        public void DrawLine(int x1, int y1, int x2, int y2, Brush color, int thickness, ref Canvas plot)
        {
            Line line = new Line();
            line.Stroke = color;
            line.X1 = x1; line.Y1 = 300 - y1;
            line.X2 = x2; line.Y2 = 300 - y2;
            line.StrokeThickness = thickness;
            plot.Children.Add(line);
        }
        public void SaveTableToFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Файл JSON|*.json";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
                IODataClass.WriteDataToFile(saveFileDialog.FileName, Data.GetTableData());
        }

    }
}
