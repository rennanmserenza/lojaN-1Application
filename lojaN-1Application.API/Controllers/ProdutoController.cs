using Data;
using lojaN_1Application.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lojaN_1Application.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly ClienteContext _context;

        public ProdutoController(ClienteContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> CadastraProduto([FromBody] Produto produto)
        {
            var cadProduto = new Produto
            {                
                NomeProduto = produto.NomeProduto,
                Marca = produto.Marca,
                Tamanho = produto.Tamanho,
                Cor = produto.Cor,
                Preco = produto.Preco
            };

            _context.Produtos.Add(cadProduto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(ConsultaProdutoPorId), new { cadProduto.CodProduto });
        }

        [HttpGet]
        public async Task<ActionResult<List<Produto>>> ConsultaProdutos()
        {
            var produtos = await _context.Produtos.ToListAsync();
            if (produtos == null)
                return NotFound();

            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> ConsultaProdutoPorId(int id)
        {
            var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.CodProduto == id);
            if(produto == null)
                return NotFound();

            return Ok(produto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> AtualizaProduto(int id, Produto produto)
        {
            Produto cadProduto = await _context.Produtos.FirstOrDefaultAsync(p => p.CodProduto == id);
            if(cadProduto == null)
                return NotFound();

            cadProduto.NomeProduto = produto.NomeProduto;
            cadProduto.Tamanho = produto.Tamanho;
            cadProduto.Preco = produto.Preco;
            cadProduto.Cor = produto.Cor;
            cadProduto.Marca = produto.Marca;

            _context.Update(cadProduto);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletaProduto(int id)
        {
            var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.CodProduto == id);
            if(produto == null) return NotFound();

            _context.Remove(produto);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
