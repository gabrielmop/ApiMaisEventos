using APIMaisEventos.Inerfaces;
using System.Collections.Generic;
using ApiMaisEventos.Models;
using System.Data.SqlClient;
using System.Data;
using APIMaisEventos.Inerfaces.Infra;
using APIMaisEventos.Infra;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace APIMaisEventos.Repositories
{
    public class UsuarioRepository : IusuarioRepository
    {
        private readonly IAppSettingsManager _appSettingsManager;
        private readonly ISqlDataContext _sqlDataContext;
        public UsuarioRepository(IAppSettingsManager appSettingsManager, ISqlDataContext sqlDataContext)
        {
            _sqlDataContext = sqlDataContext;
            _appSettingsManager = appSettingsManager;
        }
        //Criar String de conexão com o DB
        readonly string connectionString = "data source=MOOP_PC;Integrated Security =true;Initial Catalog=MaisEventos";

        public async Task Delete(int id)
        {
            await _sqlDataContext.NonQueryToSql("DeletarPorIdUsuario", new Dictionary<string, object>
            { { "@Id", id } });
        }

        public async Task<List<Usuarios>> GetAll()
        {
            IEnumerable<Usuarios> result;
            result = await _sqlDataContext.SelectListFromSql<Usuarios>("SelectAllUsers", null);

            return result.ToList();
        }
        public async Task<Usuarios> GetBy(int id)
        {
            Usuarios result;
            result = await _sqlDataContext.SelectSingleOrDefaultFromSql<Usuarios>("SelectUserByid",
                new Dictionary<string, object> { { "@Id", id } });

            return result;
        }

        public async Task Insert(Usuarios User)
        {
            await _sqlDataContext.NonQueryToSql("InsertUser",
                    new Dictionary<string, object> {
                    {"@Nome", User.Nome },
                    {"@Email", User.email },
                    {"@Senha", User.senha } });
        }

        public async Task Update(Usuarios User)
        {
            await _sqlDataContext.NonQueryToSql("UpdateUserById",
                    new Dictionary<string, object> {
                    { "@Nome", User.Nome }, {"@Email", User.email },
                    { "@Senha", User.senha } });
        }

        public async Task<Usuarios> SearchUserByName(string Nome)
        {
            Usuarios result;
            result = await _sqlDataContext.SelectSingleOrDefaultFromSql<Usuarios>("BuscarUsuarioPorNome",
                new Dictionary<string, object> { { "@Nome", Nome } });

            return result;
        }
    }
}
