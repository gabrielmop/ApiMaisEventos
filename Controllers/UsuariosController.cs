using ApiMaisEventos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace ApiMaisEventos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        //Criar String de conexão com o DB
        readonly string connectionString = "data source=MOOP_PC;Integrated Security =true;Initial Catalog=MaisEventos";

        //Post - Cadastrar
        [HttpPost]
        public IActionResult Cadastrar(Usuarios User)
        {
            try
            {
                //Abrir conexão no banco
                using (SqlConnection conexao = new SqlConnection(connectionString))
                {
                    conexao.Open();

                    string querry = "INSERT INTO Usuarios (Nome, email, senha) VALUES (@nome, @email, @senha)";


                    // Criamos o comando de execução no banco
                    using (SqlCommand cmd = new SqlCommand(querry, conexao))
                    {
                        //Fazemos as declarações das variaveis por parametros
                        cmd.Parameters.Add("@nome", System.Data.SqlDbType.NVarChar).Value = User.Nome;
                        cmd.Parameters.Add("@email", System.Data.SqlDbType.NVarChar).Value = User.email;
                        cmd.Parameters.Add("@senha", System.Data.SqlDbType.NVarChar).Value = User.senha;

                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }
                }

                return Ok(User);
            }
            catch (System.Exception ex)
            {

                return StatusCode(500, new
                {
                    msg = "Falha na conexão",
                    erro = ex.Message,

                });
            }
        }

        //Get - Listar



        //put - alterar



        //Delete - Excluir


    }
}
