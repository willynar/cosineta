using Entities.Administration;
using Entities.ViewModels;

namespace Entities.Interfaces
{
    public interface ILLogin
    {
        Task<TokenViewModel> BuildToken(ApplicationUser entity);
        Task CloseSesion(string userId);
    }
}
