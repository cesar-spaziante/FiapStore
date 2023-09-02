using FiapStore.Controllers.Entity;
using System.Reflection.Metadata.Ecma335;

namespace FiapStore.Controllers.Interface
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario ObterComPedidos(int id);
    }
}
