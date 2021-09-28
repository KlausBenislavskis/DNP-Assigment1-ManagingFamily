using System.Collections.Generic;
using Assingment1.Pages;
using Models;

namespace Assingment1.Data
{
    public interface IFamiliesData
    {
        void SaveChanges();
        IList<Family> GetFamilies();
        void AddFamily(Family family);
        void RemoveFamily(int id);
    }
}