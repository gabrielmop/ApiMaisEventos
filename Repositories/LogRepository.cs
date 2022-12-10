using APIMaisEventos.Inerfaces;
using APIMaisEventos.Inerfaces.Infra;
using APIMaisEventos.Infra;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIMaisEventos.Repositories
{
    public class LogRepository : ILogRepository
    {
        private readonly ISqlDataContext _sqlDataContext;

        public LogRepository (ISqlDataContext sqlDataContext)
        {
            _sqlDataContext = sqlDataContext;
         
        }

        public async Task SalvarLog(DateTime Data, int TipoEvento, string Mensagem, string Exception)
        {
            try
            {


                await _sqlDataContext.NonQueryToSql("RegistrarLog",
                     new Dictionary<string, object> {
                    {"@Data", Data },
                    {"@TipoEvento", TipoEvento   },
                    {"@Mensagem", Mensagem },
                    {"@Exception", Exception} });
            }
            catch (Exception ex)
            {
              
            }

        }
    }
}
