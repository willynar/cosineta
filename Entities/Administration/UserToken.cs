namespace Entities.Administration
{
    public class UserToken
    {
        [Key]
        public int Id { get; set; }

        [Required, ForeignKey("User"), StringLength(450)]
        public string? UserId { get; set; }

        [Required]
        public string Token { get; set; } = string.Empty;

        [JsonIgnore]
        public virtual ApplicationUser? User { get; set; }
    }
}
