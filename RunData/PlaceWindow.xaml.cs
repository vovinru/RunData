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
    /// Логика взаимодействия для PlaceWindow.xaml
    /// </summary>
    public partial class PlaceWindow : Window
    {
        PlaceViewModel _viewModel;

        public void UpdateDataContext()
        {
            DataContext = null;
            DataContext = _viewModel;
        }

        public PlaceWindow(Place place, TrainingData trainingData)
        {
            InitializeComponent();
            _viewModel = new PlaceViewModel(place, trainingData);
            UpdateDataContext();
        }
    }
}
