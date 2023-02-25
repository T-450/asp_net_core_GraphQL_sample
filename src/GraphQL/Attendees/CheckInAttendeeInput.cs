namespace ConferencePlanner.GraphQL.Attendees
{
    using Data;
    using HotChocolate.Types.Relay;

    public record CheckInAttendeeInput(
        [property: ID(nameof(Session))]
        int SessionId,
        [property: ID(nameof(Attendee))]
        int AttendeeId);
}
