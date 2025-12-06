using Eris.BeonSerializer.Streaming;

namespace Eris.BeonSerializer;

public interface IBeonSerializable
{
    void Serialize(IBeonStream stream);

    void OnSave(BeonSerializeStream stream)
    {
    }

    void OnLoad(BeonDeserializeStream stream)
    {
    }

    int SerializeType { get; }

    ulong SerializeId { get; }
}