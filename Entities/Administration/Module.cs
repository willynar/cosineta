namespace Entities.Administration
{
    public class Module
    {
        public int ModuleId { get; set; }

        public required string Name { get; set; }

        public required string Description { get; set; }

        [JsonIgnore]
        public virtual ICollection<Link> Links { get; } = new List<Link>();

    }
}
