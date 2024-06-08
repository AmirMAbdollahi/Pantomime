namespace Pantomime.Entities;

public class Word : BaseEntity<int>
{
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}