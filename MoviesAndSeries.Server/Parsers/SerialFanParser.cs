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
				yield return partialToFull.Parse(partial);
			}
		}
	}
}
