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
using Practika.Practika1DataSetTableAdapters;

namespace Practika
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        private Practika1Entities context = new Practika1Entities();
        public MainWindow()
        {
            InitializeComponent();

            HouseGrid.ItemsSource = context.houses.ToList();
        }

        //добавить
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            houses h = new houses();
            h.NameHouse = Txt.Text;
            context.houses.Add(h);
            context.SaveChanges();
            HouseGrid.ItemsSource = context.houses.ToList();
        }

        //удалить
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (HouseGrid.SelectedItem != null)
            {
                context.houses.Remove(HouseGrid.SelectedItem as houses);
                context.SaveChanges();
                HouseGrid.ItemsSource = context.houses.ToList();
            }
        }

        //изменить
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (HouseGrid.SelectedItem != null)
            {
                var selected = HouseGrid.SelectedItem as houses;
                selected.NameHouse = Txt.Text;
                context.SaveChanges();
                HouseGrid.ItemsSource = context.houses.ToList() ;
            }
        }

        private void HouseGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (HouseGrid.SelectedItem != null)
            {
                var selected = HouseGrid.SelectedItem as houses;
                Txt.Text = selected.NameHouse;
               
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Window1 window = new Window1();
            window.Show();
            Close();
        }
    }
}
