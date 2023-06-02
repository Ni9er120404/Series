using MoviesAndSeries.Server.SerialFan;
using NUnit.Framework;

namespace MoviesAndSeries.Server.Parsers
{
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