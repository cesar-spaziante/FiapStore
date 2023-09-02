using FiapStore.DTOs;

namespace FiapStore.Controllers.Entity
{
    public class Usuario : Entidade
    {
       
        public string? Nome { get; set; }
        public ICollection<Pedido> Pedidos { get; set; }


        public Usuario()
        {
            
        }
        public Usuario(CadastrarUsuarioDTO cadastrarUsuarioDTO)
        {
            Nome = cadastrarUsuarioDTO.Nome;
        }

        public Usuario(AlterarUsuarioDTO alterarUsuarioDTO)
        {
            Id = alterarUsuarioDTO.Id;
            Nome = alterarUsuarioDTO.Nome;

        }


    }

    

}
