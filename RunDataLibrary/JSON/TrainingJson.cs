using System;
using System.Collections.Generic;
using System.Text;

namespace RunDataLibrary.JSON
{
    public class TrainingJson
    {
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

        public List<int> PlaceIds
        {
            get;
            set;
        }

        public int CityId
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

        public TrainingJson()
        {
            PlaceIds = new List<int>();
        }
    }
}
