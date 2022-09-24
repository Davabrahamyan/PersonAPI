using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonAPI.Models;

namespace PersonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonDetailsController : ControllerBase
    {
        private readonly PersonContext _context;

        public PersonDetailsController(PersonContext context)
        {
            _context = context;
        }

        // GET: api/PersonDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonDetail>>> GetPersonDetails()
        {
            return await _context.PersonDetails.ToListAsync();
        }

        // GET: api/PersonDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonDetail>> GetPersonDetail(int id)
        {
            var personDetail = await _context.PersonDetails.FindAsync(id);

            if (personDetail == null)
            {
                return NotFound();
            }

            return personDetail;
        }

        // PUT: api/PersonDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonDetail(int id, PersonDetail personDetail)
        {
            if (id != personDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(personDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonDetailExists(id))
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

        // POST: api/PersonDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PersonDetail>> PostPersonDetail(PersonDetail personDetail)
        {
            _context.PersonDetails.Add(personDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonDetail", new { id = personDetail.Id }, personDetail);
        }

        // DELETE: api/PersonDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonDetail(int id)
        {
            var personDetail = await _context.PersonDetails.FindAsync(id);
            if (personDetail == null)
            {
                return NotFound();
            }

            _context.PersonDetails.Remove(personDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonDetailExists(int id)
        {
            return _context.PersonDetails.Any(e => e.Id == id);
        }
    }
}
