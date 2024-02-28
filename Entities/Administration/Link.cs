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

        [JsonIgnore]
        public virtual Module? ModuleIdNavigation { get; set; }

        [JsonIgnore]
        public virtual ICollection<RolLink> RolLinks { get; } = new List<RolLink>();

    }
}
