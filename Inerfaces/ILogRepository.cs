using System.Threading.Tasks;
using System;

namespace APIMaisEventos.Inerfaces
{
    public interface ILogRepository
    {
        Task SalvarLog(DateTime Data, int TipoEvento, string Mensagem, string Exception);
    }
}
