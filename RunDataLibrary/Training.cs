using System;
using System.Collections.Generic;
using System.Text;

namespace RunDataLibrary
{
    public class Training
    {
        public static int TRAINING_ID_NEXT = 1;

        public int TrainingId
        {
            get;
            set;
        }

        public DateTime Date
        {
            get;
            set;
        }

        public int LengthMeter
        {
            get;
            set;
        }

        public int TimeSecond
        {
            get;
            set;
        }

        public List<Place> Places
        {
            get;
            set;
        }

        public City City
        {
            get;
            set;
        }

        public bool Parkrun
        {
            get;
            set;
        }

        public bool Event
        {
            get;
            set;
        }

        public string EventName
        {
            get;
            set;
        }

        public Training()
        {
            TrainingId = TRAINING_ID_NEXT++;
            
            Places = new List<Place>();
            Date = DateTime.Now;
        }
    }
}
