namespace Entities.ViewModels
{
    public class TokenViewModel
    {
        public bool Success { get; set; }
        public string Token { get; set; } = string.Empty;
        public UserViewModel User { get; set; } = new UserViewModel();
    }
}
