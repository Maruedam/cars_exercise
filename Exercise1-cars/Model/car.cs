using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1_cars.Model
{
    public class car
    {
        private int id;
        private string maker;
        private string model;
        private int? year;
        private string color;
        private location location;
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public string Maker
        {
            get
            {
                return maker;
            }
            set
            {
                maker = value;
            }
        }

        public string Model
        {
            get
            {
                return model;
            }
            set
            {
                model = value;
            }
        }
        public int? Year
        {
            get
            {
                return year;
            }
            set
            {
                year = value;
            }
        }
        public string Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }
        public location Location
        {
            get
            {
                return location;
            }
            set
            {
                location = value;
            }
        }
        public car()
        {

        }



        public override string ToString()
        {
            return Maker + " " + model + " " + Color + " " + Year;
        }
    }
}
