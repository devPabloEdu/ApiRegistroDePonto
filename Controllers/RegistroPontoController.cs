using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegistroDePontosApi.Models;

namespace RegistroDePontosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroPontoController : ControllerBase
    {
        private readonly RegistroContext _context;

        public RegistroPontoController(RegistroContext context)
        {
            _context = context;
        }

        // GET: api/RegistroPonto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegistroPonto>>> GetRegistroPonto()
        {
            return await _context.RegistroPonto.ToListAsync();
        }

        // GET: api/RegistroPonto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RegistroPonto>> GetRegistroPonto(int id)
        {
            var registroPonto = await _context.RegistroPonto.FindAsync(id);

            if (registroPonto == null)
            {
                return NotFound();
            }

            return registroPonto;
        }

        // PUT: api/RegistroPonto/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistroPonto(int id, RegistroPonto registroPonto)
        {
            if (id != registroPonto.Id)
            {
                return BadRequest();
            }

            _context.Entry(registroPonto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistroPontoExists(id))
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

        // POST: api/RegistroPonto
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RegistroPonto>> PostRegistroPonto(RegistroPonto registroPonto)
        {
            _context.RegistroPonto.Add(registroPonto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegistroPonto", new { id = registroPonto.Id }, registroPonto);
        }

        // DELETE: api/RegistroPonto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistroPonto(int id)
        {
            var registroPonto = await _context.RegistroPonto.FindAsync(id);
            if (registroPonto == null)
            {
                return NotFound();
            }

            _context.RegistroPonto.Remove(registroPonto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RegistroPontoExists(int id)
        {
            return _context.RegistroPonto.Any(e => e.Id == id);
        }
    }
}
