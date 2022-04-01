using System.Collections.Generic;
using DependencyInjectionConcept.Core.Models;

namespace DependencyInjectionConcept.Core.Interfaces
{
    public interface IDataService
    {
        ICollection<Item> GetItems();
    }
}
