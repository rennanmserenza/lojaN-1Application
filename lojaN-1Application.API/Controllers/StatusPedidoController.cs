using Data;
using lojaN_1Application.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lojaN_1Application.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusPedidoController : ControllerBase
    {
        private readonly ClienteContext _context;

        public StatusPedidoController(ClienteContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<StatusPedido>> CadastraStatusPedido([FromBody] StatusPedido statusPedido)
        {
            var cadStatus = new StatusPedido
            {
                DescStatus = statusPedido.DescStatus
            };

            _context.StatusPedidos.Add(cadStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ConsultaStatusPedidoPorId), new { cadStatus.CodStatus });
        }

        [HttpGet]
        public async Task<ActionResult<List<StatusEntrega>>> ConsultaStatusPedido()
        {
            var listStatus = await _context.StatusPedidos.ToListAsync();
            if (listStatus == null)
            {
                return NotFound();
            }

            return Ok(listStatus);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StatusPedido>> ConsultaStatusPedidoPorId(int id)
        {
            var cadStatus = await _context.StatusPedidos.FirstOrDefaultAsync(s => s.CodStatus == id);
            if (cadStatus == null)
            {
                return NotFound();
            }
            return Ok(cadStatus);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> AtualizaStatusPedido(int id, StatusPedido status)
        {
            var statusPedido = await _context.StatusPedidos.FirstOrDefaultAsync(s => s.CodStatus == id);
            if (statusPedido == null)
                return BadRequest();

            statusPedido.DescStatus = status.DescStatus;

            _context.Update(statusPedido);
            await _context.SaveChangesAsync();
            return Ok(statusPedido);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveStatusPedido(int id)
        {
            var status = await _context.StatusPedidos.FirstOrDefaultAsync(s => s.CodStatus == id);
            if (status == null)
                return BadRequest();

            _context.Remove(status);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
