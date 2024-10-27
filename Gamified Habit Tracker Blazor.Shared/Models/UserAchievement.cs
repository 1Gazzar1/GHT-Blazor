namespace GamifiedHabitTracker.Models
{
    public class UserAchievement
    {
        [Key]
        public int UserAchievementID { get; set; }
        public int UserID { get; set; }
        public User? User { get; set; }
        public int AchievementID { get; set; }
        public Achievement? Achievement { get; set; }

        
        public bool Status { get; set; } = false;
        public DateTime? DateEarned { get; set; }
    }
}
