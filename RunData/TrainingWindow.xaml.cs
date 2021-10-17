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
    /// Логика взаимодействия для TrainingWindow.xaml
    /// </summary>
    public partial class TrainingWindow : Window
    {
        TrainingViewModel _viewModel;

        public void UpdateDataContext()
        {
            DataContext = null;
            DataContext = _viewModel;
        }

        public TrainingWindow(TrainingData trainingData, Training training)
        {
            InitializeComponent();

            _viewModel = new TrainingViewModel(trainingData, training);
            UpdateDataContext();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonCity_Click(object sender, RoutedEventArgs e)
        {
            ChoiceObjectsWindow window = new ChoiceObjectsWindow(_viewModel.TrainingData, _viewModel.Training, typeof(City));
            window.ShowDialog();
            UpdateDataContext();
        }

        private void buttonPlaces_Click(object sender, RoutedEventArgs e)
        {
            ChoiceObjectsWindow window = new ChoiceObjectsWindow(_viewModel.TrainingData, _viewModel.Training, typeof(Place));
            window.ShowDialog();
            UpdateDataContext();
        }
    }
}
