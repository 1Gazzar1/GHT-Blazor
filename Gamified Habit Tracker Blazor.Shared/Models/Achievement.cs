namespace GamifiedHabitTracker.Models
{
    public class Achievement
    {
        [Key]
        public int AchievementID { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public int PointsForCompletion { get; set; }
        [Required]
        public string? Description { get; set; }

        [JsonIgnore]
        public List<UserAchievement>? UserAchievements { get; set; }
    }
}