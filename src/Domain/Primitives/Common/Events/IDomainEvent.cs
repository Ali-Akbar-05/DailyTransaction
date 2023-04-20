using MediatR;

namespace Domain.Primitives.Common.Events;

/// <summary>
/// The event interface.
/// </summary>
public interface IDomainEvent : INotification
{
/*    /// <summary>
    /// Gets the event identifier.
    /// </summary>
    Guid EventId { get; }

    /// <summary>
    /// Gets the event/aggregate root version.
    /// </summary>
    long EventVersion { get; }

    /// <summary>
    /// Gets the date the <see cref="IDomainEvent"/> occurred on.
    /// </summary>
    DateTime OccurredOn { get; }

    DateTimeOffset TimeStamp { get; }

    /// <summary>
    /// Gets type of this event.
    /// </summary>
    public string EventType { get; }*/
}