namespace Gamified_Habit_Tracker_Blazor.Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

			var Http = new HttpClient()
			{
				BaseAddress = new Uri("https://localhost:7113/")
			};
			builder.Services.AddApiAuthorization();
			builder.Services.AddScoped(sp => Http);		
			builder.Services.AddScoped<HabitService>();
			builder.Services.AddScoped<UserService>();
			builder.Services.AddScoped<AchievementService>();
            builder.Services.AddScoped<ExperienceService>();
            builder.Services.AddScoped<LevelService>();

            builder.Services.AddScoped<AuthService>();
			builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthProvider>();

			builder.Services.AddBlazoredLocalStorage();

			await builder.Build().RunAsync();
        }
    }
}
