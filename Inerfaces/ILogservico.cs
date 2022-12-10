using Microsoft.VisualBasic;
using System;
using System.Threading.Tasks;

namespace APIMaisEventos.Inerfaces
{
    public interface ILogservico
    {
        Task SalvarLog(DateTime Data, int TipoEvento, string Mensagem, string Exception);
    }
}
