using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RunDataLibrary;
using RunDataLibrary.JSON;

namespace RunData
{
    public class MainWindowViewModel
    {
        const string BASE_FILE_NAME = "RunData.json";

        #region propertyes

        public TrainingData TrainingData
        {
            get;
            set;
        }

        public List<TrainingViewModel> Trainings
        {
            get;
            set;
        }

        #endregion

        #region consructors

        public MainWindowViewModel()
        {
            if(File.Exists(BASE_FILE_NAME))
            {
                string json = string.Empty;
                using(StreamReader file = new StreamReader(BASE_FILE_NAME))
                {
                    json = file.ReadToEnd();
                }

                TrainingData = ParsingJson.ConvertJsonStringToTrainingData(json);
            }

            else
            {
                TrainingData = new TrainingData();
            }

            UpdateTrainings();
        }

        #endregion

        #region methods

        public void UpdateTrainings()
        {
            Trainings = new List<TrainingViewModel>();
            TrainingData.Trainings.ForEach(t => Trainings.Add(new TrainingViewModel(TrainingData, t)));
        }

        public void SaveTrainingData()
        {
            string str = ParsingJson.ConvertTrainingDataToJsonString(TrainingData);
            using(StreamWriter file = new StreamWriter(BASE_FILE_NAME))
            {
                file.Write(str);
            }
        }

        #endregion
    }
}
