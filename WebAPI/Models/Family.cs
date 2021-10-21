
using System.Collections.Generic;

namespace WebAPI.Models
{
    public class Family
    {
        public int Id { get; set; }
        public string StreetName { get; set; }
        public int HouseNumber { get; set; }
        public List<Adult> Adults { get; set; }
        public List<Child> Children { get; set; }
        public List<Pet> Pets { get; set; }

        public string FamilyName
        {
            get => GetFamilyName();
        }

        public Family()
        {
            Adults = new List<Adult>();
        }

        public List<Person> GetPersons()
        {
            List<Person> list = new List<Person>(Adults);
            list.AddRange(Children);
            return list;
        }

        public string GetFamilyName()
        {
            if (Adults.Count > 0)
            {
                return Adults[0].LastName;
            }

            if (Children.Count > 0)
            {
                return Children[0].LastName;
            }

            return "Not found";
        }
    }
}