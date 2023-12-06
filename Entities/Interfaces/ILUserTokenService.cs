using Entities.Administration;

namespace Entities.Interfaces
{
    public interface ILUserTokenService
    {
        Task Delete(UserToken entity);
        Task<UserToken?> GetById(string userId);
        Task Save(UserToken entity);
    }
}
