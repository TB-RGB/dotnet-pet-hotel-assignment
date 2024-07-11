using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetOwnersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetOwnersController(ApplicationContext context) {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        [HttpGet]
        public IEnumerable<PetOwner> GetPets() {
            return new List<PetOwner>();
        }
             [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Find the PetOwner by id
            var petOwner = _context.PetOwners.Find(id);

            // Check if the PetOwner exists
            if (petOwner == null)
            {
                return NotFound();
            }

            // Remove the PetOwner
            _context.PetOwners.Remove(petOwner);

            // Save changes to the database
            _context.SaveChanges();

            // Return No Content status
            return NoContent();
        }
    }
}
