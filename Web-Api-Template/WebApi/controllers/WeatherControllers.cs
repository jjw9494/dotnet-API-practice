using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace WebApi;

public class WeatherControllers
{
    [Route("/")]
    [HttpGet]
    public IResult GetWeather(){
        return Results.Ok();
    }
}
