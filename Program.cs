using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using static System.Net.WebRequestMethods;
using static System.Net.WebRequestMethods;

// "DefaultKey"
var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();



// string key = File.ReadAllText("appsettings.json");
// string apiKey = JObject.Parse(key).GetValue("DefaultKey").ToString();

string apiKey = config.GetConnectionString("openweathermap");
var client = new HttpClient();

Console.WriteLine("Enter zip code");
var zipCode = Console.ReadLine();
var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?zip={zipCode}&appid={apiKey}&units=imperial";

var currentWeather = client.GetStringAsync(weatherURL).Result;
var zipTemp = JObject.Parse(currentWeather)["main"]["temp"].ToString();
Console.WriteLine($"Current temperature is: {zipTemp}°F.");




