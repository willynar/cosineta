using static Entities.Enums.StoreProcedures;

namespace Entities.Interfaces
{
    public interface IStoredProceduresService
    {
        string GetProcedureName(Procedures procedure);
    }
}
