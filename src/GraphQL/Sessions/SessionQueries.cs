namespace ConferencePlanner.GraphQL.Sessions
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Data;
    using DataLoader;
    using HotChocolate;
    using HotChocolate.Data;
    using HotChocolate.Types;
    using HotChocolate.Types.Relay;

    [ExtendObjectType(OperationTypeNames.Query)]
    public class SessionQueries
    {
        [UseApplicationDbContext]
        [UsePaging]
        [UseFiltering(typeof(SessionFilterInputType))]
        [UseSorting]
        public IQueryable<Session> GetSessions(
            [ScopedService] ApplicationDbContext context)
        {
            return context.Sessions;
        }

        public Task<Session> GetSessionByIdAsync(
            [ID(nameof(Session))] int id,
            SessionByIdDataLoader sessionById,
            CancellationToken cancellationToken)
        {
            return sessionById.LoadAsync(id, cancellationToken);
        }

        public async Task<IEnumerable<Session>> GetSessionsByIdAsync(
            [ID(nameof(Session))] int[] ids,
            SessionByIdDataLoader sessionById,
            CancellationToken cancellationToken)
        {
            return await sessionById.LoadAsync(ids, cancellationToken);
        }
    }
}
