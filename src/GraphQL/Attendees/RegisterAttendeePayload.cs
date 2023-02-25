namespace ConferencePlanner.GraphQL.Attendees
{
    using Common;
    using Data;

    public class RegisterAttendeePayload : AttendeePayloadBase
    {
        public RegisterAttendeePayload(Attendee attendee)
            : base(attendee) { }

        public RegisterAttendeePayload(UserError error)
            : base(new[] { error }) { }
    }
}
