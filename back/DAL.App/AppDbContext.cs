using Domain.App;
using Domain.App.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.App;

public class AppDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public DbSet<RefreshToken> RefreshTokens { get; set; } = default!;
    public new DbSet<User> Users { get; set; } = default!;
    public DbSet<Competition> Competitions { get; set; } = default!;
    public DbSet<CompetitionStage> CompetitionStages { get; set; } = default!;
    public DbSet<CompetitionType> CompetitionTypes { get; set; } = default!;
    public DbSet<CompetitionUser> CompetitionUsers { get; set; } = default!;
    public DbSet<Game> Games { get; set; } = default!;
    public DbSet<GameDay> GameDays { get; set; } = default!;
    public DbSet<Prediction> Predictions { get; set; } = default!;
    public DbSet<ScoringRules> ScoringRules { get; set; } = default!;
    
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
}
