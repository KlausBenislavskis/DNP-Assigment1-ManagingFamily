using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Assingment1.Data;
using Assingment1.Models;

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

        public IList<Family> GetFamilies()
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

        public void AddAdult(Adult adult, int familyId)
        {
            Families.First(f => f.Id == familyId).Adults.Add(adult);

        }
        public void AddFamily(Family family)
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
        }

        public void RemoveFamily(int id)
        {
            Family toRemove = Families.First(t => t.Id == id);
            Families.Remove(toRemove);
            SaveChanges();
        }
    }
}