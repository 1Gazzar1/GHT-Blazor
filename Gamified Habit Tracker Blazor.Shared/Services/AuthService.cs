namespace Gamified_Habit_Tracker_Blazor.Services;

public class AuthService
{
    private readonly HttpClient _httpClient;
    public AuthService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<LoginResponse> Login(LoginDTO login)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Auth/Login", login);
        response.EnsureSuccessStatusCode();
        return (await response.Content.ReadFromJsonAsync<LoginResponse>()) ?? new();
    }

}

