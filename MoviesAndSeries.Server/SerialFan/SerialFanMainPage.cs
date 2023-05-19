using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;
using MoviesAndSeries.Server.Interfaces;
using System.Diagnostics;

namespace MoviesAndSeries.Server.SerialFan
{
	internal struct SerialFanMainPage : IPartialInfoParser<PartialSerialFanSerialInfo>
	{
		internal HtmlDocument _page;

		private SerialFanMainPage(HtmlDocument document)
		{
			_page = document;
		}

		internal static async Task<SerialFanMainPage> Load()
		{
			HtmlDocument document = await Parsers.SerialFanParser.GetHtml(Parsers.SerialFanParser.SerialFanUri);
			return new SerialFanMainPage(document);
		}

		public readonly IEnumerable<PartialSerialFanSerialInfo> Parse()
		{
			// Select all li tags that have class literal__item
			IEnumerable<HtmlNode>? nodes = _page.DocumentNode.QuerySelectorAll("li.literal__item");
			Debug.Assert(nodes is not null);
			// Each node has one child node that is a link to the serial page, and inside that tag there is a name of the serial
			foreach (HtmlNode? node in nodes)
			{
				HtmlNode? link = node.QuerySelector("a");
				Debug.Assert(link is not null);
				string? name = link.InnerText;
				Debug.Assert(name is not null);
				string? href = link.Attributes["href"]?.Value;
				Debug.Assert(href is not null);
				string? startYear = node.Attributes["data-start-year"]?.Value;
				Debug.Assert(startYear is not null);
				string? endYear = node.Attributes["data-end-year"]?.Value;
				Debug.Assert(endYear is not null);
				string? kinopoiskRating = node.Attributes["data-kp"]?.Value;
				Debug.Assert(kinopoiskRating is not null);
				string? imdbRating = node.Attributes["data-imdb"]?.Value;
				Debug.Assert(imdbRating is not null);
				// Create a new PartialSeialFanSerialInfo object
				PartialSerialFanSerialInfo serialInfo = new(name, startYear, endYear, kinopoiskRating, imdbRating, new UriBuilder()
				{
					Scheme = Parsers.SerialFanParser.SerialFanUri.Scheme,
					Host = Parsers.SerialFanParser.SerialFanUri.Host,
					Path = href,
				}.Uri
				);
				// Return the object
				yield return serialInfo;
			}
		}
	}
}