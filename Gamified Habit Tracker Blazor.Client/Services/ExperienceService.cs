namespace Gamified_Habit_Tracker_Blazor.Services;
public class ExperienceService
{
    private readonly HttpClient _httpClient;

    public ExperienceService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<List<Experience>> GetExperiencesByUserID(int user_id)
    {
        var response = await _httpClient.GetFromJsonAsync<List<Experience>>($"api/Experience/user/{user_id}");
        return response ?? new();
    }
    public async Task AddExperiences(int habit_id)
    {
        var response = await _httpClient.PostAsync($"api/Experience/AddExp/{habit_id}",null);
        response.EnsureSuccessStatusCode();
    }
    public async Task<float> GetStreakBonus(int user_id)
    {
        var response = await _httpClient.GetFromJsonAsync<float>($"api/Experience/Bonus_Streak/{user_id}");
        return response;
    }


}

