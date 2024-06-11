namespace Pantomime.Entities;

public class GamePlay : BaseEntity<int>
{
    public byte Round { get; set; }
    
    public int GameId { get; set; }
    public Game Game { get; set; }
    
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    
    public int TeamId { get; set; }
    public Team Team { get; set; }
}