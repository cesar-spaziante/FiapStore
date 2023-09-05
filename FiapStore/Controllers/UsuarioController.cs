using FiapStore.Controllers.Entity;
using FiapStore.Controllers.Interface;
using FiapStore.DTOs;
using FiapStore.Enums;
using FiapStore.Repository;
using Microsoft.AspNetCore.Authorization;
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

        /// <summary>
        /// Obtem todos os usuários com Pedido
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <remarks>Exemplo de Requisição:
        /// Enviar ID para requisição
        /// </remarks>
        /// <response code ="200">RetornaSucesso</response>
        /// <response code ="401">Não Autenticado</response>
        /// <response code ="403">Não Autorizado</response>
        [Authorize]
        [HttpGet("obterTodosComPedidos/{id}")]
        public IActionResult ObterTodosComPedidos(int id) {

            return Ok(_usuarioRepository.ObterComPedidos(id));
        }

        [Authorize]
        [Authorize(Roles = Permissoes.Administrador)]
        [HttpGet("obterTodosUsuarios")]
        public IActionResult ObterTodosUsuarios() {

            try 
            {
                return Ok(_usuarioRepository.ObterTodos());
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, $"{DateTime.Now:yyyy-mm-dd} Exception forçada: {ex.Message}");
                return BadRequest();
             }
        
        }

        [Authorize]
        [Authorize(Roles = Permissoes.Funcionario)]
        [HttpGet("obterPorUsuarioID/{id}")]
        public IActionResult ObterPorUsuarioID(int id)
        {
            _logger.LogInformation("Executando método obterPorUsuarioID");
            
            return Ok(_usuarioRepository.ObterPorId(id));
        }

        [Authorize]
        [Authorize($"{Permissoes.Funcionario}, {Permissoes.Administrador}")]
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
