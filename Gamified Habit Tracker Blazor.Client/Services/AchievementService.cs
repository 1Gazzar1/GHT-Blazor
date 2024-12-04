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
	public async Task<List<bool>> CheckAllAchievements(int user_id)
	{
		var checks = await _httpClient.GetFromJsonAsync<List<bool>>($"api/Achievement/Check/{user_id}");
        return checks ?? new(); 
	}
	public async Task CompleteAchievement(int achievement_id, int user_id)
    {
		var response = await _httpClient.PostAsJsonAsync($"api/Achievement/{achievement_id}/Complete",user_id);
        response.EnsureSuccessStatusCode();
	}
	
}

