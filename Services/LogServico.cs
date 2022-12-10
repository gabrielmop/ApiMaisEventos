using System.Threading.Tasks;
using System;
using APIMaisEventos.Inerfaces;
using System.Security.Cryptography.X509Certificates;
using APIMaisEventos.Repositories;

namespace APIMaisEventos.Services
{
    public class LogServico : ILogservico
    {

        public readonly ILogRepository _logRepository;
         public LogServico(ILogRepository logRepository)
        {
            _logRepository = logRepository; 
        }


        public async Task SalvarLog(DateTime Data, int TipoEvento, string Mensagem, string Exception)
        {
             await _logRepository.SalvarLog(Data, TipoEvento, Mensagem, Exception);
        }
    }
}
