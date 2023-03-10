namespace ConferencePlanner.GraphQL.Speakers
{
    using Data;
    using HotChocolate;
    using HotChocolate.Types.Relay;

    public record ModifySpeakerInput(
        [property: ID(nameof(Speaker))]
        int Id,
        Optional<string?> Name,
        Optional<string?> Bio,
        Optional<string?> WebSite);
}
