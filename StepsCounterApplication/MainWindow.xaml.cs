using StepsCounterApplication.Model;
using StepsCounterApplication.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StepsCounterApplication
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataManagerClass MainClass = new DataManagerClass(30);
        public MainWindow()
        {
            InitializeComponent();
            MainClass.AddDataToGrid(ref GridTable);
            MainClass.DrawCoordsSystem(ref Plot);

        }


        private void Window_ContentRendered(object sender, EventArgs e)
        {
            MainClass.RecognizeTable(ref GridTable);
        }

        private void GridTable_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            try
            {
                MainClass.SelectBests((TableUserDataClass)e.Row.DataContext, ref e);
            }
            catch(Exception) { };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
             MainClass.SaveTableToFile();
        }

        private void GridTable_MouseUp(object sender, MouseButtonEventArgs e)
        {
            TableUserDataClass path = GridTable.SelectedItem as TableUserDataClass;
            if(path != null)
            MainClass.DrawPlotForUser(ref Plot, ref LabelSteps, ref LabelDays, path.User);
        }
    }
}