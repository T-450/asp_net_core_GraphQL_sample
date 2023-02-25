namespace ConferencePlanner.GraphQL.Speakers
{
    using Common;
    using Data;

    public class UploadSpeakerPhotoPayload : SpeakerPayloadBase
    {
        public UploadSpeakerPhotoPayload(Speaker speaker)
            : base(speaker) { }

        public UploadSpeakerPhotoPayload(UserError error)
            : base(new[] { error }) { }
    }
}
