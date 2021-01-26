using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CasaBoxAPI;
using CasaBoxAPI.Models;

namespace CasaBoxAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CasaBoxTypeController : ControllerBase
    {
        private readonly CasaBoxContext _context;

        public CasaBoxTypeController(CasaBoxContext context)
        {
            _context = context;
        }

        // GET: api/CasaBoxType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CasaBoxType>>> GetCasaBoxType()
        {
            return await _context.CasaBoxType.ToListAsync();
        }

        // GET: api/CasaBoxType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CasaBoxType>> GetCasaBoxType(string id)
        {
            var casaBoxType = await _context.CasaBoxType.FindAsync(id);

            if (casaBoxType == null)
            {
                return NotFound();
            }

            return casaBoxType;
        }

        // PUT: api/CasaBoxType/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCasaBoxType(string id, CasaBoxType casaBoxType)
        {
            if (id != casaBoxType.Type)
            {
                return BadRequest();
            }

            _context.Entry(casaBoxType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CasaBoxTypeExists(id))
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

        // POST: api/CasaBoxType
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CasaBoxType>> PostCasaBoxType(CasaBoxType casaBoxType)
        {
            _context.CasaBoxType.Add(casaBoxType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CasaBoxTypeExists(casaBoxType.Type))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCasaBoxType", new { id = casaBoxType.Type }, casaBoxType);
        }

        // DELETE: api/CasaBoxType/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CasaBoxType>> DeleteCasaBoxType(string id)
        {
            var casaBoxType = await _context.CasaBoxType.FindAsync(id);
            if (casaBoxType == null)
            {
                return NotFound();
            }

            _context.CasaBoxType.Remove(casaBoxType);
            await _context.SaveChangesAsync();

            return casaBoxType;
        }

        private bool CasaBoxTypeExists(string id)
        {
            return _context.CasaBoxType.Any(e => e.Type == id);
        }
    }
}
