namespace myFirstDotnetApi.Api.Dtos;
using System.ComponentModel.DataAnnotations;

public record class UpdateGameDtos(
    [Required][StringLength(50)] string Name, 
    [Required][StringLength(50)] string Genre, 
    [Range(1, 50)] decimal Price, 
    [Required] DateOnly ReleaseDate
    );
