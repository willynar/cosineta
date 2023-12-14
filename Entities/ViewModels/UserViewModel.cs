namespace Entities.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<ApplicationRole> Rols { get; set; } = new();
        public List<RolLink> Modules { get; set; } = new();
    }
}
