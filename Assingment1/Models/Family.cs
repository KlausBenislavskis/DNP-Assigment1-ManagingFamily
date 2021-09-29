using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Assingment1.Models;

namespace Assingment1.Models {
public class Family {
    
    public int Id { get; set; }
    public string StreetName { get; set; }
    public int HouseNumber{ get; set; }
    public List<Adult> Adults { get; set; }
    public List<Child> Children{ get; set; }
    public List<Pet> Pets{ get; set; }

    public Family() {
        Adults = new List<Adult>();     
    }

    public List<Person> GetPersons()
    {
        List<Person> list = new List<Person>(Adults);
        list.AddRange(Children);
        return list;
    }
}


}