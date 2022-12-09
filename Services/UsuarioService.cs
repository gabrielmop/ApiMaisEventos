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
        public UsuarioService(IusuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task Alterar(int Id, Usuarios usuario)
        {

            usuario.senha = HashPass(usuario.senha);

            if(await _usuarioRepository.GetBy(Id) != null)  
                await _usuarioRepository.Update(usuario);
        }

        private string HashPass(string senha)
        {
            byte[] pass = System.Text.Encoding.ASCII.GetBytes(senha);
            byte[] data = new System.Security.Cryptography.SHA256Managed().ComputeHash(pass);
            return System.Text.Encoding.ASCII.GetString(data);
        }

        public async Task<Usuarios> BuscarPorid(int Id)
        {
           return await _usuarioRepository.GetBy(Id);
        }

        public async Task Cadastrar(Usuarios usuario)
        {
            await _usuarioRepository.Insert(usuario);
        }

        public async Task Deletar(int Id)
        {
            if (await _usuarioRepository.GetBy(Id) != null)
                await _usuarioRepository.Delete(Id);
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
