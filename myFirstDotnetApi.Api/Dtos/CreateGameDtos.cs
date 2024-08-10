using System.ComponentModel.DataAnnotations;

namespace myFirstDotnetApi.Api.Dtos;

public record class CreateGameDtos(
    [Required][StringLength(50)] string Name, 
    [Required][StringLength(50)] string Genre, 
    [Range(1, 50)] decimal Price, 
    [Required] DateOnly ReleaseDate
    );
