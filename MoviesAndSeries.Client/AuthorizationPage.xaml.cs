namespace MoviesAndSeries.Client
{
	public partial class AuthorizationPage : ContentPage
	{
		public AuthorizationPage()
		{
			InitializeComponent();
		}

		private async void AuthorizationButtonClicked(object sender, EventArgs e)
		{
			HttpClient httpClient = new();

			string baseUrl = "https://localhost:32768/Authorization";
			string email = EmailEntry.Text;
			string password = PasswordEntry.Text;
			string url = $"{baseUrl}?email={email}&password={password}";

			HttpResponseMessage response = await httpClient.GetAsync(url);

			_ = response.EnsureSuccessStatusCode();
		}

		private void RegistrationButtonClicked(object sender, EventArgs e)
		{

		}
	}
}