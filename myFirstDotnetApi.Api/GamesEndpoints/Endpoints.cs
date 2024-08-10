using System.Net.Http.Headers;
using myFirstDotnetApi.Api.Dtos;
namespace myFirstDotnetApi.Api;

public static class Endpoints
{
const string GetGameName = "GetGame";

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

        group.MapGet("/joke", () => {
         string apiAddress = "https://v2.jokeapi.dev/";

        async void asyncasyncRunAsync(){
            
            client.BaseAddress = new Uri("http://localhost:5031");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(apiAddress);

            public class Product
{
    public string Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }
}

            Product product = null;

            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<Product>();
            }
            return product;
                }

                string joke = 
                return response;
                });

                return group;
            }
}
