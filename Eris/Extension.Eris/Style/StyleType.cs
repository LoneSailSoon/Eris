using Eris.Extension.Eris.Generic;
using Eris.Serializer;
using Eris.Utilities.Ini;
using Eris.Utilities.Ini.Parsers;
using NaegleriaSerializer;
using NaegleriaSerializer.Streaming;

namespace Eris.Extension.Eris.Style;

public class StyleType : NewTypeExtension<StyleType>, INaegleriaSerializable
{
    public static readonly NewTypeExtensionMapContainer<StyleType> ExtMap = new();
    
    
    private int _index;
    private string? _name;
    
    
    public override int Index => _index;
    public override string Section => _name!;
    public override void Initialize(int index, string section)
    {
        _index = index;
        _name = section;
    }
    
    
    
    public int Duration = 0;

    public bool HoldDuration = false;

    public int Delay = 0;

    public int InitialDelay = 0;

    public int Loop = 0;

    public override void LoadFromIni(IniReader reader)
    {
        Parsers.Parse(reader.Read(_name, "Duration"), ref Duration);
        Parsers.Parse(reader.Read(_name, "HoldDuration"), ref HoldDuration);
        Parsers.Parse(reader.Read(_name, "Delay"), ref Delay);
        Parsers.Parse(reader.Read(_name, "InitialDelay"), ref InitialDelay);
        Parsers.Parse(reader.Read(_name, "Loop"), ref Loop);
    }

    public void Serialize(INaegleriaStream stream)
    {
        stream
            .Process(ref _index)
            .ProcessStringInline(ref _name)
            .Process(ref Duration)
            .Process(ref HoldDuration)
            .Process(ref Delay)
            .Process(ref InitialDelay)
            .Process(ref Loop);
    }

    public int SerializeType => SerializeRegister.StyleTypeType;
    public ulong SerializeId { get; } = SerializeIdCreater.NewId();
}

public static class StyleTypeParser
{
    public static bool Parse(string? val, ref StyleType? buffer)
    {
        if (string.IsNullOrWhiteSpace(val))
        {
            return false;
        }

        buffer = StyleType.ExtMap.FindOrCreate(val, out _);

        return true;

    }

    //public static bool Parse(this ISection section, string key, ref StyleType? buffer) =>
    //    Parse(section.GetValue(key), ref buffer);

}

