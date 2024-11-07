namespace GamifiedHabitTracker.Models
{
    public class Habit
    {
        [Key] 
        public int HabitID { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public DateTime CreatedTime { get; set; } = DateTime.Now;

        public DateTime? CompletedTime { get; set; }

        [Required]
        public bool Status { get; set; } = false;
        [Required]
        public int ExperiencePointsReward { get; set; }

        [JsonIgnore]
        public User? User { get; set; }
        
        public int UserID { get; set; }

    }
}
