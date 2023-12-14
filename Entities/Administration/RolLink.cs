namespace Entities.Administration
{
    public class RolLink
    {
        [Key]
        public int RolLinkId { get; set; }
        public bool Consult { get; set; }
        public bool Save { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }
        public bool Especial { get; set; }

        [Required, ForeignKey("ApplicationRole")]
        public required string RoleId { get; set; }

        [Required, ForeignKey("Link")]
        public required string LinkId { get; set; }
        public virtual ApplicationRole? ApplicationRoleIdNavigation { get; set; }
        public virtual Link? LinkIdNavigation { get; set; }
    }
}
