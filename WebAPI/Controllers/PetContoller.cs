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
    [Route("Family/{familyId:int}/[controller]")]
    public class PetController : Controller
    {
        private IFamiliesData Data;

        public PetController(IFamiliesData familiesData)
        {
            Data = familiesData;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pet>>> Get([FromQuery] string name, [FromRoute] int familyId)
        {
            Console.WriteLine("Recieved");
            Family family = (await Data.GetFamilies()).First(f => f.Id == familyId);

            IList<Pet> pet;
            if (name != null)
            {
                pet = new List<Pet>() {family.Pets.First(a => a.Name == name)};
            }
            else
            {
                pet = family.Pets;
            }

            return Ok(pet);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Pet>>> Post([FromBody] Pet pet, [FromRoute] int familyId)
        {
            try
            {
                Pet added = await Data.AddPet(pet, familyId);
                return Created($"/{added.Id}", added);
            }
            catch (Exception e)
            {
                return StatusCode(505, e.Message);
            }
        }
        [HttpDelete]
        [Route("{petName}")]
        public async Task<ActionResult> Delete([FromRoute] string petName, [FromRoute] int familyId)
        {
            Data.RemovePet(familyId,petName);
            return Ok();
        }
    }
}