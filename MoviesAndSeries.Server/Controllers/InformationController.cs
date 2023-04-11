using Microsoft.AspNetCore.Mvc;
using MoviesAndSeries.Server.Models;
using MoviesAndSeries.Server.Models.DataBase;
using MoviesAndSeries.Server.Models.Models.MoviesAndSeries;

namespace MoviesAndSeries.Server.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class InformationController : Controller
	{
		private readonly MovieAndSeriesContext _context;
		private readonly string _link = "https://serialfan.net/";
		private readonly string _firstCriterion = "newscatalog-list";
		private readonly string _secondCriterion = "text-align:center;padding: 20px 0px 0px 0px;";

		public InformationController(MovieAndSeriesContext context)
		{
			_context = context;
		}

		[HttpPost]
		public async Task PostInformationOfSeries()
		{
			Information information = new(_link, _firstCriterion, _secondCriterion);

			List<Series> series = new();

			List<string> nameOfSeries = await information.GetNameOfSeriesAsync();

			List<double> ratingOfSeries = await information.GetRatingOfSeriesAsync();

			List<DateTime> dateTimes = await information.GetStartDateOfSeriesAsync();

			for (int i = 0; i < nameOfSeries.Count; i++)
			{
				series.Add(new Series() { Name = nameOfSeries[i], Rating = ratingOfSeries[i], StartDate = dateTimes[i], });
			}

			_context.Series!.AddRange(series);

			_ = await _context.SaveChangesAsync();
		}

		[HttpGet]
		public async Task<IActionResult> GetSeries()
		{
			List<string> nameOfSeries = new();

			foreach (Series? item in _context.Series!.ToList())
			{
				nameOfSeries.Add(item.Name);

				_ = await _context.SaveChangesAsync();
			}

			return Content($"{nameOfSeries}");
		}
	}
}