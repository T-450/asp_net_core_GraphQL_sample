namespace ConferencePlanner.GraphQL.Attendees
{
    using System.Collections.Generic;
    using Common;
    using Data;

    public class AttendeePayloadBase : Payload
    {
        protected AttendeePayloadBase(Attendee attendee) { }

        protected AttendeePayloadBase(IReadOnlyList<UserError> errors)
            : base(errors) { }

        public Attendee? Attendee { get; }
    }
}
