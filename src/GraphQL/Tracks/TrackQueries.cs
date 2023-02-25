namespace ConferencePlanner.GraphQL.Tracks
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

    [ExtendObjectType(OperationTypeNames.Query)]
    public class TrackQueries
    {
        [UseApplicationDbContext]
        [UsePaging]
        public IQueryable<Track> GetTracks(
            [ScopedService] ApplicationDbContext context)
        {
            return context.Tracks.OrderBy(t => t.Name);
        }

        [UseApplicationDbContext]
        public Task<Track> GetTrackByNameAsync(
            string name,
            [ScopedService] ApplicationDbContext context,
            CancellationToken cancellationToken)
        {
            return context.Tracks.FirstAsync(t => t.Name == name, cancellationToken);
        }

        [UseApplicationDbContext]
        public async Task<IEnumerable<Track>> GetTrackByNamesAsync(
            string[] names,
            [ScopedService] ApplicationDbContext context,
            CancellationToken cancellationToken)
        {
            return await context.Tracks.Where(t => names.Contains(t.Name)).ToListAsync(cancellationToken);
        }

        public Task<Track> GetTrackByIdAsync(
            [ID(nameof(Track))] int id,
            TrackByIdDataLoader trackById,
            CancellationToken cancellationToken)
        {
            return trackById.LoadAsync(id, cancellationToken);
        }

        public async Task<IEnumerable<Track>> GetSessionsByIdAsync(
            [ID(nameof(Track))] int[] ids,
            TrackByIdDataLoader trackById,
            CancellationToken cancellationToken)
        {
            return await trackById.LoadAsync(ids, cancellationToken);
        }
    }
}
