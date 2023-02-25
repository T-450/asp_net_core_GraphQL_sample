namespace ConferencePlanner.GraphQL.Tracks
{
    using System.Collections.Generic;
    using Common;
    using Data;

    public class AddTrackPayload : TrackPayloadBase
    {
        public AddTrackPayload(Track track)
            : base(track) { }

        public AddTrackPayload(IReadOnlyList<UserError> errors)
            : base(errors) { }
    }
}
