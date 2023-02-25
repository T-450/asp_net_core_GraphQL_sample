namespace ConferencePlanner.GraphQL.Speakers
{
    using Data;
    using HotChocolate.Types;
    using HotChocolate.Types.Relay;

    public record UploadSpeakerPhotoInput([ID(nameof(Speaker))] int Id, IFile Photo);
}
