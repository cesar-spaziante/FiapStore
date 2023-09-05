using FiapStore.Controllers.Entity;

namespace FiapStore.Controllers.Interface
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario ObterComPedidos(int id);
        Usuario ObterPorNomeUsuarioESenha(string nomeUsuario, string senha);
    }
}
