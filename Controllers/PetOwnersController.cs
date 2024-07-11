using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pet_hotel.Models;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetOwnersController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PetOwnersController(ApplicationContext context)
        {
            _context = context;
        }

        // GET /api/petowners
      
 [HttpGet]
        public IEnumerable<PetOwner> GetPets() {
            return _context.PetOwners;
        }

        // GET /api/petowners/{id}
        [HttpGet("{id}")]
        public ActionResult<PetOwner> GetById(int id)
        {
            PetOwner petOwner = _context.PetOwners.Include(po => po.Pets).SingleOrDefault(po => po.Id == id);

            if (petOwner == null)
            {
                return NotFound();
            }

            return petOwner;
        }
    }
}
