using NaegleriaSerializer;
using NaegleriaSerializer.Streaming;

namespace Eris.Utilities.Ini;

public abstract class IniConfig : INaegleriaSerializable
{
    public abstract void Serialize(INaegleriaStream stream);

    public abstract int SerializeType { get; }
    public ulong SerializeId { get; } = SerializeIdCreater.NewId();

    public abstract void Read(Section section);

    public virtual void Parser(string? data)
    {
        
    }

    public static void CreateAndRead<TConfig>(ref TConfig? config, Section section) where TConfig : IniConfig, new()
    {
        (config ??= new()).Read(section);
    }
}

public abstract class FilterableConfig : IniConfig
{
    public abstract bool Enable { get; }
}