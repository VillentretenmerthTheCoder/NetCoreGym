using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCoreGym.Models;

namespace NetCoreGym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembershipsTypesController : ControllerBase
    {
        private readonly gymContext _context;

        public MembershipsTypesController(gymContext context)
        {
            _context = context;
        }

        // GET: api/MembershipsTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MembershipsTypes>>> GetMembershipsTypes()
        {
            return await _context.MembershipsTypes.ToListAsync();
        }

        // GET: api/MembershipsTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MembershipsTypes>> GetMembershipsTypes(int id)
        {
            var membershipsTypes = await _context.MembershipsTypes.FindAsync(id);

            if (membershipsTypes == null)
            {
                return NotFound();
            }

            return membershipsTypes;
        }

        // PUT: api/MembershipsTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMembershipsTypes(int id, MembershipsTypes membershipsTypes)
        {
            if (id != membershipsTypes.TypeId)
            {
                return BadRequest();
            }

            _context.Entry(membershipsTypes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MembershipsTypesExists(id))
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

        // POST: api/MembershipsTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MembershipsTypes>> PostMembershipsTypes(MembershipsTypes membershipsTypes)
        {
            _context.MembershipsTypes.Add(membershipsTypes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMembershipsTypes", new { id = membershipsTypes.TypeId }, membershipsTypes);
        }

        // DELETE: api/MembershipsTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MembershipsTypes>> DeleteMembershipsTypes(int id)
        {
            var membershipsTypes = await _context.MembershipsTypes.FindAsync(id);
            if (membershipsTypes == null)
            {
                return NotFound();
            }

            _context.MembershipsTypes.Remove(membershipsTypes);
            await _context.SaveChangesAsync();

            return membershipsTypes;
        }

        private bool MembershipsTypesExists(int id)
        {
            return _context.MembershipsTypes.Any(e => e.TypeId == id);
        }
    }
}
