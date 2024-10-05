namespace Application.Abstractions.Messaging;

public abstract record IntegrationEvent(Guid Id) : IIntegrationEvent;
