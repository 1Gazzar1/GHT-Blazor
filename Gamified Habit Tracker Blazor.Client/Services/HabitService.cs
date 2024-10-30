namespace Gamified_Habit_Tracker_Blazor.Services;

public class HabitService
{   
    private readonly HttpClient _httpClient;
    public HabitService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<List<Habit>> GetHabits()
    {
        var habits= await _httpClient.GetFromJsonAsync<List<Habit>> ("api/Habit");

        return habits;
    }
    public async Task AddHabit(Habit habit)
    {
		var response = await _httpClient.PostAsJsonAsync("api/Habit",habit);   
        response.EnsureSuccessStatusCode();
    }
	public async Task UpdateHabit(int id , Habit habit)
	{
		var response = await _httpClient.PutAsJsonAsync($"api/Habit/{id}", habit);
		response.EnsureSuccessStatusCode();
	}
	public async Task DeleteHabit(int id)
	{
		var response = await _httpClient.DeleteAsync($"api/Habit/{id}");
		response.EnsureSuccessStatusCode();
	}
	public async Task CompleteHabit(int id)
	{
		var response = await _httpClient.PostAsync($"api/{id}/complete",null);
		response.EnsureSuccessStatusCode();
	}
	public async Task<int> CurrentStreak(int user_id)
    {
        var streak = await _httpClient.GetFromJsonAsync<int>($"api/Streak/Current/{user_id}");
        return streak;
    }
	public async Task<int> HighestStreak(int user_id)
	{
		var streak = await _httpClient.GetFromJsonAsync<int>($"api/Streak/Highest/{user_id}");
		return streak;
	}
}

