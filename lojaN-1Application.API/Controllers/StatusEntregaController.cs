using Data;
using lojaN_1Application.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lojaN_1Application.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusEntregaController : ControllerBase
    {
        private readonly ClienteContext _context;

        public StatusEntregaController(ClienteContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<StatusEntrega>> CadastraStatusEntrega([FromBody] StatusEntrega statusEmpresa)
        {
            var cadStatus = new StatusEntrega
            {
                DescStatus = statusEmpresa.DescStatus
            };

            _context.StatusEmpresas.Add(cadStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ConsultaStatusEntregaPorId), new { cadStatus.CodStatus });            
        }

        [HttpGet]
        public async Task<ActionResult<List<StatusEntrega>>> ConsultaStatusEntrega()
        {
            var listStatus = await _context.StatusEmpresas.ToListAsync();
            if (listStatus == null) 
            { 
                return NotFound();
            }

            return Ok(listStatus);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StatusEntrega>> ConsultaStatusEntregaPorId(int id)
        {
            var cadStatus = await _context.StatusEmpresas.FirstOrDefaultAsync(s => s.CodStatus == id);
            if(cadStatus == null)
            {
                return NotFound();
            }
            return Ok(cadStatus);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> AtualizaStatusEntrega(int id, StatusEntrega status)
        {
            var statusEmpresa = await _context.StatusEmpresas.FirstOrDefaultAsync(s => s.CodStatus == id);
            if (statusEmpresa == null)
                return BadRequest();

            statusEmpresa.DescStatus = status.DescStatus;

            _context.Update(statusEmpresa);
            await _context.SaveChangesAsync();
            return Ok(statusEmpresa);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveEntrega(int id)
        {
            var status = await _context.StatusEmpresas.FirstOrDefaultAsync(s => s.CodStatus == id);
            if(status == null)
                return BadRequest();

            _context.Remove(status);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
