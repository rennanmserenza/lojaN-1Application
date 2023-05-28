using Data;
using lojaN_1Application.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lojaN_1Application.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntregaController : ControllerBase
    {
        private readonly ClienteContext _context;

        public EntregaController(ClienteContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Entrega>> CadastraEntrega(Entrega entrega)
        {
            var novaEntrega = new Entrega
            {
                CodPedido = entrega.CodPedido,
                CodStatus = entrega.CodStatus,
                DataPrevisao = entrega.DataPrevisao,
                DataStatus = entrega.DataStatus,
            };

            _context.Add(novaEntrega);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(ConsultaEntregaPorId), new { novaEntrega.CodPedido });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Entrega>> ConsultaEntregaPorId(int id)
        {
            var entrega = await _context.Entregas.FirstOrDefaultAsync(e => e.CodEntrega == id);
            if(entrega == null)
                return NotFound();

            return Ok(entrega);
        }
    }
}
