using System.Collections.Generic;
using DependencyInjectionConcept.Core.Interfaces;
using DependencyInjectionConcept.Core.Models;

namespace DependencyInjectionConcept.Services
{
    public class DataService : IDataService
    {
        public ICollection<Item> GetItems()
        {
            return new List<Item>
            {
                new(1, "Item 1"),
                new(2, "Item 2"),
                new(3, "Item 3"),
                new(4, "Item 4")
            };
        }
    }
}
