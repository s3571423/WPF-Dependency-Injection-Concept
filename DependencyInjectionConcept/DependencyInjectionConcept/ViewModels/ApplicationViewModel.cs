using DependencyInjectionConcept.Core.Commands;
using DependencyInjectionConcept.Core.Interfaces;
using DependencyInjectionConcept.Core.ViewModels;
using DependencyInjectionConcept.SectionA.Component.Component1.ViewModels;

namespace DependencyInjectionConcept.ViewModels
{
    public class ApplicationViewModel : ViewModelBase
    {
        private readonly IInteractionService _interactionService;
        private readonly IViewModel<ViewModelA> _viewModelABuilder;

        public RelayCommand OpenViewModelCommand { get; }

        public ApplicationViewModel(
            IInteractionService interactionService,
            IViewModel<ViewModelA> viewModelABuilder) : base("WPF Dependency Injection Concept")
        {
            _interactionService = interactionService;
            _viewModelABuilder = viewModelABuilder;

            OpenViewModelCommand = new RelayCommand(OpenViewModel);
        }

        private void OpenViewModel()
        {
            _interactionService.ShowDialogWindow(_viewModelABuilder.Create());
        }
    }
}
