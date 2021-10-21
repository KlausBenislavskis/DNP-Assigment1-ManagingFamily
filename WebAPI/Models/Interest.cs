using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models {
public class Interest {
    public string Type { get; set; }
    public string Description { get; set; }

}
}