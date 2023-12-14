namespace Entities.Administration
{
    public class Link
    {
        [Key]
        public int LinkId { get; set; }
        public required string Descripcion { get; set; }
        public required string Navegacion { get; set; }
        [Required, ForeignKey("Module")]
        public required int ModuleId { get; set; }
        public virtual Module? ModuleIdNavigation { get; set; }
        public virtual ICollection<RolLink> RolLinks { get; } = new List<RolLink>();

    }
}
