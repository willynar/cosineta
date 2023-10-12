using Entities.Administration;

namespace Entities.Interfaces
{
    public interface ILUserToken
    {
        Task Delete(UserToken entity);
        Task<UserToken?> GetById(string userId);
        Task Save(UserToken entity);
    }
}
