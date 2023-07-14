using Microsoft.Maui.Controls;
using System.Collections.Generic;
using WeatherApp.Service;
using static WeatherApp.App;


namespace WeatherApp;

public partial class DetailsPage : ContentPage
{
    private readonly WeatherDay _weatherDay;
    private App.WeatherData selectedDay;

    public DetailsPage(WeatherDay weatherDay)
	{
		InitializeComponent();
        _weatherDay = weatherDay;
        BindingContext = _weatherDay;
    }

    public DetailsPage(App.WeatherData selectedDay)
    {
        this.selectedDay = selectedDay;
    }
    private void OnBackButtonClicked(object sender, EventArgs e)

    {
        if (OnBackButtonClicked != null)
        {
            OnBackButtonClicked(this, e);
        }
        Navigation.PopAsync();

    }

}

