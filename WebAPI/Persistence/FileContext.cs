using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.DataAccess;
using WebAPI.Models;

namespace Persistence
{
    public class FileContext : IFamiliesData
    {
        public async Task<IList<Family>> GetFamilies()
        {
            using FamilyContext dbContext = new FamilyContext();

            return dbContext.Families.Include(d => d.Adults).Include(d => d.Pets).Include(d => d.Children).ToList();
        }


        public async Task<Adult> AddAdult(Adult adult, int familyId)
        {
            using FamilyContext dbContext = new FamilyContext();
            dbContext.Families.First(f => f.Id == familyId).Adults.Add(adult);
            await dbContext.SaveChangesAsync();
            return adult;
        }

        public async Task<Child> AddChild(Child child, int familyId)
        {
            using FamilyContext dbContext = new FamilyContext();
            dbContext.Families.First(f => f.Id == familyId).Children.Add(child);
            await dbContext.SaveChangesAsync();
            return child;
        }


        public async Task<Pet> AddPet(Pet pet, int familyId)
        {
            using FamilyContext dbContext = new FamilyContext();
            dbContext.Families.First(f => f.Id == familyId).Pets.Add(pet);
            Console.WriteLine(dbContext.Families.First(f => f.Id == familyId).Pets.Count() + " count");
            await dbContext.SaveChangesAsync();
            return pet;
        }

        public async Task<Family> AddFamily(Family family)
        {
            using FamilyContext dbContext = new FamilyContext();
            int max;
            if (dbContext.Families.Any())
            {
                max = dbContext.Families.Max(Family => Family.Id);
            }
            else
            {
                max = 1;
            }

            family.Id = (++max);
            await dbContext.Families.AddAsync(family);
            await dbContext.SaveChangesAsync();
            return family;
        }

        public async void RemoveFamily(int id)
        {
            using FamilyContext dbContext = new FamilyContext();
            Family toRemove = dbContext.Families.First(t => t.Id == id);
            dbContext.Families.Remove(toRemove);
            await dbContext.SaveChangesAsync();
        }

        public async void RemoveAdult(int familyId, string adultName)
        {
            using FamilyContext dbContext = new FamilyContext();

            Family family = dbContext.Families.Include(d => d.Adults).Include(d => d.Pets).Include(d => d.Children).First(t => t.Id == familyId);
            if (adultName == null)
            {
                family.Adults.Clear();
                return;
            }

            Adult toRemove = family.Adults.First(a => a.FirstName == adultName);
            dbContext.Families.Include(d => d.Adults).Include(d => d.Pets).Include(d => d.Children).First(t => t.Id == familyId).Adults.Remove(toRemove);
            await dbContext.SaveChangesAsync();
        }

        public async void RemoveChild(int familyId, string childName)
        {
            using FamilyContext dbContext = new FamilyContext();

            Family family = dbContext.Families.Include(d => d.Adults).Include(d => d.Pets).Include(d => d.Children).First(t => t.Id == familyId);
            Console.WriteLine(childName);
            Child toRemove = family.Children.First(a => a.FirstName == childName);
            dbContext.Families.Include(d => d.Adults).Include(d => d.Pets).Include(d => d.Children).First(t => t.Id == familyId).Children.Remove(toRemove);
            await dbContext.SaveChangesAsync();
        }

        public async void RemovePet(int familyId, string petName)
        {
            using FamilyContext dbContext = new FamilyContext();
            Family family = dbContext.Families.Include(d => d.Adults).Include(d => d.Pets).Include(d => d.Children).First(t => t.Id == familyId);
            Pet toRemove = family.Pets.First(a => a.Name == petName);
            dbContext.Families.Include(d => d.Adults).Include(d => d.Pets).Include(d => d.Children).First(t => t.Id == familyId).Pets.Remove(toRemove);
            await dbContext.SaveChangesAsync();
        }

        public IList<Child> GetAllChildren()
        {
            using FamilyContext dbContext = new FamilyContext();

            IList<Child> children = new List<Child>();
            foreach (var family in dbContext.Families)
            {
                foreach (var child in family.Children)
                {
                    children.Add(child);
                }
            }

            return children;
        }

        public IList<Adult> GetAllAdults()
        {
            using FamilyContext dbContext = new FamilyContext();


            IList<Adult> adults = new List<Adult>();
            foreach (var family in dbContext.Families)
            {
                foreach (var adult in family.Adults)
                {
                    adults.Add(adult);
                }
            }

            return adults;
        }


        public IList<Pet> GetAllPets()
        {
            using FamilyContext dbContext = new FamilyContext();

            IList<Pet> pets = new List<Pet>();
            foreach (var family in dbContext.Families)
            {
                foreach (var pet in family.Pets)
                {
                    pets.Add(pet);
                }
            }

            return pets;
        }
    }
}