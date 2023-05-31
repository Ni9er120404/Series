using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;
using MoviesAndSeries.Server.Interfaces;
using System.Collections.Immutable;
using System.Text;

namespace MoviesAndSeries.Server.SerialFan
{
	internal struct SerialFanPartialToFullParser : IPartialToFullInfoParser<PartialSerialFanSerialInfo, SerialFanSeason, SerialFanSerialInfo, SerialFanEpisode>
	{
		private static string GetFirstNumberInString(string text)
		{
			var numberStart = 0;
			for (;numberStart < text.Length; numberStart++)
			{
				var number = text[numberStart];
				if (char.IsDigit(number))
				{
					break;
				}
			}

			if (numberStart == text.Length)
			{
				return 0;
			}

			var numberEnd = numberStart;

			for (;numberEnd < text.Length;numberEnd++)
			{
				var number = text[numberEnd];
				if (!char.IsDigit(number))
				{
					break;
				}
			}

			return text[numberStart..numberEnd];
		}

		public readonly SerialFanSerialInfo Parse(PartialSerialFanSerialInfo partialInfo)
		{
			HtmlWeb web = new();

			HtmlDocument document = web.Load(partialInfo.LinkToInfoPage);

			string name = partialInfo.Name;
			string description = document.DocumentNode.QuerySelector("div.cat-desc-serial div.body").InnerText;
			string poster = document.DocumentNode.QuerySelector("div.field-poster img").Attributes["src"].Value;

			ulong medEpisodeDuration = 0;

			foreach (HtmlNode? node in document.DocumentNode.QuerySelectorAll("ul.info-list li"))
			{
				HtmlNode? label = node.QuerySelector("div.field-label");
				if (label is null || label.InnerText != "Длительность:")
				{
					continue;
				}

				HtmlNode text = node.QuerySelector("div.field-text");
				string pureDuration = GetFirstNumberInString(text.InnerText.Split(' ')[0].Replace(" мин.", "").Replace(" мин", ""));
				medEpisodeDuration = ulong.Parse(pureDuration) * 60 * 1000;
				break;
			}

			ImmutableArray<SerialFanSeason> seasons = document.DocumentNode.QuerySelectorAll("div.episode-group").Select(group =>
			{
				string seasonNumber = group.GetAttributeValue("data-key", "1");
				ImmutableArray<SerialFanEpisode> episodes_list = group.QuerySelectorAll("ul.series-list li div.item div.item-serial div.serial-bottom div.field-description a").Reverse().Select(node =>
				{
					string name = node.InnerText.SkipWhile(chr => chr != '«').Skip(1).TakeWhile(chr => chr != '»').Aggregate(new StringBuilder(), (builder, chr) => builder.Append(chr)).ToString();
					return new SerialFanEpisode(name, medEpisodeDuration);
				}).ToImmutableArray();
				return new SerialFanSeason(seasonNumber, episodes_list);
			}).ToImmutableArray();

			return new SerialFanSerialInfo(partialInfo, description, seasons, new UriBuilder()
			{
				Scheme = Parsers.SerialFanParser.SerialFanUri.Scheme,
				Host = Parsers.SerialFanParser.SerialFanUri.Host,
				Path = poster
			}.Uri);
		}
	}
}