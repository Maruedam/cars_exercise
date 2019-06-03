using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1_cars.Model
{
   public class location
    {
        private double? latitude;
        private double? longitude;


        public double? Latitude
        {
            get
            {
                return latitude;
            }
            set
            {
                latitude = value;
            }
        }
        public double? Longitude
        {
            get
            {
                return longitude;
            }
            set
            {
                longitude = value;
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
