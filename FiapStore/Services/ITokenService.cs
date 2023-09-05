using FiapStore.Controllers.Entity;

namespace FiapStore.Services
{
    public interface ITokenService
    {

        string GerarToken(Usuario usuario);
    }
}
