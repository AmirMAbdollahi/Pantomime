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
        modelBuilder.Entity<Word>(entity =>
        {
            entity.HasKey(word => word.Id);

            entity.Property(word => word.IsDeleted)
                .IsRequired().HasColumnType("bit");

            entity.Property(word => word.Name)
                .IsRequired().HasColumnType("varchar(150)");

            entity.HasOne(word => word.Category)
                .WithMany(category => category.Words)
                .HasForeignKey(word => word.CategoryId);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(category => category.Id);

            entity.Property(category => category.IsDeleted)
                .IsRequired().HasColumnType("bit");

            entity.Property(category => category.Name)
                .IsRequired().HasColumnType("varchar(50)");
        });

        modelBuilder.Entity<GamePlay>(entity =>
        {
            entity.HasKey(gamePlay => gamePlay.Id);

            entity.Property(gamePlay => gamePlay.IsDeleted)
                .IsRequired().HasColumnType("bit");

            entity.Property(gamePlay => gamePlay.Round)
                .IsRequired()
                //.HasDefaultValue(3)
                .HasColumnType("tinyint");

            entity.HasOne(gamePlay => gamePlay.Category)
                .WithMany(category => category.GamePlays)
                .HasForeignKey(gamePlay => gamePlay.CategoryId);

            entity.HasOne(gamePlay => gamePlay.Team)
                .WithMany(team => team.GamePlays)
                .HasForeignKey(gamePlay => gamePlay.TeamId);

            entity.HasOne(gamePlay => gamePlay.Game)
                .WithMany(game => game.GamePlays)
                .HasForeignKey(gamePlay => gamePlay.GameId);
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(game => game.Id);

            entity.Property(game => game.IsDeleted)
                .IsRequired().HasColumnType("bit");

            entity.Property(game => game.Title)
                .IsRequired(false).HasColumnType("varchar(50)");

            entity.Property(game => game.IsStarted)
                .IsRequired().HasColumnType("bit");

            entity.Property(game => game.TotalRoundCount)
                .IsRequired().HasColumnType("tinyint");
        });
        
        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(team => team.Id);

            entity.Property(team => team.Name)
                .IsRequired().HasColumnType("varchar(50)");

            entity.Property(team => team.IsDeleted)
                .IsRequired().HasColumnType("bit");
        });

        modelBuilder.Entity<GameTeam>(entity =>
        {
            entity.HasKey(gameTeam => gameTeam.Id);

            entity.Property(gameTeam => gameTeam.IsDeleted)
                .IsRequired().HasColumnType("bit");

            entity.HasOne(gameTeam => gameTeam.Game)
                .WithMany(team => team.Teams)
                .HasForeignKey(gameTeam => gameTeam.GameId);

            entity.HasOne(gameTeam => gameTeam.Team)
                .WithMany(game => game.Games)
                .HasForeignKey(gameTeam => gameTeam.TeamId);
        });
    }
}