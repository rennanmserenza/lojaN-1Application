using Data;
using lojaN_1Application.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lojaN_1Application.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly ClienteContext _context;

        public PessoaController(ClienteContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Pessoa>> CadastraPessoa(Pessoa pessoa)
        {
            var novaPessoa = new Pessoa
            {
                NomePessoa = pessoa.NomePessoa,
                CodGrupo = pessoa.CodGrupo
            };

            _context.Add(novaPessoa);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(ConsultaPessoaPorId), new { novaPessoa.CodPessoa });
        }

        [HttpGet]
        public async Task<ActionResult<List<Pessoa>>> ConsultaPessoas()
        {
            List<Pessoa> pessoas = await _context.Pessoas.ToListAsync();
            if (pessoas == null)
                return NotFound();

            return Ok(pessoas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pessoa>> ConsultaPessoaPorId(int id)
        {
            var pessoa = await _context.Pessoas.FirstOrDefaultAsync(p => p.CodPessoa == id);
            if(pessoa == null)
                return NotFound();

            return Ok(pessoa);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> AtualizaCadastroPessoa(int id, [FromBody] Pessoa cadPessoa)
        {
            var pessoa = await _context.Pessoas.FirstOrDefaultAsync(p => p.CodPessoa == id);
            if(pessoa == null)
                return NotFound();

            pessoa.NomePessoa = cadPessoa.NomePessoa;
            pessoa.CodGrupo = cadPessoa.CodGrupo;

            _context.Update(pessoa);
            await _context.SaveChangesAsync();
            return Ok(pessoa);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveCadastroPessoa(int id)
        {
            var pessoa = await _context.Pessoas.FirstOrDefaultAsync(p => p.CodPessoa == id);
            if (pessoa == null)
                return NotFound();

            _context.Remove(pessoa);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
