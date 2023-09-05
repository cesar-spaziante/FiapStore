using Dapper;
using FiapStore.Controllers.Entity;
using FiapStore.Controllers.Interface;
using MySql.Data.MySqlClient;


namespace FiapStore.Repository
{
    public class UsuarioRepository : DapperRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public override void Alterar(Usuario entidade)
        {
            using var dbConnection = new MySqlConnection(ConnectionString);
            var query = "UPDATE usuario SET Nome = @Nome Where Id = @Id";
            dbConnection.Query(query, entidade);
        }

        public override void Cadastrar(Usuario entidade)
        {
            using var dbConnection = new MySqlConnection(ConnectionString);
            var query = "INSERT INTO usuario (Nome) Values(@Nome)";
            dbConnection.Execute(query, entidade);
        }

        public override void Deletar(int id)
        {
            using var dbConnection = new MySqlConnection(ConnectionString);
            var query = "DELETE FROM usuario WHERE Id = @Id";
            dbConnection.Execute(query, new { Id = id });
        }

        public override Usuario ObterPorId(int id)
        {
            using var dbConnection = new MySqlConnection(ConnectionString);
            var query = "SELECT * FROM usuario WHERE Id = @Id";
            return dbConnection.Query<Usuario>(query, new { Id = id }).FirstOrDefault();
        }

        public override IList<Usuario> ObterTodos()
        {
            using var dbConnection = new MySqlConnection(ConnectionString);
            var query = "SELECT * FROM usuario";
            return dbConnection.Query<Usuario>(query).ToList();
        }

        public Usuario ObterComPedidos(int id)
        { 
            using var dbConnection = new MySqlConnection(ConnectionString);
            var query = "SELECT usuario.Id, usuario.Nome, pedido.Id, pedido.NomeProduto, pedido.UsuarioId " +
                        "FROM usuario LEFT JOIN pedido ON usuario.Id = pedido.UsuarioId " +
                        "WHERE usuario.Id = @Id";
            var resultado = new  Dictionary<int, Usuario>();
            var parametros = new { Id = id };

            dbConnection.Query<Usuario, Pedido, Usuario>(query, 
                (usuario, pedido) => {
                    if (!resultado.TryGetValue(usuario.Id, out var usuarioExistente))
                    {
                        usuarioExistente = usuario;
                        usuarioExistente.Pedidos = new List<Pedido>();
                        resultado.Add(usuario.Id, usuarioExistente);
                    }

                    if (pedido != null)
                    { 
                    usuarioExistente.Pedidos.Add(pedido);
                    }

                    return usuarioExistente;    

                }, parametros, splitOn: "Id");
            return resultado.Values.FirstOrDefault();
            
        }

        public Usuario ObterPorNomeUsuarioESenha(string nomeUsuario, string senha)
        {
            throw new NotImplementedException();
        }
    }
    
}
