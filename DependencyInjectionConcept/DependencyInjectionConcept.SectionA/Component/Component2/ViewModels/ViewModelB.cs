using System.Linq;
using System.Windows.Input;
using DependencyInjectionConcept.Core.Commands;
using DependencyInjectionConcept.Core.Interfaces;
using DependencyInjectionConcept.Core.Models;
using DependencyInjectionConcept.Core.ViewModels;

namespace DependencyInjectionConcept.SectionA.Component.Component2.ViewModels
{
    public class ViewModelB : ViewModelBase
    {
        private readonly IInteractionService _interactionService;
        private readonly IDataService _dataService;
        private readonly IViewModel<ViewModelC, Item> _viewModelCBuilder;

        private int _itemIndex;

        public ICommand OpenItemCommand { get; }

        public ViewModelB(IInteractionService interactionService, IDataService dataService,
            IViewModel<ViewModelC, Item> viewModelCBuilder) : base("Section A - Component 2 - ViewModel B")
        {
            _interactionService = interactionService;
            _dataService = dataService;
            _viewModelCBuilder = viewModelCBuilder;

            OpenItemCommand = new RelayCommand(OpenItem);
        }

        private void OpenItem()
        {
            if (_itemIndex >= _dataService.GetItems().Count)
            {
                _itemIndex = 0;
            }

            var viewModel = _viewModelCBuilder.Create(_dataService.GetItems().ElementAt(_itemIndex++));
            _interactionService.ShowWindow(viewModel);
        }
    }
}
