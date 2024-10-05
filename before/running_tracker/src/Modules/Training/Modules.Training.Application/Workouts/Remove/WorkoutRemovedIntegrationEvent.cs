using Application.Abstractions.Messaging;

namespace Modules.Training.Application.Workouts.Remove;

public record WorkoutRemovedIntegrationEvent(Guid Id, Guid WorkoutId) : IntegrationEvent(Id);
