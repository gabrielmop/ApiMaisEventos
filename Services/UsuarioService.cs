using ApiMaisEventos.Models;
using APIMaisEventos.Inerfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APIMaisEventos.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IusuarioRepository _usuarioRepository;
        private readonly ILogservico _logservico;



        public UsuarioService(IusuarioRepository usuarioRepository, ILogservico logservico)
        {
            _usuarioRepository = usuarioRepository;
            _logservico = logservico;
        }

        public async Task Alterar(int Id, Usuarios usuario)
        {
            try
            {


                usuario.senha = HashPass(usuario.senha);

                if (await _usuarioRepository.GetBy(Id) != null)
                    await _usuarioRepository.Update(usuario);
                _logservico.SalvarLog(DateTime.Now, 0, $"O usuario {usuario.Nome} Alterou Dados Cadastrais", null);
            }
            catch (Exception ex)
            {
                _logservico.SalvarLog(DateTime.Now, 1, string.Empty, ex.Message);
            }
            
        }

        private string HashPass(string senha)
        {
            byte[] pass = System.Text.Encoding.ASCII.GetBytes(senha);
            byte[] data = new System.Security.Cryptography.SHA256Managed().ComputeHash(pass);
            return System.Text.Encoding.ASCII.GetString(data);
        }

        public async Task<Usuarios> BuscarPorid(int Id)
        {
            try
            {
                return await _usuarioRepository.GetBy(Id);
            }
            catch (Exception ex)
            {
                _logservico.SalvarLog(DateTime.Now,1,string.Empty, ex.Message);
                return null;
            }
        }
        

        public async Task Cadastrar(Usuarios usuario)
        {
            try
            {
                usuario.senha = HashPass(usuario.senha);
                await _usuarioRepository.Insert(usuario);
               

                _logservico.SalvarLog(DateTime.Now, 0, $"O Usuario {usuario.Nome} Foi cadastrado", null);
            }
         
            catch (Exception ex)
            {
                _logservico.SalvarLog(DateTime.Now,1,"", ex.Message);
            }
        }

        public async Task Deletar(int Id)
        {
            try
            {
                if (await _usuarioRepository.GetBy(Id) != null)
                    await _usuarioRepository.Delete(Id);

                _logservico.SalvarLog(DateTime.Now, 0, $"O usuario de Id {Id} foi apagado", null);
            }
            catch (Exception ex)
            {
                _logservico.SalvarLog(DateTime.Now, 1, "", ex.Message);
            }
        }

        public async Task<List<Usuarios>> Listar()
        {
            return await _usuarioRepository.GetAll();
        }

        public async Task<bool> SeachUserByName(string Nome, string Senha)
        {
            Usuarios User = new Usuarios();
            string SennhaCodificada;

           User = await _usuarioRepository.SearchUserByName(Nome);

           SennhaCodificada = HashPass(Senha);

            if (SennhaCodificada == User.senha)
            {
                return true;
            }
            else
                return false;

        }



    }
}
