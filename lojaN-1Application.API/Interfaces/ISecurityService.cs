using Models;

namespace lojaN_1Application.API.Interfaces
{
    public interface ISecurityService
    {
        public bool ComparaSenha(string senha, string confirmaSenha);
        public string EncriptaSenha(string senha);
        public bool VerificaSenha(string senha, Cliente cliente);
    }
}
