namespace Pantomime.Entities;

public class Team : BaseEntity<int>
{
    public string Name { get; set; }

    public List<Game> Games { get; set; }
    public List<GamePlay> GamePlays { get; set; }
}