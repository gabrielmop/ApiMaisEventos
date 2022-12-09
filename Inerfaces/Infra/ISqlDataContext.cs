using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIMaisEventos.Inerfaces.Infra
{
    public interface ISqlDataContext
    {
        Task<IEnumerable<T>> SelectListFromSql<T>(string ProcedureName, Dictionary<string, object> Parameters = null);
        Task<bool> NonQueryToSql(string proc, Dictionary<string, object> Parameters = null);
        Task<T> SelectSingleOrDefaultFromSql<T>(string ProcedureName, Dictionary<string, object> Parameters = null);
    }
}
