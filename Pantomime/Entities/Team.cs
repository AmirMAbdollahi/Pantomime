namespace Pantomime.Entities;

public class Team : BaseEntity<int>
{
    public string Name { get; set; }

    public List<GameTeam> Games { get; set; }
    public List<GamePlay> GamePlays { get; set; }
}