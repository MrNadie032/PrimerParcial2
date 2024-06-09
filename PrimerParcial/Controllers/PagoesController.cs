using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrimerParcial.Models;
using PrimerParcial.Models.DTOs.Pago;

namespace PrimerParcial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoesController : ControllerBase
    {
        private readonly ComercioContext _context;
        private readonly IMapper mapper;

        public PagoesController(ComercioContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: api/Pagoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PagoGetDTO>>> GetPagos()
        {
            var pagos = await _context.Pagos.ToListAsync();
            var pagosDTO = mapper.Map<IEnumerable<PagoGetDTO>>(pagos);
            return Ok(pagosDTO);
        }

        // GET: api/Pagoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PagoGetDTO>> GetPago(int id)
        {
            var pago = await _context.Pagos.FindAsync(id);

            if (pago == null)
            {
                return NotFound();
            }

            var pagosDTO = mapper.Map<PagoGetDTO>(pago);
            return Ok(pagosDTO);
        }

        // PUT: api/Pagoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPago(int id, PagoUpdateDTO pagoDTO)
        {
            if (id != pagoDTO.Id)
            {
                return BadRequest();
            }

            var pago = mapper.Map<PagoGetDTO>(pagoDTO);
            _context.Entry(pago).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PagoExists(id))
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

        // POST: api/Pagoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pago>> PostPago(PagoInsertDTO pagoDTO)
        {
            var pago = mapper.Map<Pago>(pagoDTO);
            _context.Pagos.Add(pago);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPago", new { id = pago.Id }, pagoDTO);
        }

        // DELETE: api/Pagoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePago(int id)
        {
            var pago = await _context.Pagos.FindAsync(id);
            if (pago == null)
            {
                return NotFound();
            }

            _context.Pagos.Remove(pago);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PagoExists(int id)
        {
            return _context.Pagos.Any(e => e.Id == id);
        }
    }
}
