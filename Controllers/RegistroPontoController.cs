using System;
using System.Collections.Generic;
using System.Globalization;
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
        //Removi anteriormente o post que enviava todos os registros de uma vez só, agora, ele vai registrar de acordo com a rota selecionada
        [HttpPost]
        public async Task<ActionResult<RegistroPonto>> PostRegistroPonto()
        {
            var registroPonto = new RegistroPonto();
            _context.RegistroPonto.Add(registroPonto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRegistroPonto), new { id = registroPonto.Id }, registroPonto);
        }
        [HttpPost("{id}/entrada")]
        public async Task<IActionResult> RegistrarEntrada(int id)
        {
            var dataAtual = DateTime.Today;
            // Verificar se já existe um registro de ponto para o funcionário no dia atual
            var registroPonto = await _context.RegistroPonto.FirstOrDefaultAsync(r => r.FuncionarioId == id && r.Data == dataAtual);

            if (registroPonto == null)
            {
                // Criar novo registro de ponto para o dia atual
                registroPonto = new RegistroPonto
                {
                    FuncionarioId = id,
                    Data = dataAtual,
                    PontoDeEntrada = DateTime.Now
                };

                _context.RegistroPonto.Add(registroPonto);
                await _context.SaveChangesAsync();
                return Ok(registroPonto);
            }
            else if (registroPonto.PontoDeEntrada == null)
            {
                // Atualizar ponto de entrada caso ele ainda não tenha sido registrado
                registroPonto.PontoDeEntrada = DateTime.Now;
                await _context.SaveChangesAsync();
                return Ok(registroPonto);
            }
            else
            {
                // Retornar erro caso o ponto de entrada já tenha sido registrado
                return BadRequest("Ponto de entrada já registrado para hoje.");
            }
        }
        [HttpPost("{id}/almoco")]
        public async Task<IActionResult> RegistroAlmoço(int id)
        {
            var dataAtual = DateTime.Today;
            // Verificar se já existe um registro de ponto para o funcionário no dia atual
            var registroPonto = await _context.RegistroPonto.FirstOrDefaultAsync(r => r.FuncionarioId == id && r.Data == dataAtual);

            if (registroPonto == null)
            {
                // Criar novo registro de ponto para o dia atual
                registroPonto = new RegistroPonto
                {
                    FuncionarioId = id,
                    Data = dataAtual,
                    PontoDeAlmoço = DateTime.Now
                };

                _context.RegistroPonto.Add(registroPonto);
                await _context.SaveChangesAsync();
                return Ok(registroPonto);
            }
            else if (registroPonto.PontoDeAlmoço == null)
            {
                // Atualizar ponto de entrada caso ele ainda não tenha sido registrado
                registroPonto.PontoDeAlmoço = DateTime.Now;
                await _context.SaveChangesAsync();
                return Ok(registroPonto);
            }
            else
            {
                // Retornar erro caso o ponto de entrada já tenha sido registrado
                return BadRequest("Ponto de Almoço já registrado para hoje.");
            }
        }
        [HttpPost("{id}/retorno")]
        public async Task<IActionResult> RegistroRetorno(int id)
        {
            var dataAtual = DateTime.Today;
            // Verificar se já existe um registro de ponto para o funcionário no dia atual
            var registroPonto = await _context.RegistroPonto.FirstOrDefaultAsync(r => r.FuncionarioId == id && r.Data == dataAtual);

            if (registroPonto == null)
            {
                // Criar novo registro de ponto para o dia atual
                registroPonto = new RegistroPonto
                {
                    FuncionarioId = id,
                    Data = dataAtual,
                    PontoDeVoltaAlmoço = DateTime.Now
                };

                _context.RegistroPonto.Add(registroPonto);
                await _context.SaveChangesAsync();
                return Ok(registroPonto);
            }
            else if (registroPonto.PontoDeVoltaAlmoço == null)
            {
                // Atualizar ponto de entrada caso ele ainda não tenha sido registrado
                registroPonto.PontoDeVoltaAlmoço = DateTime.Now;
                await _context.SaveChangesAsync();
                return Ok(registroPonto);
            }
            else
            {
                // Retornar erro caso o ponto de entrada já tenha sido registrado
                return BadRequest("Ponto de Retorno do almoço já registrado para hoje.");
            }
        }
        [HttpPost("{id}/saida")]
        public async Task<IActionResult> RegistroSaida(int id)
        {
            var dataAtual = DateTime.Today;
            // Verificar se já existe um registro de ponto para o funcionário no dia atual
            var registroPonto = await _context.RegistroPonto.FirstOrDefaultAsync(r => r.FuncionarioId == id && r.Data == dataAtual);

            if (registroPonto == null)
            {
                // Criar novo registro de ponto para o dia atual
                registroPonto = new RegistroPonto
                {
                    FuncionarioId = id,
                    Data = dataAtual,
                    PontoDeSaída = DateTime.Now
                };

                _context.RegistroPonto.Add(registroPonto);
                await _context.SaveChangesAsync();
                return Ok(registroPonto);
            }
            else if (registroPonto.PontoDeSaída == null)
            {
                // Atualizar ponto de entrada caso ele ainda não tenha sido registrado
                registroPonto.PontoDeSaída = DateTime.Now;
                await _context.SaveChangesAsync();
                return Ok(registroPonto);
            }
            else
            {
                // Retornar erro caso o ponto de entrada já tenha sido registrado
                return BadRequest("Ponto de Saída já registrado para hoje.");
            }
        }


        // DELETE: api/RegistroPonto/5
        [HttpDelete("{id}/entrada")]
        public async Task<IActionResult> DeleteEntrada(int id)
        {
            var registroPonto = await _context.RegistroPonto.FindAsync(id);
            if (registroPonto == null)
            {
                return NotFound();
            }
            //esse comando vai zerar ou tornar nullo o ponto registrado anteriormente
            registroPonto.PontoDeEntrada = null;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{id}/almoco")]
        public async Task<IActionResult> DeleteAlmoco(int id)
        {
            var registroPonto = await _context.RegistroPonto.FindAsync(id);
            if(registroPonto == null)
            {
                return NotFound();
            }

            registroPonto.PontoDeAlmoço = null;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{id}/retorno")]
        public async Task<IActionResult> DeleteRetorno(int id)
        {
            var registroPonto = await _context.RegistroPonto.FindAsync(id);
            if(registroPonto == null)
            {
                return NotFound();
            }

            registroPonto.PontoDeVoltaAlmoço = null;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{id}/saida")]
        public async Task<IActionResult> DeleteSaida(int id)
        {
            var registroPonto = await _context.RegistroPonto.FindAsync(id);
            if(registroPonto == null)
            {
                return NotFound();
            }

            registroPonto.PontoDeSaída = null;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RegistroPontoExists(int id)
        {
            return _context.RegistroPonto.Any(e => e.Id == id);
        }
    }
}
