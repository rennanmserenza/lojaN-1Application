using Models;
using lojaN_1Application.API.Interfaces;

namespace lojaN_1Application.API.Services
{
    public class SecutiryService : ISecurityService
    {
        public bool ComparaSenha(string senha, string confirmaSenha)
        {
            return senha.Trim().Equals(confirmaSenha.Trim());
        }

        public string EncriptaSenha(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        public bool VerificaSenha(string senha, Cliente cliente)
        {
            return BCrypt.Net.BCrypt.Verify(senha, cliente.SenhaHash);
        }
    }
}
