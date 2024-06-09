using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrimerParcial.Models;
using PrimerParcial.Models.DTOs.Direccion;

namespace PrimerParcial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DireccionsController : ControllerBase
    {
        private readonly ComercioContext _context;
        private readonly IMapper mapper;

        public DireccionsController(ComercioContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: api/Direccions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DirreccionGetDTO>>> GetDireccions()
        {
           var Direccion = await _context.Direccions.ToListAsync();
            var DireccionDTO = mapper.Map<IEnumerable<DirreccionGetDTO>>(Direccion);
            return Ok(DireccionDTO);
        }

        // GET: api/Direccions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DirreccionGetDTO>> GetDireccion(int id)
        {
            var direccion = await _context.Direccions.FindAsync(id);

            if (direccion == null)
            {
                return NotFound();
            }

            var DireccionDTO = mapper.Map<DirreccionGetDTO>(direccion);
            return Ok(DireccionDTO);
        }

        // PUT: api/Direccions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDireccion(int id, DirreccionUpdateDTO direccionDTO)
        {
            if (id != direccionDTO.Id)
            {
                return BadRequest();
            }

            var direccion = mapper.Map<Direccion>(direccionDTO);
            _context.Entry(direccion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DireccionExists(id))
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

        // POST: api/Direccions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Direccion>> PostDireccion(DirreccionInsertDTO direccionDTO)
        {
            var direccion = mapper.Map<Direccion>(direccionDTO);
            _context.Direccions.Add(direccion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDireccion", new { id = direccion.Id }, direccionDTO);
        }

        // DELETE: api/Direccions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDireccion(int id)
        {
            var direccion = await _context.Direccions.FindAsync(id);
            if (direccion == null)
            {
                return NotFound();
            }

            _context.Direccions.Remove(direccion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DireccionExists(int id)
        {
            return _context.Direccions.Any(e => e.Id == id);
        }
    }
}
