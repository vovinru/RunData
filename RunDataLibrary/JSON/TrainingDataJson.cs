using System;
using System.Collections.Generic;
using System.Text;

namespace RunDataLibrary.JSON
{
    public class TrainingDataJson
    { 
        public List<TrainingJson> Trainings
        {
            get;
            set;
        }

        public List<CityJson> Cities
        {
            get;
            set;
        }

        public List<PlaceJson> Places
        {
            get;
            set;
        }

        public TrainingDataJson()
        {
            Trainings = new List<TrainingJson>();
            Cities = new List<CityJson>();
            Places = new List<PlaceJson>();
        }
    }
}
