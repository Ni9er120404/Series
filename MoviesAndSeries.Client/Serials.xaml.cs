using MaSMAUI.Models;

namespace MaSMAUI;

public partial class Serials : ContentPage
{
	private async Task<IEnumerable<Series>> GetSerials()
	{
		return new List<Series>();
	}

	public Serials()
	{
		InitializeComponent();
		var seriesThread = new Thread(async () =>
		{
			var series = await GetSerials();
			foreach (var serial in series)
			{
				SeriesStack.Add(new Serial()
				{
					Series = serial,
				});
			}
		});
		seriesThread.Start();
	}
}