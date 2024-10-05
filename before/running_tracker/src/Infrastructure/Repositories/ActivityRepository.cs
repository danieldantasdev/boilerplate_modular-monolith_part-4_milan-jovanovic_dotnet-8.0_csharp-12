using Infrastructure.Database;
using Modules.Training.Domain.Activities;

namespace Infrastructure.Repositories;

internal sealed class ActivityRepository(ApplicationDbContext context) : IActivityRepository
{
    public void Insert(Activity activity)
    {
        context.Activities.Add(activity);
    }
}
