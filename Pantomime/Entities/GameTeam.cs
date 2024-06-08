namespace Pantomime.Entities;

public class GameTeam : BaseEntity<int>
{
    public int GameId { get; set; }
    public int TeamId { get; set; }

    public Game Game { get; set; }
    public Team Team { get; set; }
}