namespace GamifiedHabitTracker.Models
{
    public class Level
    {
        [Key]
        public int LevelID { get; set; }
        [Required]
        public string? Name { get; set; } // 1 - 50 or beginner to advanced  
        [Required]
        public int ExperiencePoints { get; set; }

    }
}