using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Family
    {
        [Key] public int Id { get; set; }

        public string StreetName { get; set; }
        public int HouseNumber { get; set; }
        [Required] public List<Adult> Adults { get; set; }
        [Required] public List<Child> Children { get; set; }
        [Required] public List<Pet> Pets { get; set; }

        public Family()
        {
            Adults = new List<Adult>();
            Children = new List<Child>();
            Pets = new List<Pet>();
        }
    }
}