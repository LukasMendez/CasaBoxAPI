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
    public class CasaBoxController : ControllerBase
    {
        private readonly CasaBoxContext _context;

        public CasaBoxController(CasaBoxContext context)
        {
            _context = context;
        }

        // GET: api/CasaBox
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CasaBox>>> GetCasaBoxes()
        {
            return await _context.CasaBoxes.ToListAsync();
        }

        // GET: api/CasaBox/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CasaBox>> GetCasaBox(int id)
        {
            var casaBox = await _context.CasaBoxes.FindAsync(id);

            if (casaBox == null)
            {
                return NotFound();
            }

            return casaBox;
        }



        // PUT: api/CasaBox/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCasaBox(int id, CasaBox casaBox)
        {
            if (id != casaBox.BoxNummer)
            {
                return BadRequest();
            }

            _context.Entry(casaBox).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CasaBoxExists(id))
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

        // POST: api/CasaBox
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CasaBox>> PostCasaBox(CasaBox casaBox)
        {
            _context.CasaBoxes.Add(casaBox);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCasaBox", new { id = casaBox.BoxNummer }, casaBox);
        }

        // DELETE: api/CasaBox/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CasaBox>> DeleteCasaBox(int id)
        {
            var casaBox = await _context.CasaBoxes.FindAsync(id);
            if (casaBox == null)
            {
                return NotFound();
            }

            _context.CasaBoxes.Remove(casaBox);
            await _context.SaveChangesAsync();

            return casaBox;
        }

        private bool CasaBoxExists(int id)
        {
            return _context.CasaBoxes.Any(e => e.BoxNummer == id);
        }
    }
}
