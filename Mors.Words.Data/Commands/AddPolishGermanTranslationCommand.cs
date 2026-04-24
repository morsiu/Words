using System.Runtime.Serialization;

namespace Mors.Words.Data.Commands;

[DataContract]
public sealed class AddPolishGermanTranslationCommand
{
    [DataMember]
    public required string GermanWord { get; init;  }

    [DataMember]
    public required string PolishWord { get; init; }
}