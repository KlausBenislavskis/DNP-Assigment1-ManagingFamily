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
    public class ChildController : Controller
    {
        private IFamiliesData Data;

        public ChildController(IFamiliesData familiesData)
        {
            Data = familiesData;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Child>>> Get([FromQuery] string name, [FromRoute] int familyId)
        {
            Family family = (await Data.GetFamilies()).First(f => f.Id == familyId);

            IList<Child> child;
            if (name != null)
            {
                child = new List<Child>() {family.Children.First(a => a.FirstName == name)};
            }
            else
            {
                child = family.Children;
            }

            return Ok(child);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Child>>> Post([FromBody] Child child, [FromRoute] int familyId)
        {
            try
            {
                Child added = await Data.AddChild(child, familyId);
                return Created($"/{added.Id}", added);
            }
            catch (Exception e)
            {
                return StatusCode(505, e.Message);
            }
        }
        [HttpDelete]
        [Route("{childName}")]
        public async Task<ActionResult<IEnumerable<Family>>> Delete([FromRoute] string childName, [FromRoute] int familyId)
        {
            Console.WriteLine("here");
            Data.RemoveChild(familyId,childName);
            return Ok();
        }
    }
}