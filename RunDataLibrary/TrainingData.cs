using System;
using System.Collections.Generic;
using System.Text;

namespace RunDataLibrary
{
    public class TrainingData
    {
        public List<Training> Trainings
        {
            get;
            set;
        }

        public List<City> Cities
        {
            get;
            set;
        }

        public List<Place> Places
        {
            get;
            set;
        }

        public City GetCity(int cityId)
        {
            return Cities.Find(c => c.CityId == cityId);
        }

        public Place GetPlace(int placeId)
        {
            return Places.Find(p => p.PlaceId == placeId);
        }

        public void DeleteCity(City city)
        {
            Cities.Remove(city);

            foreach(Training t in Trainings)
            {
                if (t.City == city)
                    t.City = null;
            }

            foreach(Place p in Places)
            {
                if (p.City == city)
                    p.City = null;
            }
        }

        public void DeletePlace(Place place)
        {
            Places.Remove(place);
            Trainings.ForEach(t => t.Places.Remove(place));
        }

        public TrainingData()
        {
            Trainings = new List<Training>();
            Places = new List<Place>();
            Cities = new List<City>();
        }
    }
}
