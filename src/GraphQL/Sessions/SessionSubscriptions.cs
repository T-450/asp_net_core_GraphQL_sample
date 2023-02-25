namespace ConferencePlanner.GraphQL.Sessions
{
    using System.Threading;
    using System.Threading.Tasks;
    using Data;
    using DataLoader;
    using HotChocolate;
    using HotChocolate.Types;

    [ExtendObjectType(OperationTypeNames.Subscription)]
    public class SessionSubscriptions
    {
        [Subscribe]
        [Topic]
        public Task<Session> OnSessionScheduledAsync(
            [EventMessage] int sessionId,
            SessionByIdDataLoader sessionById,
            CancellationToken cancellationToken)
        {
            return sessionById.LoadAsync(sessionId, cancellationToken);
        }
    }
}
