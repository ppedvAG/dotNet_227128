// See https://aka.ms/new-console-template for more information
using ConsoleApp1;

Console.WriteLine("Hello, World!");

swaggerClient client = new swaggerClient("https://localhost:7219/",new HttpClient());

var json = client.GetWeatherForecastAsync().Result;
Console.WriteLine(json);