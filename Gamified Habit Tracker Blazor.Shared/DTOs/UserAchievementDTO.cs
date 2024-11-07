namespace GamifiedHabitTracker.DTOs
{
	public class UserAchievementDTO
	{
        public int AchievementID { get; set; }
		public string? Name { get; set; }
		public int PointsForCompletion { get; set; }
		public string? Description { get; set; }
		public bool Status { get; set; }
		public DateTime? DateEarned { get; set; }
	}
}
