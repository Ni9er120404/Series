using HtmlAgilityPack;
using MoviesAndSeries.Server.Interfaces;
using MoviesAndSeries.Server.SerialFan;

namespace MoviesAndSeries.Server.Parsers
{
	public struct SerialFanParser : IParser<SerialFanSerialInfo, SerialFanSeason, SerialFanEpisode>
	{
		public static Uri SerialFanUri { get; set; } = new Uri("https://serialfan.net/");

		public SerialFanParser() { }

		internal static async Task<HtmlDocument> GetHtml(Uri address)
		{
			HtmlWeb htmlDocument = new();
			HtmlDocument doc = await htmlDocument.LoadFromWebAsync(address.ToString());
			return doc;
		}

		internal static async Task<IEnumerable<PartialSerialFanSerialInfo>> GetPartialInfo()
		{
			SerialFanMainPage mainPage = await SerialFanMainPage.Load();
			return mainPage.Parse();
		}

		public readonly async IAsyncEnumerable<SerialFanSerialInfo> Parse()
		{
			IEnumerable<PartialSerialFanSerialInfo> partials = await GetPartialInfo();
			SerialFanPartialToFullParser partialToFull = new();
			foreach (PartialSerialFanSerialInfo partial in partials)
			{
				SerialFanSerialInfo? result = null;
				// This try doesnt catch exceptions that are thrown by the partialToFull.Parse method
				try
				{
					result = partialToFull.Parse(partial);
				}
				catch
				{
					await Console.Out.WriteLineAsync($"Ошибка на сериале {partial.Name}");
				}

				if (result is not null)
				{
					yield return result;
				}
			}
		}
	}
}