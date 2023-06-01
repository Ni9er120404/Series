using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using MoviesAndSeries.Server.Models.DataBase;

namespace MoviesAndSeries.Server
{
	public class Program
	{
		public static void Main(string[] args)
		{
			WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
#if DEBUG
			string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
#else
			string connectionString = "Host=10.0.0.231;Port=5432;Database=movies_and_serials;Username=niger;Password=MyPassword1!"!;
#endif


			_ = builder.Services.AddControllers();
			_ = builder.Services.AddEndpointsApiExplorer();
			_ = builder.Services.AddSwaggerGen();
			_ = builder.Services.AddDbContext<MovieAndSeriesContext>(optionsAction => optionsAction.UseNpgsql(connectionString));

			using WebApplication app = builder.Build();

			_ = app.UseSwagger();

			if (app.Environment.IsDevelopment())
			{
				_ = app.UseSwaggerUI();
			}

			if (!app.Environment.IsDevelopment())
			{
				_ = app.UseHttpsRedirection();
			}

			_ = app.UseForwardedHeaders(new ForwardedHeadersOptions
			{
				ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
			});

			_ = app.UseAuthorization();
			_ = app.MapControllers();

			app.Run();
		}
	}
}