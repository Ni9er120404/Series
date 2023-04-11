using Microsoft.EntityFrameworkCore;
using MoviesAndSeries.Server.Models;
using MoviesAndSeries.Server.Models.DataBase;

namespace MoviesAndSeries.Server
{
	public class Program
	{
		private static readonly string _link = "https://serialfan.net/";
		private static readonly string _firstCriterion = "newscatalog-list";
		private static readonly string _secondCriterion = "text-align:center;padding: 20px 0px 0px 0px;";

		public static void Main(string[] args)
		{
			WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

			string connectionString = builder.Configuration.GetConnectionString("DefaultConnectionForSqlServer")!;

			_ = builder.Services.AddControllers();
			_ = builder.Services.AddEndpointsApiExplorer();
			_ = builder.Services.AddSwaggerGen();
			_ = builder.Services.AddDbContext<MovieAndSeriesContext>(optionsAction => optionsAction.UseSqlServer(connectionString));

			using WebApplication app = builder.Build();

			if (app.Environment.IsDevelopment())
			{
				_ = app.UseSwagger();
				_ = app.UseSwaggerUI();
			}

			_ = app.UseHttpsRedirection();
			_ = app.UseAuthorization();
			_ = app.MapControllers();

			Information information = new(_link, _firstCriterion, _secondCriterion);

			_ = app.MapGet("/", () => information.GetStartDateOfSeriesAsync());

			app.Run();
		}
	}
}