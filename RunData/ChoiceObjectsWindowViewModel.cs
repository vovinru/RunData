using RunDataLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunData
{
    public class ChoiceObjectsWindowViewModel
    {
        public string Title
        {
            get;
            set;
        }

        public string FindText
        {
            get;
            set;
        }

        public List<Object> AllObjects
        {
            get
            {
                if (Type == typeof(City))
                {
                    return TrainingData.Cities.Cast<Object>().ToList();
                }
                if (Type == typeof(Place))
                {
                    return TrainingData.Places.Cast<Object>().ToList();
                }

                return new List<Object>();
            }
        }

        public Object SelectedAllObjects
        {
            get;
            set;
        }

        public bool IsEnabledChoice
        {
            get
            {
                if (IsOneSelected && ChoiceObjects.Count > 0)
                    return false;

                return true;
            }
        }

        /// <summary>
        /// Флаг того, что можно выбрать только один элемент
        /// </summary>
        public bool IsOneSelected
        {
            get
            {
                if (Type == typeof(City))
                {
                    return true;
                }
                if (Type == typeof(Place))
                {
                    return false;
                }

                return false;
            }
        }

        public List<Object> ChoiceObjects
        {
            get
            {
                if (Type == typeof(City))
                {
                    if (Training.City != null)
                        return new List<Object> { Training.City };
                }
                if (Type == typeof(Place))
                {
                    return Training.Places.Cast<Object>().ToList();
                }

                return new List<Object>();
            }
        }

        public Object SelectedChoiceObjects
        {
            get;
            set;
        }

        public Type Type
        {
            get;
            set;
        }

        public TrainingData TrainingData
        {
            get;
            set;
        }

        public Training Training
        {
            get;
            set;
        }

        public bool AddChoiceObject()
        {
            if (SelectedAllObjects == null)
                return false;

            if (Type == typeof(City))
                Training.City = (City)SelectedAllObjects;

            if (Type == typeof(Place))
                Training.Places.Add((Place)SelectedAllObjects);

            return true;
        }

        public bool DeleteSelectedAllObject()
        {
            if (SelectedAllObjects == null)
                return false;

            if (Type == typeof(City))
                TrainingData.DeleteCity((City)SelectedAllObjects);

            if (Type == typeof(Place))
                TrainingData.DeletePlace((Place)SelectedAllObjects);

            return true;
        }

        public bool DeleteSelectedTrainingObject()
        {
            if (SelectedChoiceObjects == null)
                return false;

            if (Type == typeof(City))
                Training.City = null;

            if (Type == typeof(Place))
                Training.Places.Remove((Place)SelectedAllObjects);

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="trainingData"></param>
        /// <param name="training"></param>
        /// <param name="type"></param>
        public ChoiceObjectsWindowViewModel(TrainingData trainingData, Training training, Type type)
        {
            Type = type;
            TrainingData = trainingData;
            Training = training;
        }
    }
}
