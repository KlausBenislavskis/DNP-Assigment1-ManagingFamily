using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Models {
public class Child : Person {
    
    public List<Interest> Interests { get; set; }
    public List<Adult> Pets { get; set; }
}
}