using System.Windows;
using DependencyInjectionConcept.ViewModels;

namespace DependencyInjectionConcept.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(ApplicationViewModel viewModel)
        {
            InitializeComponent();

            DataContext = viewModel;
        }
    }
}
