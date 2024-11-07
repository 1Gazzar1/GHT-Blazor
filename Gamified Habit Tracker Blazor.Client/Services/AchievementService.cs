namespace Gamified_Habit_Tracker_Blazor.Services;
public class AchievementService
{
    private readonly HttpClient _httpClient;
    public AchievementService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<UserAchievementDTO>?> GetAllAchievement(int user_id)
    {
        var achievements = await _httpClient.GetFromJsonAsync<List<UserAchievementDTO>>($"api/Achievement/UserAchievements/{user_id}");
        return achievements;
    }
}

