using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrimerParcial.Models;
using PrimerParcial.Models.DTOs.Categorium;

namespace PrimerParcial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriumsController : ControllerBase
    {
        private readonly ComercioContext _context;
        private readonly IMapper mapper;

        public CategoriumsController(ComercioContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: api/Categoriums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriumGetDTO>>> GetCategoria()
        {
            var categoriums = await _context.Categoria.ToListAsync();
            var categoriumsDTO = mapper.Map<IEnumerable<CategoriumGetDTO>>(categoriums);
            return Ok(categoriumsDTO);
        }

        // GET: api/Categoriums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriumGetDTO>> GetCategorium(int id)
        {
            var categorium = await _context.Categoria.FindAsync(id);

            if (categorium == null)
            {
                return NotFound();
            }

            var categoriumsDTO = mapper.Map<CategoriumGetDTO>(categorium);
            return Ok(categoriumsDTO);
        }

        // PUT: api/Categoriums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategorium(int id, CategoriumUpdateDTO categoriumDTO)
        {
            if (id != categoriumDTO.Id)
            {
                return BadRequest();
            }

            var categorium = mapper.Map<Categorium>(categoriumDTO);
            _context.Entry(categorium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriumExists(id))
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

        // POST: api/Categoriums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Categorium>> PostCategorium(CategoriumInsertDTO categoriumDTO)
        {
            var categorium = mapper.Map<Categorium>(categoriumDTO);
            _context.Categoria.Add(categorium);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategorium", new { id = categorium.Id }, categoriumDTO);
        }

        // DELETE: api/Categoriums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategorium(int id)
        {
            var categorium = await _context.Categoria.FindAsync(id);
            if (categorium == null)
            {
                return NotFound();
            }

            _context.Categoria.Remove(categorium);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoriumExists(int id)
        {
            return _context.Categoria.Any(e => e.Id == id);
        }
    }
}
