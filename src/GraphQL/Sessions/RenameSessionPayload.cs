namespace ConferencePlanner.GraphQL.Sessions
{
    using Common;
    using Data;

    public class RenameSessionPayload : Payload
    {
        public RenameSessionPayload(Session session)
        {
            Session = session;
        }

        public RenameSessionPayload(UserError error)
            : base(new[] { error }) { }

        public Session? Session { get; }
    }
}
