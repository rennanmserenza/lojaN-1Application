using Data;
using Microsoft.AspNetCore.Mvc;
using Models;
using Microsoft.EntityFrameworkCore;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly ClienteContext _clientesContext;
        private readonly ILogger<ClientesController> _logger;

        public ClientesController(ClienteContext clientesContext, ILogger<ClientesController> logger)
        {
            _clientesContext = clientesContext;
            _logger = logger;
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
            _clientesContext.Clientes.Add(cliente);
            await _clientesContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCliente), new { id = cliente.Id }, cliente);
        }

        // PUT: api/clientes/5
        [HttpPut("{id}", Name = "PutCliente")]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
            if (id != cliente.Id)
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
