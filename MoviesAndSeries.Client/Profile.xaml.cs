namespace MaSMAUI;

public partial class Profile : ContentPage
{

	private static long GetHoursWatched()
	{
		return ApiConnection.GetInstance().Api.ApiSeriesGet() / 1000 / 60 / 60;
	}

	private void UpdateWatchedHours()
	{
		SpentHours.Text = GetHoursWatched().ToString();
	}

	public Profile()
	{
		InitializeComponent();
		UpdateWatchedHours();
	}

	private void Refresh_Button_Clicked(object sender, EventArgs e)
	{
		UpdateWatchedHours();
	}
}