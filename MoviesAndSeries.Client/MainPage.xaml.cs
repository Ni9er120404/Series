using System.Text.RegularExpressions;

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

internal readonly struct LoginBinding {
	public static string EmailPattern => new GeneratedRegexAttribute("""(?<name>\w*)@(?<domain>(?<domainname>\w*).(?<domainarea>\w*))""").Pattern;
	public LoginBinding() { }
}


