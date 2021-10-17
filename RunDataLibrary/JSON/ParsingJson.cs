using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RunDataLibrary.JSON
{
    public static class ParsingJson
    {
        #region ToJson

        public static TrainingDataJson ConvertTrainingDataToTrainingDataJson(TrainingData trainingData)
        {
            TrainingDataJson trainingDataJson = new TrainingDataJson();

            foreach (City city in trainingData.Cities)
                trainingDataJson.Cities.Add(ConvertCityToCityJson(city));

            foreach (Place place in trainingData.Places)
                trainingDataJson.Places.Add(ConvertPlaceToPlaceJson(place));

            foreach (Training training in trainingData.Trainings)
                trainingDataJson.Trainings.Add(ConvertTrainingToTrainingJson(training));

            return trainingDataJson;
        }

        public static CityJson ConvertCityToCityJson(City city)
        {
            CityJson cityJson = new CityJson();

            cityJson.CityId = city.CityId;
            cityJson.Name = city.Name;

            return cityJson;
        }

        public static PlaceJson ConvertPlaceToPlaceJson(Place place)
        {
            PlaceJson placeJson = new PlaceJson();

            placeJson.PlaceId = place.PlaceId;
            placeJson.Name = place.Name;
            placeJson.CityId = place.City.CityId;

            return placeJson;
        }

        public static TrainingJson ConvertTrainingToTrainingJson(Training training)
        {
            TrainingJson trainingJson = new TrainingJson();

            trainingJson.TrainingId = training.TrainingId;
            trainingJson.Date = training.Date;
            trainingJson.Event = training.Event;
            trainingJson.EventName = training.EventName;
            trainingJson.Parkrun = training.Parkrun;
            trainingJson.CityId = training.City.CityId;

            training.Places.ForEach(p => trainingJson.PlaceIds.Add(p.PlaceId));

            return trainingJson;
        }

        public static TrainingDataJson ConvertJsonStringToTrainingDataJson(string json)
        {
            TrainingDataJson trainingDataJson = JsonConvert.DeserializeObject<TrainingDataJson>(json);

            return trainingDataJson;
        }

        public static string ConvertTrainingDataToJsonString(TrainingData trainingData)
        {
            TrainingDataJson trainingDataJson = ConvertTrainingDataToTrainingDataJson(trainingData);
            string json = JsonConvert.SerializeObject(trainingDataJson);
            return json;
        }

        #endregion

        #region ToDynamic

        public static TrainingData ConvertTrainingDataJsonToTrainingData(TrainingDataJson trainingDataJson)
        {
            TrainingData trainingData = new TrainingData();

            if (trainingDataJson.Cities != null)
            {
                foreach (CityJson cityJson in trainingDataJson.Cities)
                    trainingData.Cities.Add(ConvertCityJsonToCity(cityJson, trainingData));
            }

            if (trainingDataJson.Places != null)
            {
                foreach (PlaceJson placeJson in trainingDataJson.Places)
                    trainingData.Places.Add(ConvertPlaceJsonToPlace(placeJson, trainingData));
            }

            if (trainingDataJson.Trainings != null)
            {
                foreach (TrainingJson training in trainingDataJson.Trainings)
                    trainingData.Trainings.Add(ConvertTrainingJsonToTraining(training, trainingData));
            }

            return trainingData;
        }

        public static City ConvertCityJsonToCity(CityJson cityJson, TrainingData trainingData)
        {
            City city = new City();

            city.CityId = cityJson.CityId;
            city.Name = cityJson.Name;

            return city;
        }

        public static Place ConvertPlaceJsonToPlace(PlaceJson placeJson, TrainingData trainingData)
        {
            Place place = new Place();

            place.PlaceId = placeJson.PlaceId;
            place.Name = placeJson.Name;
            place.City = trainingData.GetCity(placeJson.CityId);

            return place;
        }

        public static Training ConvertTrainingJsonToTraining(TrainingJson trainingJson, TrainingData trainingData)
        {
            Training training = new Training();

            training.TrainingId = trainingJson.TrainingId;
            training.Date = trainingJson.Date;
            training.Event = trainingJson.Event;
            training.EventName = trainingJson.EventName;
            training.Parkrun = trainingJson.Parkrun;
            training.City = trainingData.GetCity(trainingJson.CityId);

            trainingJson.PlaceIds.ForEach(p => training.Places.Add(trainingData.GetPlace(p)));

            return training;
        }

        public static TrainingData ConvertJsonStringToTrainingData(string json)
        {
            TrainingDataJson trainingDataJson = ConvertJsonStringToTrainingDataJson(json);
            TrainingData trainingData = ConvertTrainingDataJsonToTrainingData(trainingDataJson);

            return trainingData;
        }


        #endregion
    }
}
