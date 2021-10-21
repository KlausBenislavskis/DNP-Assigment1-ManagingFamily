using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FamilyController : Controller
    {
        private IFamiliesData Data;

        public FamilyController(IFamiliesData familiesData)
        {
            Data = familiesData;
        }


        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<Family>>> Get([FromQuery] int? familyId)
        // {
        //     IList<Family> families;
        //     if (familyId != null)
        //     {
        //         families = new List<Family>() {(await Data.GetFamilies()).First(f => f.Id == familyId)};
        //     }
        //     else
        //     {
        //         families = await Data.GetFamilies();
        //     }
        //
        //     return Ok(families);
        // }
    }
}