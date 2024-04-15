using Practika.Practika1DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace Practika
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
           DistrictTableAdapter context = new DistrictTableAdapter();
        public Window1()
        {
            InitializeComponent();
            DistrictGrid.ItemsSource = context.GetData();
        }

        //добавить
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            context.InsertQuery1(Txt.Text, Convert.ToInt32(Txt2.Text));
            DistrictGrid.ItemsSource = context.GetData();
        }

        //удалить
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            object id = (DistrictGrid.SelectedItem as DataRowView).Row[0];
            context.DeleteQuery(Convert.ToInt32(id));
            DistrictGrid.ItemsSource = context.GetData();
        }

        //изменить
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            object id = (DistrictGrid.SelectedItem as DataRowView).Row[0];
            context.UpdateQuery(Txt.Text, Convert.ToInt32(id));
            DistrictGrid.ItemsSource = context.GetData();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            Close();
        }

       
    }
}
