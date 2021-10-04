using System.Collections.Generic;
using Assingment1.Pages;
using Assingment1.Models;
using Assingment1.Pages.Fam;
using Adults = Assingment1.Pages.Fam.Adults;
using Pet = Assingment1.Models.Pet;

namespace Assingment1.Data
{
    public interface IFamiliesData
    {
        void SaveChanges();
        IList<Family> GetFamilies();
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