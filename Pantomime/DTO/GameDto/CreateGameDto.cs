namespace Pantomime.DTO.GameDto;

public class CreateGameDto
{
    public string Title { get; set; }
    public byte TotalRoundCount { get; set; }
    public bool IsStarted { get; set; }
}