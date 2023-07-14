using System.ComponentModel;
using System.Runtime.CompilerServices;
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using static WeatherApp.App;

namespace WeatherApp
{
    public partial class LandingPage : ContentPage, INotifyPropertyChanged
    {
        private WeatherDay _seclectedDay;
        public WeatherDay  SeclectedDay
        {
            get {return _seclectedDay;}
            set
            {
                _seclectedDay = value;
                OnPropertyChanged(nameof(SeclectedDay));
            }
        }
    public List<WeatherDay> WeatherForecat { get; set; }
    public WeatherData SelectedDay { get; private set; }

        public LandingPage()
        {
            InitializeComponent();
            BindingContext = this;

        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadWeatherForecast();

        }
        private async Task LoadWeatherForecast()
        {
            // Retrieve weather data from the API using HttpClient or any other HTTP library
            // Parse the response and populate the WeatherForecast property with the data
            // You will need to sign up for an API key from OpenWeatherMap and replace 'YOUR_API_KEY' below
            string apiKey = "fc49ac32d4806856e9d584a3c5e12c68";
            string apiUrl = $"https://api.openweathermap.org/data/2.5/forecast?q=Midrand&appid={apiKey}";
            var response = await new System.Net.Http.HttpClient().GetStringAsync(apiUrl);

            WeatherData weatherData = Newtonsoft.Json.JsonConvert.DeserializeObject<WeatherData>(response);

            WeatherForecat = new List<WeatherDay>();
            foreach (var forcast in weatherData.List)
            {

                DateTime dateTime = DateTimeOffset.FromUnixTimeSeconds(forcast.dt).LocalDateTime;
                string dayOfWeeks = dateTime.ToString("dddd");
                string temperature = $"{forcast.main.tem_mix}C/{forcast.main.tem_max}C";

                WeatherForecat.Add(new WeatherDay { Day = dayOfWeeks, Temperature = temperature, Deatails = forcast.weather[0].deccription });
            }

            OnPropertyChanged(nameof(WeatherForecat));


         }

        private async void OnDaySelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            await Navigation.PushAsync(new DetailsPage(SelectedDay));
            ((ListView)sender).SelectedItem = null;

        }

        public new event PropertyChangedEventHandler PropertyChanged;

        protected override void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
