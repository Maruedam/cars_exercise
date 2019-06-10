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
        public List<car> car_List2;//en esta lista vamos a cargar loseementos seleccionaddos del listbox1
        public List<int> enumerador1; //lista auxiliar a car_list para saber el id de cada elemento.      

        public MainWindow()
        {
            InitializeComponent();

            string outputJSON = File.ReadAllText("Cars.json"); //aqui leemos el json
            car_List = JsonConvert.DeserializeObject<List<car>>(outputJSON); //dserializamos el json en car_list.

            //iniccializamos la lista
            enumerador1 = new List<int>();
            car_List2 = new List<car>();
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
           
            comboBox1.Items.Insert(0, "No selected");
            comboBox2.Items.Insert(0, "No selected");
            comboBox3.Items.Insert(0, "No selected");
            comboBox4.Items.Insert(0, "No selected");
            comboBox5.Items.Insert(0, "No selected");
            comboBox6.Items.Insert(0, "No selected");


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
            
            foreach (var item in car_List)
            {
                if (comboBox2.SelectedItem.ToString() == item.Model )
                {
                    listBox1.Items.Add(item);
                }
               
            }
        }

        private void ComboBox3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listBox1.Items.Clear();
          
            foreach (var item in car_List)
            {
                if (comboBox3.SelectedItem.ToString() == item.Color && comboBox1.SelectedItem.ToString() == item.Maker && comboBox2.SelectedItem.ToString() == item.Model)
                {
                    listBox1.Items.Add(item);
                }
              
            }
        }

        private void ComboBox4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listBox2.Items.Clear();


            foreach (var item in car_List2)
            {
                if (comboBox4.SelectedItem.ToString() == item.Maker)
                {
                    listBox2.Items.Add(item);
                }

            }
        }

        private void ComboBox5_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listBox2.Items.Clear();


            foreach (var item in car_List2)
            {
                if (comboBox5.SelectedItem.ToString() == item.Model)
                {
                    listBox2.Items.Add(item);
                }

            }
        }

        private void ComboBox6_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listBox2.Items.Clear();

            foreach (var item in car_List2)
            {
                if (comboBox6.SelectedItem.ToString() == item.Color)
                {
                    listBox2.Items.Add(item);
                }

            }

        }

        public void actualizarCombobox()                                                                   //Metodo para actualizar los combobox de la zona Derecha
        {
            comboBox4.Items.Clear();
            comboBox5.Items.Clear();
            comboBox6.Items.Clear();

            IEnumerable<String> busmaker2 = BusCombobox(car_List2, "Maker");
            IEnumerable<String> busmodelo2 = BusCombobox(car_List2, "Model");
            IEnumerable<String> buscolor2 = BusCombobox(car_List2, "Color");
            foreach (var item in busmaker2)
            {
                comboBox4.Items.Add(item);
            }

            foreach (var item in busmodelo2)
            {
                comboBox5.Items.Add(item);

            }

            foreach (var item in buscolor2)
            {
                comboBox6.Items.Add(item);

            }
            listBox2.Items.Clear();
            foreach (car item in car_List2)
            {
                listBox2.Items.Add(item.ToString());
            }

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            car c = (car)listBox1.SelectedItem;
            Boolean confirmacion = false;
            IEnumerable<int> res = from o in car_List2 where o.ToString().Equals(listBox1.SelectedItem.ToString()) select 1;

            foreach (int u in res)
            {
                if (u == 1)
                {
                    MessageBox.Show("Este coche ya esta en la tabla");
                    confirmacion = true;
                }
                else
                {
                    confirmacion = false;
                }
            }

            if (confirmacion == false)
                car_List2.Add(c);


            actualizarCombobox();

        }

       

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           listafinal x = new listafinal(car_List2);
           x.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (listBox2.SelectedItem==null)
            {
                MessageBox.Show("No hay un coche seleccionado");
            }
            else
            {
                for (int i = 0; i < car_List2.Count; i++)
                {
                    if (car_List2[i].ToString().Equals(listBox2.SelectedItem.ToString()))
                    {
                        car_List2.RemoveAt(i);
                    }
                }
            }
            actualizarCombobox();
        }
    }
    }
