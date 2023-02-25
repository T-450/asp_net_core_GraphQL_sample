namespace ConferencePlanner.GraphQL.Speakers
{
    using System.Collections.Generic;
    using Common;
    using Data;

    public class SpeakerPayloadBase : Payload
    {
        protected SpeakerPayloadBase(Speaker speaker)
        {
            Speaker = speaker;
        }

        protected SpeakerPayloadBase(IReadOnlyList<UserError> errors)
            : base(errors) { }

        public Speaker? Speaker { get; }
    }
}
