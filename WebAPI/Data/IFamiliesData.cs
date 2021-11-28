using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Data
{
    public interface IFamiliesData
    {
        Task<IList<Family>> GetFamilies();
        Task<Family> AddFamily(Family family);
        void RemoveFamily(int id);
        Task<Adult> AddAdult(Adult adult, int familyId);
        Task<Child> AddChild(Child child, int familyId);
        Task<Pet> AddPet(Pet pet, int familyId);
        void RemoveAdult(int familyId, string? adultName);
        void RemoveChild(int familyId, string childName);
        void RemovePet(int familyId, string petName);
        IList<Child> GetAllChildren();
        IList<Adult> GetAllAdults();
        IList<Pet> GetAllPets();


    }
}