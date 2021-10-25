﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Models;

namespace Persistence
{
    public class FileContext : IFamiliesData
    {
        public IList<Family> Families { get; private set; }
        public IList<Adult> Adults { get; private set; }

        private readonly string familiesFile = "families.json";
        private readonly string adultsFile = "adults.json";

        public FileContext()
        {
            Families = File.Exists(familiesFile) ? ReadData<Family>(familiesFile) : new List<Family>();
            Adults = File.Exists(adultsFile) ? ReadData<Adult>(adultsFile) : new List<Adult>();
        }

        private IList<T> ReadData<T>(string s)
        {
            using (var jsonReader = File.OpenText(familiesFile))
            {
                return JsonSerializer.Deserialize<List<T>>(jsonReader.ReadToEnd());
            }
        }

        public void SaveChanges()
        {
            // storing families
            string jsonFamilies = JsonSerializer.Serialize(Families, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            using (StreamWriter outputFile = new StreamWriter(familiesFile, false))
            {
                outputFile.Write(jsonFamilies);
            }

            // storing persons
            string jsonAdults = JsonSerializer.Serialize(Adults, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            using (StreamWriter outputFile = new StreamWriter(adultsFile, false))
            {
                outputFile.Write(jsonAdults);
            }
        }

        public async Task<IList<Family>> GetFamilies()
        {
            List<Family> tmp;
            if (Families == null)
            {
                tmp = new List<Family>();
            }
            else
            {
                tmp = new List<Family>(Families);
            }

            return tmp;
        }



        public async Task<Adult> AddAdult(Adult adult, int familyId)
        {
            Families.First(f => f.Id == familyId).Adults.Add(adult);
            SaveChanges();
            return adult;
        }

        public async Task<Child> AddChild(Child child, int familyId)
        {
            Families.First(f => f.Id == familyId).Children.Add(child);
            SaveChanges();
            return child;
        }


        public async Task<Pet> AddPet(Pet pet, int familyId)
        {
            Families.First(f => f.Id == familyId).Pets.Add(pet);
            SaveChanges();
            return pet;
        }

        public async Task<Family> AddFamily(Family family)
        {
            int max;
            if (Families.Count > 0)
            {
                max = Families.Max(Family => Family.Id);
            }
            else
            {
                max = 1;
            }

            family.Id = (++max);
            Families.Add(family);
            SaveChanges();
            return family;
        }

        public async void RemoveFamily(int? id)
        {
            if (id == null)
            {
                Families.Clear();
                return;
            }

            try
            {
                Family toRemove = Families.First(t => t.Id == id);
                Families.Remove(toRemove);
                SaveChanges();
            }catch (Exception)
            {
                
            }
        }

        public void RemoveAdult(int familyId, string adultName)
        {
            Family family = Families.First(t => t.Id == familyId);
            if (adultName == null)
            {
                family.Adults.Clear();
                return;
            }

            Adult toRemove = family.Adults.First(a => a.FirstName == adultName);
            family.Adults.Remove(toRemove);
            SaveChanges();
        }

        public void RemoveChild(int familyId, string childName)
        {
            Family family = Families.First(t => t.Id == familyId);
            Console.WriteLine(childName);
            Child toRemove = family.Children.First(a => a.FirstName == childName);
            family.Children.Remove(toRemove);
            SaveChanges();
        }

        public void RemovePet(int familyId, string petName)
        {
            Family family = Families.First(t => t.Id == familyId);
            Pet toRemove = family.Pets.First(a => a.Name == petName);
            family.Pets.Remove(toRemove);
            SaveChanges();
        }

        public IList<Child> GetAllChildren()
        {
            IList<Child> children = new List<Child>();
            foreach (var family in Families)
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
            IList<Adult> adults = new List<Adult>();
            foreach (var family in Families)
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
            IList<Pet> pets = new List<Pet>();
            foreach (var family in Families)
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