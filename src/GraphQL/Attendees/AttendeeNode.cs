namespace ConferencePlanner.GraphQL.Attendees
{
    using System.Collections.Generic;
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
    [ExtendObjectType]
    public class AttendeeNode
    {
        public async Task<IEnumerable<Session>> GetSessionsAsync(
            [Parent] Attendee attendee,
            [ScopedService] ApplicationDbContext dbContext,
            SessionByIdDataLoader sessionById,
            CancellationToken cancellationToken)
        {
            int[] speakerIds = await dbContext.Attendees
                .Where(a => a.Id == attendee.Id)
                .Include(a => a.SessionsAttendees)
                .SelectMany(a => a.SessionsAttendees.Select(t => t.SessionId))
                .ToArrayAsync(cancellationToken);

            return await sessionById.LoadAsync(speakerIds, cancellationToken);
        }

        [NodeResolver]
        public static Task<Attendee> GetAttendeeAsync(
            int id,
            AttendeeByIdDataLoader attendeeById,
            CancellationToken cancellationToken)
        {
            return attendeeById.LoadAsync(id, cancellationToken);
        }
    }
}
