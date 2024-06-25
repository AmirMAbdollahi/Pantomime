namespace Pantomime.DTO.GameDto;

public class UpdateGameDto
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public byte TotalRoundCount { get; set; }
    
    public bool IsStarted { get; set; }
}