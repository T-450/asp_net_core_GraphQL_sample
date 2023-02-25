namespace ConferencePlanner.GraphQL.Sessions
{
    using System;
    using Data;
    using HotChocolate.Types.Relay;

    public record ScheduleSessionInput(
        [property: ID(nameof(Session))]
        int SessionId,
        [property: ID(nameof(Track))]
        int TrackId,
        DateTimeOffset StartTime,
        DateTimeOffset EndTime);
}
