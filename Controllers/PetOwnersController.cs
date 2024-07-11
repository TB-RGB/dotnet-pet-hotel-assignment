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
        

        public IEnumerable<PetOwner> GetPets() {
            return new List<PetOwner>();
        }


        
    }
}
