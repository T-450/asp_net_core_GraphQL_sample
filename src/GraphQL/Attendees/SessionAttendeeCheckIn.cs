namespace ConferencePlanner.GraphQL.Attendees
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Data;
    using DataLoader;
    using HotChocolate;
    using HotChocolate.Types.Relay;
    using Microsoft.EntityFrameworkCore;

    public class SessionAttendeeCheckIn
    {
        public SessionAttendeeCheckIn(int attendeeId, int sessionId)
        {
            AttendeeId = attendeeId;
            SessionId = sessionId;
        }

        [ID(nameof(Attendee))]
        public int AttendeeId { get; }

        [ID(nameof(Session))]
        public int SessionId { get; }

        [UseApplicationDbContext]
        public async Task<int> CheckInCountAsync(
            [ScopedService] ApplicationDbContext context,
            CancellationToken cancellationToken)
        {
            return await context.Sessions
                .Where(session => session.Id == SessionId)
                .SelectMany(session => session.SessionAttendees)
                .CountAsync(cancellationToken);
        }

        public Task<Attendee> GetAttendeeAsync(
            AttendeeByIdDataLoader attendeeById,
            CancellationToken cancellationToken)
        {
            return attendeeById.LoadAsync(AttendeeId, cancellationToken);
        }

        public Task<Session> GetSessionAsync(
            SessionByIdDataLoader sessionById,
            CancellationToken cancellationToken)
        {
            return sessionById.LoadAsync(AttendeeId, cancellationToken);
        }
    }
}
