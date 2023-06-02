using MoviesAndSeries.Server.Interfaces;

namespace MoviesAndSeries.Server.SerialFan
{
    public class PartialSerialFanSerialInfo : IPartialSerialInfo
    {
        public string Name { get; }

        public string StartYear { get; }

        public string EndYear { get; }

        public string KinopoiskRating { get; }

        public string ImdbRating { get; }

        public Uri LinkToInfoPage { get; }

        string IPartialSerialInfo.Name => Name;

        internal PartialSerialFanSerialInfo(string name, string startYear, string endYear, string kinopoiskRating, string imdbRating, Uri linkToInfoPage)
        {
            Name = name;
            StartYear = startYear;
            EndYear = endYear;
            KinopoiskRating = kinopoiskRating;
            ImdbRating = imdbRating;
            LinkToInfoPage = linkToInfoPage;
        }

        internal PartialSerialFanSerialInfo(PartialSerialFanSerialInfo other)
        {
            Name = other.Name;
            StartYear = other.StartYear;
            EndYear = other.EndYear;
            KinopoiskRating = other.KinopoiskRating;
            ImdbRating = other.ImdbRating;
            LinkToInfoPage = other.LinkToInfoPage;
        }
    }
}