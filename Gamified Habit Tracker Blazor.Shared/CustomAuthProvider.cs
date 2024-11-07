namespace Gamified_Habit_Tracker_Blazor.Client;

public class CustomAuthProvider : AuthenticationStateProvider
{
	
	private string _token;	
    
	public override async Task<AuthenticationState> GetAuthenticationStateAsync()
	{		
		_token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjYiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoibWVsYW1vIiwiZXhwIjoxNzMxMDk4MzM5LCJpc3MiOiJpZGsiLCJhdWQiOiJpZGsyIn0.-t_F18I3bRYzz2cI5FoVX2ZfD17OEjuis3iTKMXzzX4";

		var identity = string.IsNullOrEmpty(_token)
			? new ClaimsIdentity()
			: new ClaimsIdentity(ParseClaimsFromJwt(_token), "jwt");
		return new AuthenticationState(new ClaimsPrincipal(identity));
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
	// i copied this , i have no idea how it works 
	private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)  
	{
		var claims = new List<Claim>();
		var payload = jwt.Split('.')[1];
		var jsonBytes = Convert.FromBase64String(payload.PadRight(payload.Length + (4 - payload.Length % 4) % 4, '='));
		var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

		claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));
		return claims;
	}
}
