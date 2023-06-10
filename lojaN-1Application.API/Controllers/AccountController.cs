using Data;
using Microsoft.AspNetCore.Mvc;
using Models;
using Microsoft.EntityFrameworkCore;
using lojaN_1Application.API.Interfaces;
using lojaN_1Application.API.Models;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ClienteContext _clientesContext;
        private readonly ISecurityService _securityService;

        public AccountController(ClienteContext clientesContext, ISecurityService securityService)
        {
            _clientesContext = clientesContext;
            _securityService = securityService;
        }

        // POST: api/clientes
        [HttpPost(Name = "Login")]
        public async Task<IActionResult> Cadastrar(string name, string email, string password)
        {
            try
            {
                var pessoa = await _clientesContext.Clientes.FindAsync(email);
                if (pessoa != null)
                    return NoContent();

                var cadastro = new Cliente()
                {
                    Nome = name,
                    Email = email,
                    Senha = password,
                    SenhaHash = _securityService.EncriptaSenha(password),
                };

                await _clientesContext.Clientes.AddAsync(cadastro);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }

        // POST: api/clientes
        [HttpPost(Name = "Login")]
        public async Task<IActionResult> Login(IFormCollection form)
        {
            try
            {
                var login = form["login_username"][0];
                var senha = form["login_password"][0];

                if (login == null || senha == null)
                    return NoContent();

                var usuario = await _clientesContext.Clientes.FindAsync(login);
                if (usuario == null)
                    return NotFound();

                return Ok(_securityService.VerificaSenha(senha, usuario));
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
