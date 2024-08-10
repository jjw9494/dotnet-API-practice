
using myFirstDotnetApi.Api.Dtos;
namespace myFirstDotnetApi.Api;
using System;
using System.Threading.Tasks;
using System.Net.Http;

public static class Endpoints
{
const string GetGameName = "GetGame";

            public class Product
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public decimal? Price { get; set; }
    public string? Category { get; set; }
}

static readonly HttpClient client = new HttpClient(); 
private static readonly List<GameDto> games = [
    new (
        1,
        "GTA V",
        "RPG",
        29.99M,
        new DateOnly(1992, 10, 11)
    ),
        new (
        2,
        "Rocket League",
        "Sports",
        4.99M,
        new DateOnly(2001, 11, 08)
    ),
     new (
        3,
        "Red Dead Redemption",
        "Western",
        54.99M,
        new DateOnly(2001, 11, 08)
    )
];

    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app){

        var group = app.MapGroup("games").WithParameterValidation();
        group.MapGet("/", () => games);

        group.MapGet("/{id}", (int id) => {
            GameDto? game = games.Find(x => x.Id == id);

            return game is null ? Results.NotFound() : Results.Ok(game);
        }
        ).WithName(GetGameName);

        group.MapPost("/", (CreateGameDtos newGame) => {
            GameDto game = new(
                games.Count + 1,
                newGame.Name,
                newGame.Genre,
                newGame.Price,
                newGame.ReleaseDate
            );

            games.Add(game);

            return Results.CreatedAtRoute(GetGameName, new { id = game.Id }, game);
        });

        group.MapPut("/{id}", (int id, UpdateGameDtos gameUpdate) => {
            int index = games.FindIndex(x => x.Id == id);

            if(index == -1){
                return Results.NotFound();
            }

            games[index] = new GameDto(
                id,
                gameUpdate.Name,
                gameUpdate.Genre,
                gameUpdate.Price,
                gameUpdate.ReleaseDate
            );

            return Results.NoContent();

        });

        group.MapDelete("/{id}", (int id) => {
            games.RemoveAll(x => x.Id == id);
        });

        group.MapGet("/joke", async () => {

            var response = await client.GetAsync("https://jokeapi.dev/joke/Any?format=txt&type=single&blacklistFlags=nsfw,racist,sexist&lang=en");
            var joke = await response.Content.ReadAsStringAsync();
            return joke;
                }
                );

                return group;
            }
}
