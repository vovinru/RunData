using RunDataLibrary;
using RunDataLibrary.JSON;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RunData
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();

            _viewModel = new MainWindowViewModel();
            UpdateDataContext();
        }

        public void UpdateDataContext()
        {
            DataContext = null;
            DataContext = _viewModel;
        }

        private void buttonAddTraining_Click(object sender, RoutedEventArgs e)
        {
            Training training = new Training();
            _viewModel.TrainingData.Trainings.Add(training);

            TrainingWindow window = new TrainingWindow(_viewModel.TrainingData, training);
            window.ShowDialog();

            _viewModel.UpdateTrainings();
            UpdateDataContext();
        }

        private void buttonChangeTraining_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonDeleteTraining_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.SaveTrainingData();

        }
    }
}
