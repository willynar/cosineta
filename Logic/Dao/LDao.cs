using Microsoft.Data.SqlClient;
using System.Data;
using static Entities.Enums.StoreProcedures;

namespace Logic.Dao
{
    public class LDao:IDaoService
    {
        private readonly IStoredProceduresService IStoredProceduresService;
        public LDao(IStoredProceduresService iStoreProceduresService)
        {
            IStoredProceduresService = iStoreProceduresService;

        }

        public async Task<DataSet> ProcedureAccessAsync(IConfiguration Configurationstring, Procedures Procedure, params SqlParameter[] Parameters)
        {
            DataSet dataset = new();
            try
            {
                using SqlConnection connection = new(Configurationstring.GetConnectionString("DefaultConnection"));
                SqlCommand command = new(IStoredProceduresService.GetProcedureName(Procedure), connection)
                {
                    //ojo ajustar time out en segundos
                    CommandTimeout = 7200,
                    CommandType = CommandType.StoredProcedure
                };

                if (Parameters != null)
                {
                    foreach (SqlParameter item in Parameters)
                        command.Parameters.Add(item);
                }

                SqlDataAdapter dataAdapter = new(command);

                await connection.OpenAsync();
                dataAdapter.Fill(dataset);
                command.Parameters.Clear();
                await connection.CloseAsync();
                return dataset;
            }
            catch (Exception ex)
            {

                if (ex is SqlException)
                {
                    dataset = new();
                    dataset.Tables.Add(DataError(ex));
                    return dataset;
                }
                else
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public DataTable DataError(Exception ex)
        {
            DataTable data = new();
            data.Columns.Add("error");
            data.Columns[0].DataType = typeof(string);
            DataRow Row = data.NewRow();
            Row["error"] = $"error {ex.Message} /// {ex.InnerException}";
            data.Rows.Add(Row);
            return data;
        }
    }
}
