using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrimerParcial.Models;
using PrimerParcial.Models.DTOs.DetallePedido;

namespace PrimerParcial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallePedidoesController : ControllerBase
    {
        private readonly ComercioContext _context;
        private readonly IMapper mapper;

        public DetallePedidoesController(ComercioContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: api/DetallePedidoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetallePedidoGetDTO>>> GetDetallePedidos()
        {
            var DetallePedido = await _context.DetallePedidos.ToListAsync();
            var DetallePedidoDTO = mapper.Map<IEnumerable<DetallePedidoGetDTO>>(DetallePedido);
            return Ok(DetallePedidoDTO);
        }

        // GET: api/DetallePedidoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetallePedidoGetDTO>> GetDetallePedido(int id)
        {
            var detallePedido = await _context.DetallePedidos.FindAsync(id);

            if (detallePedido == null)
            {
                return NotFound();
            }

            var DetallePedidoDTO = mapper.Map<DetallePedidoGetDTO>(detallePedido);
            return Ok(DetallePedidoDTO);
        }

        // PUT: api/DetallePedidoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetallePedido(int id, DetallePedidoUpdateDTO detallePedidoDTO)
        {
            if (id != detallePedidoDTO.Id)
            {
                return BadRequest();
            }

            var detallePedido = mapper.Map<DetallePedido>(detallePedidoDTO);
            _context.Entry(detallePedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetallePedidoExists(id))
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

        // POST: api/DetallePedidoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetallePedido>> PostDetallePedido(DetallePedidoInsertDTO detallePedidoDTO)
        {
            var detallePedido = mapper.Map<DetallePedido>(detallePedidoDTO);
            _context.DetallePedidos.Add(detallePedido);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetallePedido", new { id = detallePedido.Id }, detallePedidoDTO);
        }

        // DELETE: api/DetallePedidoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetallePedido(int id)
        {
            var detallePedido = await _context.DetallePedidos.FindAsync(id);
            if (detallePedido == null)
            {
                return NotFound();
            }

            _context.DetallePedidos.Remove(detallePedido);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetallePedidoExists(int id)
        {
            return _context.DetallePedidos.Any(e => e.Id == id);
        }
    }
}
