namespace ConferencePlanner.GraphQL.Speakers
{
    using System.Collections.Generic;
    using Common;
    using Data;

    public class AddSpeakerPayload : SpeakerPayloadBase
    {
        public AddSpeakerPayload(Speaker speaker)
            : base(speaker) { }

        public AddSpeakerPayload(IReadOnlyList<UserError> errors)
            : base(errors) { }
    }
}
