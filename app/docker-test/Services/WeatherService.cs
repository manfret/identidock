namespace docker_test.Services;

public interface IWeatherService
{
    string GetLooksLike(string input);
}

public class WeatherService : IWeatherService
{
    public string GetLooksLike(string input)
    {
        var res = input.Reverse();
        return string.Join("", res);
    }
}