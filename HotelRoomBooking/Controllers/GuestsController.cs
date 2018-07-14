using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelRoomBooking.Model;
using HotelRoomBooking.Persistance;
using AutoMapper;

namespace HotelRoomBooking.Controllers
{
    [Produces("application/json")]
    [Route("api/Guests")]
    public class GuestsController : Controller
    {
        public HotelRoomBookingDbContext Context { get; }
        public IMapper Mapper { get; }

        public GuestsController(HotelRoomBookingDbContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        // GET: api/Guests
        [HttpGet]
        public IEnumerable<Guest> GetGuest()
        {
            return Context.Guest;
        }

        // GET: api/Guests/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGuest([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var guest = await Context.Guest.SingleOrDefaultAsync(m => m.ID == id);

            if (guest == null)
            {
                return NotFound();
            }

            return Ok(guest);
        }

        // PUT: api/Guests/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGuest([FromRoute] int id, [FromBody] Guest guest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != guest.ID)
            {
                return BadRequest();
            }

            Context.Entry(guest).State = EntityState.Modified;

            try
            {
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GuestExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Guests
        [HttpPost]
        public async Task<IActionResult> PostGuest([FromBody] Guest guest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Context.Guest.Add(guest);
            await Context.SaveChangesAsync();

            return CreatedAtAction("GetGuest", new { id = guest.ID }, guest);
        }

        // DELETE: api/Guests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuest([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var guest = await Context.Guest.SingleOrDefaultAsync(m => m.ID == id);
            if (guest == null)
            {
                return NotFound();
            }

            Context.Guest.Remove(guest);
            await Context.SaveChangesAsync();

            return Ok(guest);
        }

        private bool GuestExists(int id)
        {
            return Context.Guest.Any(e => e.ID == id);
        }
    }
}