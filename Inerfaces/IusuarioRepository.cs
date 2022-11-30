using ApiMaisEventos.Models;
using System.Collections.Generic;

namespace APIMaisEventos.Inerfaces
{
    public interface IusuarioRepository
    {
        //CRUD
        //Read
        ICollection<Usuarios>GetAll();
        Usuarios GetBy(int id);
        //Create
        Usuarios Insert(Usuarios User);
        //Update
        Usuarios Update(int id, Usuarios User);
        //Delete
        bool Delete(int id);
    }
}
