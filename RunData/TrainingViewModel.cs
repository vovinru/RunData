using RunDataLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunData
{
    public class TrainingViewModel
    {
        #region propertyes

        public Training Training
        {
            get;
            set;
        }

        public TrainingData TrainingData
        {
            get;
            set;
        }

        public DateTime Date
        {
            get
            {
                return Training.Date;
            }
            set
            {
                Training.Date = value;
            }
        }

        public string DateString
        {
            get
            {
                return Training.Date.ToString("dd.mm.yyyy");
            }
        }

        public string City
        {
            get
            {
                if (Training.City == null)
                    return string.Empty;
                return Training.City.ToString();
            }
        }

        public string Places
        {
            get
            {
                string places = string.Empty;
                foreach (Place place in Training.Places)
                    places += string.Format("{0}; ", place.ToString());

                return places;
            }
        }

        public string LengthKilometer
        {
            get
            {
                return ((float)Training.LengthMeter / 1000).ToString();
            }
            set
            {
                float result = 0;
                if(float.TryParse(value, out result))
                {
                    Training.LengthMeter = Convert.ToInt32(result * 1000);
                }
            }
        }

        public string Time
        {
            get
            {
                return ConvertTimeSecondToTimeString(Training.TimeSecond);
            }
            set
            {
                string[] strs = value.Split(':');

                if(strs.Length <= 3)
                {
                    int result = 0;
                    int resultCurrent = 0;
                    foreach(string str in strs)
                    {
                        if (Int32.TryParse(str, out resultCurrent))
                        {
                            result *= 60;
                            result += resultCurrent;
                        }
                        else
                            return;
                    }
                    Training.TimeSecond = result;
                }
            }
        }

        public string TimeKm
        {
            get
            {
                int timeSecond = 0;
                if (Training.TimeSecond > 0)
                    timeSecond = Training.TimeSecond * 1000 / Training.LengthMeter;
                return ConvertTimeSecondToTimeString(timeSecond);
            }
        }

        public bool Parkrun
        {
            get
            {
                return Training.Parkrun;
            }
            set
            {
                Training.Parkrun = value;
            }
        }

        public bool Event
        {
            get
            {
                return Training.Event;
            }
            set
            {
                Training.Event = value;
            }
        }

        public string EventName
        {
            get
            {
                return Training.EventName;
            }
            set
            {
                Training.EventName = value;
            }
        }

        #endregion

        #region constructors

        public TrainingViewModel (TrainingData trainingData, Training training)
        {
            Training = training;
            TrainingData = trainingData;
        }

        #endregion

        #region methods

        public string ConvertTimeSecondToTimeString(int timeSecond)
        {
            int hour = timeSecond / 3600;
            int minute = timeSecond % 3600 / 60;
            int second = timeSecond % 60;

            string time = string.Empty;

            if (hour > 0)
            {
                time += string.Format("{0}:", hour);
            }

            if (minute < 10)
                time += "0";

            time += string.Format("{0}:", minute);

            if (second < 10)
                time += "0";

            time += second.ToString();

            return time;
        }

        #endregion

    }
}
