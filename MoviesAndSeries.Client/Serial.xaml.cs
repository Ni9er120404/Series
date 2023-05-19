using MaSMAUI.Models;

namespace MaSMAUI;

public partial class Serial : ContentView
{
	public Series? Series { get => (Series?)BindingContext; set => BindingContext = value; }

	public Serial()
	{
		InitializeComponent();
	}
}