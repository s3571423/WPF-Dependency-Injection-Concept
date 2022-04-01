using DependencyInjectionConcept.Core.Interfaces;
using DependencyInjectionConcept.Core.ViewModels;
using DependencyInjectionConcept.Views;

namespace DependencyInjectionConcept.Services
{
    public class InteractionService : IInteractionService
    {
        public bool ShowDialogWindow(ViewModelBase viewModel)
        {
            var response = new DialogWindow
            {
                DataContext = viewModel
            }.ShowDialog();

            return response == true;
        }

        public void ShowWindow(ViewModelBase viewModel)
        {
            new DialogWindow
            {
                DataContext = viewModel
            }.Show();
        }
    }
}
