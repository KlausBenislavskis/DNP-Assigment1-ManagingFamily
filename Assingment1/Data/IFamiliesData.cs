using System.Collections.Generic;
using System.Threading.Tasks;
using Assingment1.Models;

namespace Assingment1.Data
{
    public interface IFamiliesData
    {
        Task<IList<Family>>  GetFamilies();
        Task<Family> GetFamily(string id);

        Task<Family> AddFamily(Family family);
        void RemoveFamily(int? id);
        Task<Adult> AddAdult(Adult adult, int familyId);
        Task<Child> AddChild(Child child, int familyId);
        Task<Pet> AddPet(Pet pet, int familyId);
        void RemoveAdult(int familyId, string? adultName);
        void RemoveChild(int familyId, string childName);
        void RemovePet(int familyId, string petName);
        Task<IList<Child>> GetAllChildren();
        Task<IList<Adult>> GetAllAdults();
        Task<IList<Pet>> GetAllPets();


    }
}