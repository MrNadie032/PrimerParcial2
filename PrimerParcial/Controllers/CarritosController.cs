using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrimerParcial.Models;
using PrimerParcial.Models.DTOs.Carritos;

namespace PrimerParcial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritosController : ControllerBase
    {
        private readonly ComercioContext _context;
        private readonly IMapper mapper;

        public CarritosController(ComercioContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: api/Carritos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarritoGetDTO>>> GetCarritos()
        {
            var carritos = await _context.Carritos.ToListAsync();
            var carritosDTO = mapper.Map<IEnumerable<CarritoGetDTO>>(carritos);
            return Ok (carritosDTO);
        }

        // GET: api/Carritos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarritoGetDTO>> GetCarrito(int id)
        {
            var carrito = await _context.Carritos.FindAsync(id);

            if (carrito == null)
            {
                return NotFound();
            }

            var carritoDTO = mapper.Map<CarritoGetDTO>(carrito);
            return Ok(carritoDTO);
        }

        // PUT: api/Carritos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarrito(int id, CarritoUpdateDTO carritoDTO)
        {
            if (id != carritoDTO.Id)
            {
                return BadRequest();
            }

            var carrito = mapper.Map<Carrito>(carritoDTO);
            _context.Entry(carrito).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarritoExists(id))
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

        // POST: api/Carritos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Carrito>> PostCarrito(CarritoInsertDTO carritoDTO)
        {
            var carrito = mapper.Map<Carrito>(carritoDTO);
            _context.Carritos.Add(carrito);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarrito", new { id = carrito.Id }, carritoDTO);
        }

        // DELETE: api/Carritos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarrito(int id)
        {
            var carrito = await _context.Carritos.FindAsync(id);
            if (carrito == null)
            {
                return NotFound();
            }

            _context.Carritos.Remove(carrito);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarritoExists(int id)
        {
            return _context.Carritos.Any(e => e.Id == id);
        }
    }
}
