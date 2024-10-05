using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Modules.Users.Domain.Followers;

namespace Infrastructure.Repositories;

internal sealed class FollowerRepository(ApplicationDbContext context) : IFollowerRepository
{
    public Task<bool> IsAlreadyFollowingAsync(
        Guid userId,
        Guid followedId,
        CancellationToken cancellationToken = default) =>
        context.Followers.AnyAsync(
            f => f.UserId == userId && f.FollowedId == followedId,
            cancellationToken);

    public void Insert(Follower follower)
    {
        context.Followers.Add(follower);
    }
}
