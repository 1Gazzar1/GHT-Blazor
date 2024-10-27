namespace GamifiedHabitTracker.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public int ExpPoints { get; set; }
        [Required]
        public bool HasSkipDay { get; set; } = true;

        [JsonIgnore]
        public List<Habit>? Habits { get; set; }
        [JsonIgnore]
        public Level? Level { get; set; }
        [JsonIgnore]
        public List<Experience>? Experinces { get; set; }
        [JsonIgnore]
        public List<UserAchievement>? UserAchievements { get; set; }
    }
}
