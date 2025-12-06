using Eris.BeonSerializer;
using Eris.BeonSerializer.Streaming;

namespace Eris.Utilities.Ini;

public abstract class IniConfig : IBeonSerializable
{
    public abstract void Serialize(IBeonStream stream);

    public abstract int SerializeType { get; }
    public ulong SerializeId { get; } = SerializeIdCreater.NewId();

    public abstract void Read(IniSection section, IIniId id);

    public virtual void Parser(string? data)
    {
        
    }

    public static void CreateAndRead<TConfig>(ref TConfig? config, IniSection section, IIniId id) where TConfig : IniConfig, new()
    {
        (config ??= new()).Read(section, id);
    }
}

public abstract class FilterableConfig : IniConfig
{
    public abstract bool Enable { get; }
}