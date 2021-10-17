using RunDataLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RunData
{
    /// <summary>
    /// Логика взаимодействия для ChoiceObjectsWindow.xaml
    /// </summary>
    public partial class ChoiceObjectsWindow : Window
    {
        ChoiceObjectsWindowViewModel _viewModel;

        public void UpdateDataContect()
        {
            DataContext = null;
            DataContext = _viewModel;
        }

        public ChoiceObjectsWindow(TrainingData trainingData, Training training, Type type)
        {
            InitializeComponent();
            _viewModel = new ChoiceObjectsWindowViewModel(trainingData, training, type);

            UpdateDataContect();
        }

        private void ButtonChoice_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.AddChoiceObject())
                UpdateDataContect();
        }

        private void ButtonNew_Click(object sender, RoutedEventArgs e)
        {
            if(_viewModel.Type == typeof(City))
            {
                City city = new City();
                _viewModel.TrainingData.Cities.Add(city);
                CityWindow window = new CityWindow(city);
                window.ShowDialog();
            }

            if(_viewModel.Type == typeof(Place))
            {
                Place place = new Place();
                _viewModel.TrainingData.Places.Add(place);
                PlaceWindow window = new PlaceWindow(place, _viewModel.TrainingData);
                window.ShowDialog();
            }

            UpdateDataContect();
        }

        private void ButtonChange_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.SelectedAllObjects == null)
                return;

            if (_viewModel.Type == typeof(City))
            {
                City city = (City)_viewModel.SelectedAllObjects;
                CityWindow window = new CityWindow(city);
                window.ShowDialog();
            }

            if (_viewModel.Type == typeof(Place))
            {
                Place place = (Place)_viewModel.SelectedAllObjects;
                PlaceWindow window = new PlaceWindow(place, _viewModel.TrainingData);
                window.ShowDialog();
            }

            UpdateDataContect();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.DeleteSelectedAllObject())
                UpdateDataContect();
        }

        private void ButtonDeleteSelectedObject_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.DeleteSelectedTrainingObject())
                UpdateDataContect();
        }
    }
}
