namespace GamifiedHabitTracker.Models
{
    public class Experience
    {
        [Key]
        public int ExperinceID { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public int Points { get; set; }

        [JsonIgnore]
        public User? User { get; set; }
        
        public int UserID { get; set; }


    }
}