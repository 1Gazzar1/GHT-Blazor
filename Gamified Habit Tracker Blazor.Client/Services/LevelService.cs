namespace Gamified_Habit_Tracker_Blazor.Services;
public class LevelService
{
    private readonly HttpClient _httpClient;
	private readonly AuthenticationStateProvider _authState;
	public LevelService(HttpClient httpClient , AuthenticationStateProvider authState)
    {
        _httpClient = httpClient;
        _authState = authState;
    }
    public async Task<bool> CheckLevelUp(int user_id)
    {
        var token = ((CustomAuthProvider)_authState).GetToken();
		_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
	

	    var response = await _httpClient.PostAsync($"api/Level/{user_id}/LevelUp",null);
        response.EnsureSuccessStatusCode();
		return await response.Content.ReadFromJsonAsync<bool>();
    }
	public async Task<Level> GetPastLvl(int user_id)
	{
		var token = ((CustomAuthProvider)_authState).GetToken();
		_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);


		var response = await _httpClient.GetFromJsonAsync<Level>($"api/Level/PastLevel/{user_id}");
		return response;
	}
}

