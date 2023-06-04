using Domain.App;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.Seeding;

public class DataSeeder
{
    public static void DropDatabase(AppDbContext ctx)
    {
        ctx.Database.EnsureDeleted();
    }
    
    public static void MigrateDatabase(AppDbContext ctx)
    {
        ctx.Database.Migrate();
    }
    
    public static void SeedAppData(AppDbContext ctx)
    {
        // ctx.SaveChanges();
    }
    
    private static User? SeedUser(
        UserManager<User> userManager,
        string username,
        string email,
        string password)
    {
        User appUser = new()
        {
            UserName = username,
            Email = email,
            RefreshToken = Guid.NewGuid().ToString(),
            RefreshTokenExpirationDT = DateTime.UtcNow.AddDays(7)
        };

        IdentityResult result = userManager.CreateAsync(appUser, password).Result;

        return result.Succeeded ? appUser : null;
    }
    
    public static void SeedTestData(AppDbContext ctx, UserManager<User> userManager)
    {
        User? u1 = userManager.FindByEmailAsync("user1@seeded.com").Result;
        User? u2 = userManager.FindByEmailAsync("user2@seeded.com").Result;
        User? u3 = userManager.FindByEmailAsync("user3@seeded.com").Result;
        
        if (u1 != null && u2 != null && u3 != null) return;
        
        u1 = SeedUser(userManager, "user1", "user1@seeded.com", "User.1");
        u2 = SeedUser(userManager, "user2", "user2@seeded.com", "User.2");
        u3 = SeedUser(userManager, "user3", "user3@seeded.com", "User.3");

        SeedAppData(ctx);

        Competition c = new()
        {
            Name = "MM 2022",
            HasEnded = false
        };
        ctx.Competitions.AddRange(c);

        CompetitionStage cs = new()
        {
            Competition = c,
            Name = "GROUP STAGE",
            PointsOnCorrectScore = 3,
            PointsOnCorrectScoreDifference = 2,
            PointsOnCorrectResult = 1,
            CreatedDT = DateTime.UtcNow
        };
        ctx.CompetitionStages.AddRange(cs);

        GameGroup nov20 = new()
        {
            CompetitionStage = cs,
            Name = "20. November",
            CreatedDT = DateTime.UtcNow.AddDays(-1)
        };
        GameGroup nov21 = new()
        {
            CompetitionStage = cs,
            Name = "21. November",
            CreatedDT = DateTime.UtcNow
        };
        ctx.GameGroups.AddRange(nov20, nov21);

        Game qatarEcuador = new()
        {
            GameGroup = nov20,
            TeamOneName = "Qatar",
            TeamTwoName = "Ecuador",
            TeamOneScore = 0,
            TeamTwoScore = 2,
            PredictionDeadlineDT = DateTime.UtcNow.AddDays(-1),
            CreatedDT = DateTime.UtcNow
        };
        Game englandIran = new()
        {
            GameGroup = nov21,
            TeamOneName = "England",
            TeamTwoName = "Iran",
            TeamOneScore = null,
            TeamTwoScore = null,
            PredictionDeadlineDT = DateTime.UtcNow,
            CreatedDT = DateTime.UtcNow
        };
        Game senegalNetherlands = new()
        {
            GameGroup = nov21,
            TeamOneName = "Senegal",
            TeamTwoName = "Netherlands",
            TeamOneScore = null,
            TeamTwoScore = null,
            PredictionDeadlineDT = DateTime.UtcNow.AddHours(1),
            CreatedDT = DateTime.UtcNow.AddHours(1)
        };
        Game usaWales = new()
        {
            GameGroup = nov21,
            TeamOneName = "USA",
            TeamTwoName = "Wales",
            TeamOneScore = null,
            TeamTwoScore = null,
            PredictionDeadlineDT = DateTime.UtcNow.AddHours(2),
            CreatedDT = DateTime.UtcNow.AddHours(2)
        };
        ctx.Games.AddRange(qatarEcuador, englandIran, senegalNetherlands, usaWales);
        
        CompetitionUser cu1 = new()
        {
            Competition = c,
            User = u1,
            IsHost = true,
            CreatedDT = DateTime.UtcNow.AddDays(-2)
        };
        CompetitionUser cu2 = new()
        {
            Competition = c,
            User = u2,
            IsHost = false,
            CreatedDT = DateTime.UtcNow.AddDays(-1)
        };
        CompetitionUser cu3 = new()
        {
            Competition = c,
            User = u3,
            IsHost = false,
            CreatedDT = DateTime.UtcNow
        };
        ctx.CompetitionUsers.AddRange(cu1, cu2, cu3);
        
        Prediction p1 = new()
        {
            CompetitionUser = cu1,
            Game = senegalNetherlands,
            TeamOneScore = 1,
            TeamTwoScore = 1
        };
        Prediction p2 = new()
        {
            CompetitionUser = cu2,
            Game = usaWales,
            TeamOneScore = 2,
            TeamTwoScore = 2
        };
        Prediction p3 = new()
        {
            CompetitionUser = cu3,
            Game = englandIran,
            TeamTwoScore = 3,
            TeamOneScore = 0
        };
        ctx.Predictions.AddRange(p1, p2, p3);
        
        ctx.SaveChanges();
    }
}
