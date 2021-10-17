using RunDataLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunData
{
    class CityViewModel
    {
        public City City
        {
            get;
            set;
        }

        public string Name
        {
            get
            {
                return City.Name;
            }

            set
            {
                City.Name = value;
            }
        }

        public CityViewModel(City city)
        {
            City = city;
        }


    }
}
