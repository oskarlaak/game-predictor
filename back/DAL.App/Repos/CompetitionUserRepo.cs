using DAL.Interfaces.App.Repos;
using Domain.App;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.Repos;

public class CompetitionUserRepo : AppBaseRepo<CompetitionUser>, ICompetitionUserRepo
{
    public CompetitionUserRepo(AppDbContext ctx) : base(ctx)
    {
    }

    public async Task<bool> CompetitionHasUser(Guid competitionId, Guid userId)
    {
        return await DbSet
            .AnyAsync(cu =>
                cu.CompetitionId == competitionId &&
                cu.UserId == userId
            );
    }

    public async Task<bool> CompetitionDoesNotHaveUser(Guid competitionId, Guid userId)
    {
        return !await CompetitionHasUser(competitionId, userId);
    }

    public async Task<bool> UserIsHostOfCompetition(Guid userId, Guid competitionId)
    {
        return await DbSet
            .AnyAsync(cu =>
                cu.CompetitionId == competitionId &&
                cu.UserId == userId &&
                cu.IsHost
            );
    }

    public async Task<bool> UserIsNotHostOfCompetition(Guid userId, Guid competitionId)
    {
        return await DbSet
            .AnyAsync(cu =>
                cu.CompetitionId == competitionId &&
                cu.UserId == userId &&
                !cu.IsHost
            );
    }

    public async Task DeleteUserFromCompetition(Guid userId, Guid competitionId)
    {
        DbSet.Remove(
            await DbSet.FirstAsync(cu =>
                cu.CompetitionId == competitionId &&
                cu.UserId == userId
            )
        );
    }

    public async Task<bool> CompetitionUserDoesNotBelongToUser(Guid id, Guid userId)
    {
        return await DbSet
            .AnyAsync(cu =>
                cu.Id == id &&
                cu.UserId != userId
            );
    }
}
