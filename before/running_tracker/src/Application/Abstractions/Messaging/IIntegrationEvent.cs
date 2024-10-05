using MediatR;

namespace Application.Abstractions.Messaging;

public interface IIntegrationEvent : INotification
{
    Guid Id { get; init; }
}
