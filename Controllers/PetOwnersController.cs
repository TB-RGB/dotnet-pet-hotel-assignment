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
        public PetOwnersController(ApplicationContext context)
        {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        [HttpGet]
        public IEnumerable<PetOwner> GetPets()
        {
            return _context.PetOwners;
        }

        // GET /api/petowners/{id}
        [HttpGet("{id}")]
        public ActionResult<PetOwner> GetById(int id)
        {

            PetOwner petOwner = _context.PetOwners.Include(po => po.pets).SingleOrDefault(po => po.id == id);


            if (petOwner == null)
            {
                return NotFound();
            }

            return petOwner;
        }

        [HttpPost]
        public PetOwner Post(PetOwner petOwner)
        {
            // Will add petobject to to database
            _context.Add(petOwner);
            // will save changes from pet object
            _context.SaveChanges();
            // Respond back with the created pet object
            return petOwner;
        }


        [HttpPut("{id}")]
        public PetOwner Put(int id, PetOwner petOwner)
        {
            petOwner.id = id;
            _context.Update(petOwner);
            _context.SaveChanges();
            return petOwner;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // Find the PetOwner by id
            PetOwner petOwner = _context.PetOwners.Find(id);

            // Remove the PetOwner
            _context.PetOwners.Remove(petOwner);

            // Save changes to the database
            _context.SaveChanges();

        }

    }
}
