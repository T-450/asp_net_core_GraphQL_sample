namespace ConferencePlanner.GraphQL.Tracks
{
    using System.Collections.Generic;
    using Common;
    using Data;

    public class RenameTrackPayload : TrackPayloadBase
    {
        public RenameTrackPayload(Track track)
            : base(track) { }

        public RenameTrackPayload(IReadOnlyList<UserError> errors)
            : base(errors) { }
    }
}
