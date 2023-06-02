using MaSMAUI.Models;

namespace MaSMAUI;

public partial class Serials : ContentPage
{
	private static readonly Lazy<List<Series>> _series = new(GetSerials);
	public static List<Series> Series { get => _series.Value; }

	private static List<Series> GetSerials()
	{
		var connection = ApiConnection.GetInstance();
		var series = connection.Api.ApiSeriesListStartAmountGet(0, 100);
		return series
			.Select(series => new Series(series) {
				WatchCounter = connection.Api.ApiSeriesSeriesWatchedSeriesNamePost(series.Name)
			})
			.ToList();
	}

	public Serials()
	{
		InitializeComponent();

		foreach (var serial in Series)
		{
			SeriesStack.Add(new Serial()
			{
				Series = serial,
			});
		}
	}
}