using HtmlAgilityPack;
using MoviesAndSeries.Server.Interfaces;
using MoviesAndSeries.Server.SerialFan;
using NUnit.Framework;

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

		public async IAsyncEnumerable<SerialFanSerialInfo> Parse()
		{
			IEnumerable<PartialSerialFanSerialInfo> partials = await GetPartialInfo();
			SerialFanPartialToFullParser partialToFull = new();
			foreach (PartialSerialFanSerialInfo partial in partials)
			{
				yield return partialToFull.Parse(partial);
			}
		}
	}

	[TestFixture]
	public class SerialFanParserTest
	{
		[Test]
		public async Task PartialParseTest()
		{
			IEnumerable<PartialSerialFanSerialInfo> serials = await SerialFanParser.GetPartialInfo();
			PartialSerialFanSerialInfo? firstSerial = null;
			foreach (PartialSerialFanSerialInfo serial in serials)
			{
				if (serial.Name == "11.22.63")
				{
					firstSerial = serial;
					break;
				}
			}
			Assert.IsNotNull(firstSerial, "Could not find serial 11.22.63");
			PartialSerialFanSerialInfo surelySerial = firstSerial!;

			Assert.AreEqual("2016", surelySerial.StartYear, "The start year is not right");
			Assert.AreEqual("2016", surelySerial.EndYear, "The end year is not right");
			Assert.AreEqual("7.862", surelySerial.KinopoiskRating, "The kinopoisk rating is not right");
			Assert.AreEqual("8.1", surelySerial.ImdbRating, "The imdb rating is not right");

			Assert.AreEqual("https", surelySerial.LinkToInfoPage.Scheme, "The link's scheme is not right");
			Assert.AreEqual("serialfan.net", surelySerial.LinkToInfoPage.Host, "The link's host is not right");
			Assert.AreEqual("/670-112263-2.html", surelySerial.LinkToInfoPage.PathAndQuery, "The link's path is not right");
		}
	}
}
