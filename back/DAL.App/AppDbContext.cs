using Domain.App;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.App;

public class AppDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public new DbSet<User> Users { get; set; } = default!;
    public DbSet<Competition> Competitions { get; set; } = default!;
    public DbSet<CompetitionStage> CompetitionStages { get; set; } = default!;
    public DbSet<CompetitionUser> CompetitionUsers { get; set; } = default!;
    public DbSet<Game> Games { get; set; } = default!;
    public DbSet<GameGroup> GameGroups { get; set; } = default!;
    public DbSet<Prediction> Predictions { get; set; } = default!;
    
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
}
