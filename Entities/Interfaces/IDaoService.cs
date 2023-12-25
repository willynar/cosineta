using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using static Entities.Enums.StoreProcedures;
using System.Data;

namespace Entities.Interfaces
{
    public interface IDaoService
    {
        Task<DataSet> ProcedureAccessAsync(IConfiguration Configurationstring, Procedures Procedure, params SqlParameter[] Parameters);
    }
}
