using Newtonsoft.Json.Linq;
using static System.Net.WebRequestMethods;
using static System.Net.WebRequestMethods;



string apiKey = "6d2b93a6b18061428c87beb1cb18891b";
var client = new HttpClient();

Console.WriteLine("Enter zip code");
var zipCode = Console.ReadLine();
var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?zip={zipCode}&appid={apiKey}&units=imperial";

var currentWeather = client.GetStringAsync(weatherURL).Result;
var zipTemp = JObject.Parse(currentWeather)["main"]["temp"].ToString();
Console.WriteLine($"Current temperature is: {zipTemp}°F.");




