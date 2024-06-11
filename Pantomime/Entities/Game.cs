namespace Pantomime.Entities;

public class Game : BaseEntity<int>
{
    public string Title { get; set; }
    public byte TotalRoundCount { get; set; }
    public bool IsStarted { get; set; }
    
    public List<GameTeam> Teams { get; set; }
    public List<GamePlay> GamePlays { get; set; }
}