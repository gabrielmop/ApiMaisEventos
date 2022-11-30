using APIMaisEventos.Inerfaces;
using System.Collections.Generic;
using ApiMaisEventos.Models;
using System.Data.SqlClient;
using System.Data;

namespace APIMaisEventos.Repositories
{
    public class UsuarioRepository : IusuarioRepository
    {

        //Criar String de conexão com o DB
        readonly string connectionString = "data source=MOOP_PC;Integrated Security =true;Initial Catalog=MaisEventos";

        public bool Delete(int id)
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
                    int linhasafetadas = cmd.ExecuteNonQuery();
                    if (linhasafetadas == 0)
                    {
                        return false;
                    }
                }

            }
            return true;
        }

        public ICollection<Usuarios> GetAll()
        {
            var usuario = new List<Usuarios>();
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {

                conexao.Open();

                string consulta = "Select * from Usuarios";

                using (SqlCommand cmd = new SqlCommand(consulta, conexao))
                {
                    //ler todos os itens da consulta
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
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
            return usuario;
        }
        public Usuarios GetBy(int id)
        {
            var usuario = new Usuarios();
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {

                conexao.Open();

                string consulta = "Select * from Usuarios where id=@id";



                using (SqlCommand cmd = new SqlCommand(consulta, conexao))
                {
                    cmd.Parameters.Add("@id", System.Data.SqlDbType.NVarChar).Value = id;
                    //ler todos os itens da consulta
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                         
                            {
                                usuario.Id = (int)reader[0];
                                usuario.Nome = (string)reader[1];
                                usuario.email = (string)reader[2];
                                usuario.senha = (string)reader[3];

                            }
                        }
                    }
                }
            }
            return usuario;
        }

        public Usuarios Insert(Usuarios User)
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
                return User;
            }


        }

        public Usuarios Update(int id, Usuarios User)
        {
            SqlConnection conexao = new SqlConnection(connectionString);
            conexao.Open();

            string query = "Update Usuarios Set Nome=@Nome, Email=@Email,Senha=@Senha Where Id=@id";



            // Criamos o comando de execução no banco
            using (SqlCommand cmd = new SqlCommand(query, conexao))
            {
                //Fazemos as declarações das variaveis por parametros
                cmd.Parameters.Add("@id", System.Data.SqlDbType.NVarChar).Value = id;
                cmd.Parameters.Add("@nome", System.Data.SqlDbType.NVarChar).Value = User.Nome;
                cmd.Parameters.Add("@email", System.Data.SqlDbType.NVarChar).Value = User.email;
                cmd.Parameters.Add("@senha", System.Data.SqlDbType.NVarChar).Value = User.senha;

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                User.Id = id;
            }
            return User;
        }
    }
}
