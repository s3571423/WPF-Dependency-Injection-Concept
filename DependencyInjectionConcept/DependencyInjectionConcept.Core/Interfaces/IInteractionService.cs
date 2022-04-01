using DependencyInjectionConcept.Core.ViewModels;

namespace DependencyInjectionConcept.Core.Interfaces
{
    public interface IInteractionService
    {
        bool ShowDialogWindow(ViewModelBase viewModel);

        void ShowWindow(ViewModelBase viewModel);
    }
}
