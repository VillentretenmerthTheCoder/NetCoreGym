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
    public class InvoicesController : ControllerBase
    {
        private readonly gymContext _context;

        public InvoicesController(gymContext context)
        {
            _context = context;
        }

        // GET: api/Invoices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Invoices>>> GetInvoices()
        {
            return await _context.Invoices.ToListAsync();
        }

        // GET: api/Invoices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Invoices>> GetInvoices(int id)
        {
            var invoices = await _context.Invoices.FindAsync(id);

            if (invoices == null)
            {
                return NotFound();
            }

            return invoices;
        }

        // PUT: api/Invoices/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoices(int id, Invoices invoices)
        {
            if (id != invoices.Id)
            {
                return BadRequest();
            }

            _context.Entry(invoices).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoicesExists(id))
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

        // POST: api/Invoices
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Invoices>> PostInvoices(Invoices invoices)
        {
            _context.Invoices.Add(invoices);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvoices", new { id = invoices.Id }, invoices);
        }

        // DELETE: api/Invoices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Invoices>> DeleteInvoices(int id)
        {
            var invoices = await _context.Invoices.FindAsync(id);
            if (invoices == null)
            {
                return NotFound();
            }

            _context.Invoices.Remove(invoices);
            await _context.SaveChangesAsync();

            return invoices;
        }

        private bool InvoicesExists(int id)
        {
            return _context.Invoices.Any(e => e.Id == id);
        }


        [HttpPost]
        [Route("newMemberTransaction")]
        
        public void async([FromBody] TransactionModel transactionModel)
        {
            transactionHandler.callTransaction(transactionModel);
        }
    }
}
