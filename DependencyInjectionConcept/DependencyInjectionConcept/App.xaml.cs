using System.Windows;
using DependencyInjectionConcept.Core.Interfaces;
using DependencyInjectionConcept.SectionA.Services;
using DependencyInjectionConcept.Services;
using DependencyInjectionConcept.ViewModels;
using DependencyInjectionConcept.Views;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjectionConcept
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public static ServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var serviceCollection = new ServiceCollection();

            serviceCollection.AddTransient<ApplicationViewModel>();
            serviceCollection.AddTransient<MainWindow>();

            serviceCollection.AddTransient<IInteractionService, InteractionService>();
            serviceCollection.AddTransient<IDataService, DataService>();

            serviceCollection.RegisterSectionAServices();

            ServiceProvider = serviceCollection.BuildServiceProvider(true);

            var mainWindow = ServiceProvider.GetService<MainWindow>();
            mainWindow?.Show();
        }
    }
}
