namespace ConferencePlanner.GraphQL.Speakers
{
    using Common;
    using Data;

    public class ModifySpeakerPayload : SpeakerPayloadBase
    {
        public ModifySpeakerPayload(Speaker speaker)
            : base(speaker) { }

        public ModifySpeakerPayload(UserError error)
            : base(new[] { error }) { }
    }
}
