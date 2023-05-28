using Data;
using lojaN_1Application.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lojaN_1Application.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FuncionarioController : ControllerBase
    {
        private readonly ClienteContext _context;

        public FuncionarioController(ClienteContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> CadastraFuncionario(Funcionario func)
        {
            var funcionario = new Funcionario
            {
                CodPessoa = func.CodPessoa
            };

            _context.Add(funcionario);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(ConsultaFuncionarioPorId), new { funcionario.CodFuncionario });
        }

        [HttpGet]
        public async Task<ActionResult<List<Funcionario>>> ConsultaFuncionario()
        {
            var funcionario = await _context.Funcionarios.ToListAsync();
            if(funcionario == null)
                return NotFound();

            return Ok(funcionario);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Funcionario>> ConsultaFuncionarioPorId(int id)
        {
            var funcionario = await _context.Funcionarios.FirstOrDefaultAsync(f => f.CodFuncionario == id);
            if(funcionario == null)
                return NotFound();

            return Ok(funcionario);
        }
    }
}
