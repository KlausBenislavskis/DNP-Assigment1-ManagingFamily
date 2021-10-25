using System;
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


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Family>>> Get([FromQuery] int? familyId)
        {
            IList<Family> families;
            if (familyId != null)
            {
                families = new List<Family>() {(await Data.GetFamilies()).First(f => f.Id == familyId)};
            }
            else
            {
                Console.WriteLine("here");
                families = await Data.GetFamilies();
                Console.WriteLine("here2");
            }

            return Ok(families);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Family>>> Post([FromBody] Family family)
        {
            try
            {
                Family added = await Data.AddFamily(family);
                return Created($"/{added.Id}", added);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(505, e.Message);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {

                Data.RemoveFamily(id);
                return Ok();
            

        }
    }
}