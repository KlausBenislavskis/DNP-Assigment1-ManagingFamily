using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Assingment1.Models;

namespace Assingment1.Models
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
            Children = new List<Child>();
            Pets = new List<Pet>();
        }

        public List<Person> GetPersons()
        {
            List<Person> list = new List<Person>(Adults);
            list.AddRange(Children);
            return list;
        }

        public string GetFamilyName()
        {
            if (Adults == null)
            {
                Adults = new List<Adult>();

            }

            if (Children == null)
            {
                Children = new List<Child>();
            }

            if (Pets == null)
            {
                Pets = new List<Pet>();
            }
            if (Adults.Any())
            {
                return Adults[0].LastName;
            }

            if (Children.Any())
            {
                return Children[0].LastName;
            }

            return "Not found";
        }
    }
}