namespace ConferencePlanner.GraphQL.Speakers
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
    public class SpeakerQueries
    {
        [UseApplicationDbContext]
        [UsePaging]
        public IQueryable<Speaker> GetSpeakers(
            [ScopedService] ApplicationDbContext context)
        {
            return context.Speakers.OrderBy(t => t.Name);
        }

        public Task<Speaker> GetSpeakerByIdAsync(
            [ID(nameof(Speaker))] int id,
            SpeakerByIdDataLoader dataLoader,
            CancellationToken cancellationToken)
        {
            return dataLoader.LoadAsync(id, cancellationToken);
        }

        public async Task<IEnumerable<Speaker>> GetSpeakersByIdAsync(
            [ID(nameof(Speaker))] int[] ids,
            SpeakerByIdDataLoader dataLoader,
            CancellationToken cancellationToken)
        {
            return await dataLoader.LoadAsync(ids, cancellationToken);
        }
    }
}
