namespace ConferencePlanner.GraphQL.Sessions
{
    using System.Collections.Generic;
    using Common;
    using Data;

    public class SessionPayloadBase : Payload
    {
        protected SessionPayloadBase(Session session)
        {
            Session = session;
        }

        protected SessionPayloadBase(IReadOnlyList<UserError> errors)
            : base(errors) { }

        public Session? Session { get; }
    }
}
