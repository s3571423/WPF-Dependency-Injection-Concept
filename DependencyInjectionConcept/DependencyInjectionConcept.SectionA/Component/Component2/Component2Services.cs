using System;
using DependencyInjectionConcept.Core.Interfaces;
using DependencyInjectionConcept.Core.Models;
using DependencyInjectionConcept.SectionA.Component.Component2.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjectionConcept.SectionA.Component.Component2
{
    public class Component2Services :
        IViewModel<ViewModelB>,
        IViewModel<ViewModelC, Item>
    {
        private readonly IInteractionService _interactionService;
        private readonly IDataService _dataService;
        private readonly IServiceProvider _serviceProvider;

        public static void RegisterServices(ServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IViewModel<ViewModelB>, Component2Services>();
            serviceCollection.AddSingleton<IViewModel<ViewModelC, Item>, Component2Services>();
        }

        public Component2Services(
            IServiceProvider serviceProvider,
            IInteractionService interactionService,
            IDataService dataService)
        {
            _interactionService = interactionService;
            _dataService = dataService;
            _serviceProvider = serviceProvider;
        }

        ViewModelB IViewModel<ViewModelB>.Create()
        {
            return new ViewModelB(_interactionService, _dataService, _serviceProvider.GetRequiredService<IViewModel<ViewModelC, Item>>());
        }

        ViewModelC IViewModel<ViewModelC, Item>.Create(Item parameter)
        {
            return new ViewModelC(_dataService, parameter);
        }
    }
}
