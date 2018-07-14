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
using HotelRoomBooking.Controllers.Resources;

namespace HotelRoomBooking.Controllers
{
    [Produces("application/json")]
    [Route("api/Bookings")]
    public class BookingsController : Controller
    {
        public HotelRoomBookingDbContext Context { get; }
        public IMapper Mapper { get; }

        public BookingsController(HotelRoomBookingDbContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        // GET: api/Bookings
        [HttpGet]
        public async Task<IEnumerable<BookingResource>> GetBooking()
        {
            var bookings = await Context.Booking.Include(m => m.Guests).ToListAsync();
            return Mapper.Map<List<Booking>, List<BookingResource>>(bookings);
            
        }

        // GET: api/Bookings/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBooking([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var booking = await Context.Booking.SingleOrDefaultAsync(m => m.ID == id);

            if (booking == null)
            {
                return NotFound();
            }

            return Ok(booking);
        }

        // PUT: api/Bookings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooking([FromRoute] int id, [FromBody] Booking booking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != booking.ID)
            {
                return BadRequest();
            }

            Context.Entry(booking).State = EntityState.Modified;

            try
            {
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(id))
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

        // POST: api/Bookings
        [HttpPost]
        public async Task<IActionResult> PostBooking([FromBody] Booking booking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Context.Booking.Add(booking);
            await Context.SaveChangesAsync();

            return CreatedAtAction("GetBooking", new { id = booking.ID }, booking);
        }

        // DELETE: api/Bookings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var booking = await Context.Booking.SingleOrDefaultAsync(m => m.ID == id);
            if (booking == null)
            {
                return NotFound();
            }

            Context.Booking.Remove(booking);
            await Context.SaveChangesAsync();

            return Ok(booking);
        }

        private bool BookingExists(int id)
        {
            return Context.Booking.Any(e => e.ID == id);
        }
    }
}