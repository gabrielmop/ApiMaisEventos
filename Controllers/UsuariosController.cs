using ApiMaisEventos.Models;
using APIMaisEventos.Inerfaces;
using APIMaisEventos.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ApiMaisEventos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IusuarioRepository _usarioRepository;
        public UsuariosController(IusuarioRepository usuarioRepository) 
        {
            _usarioRepository = usuarioRepository;
        }

        //Post - Cadastrar
        /// <summary>
        /// Cadastra usuarios na aplicação
        /// </summary>
        /// <param name="User">Dados do usuario</param>
        /// <returns>Dados do Usuario cadastrado</returns>
        [HttpPost]
        public async Task<IActionResult> Cadastrar(Usuarios User)
        {
            try
            {
                await _usarioRepository.Insert(User);
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
        public async Task<IActionResult> Listar()
        {
            try
            {
                
               var Usuarios = await _usarioRepository.GetAll();
                                                   
                return Ok(Usuarios);
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

        [HttpGet("{Id}")]
        public async Task<IActionResult> BuscarPorid(int Id)
        {
            try
            {
                var Usuarios = await _usarioRepository.GetBy(Id);

                return Ok(Usuarios);
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
        public async Task<IActionResult> Alterar(int id, Usuarios usuario)
        {
            try
            {
                var BuscarUsuario = _usarioRepository.GetBy(id);
                if(BuscarUsuario == null)
                {
                    return NotFound();
                }
                else
                {
                    var userAlterado = _usarioRepository.Update(usuario);
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


        //Delete - Excluir
        /// <summary>
        /// Apaga Usuarios do Banco de dados
        /// </summary>
        /// <param name="id">Id do Usuario</param>
        /// <returns>Usuario apagado</returns>
        [HttpDelete("/{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            try
            {
                var BuscarUsuario = await _usarioRepository.GetBy(id);
                if (BuscarUsuario == null)
                {
                    return NotFound();
                }
                _usarioRepository.Delete(id);
                return Ok(new
                {
                    mgs = "Usuario Excluido com sucesso"
                });
                


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


        // Repository Pattern


    }
}
