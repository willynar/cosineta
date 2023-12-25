using static Entities.Enums.StoreProcedures;

namespace Logic.Dao
{
    public class LStoreProcedures : IStoredProceduresService
    {
        public string GetProcedureName(Procedures procedure) => procedure switch
        {
            Procedures.PaginatedProduct => "[dbo].[paginated_products]",
            _ => "Procedimiento almacenado no agregado",
        };
    }
}
