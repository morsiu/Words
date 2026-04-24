using System.Runtime.Serialization;

namespace Mors.Words.Data.Commands;

[DataContract(Name ="TrackWordCommand", Namespace = "words/commands")]
public sealed class TrackWordCommand
{
    [DataMember]
    public required string Word { get; init; }

    [DataMember]
    public WordContexts Contexts { get; init; }
}