using Data;
using lojaN_1Application.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lojaN_1Application.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class ItemPedidoController : ControllerBase
    {
        private readonly ClienteContext _context;

        public ItemPedidoController(ClienteContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<ItemPedido>> AdicionaItemAoPedido(ItemPedido itemPedido)
        {
            var pedido = new ItemPedido
            {
                CodPedido = itemPedido.CodPedido,
                CodProduto = itemPedido.CodProduto,
                QtdProduto = itemPedido.QtdProduto,
            };

            _context.Add(pedido);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(ConsultaItensPorPedido), new { pedido.CodPedido });
        }


        [HttpGet("{codPedido}")]
        public async Task<ActionResult<List<ItemPedido>>> ConsultaItensPorPedido(int codPedido)
        {
            var pedido = await _context.ItemPedidos.Where(p => p.CodPedido == codPedido).ToListAsync();
            if (pedido == null)
                return NotFound();

            return Ok(pedido);
        }

        [HttpGet("{codPedido}/{codProduto}")]
        public async Task<ActionResult<ItemPedido>> ConsultaItemPorPedido(int codPedido, int codProduto)
        {
            var item = await _context.ItemPedidos
                                     .Where(p => p.CodPedido == codPedido && p.CodProduto == codProduto)
                                     .ToListAsync();
            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPut("{codPedido}/{codProduto}")]
        public async Task<ActionResult<ItemPedido>> AlteraItensProduto(int codPedido, int codProduto, [FromBody] ItemPedido itensPedido)
        {
            var item = await _context.ItemPedidos.FirstOrDefaultAsync(p => p.CodPedido == codPedido && p.CodProduto == codProduto);
            if (item == null)
                return NotFound();

            item.CodProduto = itensPedido.CodPedido;
            item.QtdProduto = itensPedido.QtdProduto;

            _context.Update(item);
            await _context.SaveChangesAsync();
            return Ok(item);
        }

        [HttpDelete("{codPedido}/{codProduto}")]
        public async Task<ActionResult<ItemPedido>> RemoveItemPedido(int codPedido, int codProduto)
        {
            var item = await _context.ItemPedidos.FirstOrDefaultAsync(p => p.CodPedido == codPedido && p.CodProduto == codProduto);
            if (item == null)
                return NotFound();

            _context.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
