using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Modules.Training.Domain.Activities;
using Modules.Training.Domain.Workouts;
using Modules.Users.Domain.Users;
using SharedKernel;

namespace Modules.Training.Application.Activities.Create;

internal sealed class CreateActivityCommandHandler(
    IUserRepository userRepository,
    IWorkoutRepository workoutRepository,
    IActivityRepository activityRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<CreateActivityCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateActivityCommand request, CancellationToken cancellationToken)
    {
        User? user = await userRepository.GetByIdAsync(request.UserId, cancellationToken);
        if (user is null)
        {
            return Result.Failure<Guid>(UserErrors.NotFound(request.UserId));
        }

        Workout? workout = await workoutRepository.GetByIdAsync(request.WorkoutId, cancellationToken);
        if (workout is null)
        {
            return Result.Failure<Guid>(WorkoutErrors.NotFound(request.WorkoutId));
        }

        var activity = Activity.Create(
            user.Id,
            workout.Id,
            new Distance(request.DistanceInMeters),
            TimeSpan.FromSeconds(request.DurationInSeconds));

        activityRepository.Insert(activity);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return activity.Id;
    }
}
