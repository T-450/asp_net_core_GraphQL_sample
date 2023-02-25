namespace ConferencePlanner.GraphQL.Tracks
{
    using Data;
    using HotChocolate.Types.Relay;

    public record RenameTrackInput(
        [property: ID(nameof(Track))] int Id,
        string Name);
}
