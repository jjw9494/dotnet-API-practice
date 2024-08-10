using myFirstDotnetApi.Api;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGamesEndpoints();

app.Run();
