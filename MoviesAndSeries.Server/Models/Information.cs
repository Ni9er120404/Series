using System.Globalization;
using System.Text;

namespace MoviesAndSeries.Server.Models
{
	public class Information
	{
		private readonly string _link;
		private readonly string _firstCriterion;
		private readonly string _secondCriterion;

		public Information(string link, string firstCriterion, string secondCriterion)
		{
			_link = link;
			_firstCriterion = firstCriterion;
			_secondCriterion = secondCriterion;
		}

		private async Task<string> GetHtmlAsync()
		{
			using HttpClient client = new();
			using HttpResponseMessage response = await client.GetAsync(_link);

			_ = response.EnsureSuccessStatusCode();

			string html = await response.Content.ReadAsStringAsync();

			return html;
		}

		private async Task<List<string>> GetPartOfHtmlAsync()
		{
			List<string> list = new();

			string? html = await GetHtmlAsync();

			string[] splitString = html.Split("\n");

			bool foundStart = false;

			foreach (string line in splitString)
			{
				if (line.Contains(_firstCriterion))
				{
					foundStart = true;
				}
				else if (foundStart && line.Contains(_secondCriterion))
				{
					break;
				}
				else if (foundStart)
				{
					list.Add(line);
				}
			}

			return list;
		}

		public async Task<List<string>> GetNameOfSeriesAsync()
		{
			List<string> list = await GetPartOfHtmlAsync();
			List<string> series = new();

			foreach (string line in list)
			{
				if (line.Contains(".html"))
				{
					int startNumber = line.IndexOf(".html") + 7;

					StringBuilder nameOfSeries = new();

					_ = nameOfSeries.Append(line[startNumber..]);

					int endNumber = nameOfSeries.Length - 4;

					_ = nameOfSeries.Remove(endNumber, 4);

					series.Add(nameOfSeries.ToString());
				}
			}

			return series;
		}

		public async Task<List<double>> GetRatingOfSeriesAsync()
		{
			CultureInfo culture = new("en-US");
			culture.NumberFormat.NumberDecimalSeparator = ".";

			List<string> list = await GetPartOfHtmlAsync();
			List<double> ratingOfSeries = new();

			string param = "data-kp=";

			foreach (string line in list)
			{
				if (line.Contains(param))
				{
					int startNumber = line.IndexOf(param) + param.Length;

					StringBuilder stringBuilder = new();

					for (int i = startNumber + 1; i < startNumber + 2; i++)
					{
						_ = stringBuilder.Append(line[i]);
					}
					string num;
					if (stringBuilder.ToString() == "\"")
					{
						num = "0";
					}
					else
					{
						num = stringBuilder.ToString();
					}

					ratingOfSeries.Add(double.Parse(num, culture));
				}
			}

			return ratingOfSeries;
		}

		public async Task<List<DateTime>> GetStartDateOfSeriesAsync()
		{
			List<DateTime> dateTimes = new();

			List<string> list = await GetPartOfHtmlAsync();

			string param = "data-start-year=";
			int j = 0;
			foreach (string line in list)
			{
				if (line.Contains(param))
				{

					int startNumber = line.IndexOf(param) + param.Length;

					StringBuilder stringBuilder = new();

					for (int i = startNumber + 1; i < startNumber + 5; i++)
					{
						_ = stringBuilder.Append(line[i]);
					}
					DateTime dateTime = new();
					if (stringBuilder.ToString() == "\" da")
					{
						_ = dateTime.AddYears(0000);
					}
					else
					{
						dateTimes.Add(dateTime.AddYears(int.Parse(stringBuilder.ToString())));
					}
					j++;
					Console.WriteLine(j);
				}
			}

			return dateTimes;
		}
	}
}