namespace Pantomime.Entities;

public class Category : BaseEntity<int>
{
    public string Name { get; set; }
    
    public List<Word> Words { get; set; }
    public List<GamePlay> GamePlays { get; set; }
}