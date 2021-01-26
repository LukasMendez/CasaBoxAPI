using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CasaBoxAPI;
using CasaBoxAPI.Models;
using CasaBoxAPI.Dto;
using AutoMapper;

namespace CasaBoxAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CasaBoxVariantController : ControllerBase
    {
        private readonly CasaBoxContext _context;
        private readonly IMapper _mapper;

        public CasaBoxVariantController(CasaBoxContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/CasaBoxVariant
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CasaBoxVariantDto>>> GetCasaBoxVariants()
        {
            var casaBoxVariants = await _context.CasaBoxVariant.ToListAsync();
            var casaBoxVariantsDtoList = new List<CasaBoxVariantDto>(); // The list to be returned 
            foreach (var variant in casaBoxVariants)
            {
                var variantDto = _mapper.Map<CasaBoxVariantDto>(variant);
                variantDto.AntalLedige = CasaBoxesAvailable(variant);
                casaBoxVariantsDtoList.Add(variantDto);
            }
            return casaBoxVariantsDtoList;
        }

        // GET: api/CasaBoxVariant/ByIds?m2=4&m3=10&type=depotrum
        // Returns information about CasaBox Variant and info about availability
        [HttpGet("ByIds")]
        public async Task<ActionResult<CasaBoxVariantDto>> GetCasaBoxVariant(
            [FromQuery] double m2,
            [FromQuery] double m3,
            [FromQuery] string type)
        {
            var casaBoxVariant = await _context.CasaBoxVariant.FirstOrDefaultAsync(
                cv => cv.M2 == m2 && cv.M3 == m3 && cv.Type == type);

            if (casaBoxVariant == null)
            {
                return NotFound();
            }

            var casaBoxVariantDto = _mapper.Map<CasaBoxVariantDto>(casaBoxVariant);
            casaBoxVariantDto.AntalLedige = CasaBoxesAvailable(casaBoxVariant);

            return casaBoxVariantDto;
        }

        // GET: api/CasaBoxVariant/Available?m2=4&m3=10&type=depotrum
        // Check if there are any CasaBoxes available and also how many of them
        // Returns true if there are at least one, else false
        [HttpGet("Available")]
        public async Task<ActionResult<bool>> CheckAvailability(
            [FromQuery]double m2,
            [FromQuery] double m3,
            [FromQuery] string type)
        {
            var casaBoxVariant = await _context.CasaBoxVariant.FirstOrDefaultAsync(
                cv => cv.M2 == m2 && cv.M3 == m3 && cv.Type == type);

            if (casaBoxVariant == null)
            {
                return NotFound();
            }

            return 0 < CasaBoxesAvailable(casaBoxVariant);
        }


        // POST: api/CasaBoxVariant
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CasaBoxVariant>> PostCasaBoxVariant(CasaBoxVariant casaBoxVariant)
        {
            _context.CasaBoxVariant.Add(casaBoxVariant);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CasaBoxVariantExists(casaBoxVariant.M2, casaBoxVariant.M3, casaBoxVariant.Type))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCasaBoxVariant", new { id = casaBoxVariant.M2 }, casaBoxVariant);
        }


        private bool CasaBoxVariantExists(double m2, double m3, string type)
        {
            return _context.CasaBoxVariant.Any(e => e.M2 == m2 && e.M3 == m3 && e.Type == type);
        }

        private int CasaBoxesAvailable(CasaBoxVariant casaBoxVariant)
        {
            return _context.CasaBoxes.Where(
                c => c.CasaBoxVariant.M3 == casaBoxVariant.M3 &&
                c.CasaBoxVariant.M2 == casaBoxVariant.M2 &&
                c.CasaBoxVariant.Type == casaBoxVariant.Type &&
                c.Ledig == true).Count();
        }
    }
}
