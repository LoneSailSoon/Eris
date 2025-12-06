using Eris.BeonSerializer;

namespace Eris.Component.Root.CustomEntity;

public interface ICustomEntityType : IBeonSerializable
{
    public static abstract string Id { get; }
}