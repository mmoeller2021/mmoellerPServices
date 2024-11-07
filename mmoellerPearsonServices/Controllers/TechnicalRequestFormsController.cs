using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mmoellerPearsonServices.Models;

namespace mmoellerPearsonServices.Controllers
{
    [Route("api/technical-request")]
    [ApiController]
    [Produces("application/json")]
    public class TechnicalRequestFormsController : ControllerBase
    {
        private readonly TechnicalRequestContext _context;

        public TechnicalRequestFormsController(TechnicalRequestContext context)
        {
            _context = context;
        }

        // GET: api/TechnicalRequestForms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TechnicalRequestForm>>> GetTechinalRequestForms()
        {
            return await _context.TechinalRequestForms.ToListAsync();
        }

        // GET: api/TechnicalRequestForms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TechnicalRequestForm>> GetTechnicalRequestForm(long id)
        {
            var technicalRequestForm = await _context.TechinalRequestForms.FindAsync(id);

            if (technicalRequestForm == null)
            {
                return NotFound();
            }

            return technicalRequestForm;
        }

        // PUT: api/TechnicalRequestForms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTechnicalRequestForm(long id, TechnicalRequestForm technicalRequestForm)
        {
            if (id != technicalRequestForm.Id)
            {
                return BadRequest();
            }

            _context.Entry(technicalRequestForm).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TechnicalRequestFormExists(id))
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

        // POST: api/TechnicalRequestForms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TechnicalRequestForm>> PostTechnicalRequestForm(TechnicalRequestForm technicalRequestForm)
        {
            _context.TechinalRequestForms.Add(technicalRequestForm);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTechnicalRequestForm), new { id = technicalRequestForm.Id }, technicalRequestForm);
        }

        // DELETE: api/TechnicalRequestForms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTechnicalRequestForm(long id)
        {
            var technicalRequestForm = await _context.TechinalRequestForms.FindAsync(id);
            if (technicalRequestForm == null)
            {
                return NotFound();
            }

            _context.TechinalRequestForms.Remove(technicalRequestForm);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TechnicalRequestFormExists(long id)
        {
            return _context.TechinalRequestForms.Any(e => e.Id == id);
        }
    }
}
