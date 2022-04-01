using System;
using DependencyInjectionConcept.Core.Interfaces;
using DependencyInjectionConcept.SectionA.Component.Component1.ViewModels;
using DependencyInjectionConcept.SectionA.Component.Component2.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjectionConcept.SectionA.Component.Component1
{
    public class Component1Services :
        IViewModel<ViewModelA>
    {
        private readonly IInteractionService _interactionService;
        private readonly IDataService _dataService;
        private readonly IServiceProvider _serviceProvider;

        public static void RegisterServices(ServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IViewModel<ViewModelA>, Component1Services>();
        }

        public Component1Services(
            IServiceProvider serviceProvider,
            IInteractionService interactionService,
            IDataService dataService)
        {
            _interactionService = interactionService;
            _dataService = dataService;
            _serviceProvider = serviceProvider;
        }

        ViewModelA IViewModel<ViewModelA>.Create()
        {
            return new ViewModelA(_interactionService, _serviceProvider.GetRequiredService<IViewModel<ViewModelB>>());
        }
    }
}
