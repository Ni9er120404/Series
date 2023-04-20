using Microsoft.EntityFrameworkCore;
using MoviesAndSeries.Server.Models.DataBase;

namespace MoviesAndSeries.Server
{
	public class Program
	{
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

			app.Run();
		}
	}
}