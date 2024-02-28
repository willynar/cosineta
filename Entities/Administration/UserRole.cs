namespace Entities.Administration
{
    public class UserRole
    {
        [Key]
        public int UserRoleId { get; set; }

        [ForeignKey("ApplicationRole")]
        public string? RoleId { get; set; }

        [Required, ForeignKey("ApplicationUser")]
        public required string ApplicationUserId { get; set; }

        [JsonIgnore]
        public virtual ApplicationRole? ApplicationRoleIdNavigation { get; set; }

        [JsonIgnore]
        public virtual ApplicationUser? ApplicationUserIdNavigation { get; set; }
    }
}
