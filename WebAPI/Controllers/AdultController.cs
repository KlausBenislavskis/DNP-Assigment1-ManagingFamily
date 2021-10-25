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
    public class AdultController : Controller
    {
        private IFamiliesData Data;

        public AdultController(IFamiliesData familiesData)
        {
            Data = familiesData;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Adult>>> Get([FromQuery] string name, [FromRoute] int familyId)
        {
            Family family = (await Data.GetFamilies()).First(f => f.Id == familyId);

            IList<Adult> adults;
            if (name != null)
            {
                adults = new List<Adult>() {family.Adults.First(a => a.FirstName == name)};
            }
            else
            {
                adults = family.Adults;
            }

            return Ok(adults);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Adult>>> Post([FromBody] Adult adult, [FromRoute] int familyId)
        {
            try
            {
                Adult added = await Data.AddAdult(adult, familyId);
                return Created($"/{added.Id}", added);
            }
            catch (Exception e)
            {
                return StatusCode(505, e.Message);
            }
        }
        [HttpDelete]
        [Route("{adultName}")]
        public async Task<ActionResult> Delete([FromRoute] string adultName, [FromRoute] int familyId)
        {
            Data.RemoveAdult(familyId,adultName);
            return Ok();
        }
    }
}