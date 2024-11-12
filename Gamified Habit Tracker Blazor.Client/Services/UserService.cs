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
    public async Task<User> GetUserByID(int user_id)
    {
        var response = await _httpClient.GetFromJsonAsync<User>($"api/User/{user_id}");
        return response;
    }
    public async Task<Level> GetUserLevel(int user_id)
    {
        var response = await _httpClient.GetFromJsonAsync<Level>($"api/User/{user_id}/level");
        return response;
    }
}

