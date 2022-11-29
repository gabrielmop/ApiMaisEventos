using ApiMaisEventos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
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
        /// <summary>
        /// Cadastra usuarios na aplicação
        /// </summary>
        /// <param name="User">Dados do usuario</param>
        /// <returns>Dados do Usuario cadastrado</returns>
        [HttpPost]
        public IActionResult Cadastrar(Usuarios User)
        {
            try
            {
                //Abrir conexão no banco
                using (SqlConnection conexao = new SqlConnection(connectionString))
                {
                    conexao.Open();

                    string query = "INSERT INTO Usuarios (Nome, email, senha) VALUES (@nome, @email, @senha)";


                    // Criamos o comando de execução no banco
                    using (SqlCommand cmd = new SqlCommand(query, conexao))
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
        /// <summary>
        /// Lista todos os usuarios da aplicação
        /// </summary>
        /// <returns>Lista de usuarios</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                var usuario = new List<Usuarios>();
                using(SqlConnection conexao = new SqlConnection(connectionString)) {

                    conexao.Open();

                    string consulta = "Select * from Usuarios";

                    using(SqlCommand cmd = new SqlCommand(consulta, conexao))
                    {
                        //ler todos os itens da consulta
                        using(SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                usuario.Add(new Usuarios
                                {
                                    Id = (int)reader[0],
                                    Nome = (string)reader[1],
                                    email = (string)reader[2],
                                    senha = (string)reader[3],

                                });
                            }
                        }

                    }
                }
                return Ok(usuario);
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




        //put - alterar
        /// <summary>
        /// Altera os Registros dentro do Banco de dados
        /// </summary>
        /// <param name="id">Id do Usuario</param>
        /// <param name="usuario">Todas as inforamações do usuario</param>
        /// <returns>Informações do Usuario modificadas</returns>
        [HttpPut("/{id}")]
        public IActionResult Alterar(int id, Usuarios usuario)
        {
            try
            {
                //Abrir conexão no banco
                using (SqlConnection conexao = new SqlConnection(connectionString))
                {
                    conexao.Open();

                    string query = "Update Usuarios Set Nome=@Nome, Email=@Email,Senha=@Senha Where Id=@id";


                    // Criamos o comando de execução no banco
                    using (SqlCommand cmd = new SqlCommand(query, conexao))
                    {
                        //Fazemos as declarações das variaveis por parametros
                        cmd.Parameters.Add("@id", System.Data.SqlDbType.NVarChar).Value = id;
                        cmd.Parameters.Add("@nome", System.Data.SqlDbType.NVarChar).Value = usuario.Nome;
                        cmd.Parameters.Add("@email", System.Data.SqlDbType.NVarChar).Value = usuario.email;
                        cmd.Parameters.Add("@senha", System.Data.SqlDbType.NVarChar).Value = usuario.senha;

                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        usuario.Id = id;

                    }
                    return Ok(usuario);
                }
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


        //Delete - Excluir
        /// <summary>
        /// Apaga Usuarios do Banco de dados
        /// </summary>
        /// <param name="id">Id do Usuario</param>
        /// <returns>Usuario apagado</returns>
        [HttpDelete("/{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                //Abrir conexão no banco
                using (SqlConnection conexao = new SqlConnection(connectionString))
                {
                    conexao.Open();

                    string query = "Delete from Usuarios Where Id=@id";


                    // Criamos o comando de execução no banco
                    using (SqlCommand cmd = new SqlCommand(query, conexao))
                    {
                        //Fazemos as declarações das variaveis por parametros
                        cmd.Parameters.Add("@id", System.Data.SqlDbType.NVarChar).Value = id;
                      

                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        
                    }
                    return Ok(new
                    {
                        Msg = "Usuario excluido com sucesso"

                    });
                }
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
    }
}
