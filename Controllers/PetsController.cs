using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pet_hotel.Models;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PetsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET /api/pets
        [HttpGet]
        public IEnumerable<Pet> GetPets()
        {
            return _context.Pets.Include(p => p.PetOwner).ToList();
        }

        // GET /api/pets/{id}
        [HttpGet("{id}")]
        public ActionResult<Pet> GetById(int id)
        {
            var pet = _context.Pets.Include(p => p.PetOwner).SingleOrDefault(p => p.Id == id);

            if (pet == null)
            {
                return NotFound();
            }

            return pet;
        }
    }
}
