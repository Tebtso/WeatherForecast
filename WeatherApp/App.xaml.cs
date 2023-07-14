namespace WeatherApp;

public partial class App : Application
{

    public class WeatherDay
    {
        public string Day { get; set; }
        public string Min_temp { get; set; }
        public string Max_temp { get; set; }
        public string Deatails { get; internal set; }
        public string Temperature { get; internal set; }
    }

    public class WeatherData
    {

        public List<WeatherForecast> List { get; set; }

    }
    public class WeatherForecast
    {

        public long dt { get; set; }
        public MainData main { get; set; }
        public List<Weather> weather { get; set; }
    }

    public class MainData
    {
        public double tem_mix { get; set; }
        public double tem_max { get; set; }

    }
    public class Weather
    {
        public string deccription { get; set; }
    }
}
