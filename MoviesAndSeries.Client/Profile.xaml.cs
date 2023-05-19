namespace MaSMAUI;

public partial class Profile : ContentPage
{

	private uint GetHoursWatched()
	{
		return 0;
	}

	public Profile()
	{
		InitializeComponent();
		SpentHours.Text = GetHoursWatched().ToString();
	}
}