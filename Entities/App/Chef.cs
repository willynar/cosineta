namespace Entities.App
{
    public class Chef
    {
        [Key, StringLength(50)]
        public string Id { get; set; } = string.Empty;

        [Required, StringLength(200)]
        public string Name { get; set; } = string.Empty;

        [StringLength(15)]
        public string? Phone { get; set; }

        [StringLength(15)]
        public string? Cellphone { get; set; }

        [StringLength(50)]
        public string? Email { get; set; }

        [StringLength(200)]
        public string? Image { get; set; }

        [StringLength(200)]
        public string? Cover { get; set; }

        [StringLength(20)]
        public string? Gender { get; set; }

        [StringLength(100)]
        public string? Nationality { get; set; }

        [StringLength(100)]
        public string? Country { get; set; }

        [StringLength(100)]
        public string? Department { get; set; }

        [StringLength(5)]
        public string Status { get; set; } = string.Empty;

        public bool Certified { get; set; }

        public string? CertifiedMessage { get; set; }

        public string? Description { get; set; }

        public bool Active { get; set; }
    }
}
