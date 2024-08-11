// using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;


namespace WebApi.controllers;
[ApiController]
public class WeatherControllers
{
    [Route("/")]
    [HttpGet]
    public IResult GetWeather(){
        return Results.Ok();
    }

    [Route("/{id}")]
    [HttpGet]
    public IResult GetWeatherId(int id){
        return Results.Ok(id);
    }
}
