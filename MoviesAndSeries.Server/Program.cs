using Microsoft.EntityFrameworkCore;
using MoviesAndSeries.Server.Models.DataBase;

namespace MoviesAndSeries.Server
{
	public class Program
	{
		private static readonly HttpClient? _httpClient;

		public static void Main(string[] args)
		{
			WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

			string connectionString = builder.Configuration.GetConnectionString("DefaultConnectionForSqlServer")!;

			_ = builder.Services.AddControllers();
			_ = builder.Services.AddEndpointsApiExplorer();
			_ = builder.Services.AddSwaggerGen();
			_ = builder.Services.AddDbContext<MovieAndSeriesContext>(optionsAction => optionsAction.UseSqlServer(connectionString));

			WebApplication app = builder.Build();

			if (app.Environment.IsDevelopment())
			{
				_ = app.UseSwagger();
				_ = app.UseSwaggerUI();
			}

			_ = app.UseHttpsRedirection();
			_ = app.UseAuthorization();
			_ = app.MapControllers();

			_ = app.MapGet("/getInfo", () => GetHtmlAsync("https://serialfan.net/"));

			app.Run();
		}

		private static async Task<string> GetHtmlAsync(string url)
		{
			HttpResponseMessage response = await _httpClient!.GetAsync(url);

			_ = response.EnsureSuccessStatusCode();

			string html = await response.Content.ReadAsStringAsync();

			return html;
		}
	}
}