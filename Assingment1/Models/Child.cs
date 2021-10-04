using System.Collections.Generic;
using Assingment1.Models;

namespace Assingment1.Models {
public class Child : Person {
    
    public List<Interest> Interests { get; set; }
    public List<Adult> Pets { get; set; }
}
}