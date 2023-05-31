using BCrypt.Net;
using lojaN_1Application.API.Interfaces;
using Models;

namespace lojaN_1Application.API.Services
{
    public class SecutiryService : ISecurityService
    {
        public bool ComparaSenha(string senha, string confirmaSenha)
        {
            var isEquals = senha.Trim().Equals(confirmaSenha.Trim());
            return isEquals;
        }

        public string EncriptaSenha(string senha)
        {
            var senhaEncriptada = BCrypt.Net.BCrypt.HashPassword(senha);
            return senhaEncriptada;
        }

        public bool VerificaSenha(string senha, Cliente cliente)
        {
            bool validaSenha = BCrypt.Net.BCrypt.Verify(senha, cliente.SenhaHash);
            return validaSenha;
        }
    }
}
