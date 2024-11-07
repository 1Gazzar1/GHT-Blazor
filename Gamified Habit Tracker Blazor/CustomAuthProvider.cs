namespace Gamified_Habit_Tracker_Blazor.Client;

public class CustomAuthProvider : AuthenticationStateProvider
{
	private readonly AuthService _authService;
    public CustomAuthProvider(AuthService authService)
    {
		_authService = authService;

	}
	public override async Task<AuthenticationState> GetAuthenticationStateAsync()
	{
		var response = await _authService.Login(new LoginDTO() { Username = "melamo",Password= "wat up" });			
		var _token = response._token;
		//var _token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c";


		var identity = string.IsNullOrEmpty(_token)
			? new ClaimsIdentity()
			: new ClaimsIdentity(ParseClaimsFromJwt(_token), "jwt");
		return new AuthenticationState(new ClaimsPrincipal(identity));
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
