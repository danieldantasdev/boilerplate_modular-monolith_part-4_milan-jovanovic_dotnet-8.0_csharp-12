using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Modules.Training.Domain.Workouts;

namespace Infrastructure.Repositories;

internal sealed class WorkoutRepository(ApplicationDbContext context) : IWorkoutRepository
{
    public Task<Workout?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return context.Workouts.Include(w => w.Exercises).FirstOrDefaultAsync(w => w.Id == id, cancellationToken);
    }

    public void Insert(Workout workout)
    {
        context.Workouts.Add(workout);
    }

    public void Remove(Workout workout)
    {
        context.Workouts.Remove(workout);
    }
}
