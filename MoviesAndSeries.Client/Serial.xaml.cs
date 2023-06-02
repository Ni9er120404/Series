using MaSMAUI.Models;

namespace MaSMAUI;

public partial class Serial : ContentView
{
    public Series? Series { get => (Series?)BindingContext; set => BindingContext = value; }

    public Serial()
    {
        InitializeComponent();
    }

    private void AddOneView()
    {
        Series?.AddOneView();
    }

    private void DeleteOneView()
    {
        Series?.DeleteOneView();
    }

    private void UpdateAmount()
    {
        if (Series is not null)
        {
            Amount.Text = Series.WatchCounter.ToString();
            ApiConnection.GetInstance().Api.ApiSeriesNameQuantityPost(Series.Name, Series.WatchCounter);
        }
    }

    private void Add_Button_Clicked(object sender, EventArgs e)
    {
        AddOneView();
        UpdateAmount();
    }

    private void Minus_Button_Clicked(object sender, EventArgs e)
    {
        DeleteOneView();
        UpdateAmount();
    }
}