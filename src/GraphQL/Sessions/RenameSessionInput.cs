namespace ConferencePlanner.GraphQL.Sessions
{
    using Data;
    using HotChocolate.Types.Relay;

    public record RenameSessionInput(
        [property: ID(nameof(Session))] string SessionId,
        string Title);
}
