using ApiMaisEventos.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIMaisEventos.Inerfaces
{
    public interface IUsuarioService
    {
        Task Cadastrar(Usuarios usuario);
        Task<List<Usuarios>> Listar();
        Task<Usuarios> BuscarPorid(int Id);
        Task Alterar(int id, Usuarios usuario);
        Task Deletar(int id);
        Task<bool> SeachUserByName(string Nome, string Senha);
    }
}
