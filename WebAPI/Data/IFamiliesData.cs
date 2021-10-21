using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Data
{
    public interface IFamiliesData
    {
        void SaveChanges();
        Task<IList<Family>>  GetFamilies();
        void AddFamily(Family family);
        void RemoveFamily(int id);
        void AddAdult(Adult adult, int familyId);
        void AddChild(Child child, int familyId);
        void AddPet(Pet pet, int familyId);
        void RemoveAdult(int familyId, string adultName);
        void RemoveChild(int familyId, string childName);
        void RemovePet(int familyId, string petName);
        IList<Child> GetAllChildren();
        IList<Adult> GetAllAdults();
        IList<Pet> GetAllPets();


    }
}