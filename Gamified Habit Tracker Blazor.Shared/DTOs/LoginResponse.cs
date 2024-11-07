namespace GamifiedHabitTracker.DTOs;

public class LoginResponse
{
    public string? _token { get; set; }
	public DateTime expiration_date { get; set; }
}

