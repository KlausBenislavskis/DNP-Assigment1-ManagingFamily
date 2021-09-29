using System.Collections.Generic;
using Assingment1.Pages;
using Assingment1.Models;

namespace Assingment1.Data
{
    public interface IFamiliesData
    {
        void SaveChanges();
        IList<Family> GetFamilies();
        void AddFamily(Family family);
        void RemoveFamily(int id);
        void AddAdult(Adult adult, int familyId);
    }
}