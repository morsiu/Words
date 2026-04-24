using System.Runtime.Serialization;

namespace Mors.Words.Data.Commands;

[DataContract(Name = "HideWordCommand", Namespace = "words/commands")]
public sealed class HideWordCommand
{
    [DataMember]
    public required string Word { get; init; }

    [DataMember]
    public WordContext Context { get; init; }
}