﻿namespace MaSMAUI;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
        Navigation.PushAsync(new AfterLogin());
    }
}

