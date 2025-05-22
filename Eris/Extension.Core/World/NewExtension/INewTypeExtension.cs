using NaegleriaSerializer;

namespace Eris.Extension.Core.World.NewExtension;

public interface INewTypeExtension : INaegleriaSerializable
{
    public static abstract string Id { get; }
}