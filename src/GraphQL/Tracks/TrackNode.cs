namespace ConferencePlanner.GraphQL.Tracks
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Data;
    using DataLoader;
    using HotChocolate;
    using HotChocolate.Types;
    using HotChocolate.Types.Relay;

    [Node]
    [ExtendObjectType(typeof(Track))]
    public class TrackNode
    {
        [UseUpperCase]
        public string GetName([Parent] Track track)
        {
            return track.Name!;
        }

        [UseApplicationDbContext]
        [UsePaging(ConnectionName = "TrackSessions")]
        public IQueryable<Session> GetSessions(
            [Parent] Track track,
            [ScopedService] ApplicationDbContext dbContext)
        {
            return dbContext.Tracks.Where(t => t.Id == track.Id).SelectMany(t => t.Sessions);
        }

        [NodeResolver]
        public static Task<Track> GetTrackByIdAsync(
            int id,
            TrackByIdDataLoader trackByIdDataLoader,
            CancellationToken cancellationToken)
        {
            return trackByIdDataLoader.LoadAsync(id, cancellationToken);
        }
    }
}
