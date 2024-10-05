using Infrastructure.Database;
using Modules.Training.Domain.Workouts;

namespace Infrastructure.Repositories;

internal sealed class ExerciseRepository(ApplicationDbContext context) : IExerciseRepository
{
    public void Insert(Exercise exercise)
    {
        context.Exercises.Add(exercise);
    }
}
