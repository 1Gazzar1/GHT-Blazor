namespace Gamified_Habit_Tracker_Blazor.Services;

public class UserService
{
	private readonly HttpClient _httpClient;
    public UserService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task RegisterUser(User user)
    {
        var response = await _httpClient.PostAsJsonAsync("api/User",user);
        response.EnsureSuccessStatusCode();
    }
}

