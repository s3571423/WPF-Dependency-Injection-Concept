using DependencyInjectionConcept.SectionA.Component.Component1;
using DependencyInjectionConcept.SectionA.Component.Component2;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjectionConcept.SectionA.Services
{
    public static class SectionAServices
    {
        public static void RegisterSectionAServices(this ServiceCollection serviceCollection)
        {
            Component1Services.RegisterServices(serviceCollection);
            Component2Services.RegisterServices(serviceCollection);
        }
    }
}
