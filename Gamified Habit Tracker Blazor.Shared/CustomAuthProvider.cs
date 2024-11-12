namespace Gamified_Habit_Tracker_Blazor.Client;

public class CustomAuthProvider : AuthenticationStateProvider
{

    private string? _token;

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
		// _token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjYiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoibWVsYW1vIiwiZXhwIjoxNzMxMjQ4MjkwLCJpc3MiOiJpZGsiLCJhdWQiOiJpZGsyIn0.G3WZBYKrZirqfy_DxdnfWOM4ixO0AZf1CUxwAyrMVV8";

		var identity = string.IsNullOrEmpty(_token)
            ? new ClaimsIdentity()
            : new ClaimsIdentity(ParseClaimsFromJwt(_token), "jwt");

        return Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity)));
    }

    public void MarkasLoggedIn(string token)
    {
        _token = token;
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
    public void MarkUserAsLoggedOut()
    {
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
