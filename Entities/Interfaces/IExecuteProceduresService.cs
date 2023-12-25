using Microsoft.Data.SqlClient;
using System.Data;

namespace Entities.Interfaces
{
    public interface IExecuteProceduresService
    {
        Task<DataTable> GetPaginatedProducts(SqlParameter[] parameters);
    }
}
