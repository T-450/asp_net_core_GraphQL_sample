namespace ConferencePlanner.GraphQL.Sessions
{
    using System.Collections.Generic;
    using Data;
    using HotChocolate.Types.Relay;

    public record AddSessionInput(
        string Title,
        string? Abstract,
        [property: ID(nameof(Speaker))]
        IReadOnlyList<int> SpeakerIds);
}
