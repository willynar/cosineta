namespace Entities.App
{
    public class UserSchedule
    {
        [Key]
        public int UserScheduleId { get; set; }

        public int StarTime { get; set; }

        public int EndTime { get; set; }

        [Required, ForeignKey("ApplicationUser")]
        public required string ApplicationUserId { get; set; }

        [JsonIgnore]
        public virtual ApplicationUser? ApplicationUserIdNavigation { get; set; }
    }
}
