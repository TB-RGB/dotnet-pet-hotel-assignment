using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

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

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        // GET /api/pets
        [HttpGet]
        public IEnumerable<Pet> GetPets()
        {
            return _context.Pets.Include(p => p.petOwner);
        }
        // GET /api/pets/{id}
        [HttpGet("{id}")]
        public ActionResult<Pet> GetById(int id)
        {
            Pet pet = _context.Pets.SingleOrDefault(p => p.id == id);
            if (pet is null)
            {
                return NotFound();
            }
            return pet;
        }

        [HttpDelete("{id}")]
        public void DeletePet(int id)
        {
            // _context.Pets is the PetsTable in DB.
            Pet petToDelete = _context.Pets.Find(id);
            _context.Pets.Remove(petToDelete);
            _context.SaveChanges();
        }

        [HttpPut("{id}")]
        public Pet Put(int id, Pet pet)
        {
            pet.id = id;
            _context.Update(pet);
            _context.SaveChanges();
            return pet;
        }

        [HttpPut("{id}/checkin")]
        public async Task<IActionResult> CheckInPet(int id)
        {
            var pet = await _context.Pets.FindAsync(id);
            if (pet is null)
            {
                return NotFound();
            }
            pet.checkedInAt = DateTime.UtcNow;
            var updatedPet = await _context.SaveChangesAsync();
            return Ok(updatedPet);
        }

        [HttpPut("{id}/checkout")]
        public async Task<IActionResult> CheckOutPet(int id)
        {
            var pet = await _context.Pets.FindAsync(id);
            if (pet is null)
            {
                return NotFound();
            }
            pet.checkedInAt = null;
            var updatedPet = await _context.SaveChangesAsync();
            return Ok(updatedPet);
        }

        [HttpPost]
        public Pet Post(Pet pet)
        {
            _context.Add(pet);
            _context.SaveChanges();
            return pet;
        }


        // [HttpGet]
        // [Route("test")]
        // public IEnumerable<Pet> GetPets() {
        //     PetOwner blaine = new PetOwner{
        //         name = "Blaine"
        //     };

        //     Pet newPet1 = new Pet {
        //         name = "Big Dog",
        //         petOwner = blaine,
        //         color = PetColorType.Black,
        //         breed = PetBreedType.Poodle,
        //     };

        //     Pet newPet2 = new Pet {
        //         name = "Little Dog",
        //         petOwner = blaine,
        //         color = PetColorType.Golden,
        //         breed = PetBreedType.Labrador,
        //     };

        //     return new List<Pet>{ newPet1, newPet2};
        // }
    }
}
