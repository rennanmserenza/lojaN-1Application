using Data;
using Microsoft.AspNetCore.Mvc;
using Models;
using Microsoft.EntityFrameworkCore;
using lojaN_1Application.API.Interfaces;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly ClienteContext _clientesContext;
        private readonly ISecurityService _securityService;

        public ClientesController(ClienteContext clientesContext, ISecurityService securityService)
        {
            _clientesContext = clientesContext;
            _securityService = securityService;
        }

        #region CRUD
        // GET: api/clientes
        [HttpGet(Name = "GetClientes")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return await _clientesContext.Clientes.ToListAsync();
        }

        // GET: api/clientes/5
        [HttpGet("{id}", Name = "GetCliente")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _clientesContext.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        // POST: api/clientes
        [HttpPost(Name = "PostCliente")]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            var isEquals = _securityService.ComparaSenha(cliente.Senha, cliente.ConfirmaSenha);

            if(!isEquals)
            {
                return BadRequest("As senhas não conferem");
            }

            cliente.Senha = _securityService.EncriptaSenha(cliente.Senha);
            cliente.SenhaHash = _securityService.EncriptaSenha(cliente.Senha);

            var novoCliente = new Cliente
            {
                Nome = cliente.Nome,
                Endereco = cliente.Endereco,
                Email = cliente.Email,
                Senha = cliente.Senha,
                SenhaHash = cliente.SenhaHash,
            };

            _clientesContext.Clientes.Add(novoCliente);
            await _clientesContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCliente), new { id = novoCliente.CodCliente }, novoCliente);
        }

        // PUT: api/clientes/5
        [HttpPut("{id}", Name = "PutCliente")]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
            if (id != cliente.CodCliente)
            {
                return BadRequest();
            }

            _clientesContext.Entry(cliente).State = EntityState.Modified;
            await _clientesContext.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/clientes/5
        [HttpDelete("{id}", Name = "DeleteCliente")]
        public async Task<ActionResult> DeleteCliente(int id)
        {
            var cliente = await _clientesContext.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            _clientesContext.Clientes.Remove(cliente);
            await _clientesContext.SaveChangesAsync();

            return NoContent();
        }
        #endregion

        // retorno de teste
        [HttpGet("teste")]
        public string Teste()
        {
            return "Hello World!";
        }
    }
}
