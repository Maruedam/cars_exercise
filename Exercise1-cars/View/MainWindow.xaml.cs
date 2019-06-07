using Exercise1_cars.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Exercise1_cars
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public List<car> car_List;//en esta lista vamos a cargar el json.
        public List<int> enumerador1; //lista auxiliar a car_list para saber el id de cada elemento.      

        public MainWindow()
        {
            InitializeComponent();

            string outputJSON = File.ReadAllText("Cars.json"); //aqui leemos el json
            car_List = JsonConvert.DeserializeObject<List<car>>(outputJSON); //dserializamos el json en car_list.

            //iniccializamos la lista
            enumerador1 = new List<int>();
            
            //mostramos la lista en el listbox1
            foreach (var item in car_List)
            {
                listBox1.Items.Add(item);

            }

            //creamos un String por cada seccion del json a dividir(maker, model, color)
            IEnumerable<String> busmaker1 = BusCombobox(car_List, "Maker");
            IEnumerable<String> busmodelo1 = BusCombobox(car_List, "Model");
            IEnumerable<String> buscolor1 = BusCombobox(car_List, "Color");

            //introducir las secciones en los combobox(metodo abajo)
            NewMethod(busmaker1, busmodelo1, buscolor1);
          
        }

        private void NewMethod(IEnumerable<string> busmaker1, IEnumerable<string> busmodelo1, IEnumerable<string> buscolor1)
        {
            //introducir las secciones en los combobox
            foreach (var item in busmaker1)
            {
                comboBox1.Items.Add(item);
            }

            foreach (var item in busmodelo1)
            {
                comboBox2.Items.Add(item);

            }

            foreach (var item in buscolor1)
            {
                comboBox3.Items.Add(item);

            }
        }

        //metodo para introducir cada campo en su coleccion
        public IEnumerable<String> BusCombobox(List<car> ccar, String TipoMostrar)                             
        {
            IEnumerable<String> resultado;
            if (TipoMostrar.Equals("Color"))
            {
                resultado = ccar.Where(x => x.Color != null).Select(x => x.Color).Distinct().ToList();
            }
            else if (TipoMostrar.Equals("Maker"))
            {
                resultado = ccar.Where(x => x.Maker != null).Select(x => x.Maker).Distinct().ToList();
            }
            else
            {
                resultado = ccar.Where(x => x.Model != null).Select(x => x.Model).Distinct().ToList();
            }

            return resultado;
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
           
        }

        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listBox1.Items.Clear();
            // MessageBox.Show(comboBox1.SelectedItem.ToString());
            
            foreach (var item in car_List)
            {
                if (comboBox1.SelectedItem.ToString() ==item.Maker)
                {
                   listBox1.Items.Add(item);
                }
               
            }
           
        }

        private void ComboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listBox1.Items.Clear();
            // MessageBox.Show(comboBox1.SelectedItem.ToString());
            
            foreach (var item in car_List)
            {
                if (comboBox1.SelectedItem.ToString() == item.Maker && comboBox2.SelectedItem.ToString() == item.Model )
                {
                    listBox1.Items.Add(item);
                }
               
            }
        }

        private void ComboBox3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listBox1.Items.Clear();
            // MessageBox.Show(comboBox1.SelectedItem.ToString());
          
            foreach (var item in car_List)
            {
                if (comboBox3.SelectedItem.ToString() == item.Color && comboBox1.SelectedItem.ToString() == item.Maker && comboBox2.SelectedItem.ToString() == item.Model)
                {
                    listBox1.Items.Add(item);
                }
              
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            listBox2.Items.Add(listBox1.SelectedItem);

            foreach (var item in  listBox2.Items)
            {
                if (listBox1.SelectedItem.ToString() != item)
                {
                  listBox2.Items.Add(listBox1.SelectedItem);
                }
                else
                {
                    MessageBox.Show("El coche ya esta en la lista");
                }
            }

        }
    }
}
