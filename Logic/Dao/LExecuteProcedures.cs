using Microsoft.Data.SqlClient;
using System.Data;
using static Entities.Enums.StoreProcedures;

namespace Logic.Dao
{
    public class LExecuteProcedures : IExecuteProceduresService
    {
        public IDaoService Dao;

        public IConfiguration Configuration;

        public LExecuteProcedures(IDaoService dao, IConfiguration configuration)
        {
            Dao = dao;
            Configuration = configuration;
        }

        public async Task<DataTable> GetPaginatedProducts(SqlParameter[] parameters) => (await Dao.ProcedureAccessAsync(Configuration, Procedures.PaginatedProduct, parameters)).Tables[0];
    }
}
