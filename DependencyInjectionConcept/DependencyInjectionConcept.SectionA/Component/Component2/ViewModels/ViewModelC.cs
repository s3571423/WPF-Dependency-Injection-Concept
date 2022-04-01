using DependencyInjectionConcept.Core.Interfaces;
using DependencyInjectionConcept.Core.Models;
using DependencyInjectionConcept.Core.ViewModels;

namespace DependencyInjectionConcept.SectionA.Component.Component2.ViewModels
{
    public class ViewModelC : ViewModelBase
    {
        private readonly IDataService _dataService;

        public Item Item
        {
            get => GetValue<Item>();
            set => SetValue(value);
        }

        public ViewModelC(IDataService dataService, Item item) : base("Section A - Component 2 - ViewModel C")
        {
            _dataService = dataService;
            Item = item;
        }
    }
}
