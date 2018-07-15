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
    [Route("api/RoomTypes")]
    public class RoomTypesController : Controller
    {
        public HotelRoomBookingDbContext Context { get; }
        public IMapper Mapper { get; }

        public RoomTypesController(HotelRoomBookingDbContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        // GET: api/RoomTypes
        [HttpGet]
        public async Task<IEnumerable<RoomType>> GetRoomType()
        {
            return await Context.RoomType.ToListAsync();
        }

        // GET: api/RoomTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var roomType = await Context.RoomType.SingleOrDefaultAsync(m => m.ID == id);

            if (roomType == null)
            {
                return NotFound();
            }

            return Ok(roomType);
        }

        // PUT: api/RoomTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomType([FromRoute] int id, [FromBody] RoomType roomType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != roomType.ID)
            {
                return BadRequest();
            }

            Context.Entry(roomType).State = EntityState.Modified;

            try
            {
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomTypeExists(id))
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

        // POST: api/RoomTypes
        [HttpPost]
        public async Task<IActionResult> PostRoomType([FromBody] RoomType roomType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Context.RoomType.Add(roomType);
            await Context.SaveChangesAsync();

            return CreatedAtAction("GetRoomType", new { id = roomType.ID }, roomType);
        }

        // DELETE: api/RoomTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var roomType = await Context.RoomType.SingleOrDefaultAsync(m => m.ID == id);
            if (roomType == null)
            {
                return NotFound();
            }

            Context.RoomType.Remove(roomType);
            await Context.SaveChangesAsync();

            return Ok(roomType);
        }

        private bool RoomTypeExists(int id)
        {
            return Context.RoomType.Any(e => e.ID == id);
        }
    }
}