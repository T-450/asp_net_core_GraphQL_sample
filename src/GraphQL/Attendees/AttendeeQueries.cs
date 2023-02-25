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

    [ExtendObjectType(OperationTypeNames.Query)]
    public class AttendeeQueries
    {
        /// <summary>
        ///     Gets all attendees of this conference.
        /// </summary>
        [UseApplicationDbContext]
        [UsePaging]
        public IQueryable<Attendee> GetAttendees(
            [ScopedService] ApplicationDbContext context)
        {
            return context.Attendees;
        }

        /// <summary>
        ///     Gets an attendee by its identifier.
        /// </summary>
        /// <param name="id">The attendee identifier.</param>
        /// <param name="attendeeById"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<Attendee> GetAttendeeByIdAsync(
            [ID(nameof(Attendee))] int id,
            AttendeeByIdDataLoader attendeeById,
            CancellationToken cancellationToken)
        {
            return attendeeById.LoadAsync(id, cancellationToken);
        }

        public async Task<IEnumerable<Attendee>> GetAttendeesByIdAsync(
            [ID(nameof(Attendee))] int[] ids,
            AttendeeByIdDataLoader attendeeById,
            CancellationToken cancellationToken)
        {
            return await attendeeById.LoadAsync(ids, cancellationToken);
        }
    }
}
