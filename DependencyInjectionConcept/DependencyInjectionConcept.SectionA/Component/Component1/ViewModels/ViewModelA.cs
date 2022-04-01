using DependencyInjectionConcept.Core.Commands;
using DependencyInjectionConcept.Core.Interfaces;
using DependencyInjectionConcept.Core.ViewModels;
using DependencyInjectionConcept.SectionA.Component.Component2.ViewModels;

namespace DependencyInjectionConcept.SectionA.Component.Component1.ViewModels
{
    public class ViewModelA : ViewModelBase
    {
        private readonly IInteractionService _interactionService;
        private readonly IViewModel<ViewModelB> _viewModelBBuilder;

        public RelayCommand OpenViewModelCommand { get; }

        public ViewModelA(
            IInteractionService interactionService,
            IViewModel<ViewModelB> viewModelBBuilder) : base("Section A - Component 1 - ViewModel A")
        {
            _interactionService = interactionService;
            _viewModelBBuilder = viewModelBBuilder;

            OpenViewModelCommand = new RelayCommand(OpenViewModel);
        }

        private void OpenViewModel()
        {
            _interactionService.ShowDialogWindow(_viewModelBBuilder.Create());
        }
    }
}
