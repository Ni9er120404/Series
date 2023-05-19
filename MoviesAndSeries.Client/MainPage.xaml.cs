namespace MaSMAUI;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private async void Login(object sender, EventArgs e)
	{
        // Navigate to page AfterLogin
        await Navigation.PushAsync(new AfterLogin()); 
    }
}

