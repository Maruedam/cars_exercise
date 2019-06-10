using Exercise1_cars.Model;
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
using System.Windows.Shapes;

namespace Exercise1_cars
{
    /// <summary>
    /// Lógica de interacción para listafinal.xaml
    /// </summary>
    public partial class listafinal : Window
    {
        List<car> listfin;
        public listafinal(List<car> car_List2)
        {
            InitializeComponent();

            listfin = car_List2;
        }

      
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in listfin)
            {
                listBox1.Items.Add(item.ToString());
            }
        }
    }
}
