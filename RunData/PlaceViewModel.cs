using RunDataLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunData
{
    public class PlaceViewModel
    {
        public Place Place
        {
            get;
            set;
        }

        public TrainingData TrainingData
        {
            get;
            set;
        }

        public City City
        {
            get
            {
                return Place.City;
            }
            set
            {
                Place.City = value;
            }
        }

        public List<City> Cities
        {
            get
            {
                return TrainingData.Cities;
            }
        }

        public string Name
        {
            get
            {
                return Place.Name;
            }
            set
            {
                Place.Name = value;
            }
        }

        public PlaceViewModel(Place place, TrainingData trainingData)
        {
            Place = place;
            TrainingData = trainingData;
        }
    }
}
