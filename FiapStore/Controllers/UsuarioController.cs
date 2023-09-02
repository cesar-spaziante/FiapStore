using FiapStore.Controllers.Entity;
using FiapStore.Controllers.Interface;
using FiapStore.DTOs;
using FiapStore.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FiapStore.Controllers
{
    [ApiController] //avisando que a Controller e do tipo API 
    [Route("usuario")] //definindo os endpoints
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
           
        }

        [HttpGet("obterTodosComPedidos/{id}")]
        public IActionResult ObterTodosComPedidos(int id) {

            return Ok(_usuarioRepository.ObterComPedidos(id));
        }

        [HttpGet("obterTodosUsuarios")]
        public IActionResult ObterTodosUsuarios() {
        return Ok(_usuarioRepository.ObterTodos());
        }

        [HttpGet("obterPorUsuarioID/{id}")]
        public IActionResult ObterPorUsuarioID(int id)
        {
            return Ok(_usuarioRepository.ObterPorId(id));
        }

        [HttpPost]
        public IActionResult CadastrarUsuario(CadastrarUsuarioDTO usuarioDTO)
        {
            _usuarioRepository.Cadastrar(new Usuario(usuarioDTO));
            return Ok("Usuário criado com sucesso!");
        }

        [HttpPut]
        public IActionResult AlterarUsuario(AlterarUsuarioDTO usuarioDTO)
        {
            _usuarioRepository.Alterar(new Usuario(usuarioDTO));
            return Ok("Usuário alterado com sucesso!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarUsuario(int id)
        {
            _usuarioRepository.Deletar(id);
            return Ok("Usuário deletado com sucesso!");
        }

    }
}
