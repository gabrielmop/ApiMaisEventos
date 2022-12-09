using ApiMaisEventos.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIMaisEventos.Inerfaces
{
    public interface IusuarioRepository
    {
        //CRUD
        //Read
        Task<List<Usuarios>> GetAll();
        Task<Usuarios> GetBy(int id);
        //Create
        Task Insert(Usuarios User);
        //Update
        Task Update(Usuarios User);
        //Delete
        Task Delete(int id);
    }
}
