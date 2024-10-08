using Apitest.Data;
using Apitest.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace Apitest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaController : ControllerBase
    {
        // GET: api/villa
        [HttpGet]
        public ActionResult<IEnumerable<VillaDTO>> GetAllVillas()
        {
            return Ok(VillaStore.Villas);
        }

        // GET: api/villa/{id}
        [HttpGet("{id:int}", Name = "GetVillaById")]
        public ActionResult<VillaDTO> GetVillaById(int id)
        {
            var villa = VillaStore.Villas.FirstOrDefault(u => u.Id == id);

            if (villa == null)
            {
                return NotFound();
            }

            return Ok(villa);
        }

        // POST: api/villa
        [HttpPost]
        public ActionResult<VillaDTO> CreateVilla([FromBody] VillaDTO villaDTO)
        {
            if (villaDTO == null)
            {
                return BadRequest();
            }

            if (villaDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "ID should not be passed while creating a new villa.");
            }

            villaDTO.Id = VillaStore.Villas.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
            VillaStore.Villas.Add(villaDTO);

            return CreatedAtRoute("GetVillaById", new { id = villaDTO.Id }, villaDTO);
        }

        // DELETE: api/villa/{id}
        [HttpDelete("{id:int}")]
        public IActionResult DeleteVilla(int id)
        {
            var villa = VillaStore.Villas.FirstOrDefault(v => v.Id == id);

            if (villa == null)
            {
                return NotFound(); 
            }

            VillaStore.Villas.Remove(villa);

            return NoContent(); 
        }
    }
}
