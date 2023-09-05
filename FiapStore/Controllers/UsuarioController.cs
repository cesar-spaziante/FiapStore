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
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(IUsuarioRepository usuarioRepository, ILogger<UsuarioController> logger)
        {
            _usuarioRepository = usuarioRepository;
            _logger = logger;
        }

        [HttpGet("obterTodosComPedidos/{id}")]
        public IActionResult ObterTodosComPedidos(int id) {

            return Ok(_usuarioRepository.ObterComPedidos(id));
        }

        [HttpGet("obterTodosUsuarios")]
        public IActionResult ObterTodosUsuarios() {

            try 
            {
                throw new Exception("DEU ERRO");
                return Ok(_usuarioRepository.ObterTodos());
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, $"{DateTime.Now:yyyy-mm-dd} Exception forçada: {ex.Message}");
                return BadRequest();
             }
        
        }

        [HttpGet("obterPorUsuarioID/{id}")]
        public IActionResult ObterPorUsuarioID(int id)
        {
            _logger.LogInformation("Executando método obterPorUsuarioID");
            
            return Ok(_usuarioRepository.ObterPorId(id));
        }

        [HttpPost]
        public IActionResult CadastrarUsuario(CadastrarUsuarioDTO usuarioDTO)
        {

            _logger.LogWarning("Cuida com o tempo da Requisição");
            _usuarioRepository.Cadastrar(new Usuario(usuarioDTO));

            var mensagem = $"USuario cadastrado com sucesso! | Nome: {usuarioDTO.Nome}";
            _logger.LogWarning(mensagem);

            return Ok(mensagem);
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
