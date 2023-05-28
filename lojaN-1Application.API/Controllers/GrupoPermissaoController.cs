using Controllers;
using Data;
using lojaN_1Application.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lojaN_1Application.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GrupoPermissaoController : ControllerBase
    {
        private readonly ClienteContext _context;

        public GrupoPermissaoController(ClienteContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<StatusPedido>> CadastraGrupoPermissao([FromBody] GrupoPermissao grupo)
        {
            var cadGrupo = new GrupoPermissao
            {
                DescPermissao = grupo.DescPermissao
            };

            _context.GrupoPermissoes.Add(cadGrupo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ConsultaGrupoPermissaoPorId), new { cadGrupo.CodGrupo});
        }

        [HttpGet]
        public async Task<ActionResult<List<GrupoPermissao>>> ConsultaGrupoPermissao()
        {
            var listGrupo = await _context.GrupoPermissoes.ToListAsync();
            if (listGrupo == null)
            {
                return NotFound();
            }

            return Ok(listGrupo);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GrupoPermissao>> ConsultaGrupoPermissaoPorId(int id)
        {
            var cadGrupo = await _context.GrupoPermissoes.FirstOrDefaultAsync(s => s.CodGrupo == id);
            if (cadGrupo == null)
            {
                return NotFound();
            }
            return Ok(cadGrupo);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> AtualizaGrupoPermissao(int id, GrupoPermissao grupo)
        {
            var grupoPerm = await _context.GrupoPermissoes.FirstOrDefaultAsync(s => s.CodGrupo == id);
            if (grupoPerm == null)
                return BadRequest();

            grupoPerm.DescPermissao = grupoPerm.DescPermissao;

            _context.Update(grupoPerm);
            await _context.SaveChangesAsync();
            return Ok(grupoPerm);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveGrupoPermissao(int id)
        {
            var grupo = await _context.GrupoPermissoes.FirstOrDefaultAsync(s => s.CodGrupo == id);
            if (grupo == null)
                return BadRequest();

            _context.Remove(grupo);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
