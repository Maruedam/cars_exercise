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
        public List<car> car_list2;  //esta lista la usaremos para el istbox de la derecha
        public List<int> enumerador1; //lista auxiliar a car_list para saber el id de cada elemento.      

        public MainWindow()
        {
            InitializeComponent();

            string outputJSON = File.ReadAllText("Cars.json"); //aqui leemos el json
            car_List = JsonConvert.DeserializeObject<List<car>>(outputJSON); //dserializamos el json en car_list.

            //iniccializamos las otras dos listas
            car_list2 = new List<car>();
            enumerador1 = new List<int>();

            //añadimos la posicion no seleccted
            car_list2.Add(car_List[0]);
            
            //mostramos la lista en el listbox1
            foreach (var item in car_List)
            {
                listBox1.Items.Add(item);
            }

            //creamos un String por cada seccion del json a dividir(maker, model, color)
            IEnumerable<String> busmaker1 = BusCombobox(car_List, "Maker");
            IEnumerable<String> busmodelo1 = BusCombobox(car_List, "Model");
            IEnumerable<String> buscolor1 = BusCombobox(car_List, "Color");

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

        private void filtra_lista(object sender, EventArgs e)
        {
           // listBox1.Items.Clear();
          //  enumerador1.Clear();

            IEnumerable<car> resultadof;
            resultadof = car_List.Where(x => x.Maker == comboBox1.Text && x.Model == comboBox2.Text && x.Color == comboBox3.Text).ToList();
           

            //mostramos la lista filtrada en listbx
            foreach (car resultado in resultadof)
            {
                if (resultado.Id != 0)
                {
                    listBox1.Items.Add(resultado.Maker + " " + resultado.Model + " " + resultado.Color + " " + resultado.Year);
                    enumerador1.Add(resultado.Id);
                }
                 
            }
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
           
        }
    }
}
