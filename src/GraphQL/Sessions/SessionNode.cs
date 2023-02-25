namespace ConferencePlanner.GraphQL.Sessions
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Data;
    using DataLoader;
    using HotChocolate;
    using HotChocolate.Types;
    using HotChocolate.Types.Relay;
    using Microsoft.EntityFrameworkCore;

    [Node]
    [ExtendObjectType(typeof(Session))]
    public class SessionNode
    {
        [BindMember(nameof(Session.SessionSpeakers), Replace = true)]
        public Task<Speaker[]> GetSpeakersAsync(
            [Parent] Session session,
            SpeakerBySessionIdDataLoader speakerBySessionId,
            CancellationToken cancellationToken)
        {
            return speakerBySessionId.LoadAsync(session.Id, cancellationToken);
        }

        [UsePaging(ConnectionName = "SessionAttendees")]
        [BindMember(nameof(Session.SessionAttendees), Replace = true)]
        public IQueryable<Attendee> GetAttendees(
            [Parent] Session session,
            [ScopedService] ApplicationDbContext dbContext)
        {
            return dbContext.Sessions
                .Where(s => s.Id == session.Id)
                .Include(s => s.SessionAttendees)
                .SelectMany(s => s.SessionAttendees.Select(t => t.Attendee!));
        }

        public async Task<Track?> GetTrackAsync(
            [Parent] Session session,
            TrackByIdDataLoader trackById,
            CancellationToken cancellationToken)
        {
            return session.TrackId is not null
                ? await trackById.LoadAsync(session.TrackId.Value, cancellationToken)
                : null;
        }

        [NodeResolver]
        public static Task<Session> GetSessionByIdAsync(
            int id,
            SessionByIdDataLoader sessionById,
            CancellationToken cancellationToken)
        {
            return sessionById.LoadAsync(id, cancellationToken);
        }
    }
}
