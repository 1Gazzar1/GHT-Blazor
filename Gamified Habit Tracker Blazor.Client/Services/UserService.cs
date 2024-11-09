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
        var response = await _httpClient.PostAsJsonAsync("api/User", user);
        response.EnsureSuccessStatusCode();
    }
	public async Task<bool> UserExists(UserDTO userInfo)
	{
		var response = await _httpClient.PostAsJsonAsync("api/User/UserExists", userInfo);
		response.EnsureSuccessStatusCode();
		return await response.Content.ReadFromJsonAsync<bool>();
		
        
	}
}

