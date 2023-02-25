namespace ConferencePlanner.GraphQL.Sessions
{
    using Common;
    using Data;

    public class AddSessionPayload : Payload
    {
        public AddSessionPayload(Session session)
        {
            Session = session;
        }

        public AddSessionPayload(UserError error)
            : base(new[] { error }) { }

        public Session? Session { get; }
    }
}
