using Microsoft.EntityFrameworkCore;
using Pantomime.Entities;

namespace Pantomime.DbContexts;

public class PantomimeDbContext : DbContext
{
    public PantomimeDbContext()
    {
        
    }
    
    public PantomimeDbContext(DbContextOptions<PantomimeDbContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<GamePlay> GamePlays { get; set; }
    public DbSet<GameTeam> GameTeams { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Word> Words { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "server=localhost;database=Pantomime;user=sa;password=yourStrong(!)Password;TrustServerCertificate=True");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}