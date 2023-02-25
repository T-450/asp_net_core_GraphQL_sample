namespace ConferencePlanner.GraphQL.Tracks
{
    using System.Collections.Generic;
    using Common;
    using Data;

    public class TrackPayloadBase : Payload
    {
        public TrackPayloadBase(Track track)
        {
            Track = track;
        }

        public TrackPayloadBase(IReadOnlyList<UserError> errors)
            : base(errors) { }

        public Track? Track { get; }
    }
}
