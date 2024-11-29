﻿namespace Gamified_Habit_Tracker_Blazor.Client;

public class CustomAuthProvider : AuthenticationStateProvider
{

    private readonly ILocalStorageService _localStorageService;
    private string? _token;

    public CustomAuthProvider(ILocalStorageService localStorageService)
    {
		_localStorageService = localStorageService;
	}
	private async Task<bool> IsBrowser()   // I have no idea what is this 
	{
		try
		{
			// This will throw an exception if not in the browser
			await _localStorageService.GetItemAsync<string>("dummy");
			return true;
		}
		catch
		{
			return false;
		}
	} 
	public async override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
		// _token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjYiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoibWVsYW1vIiwiZXhwIjoxNzMxMjQ4MjkwLCJpc3MiOiJpZGsiLCJhdWQiOiJpZGsyIn0.G3WZBYKrZirqfy_DxdnfWOM4ixO0AZf1CUxwAyrMVV8";

		if (await IsBrowser())
		{
			_token = await _localStorageService.GetItemAsync<string>("token");
		}

		var identity = string.IsNullOrEmpty(_token)
            ? new ClaimsIdentity()
            : new ClaimsIdentity(ParseClaimsFromJwt(_token), "jwt");

        return (new AuthenticationState(new ClaimsPrincipal(identity)));
    }

    public async void MarkasLoggedIn(string token)
    {
        await _localStorageService.SetItemAsync("token", token);
        _token = token;
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
    public async void MarkUserAsLoggedOut()
    {
		await _localStorageService.RemoveItemAsync("token");
		_token = "";
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
	public int GetUserID()
	{
		var claim = ParseClaimsFromJwt(_token).FirstOrDefault(c =>
						c.Type == ClaimTypes.NameIdentifier);

		if (claim == null || !int.TryParse(claim.Value, out var userId))
		{
			
			return -1; 
		}

		return userId;
	}
    public string GetToken()
    {
        return _token ?? "";
    }
	// i copied this , i have no idea how it works 
	private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
		if (string.IsNullOrWhiteSpace(jwt))
		{
			return Enumerable.Empty<Claim>(); // Return an empty claims list if the token is null or empty
		}
		var claims = new List<Claim>();
        var payload = jwt.Split('.')[1];
        var jsonBytes = Convert.FromBase64String(payload.PadRight(payload.Length + (4 - payload.Length % 4) % 4, '='));
        var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

        if (keyValuePairs is null)
        {
            return claims;
        }
        claims.AddRange((keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString() ?? string.Empty))));
        return claims;
    }
}