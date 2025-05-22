using Eris.Extension.Core.Style.Modules.Behavior;
using Eris.Extension.Core.Style.Modules.DamageSelf;
using Eris.Extension.Core.Style.State.DestroySelf;
using Eris.Extension.Core.World.NewExtension;
using Eris.Serializer;
using Eris.Utilities.Ini;
using Eris.Utilities.Ini.Parsers;
using NaegleriaSerializer;
using NaegleriaSerializer.Streaming;

namespace Eris.Extension.Core.Style;

public class StyleType : NewTypeExtension<StyleType>, INewTypeExtension, INewExt
{
    public static readonly NewTypeExtensionMapContainer<StyleType> ExtMap = new();
    static INewExtMap INewExt.ExtMap => ExtMap;

    private int _index;
    private string? _name;


    public override int Index => _index;
    public override string Section => _name!;

    public override void Initialize(int index, string section)
    {
        _index = index;
        _name = section;
    }

    public int Duration;

    public bool HoldDuration;

    public int Delay;

    public int InitialDelay;

    public int Loop;

    public StyleType[]? Next;

    public string? Group;
    public int GroupMaxCount = -1;
    public SameGroupBehavior GroupJoin = SameGroupBehavior.None;
    
    //Module
    protected DamageSelfModuleData? DamageSelfModuleData;
    protected BehaviorMoudleData? BehaviorMoudleData;
    
    //State
    protected DestroySelfData? DestroySelfStateModuleData;
    
    public override void LoadFromIni(IniReader reader)
    {
        using var section = reader[_name!];

        Parsers.Parse(section["Duration"u8], ref Duration);
        Parsers.Parse(section["HoldDuration"u8], ref HoldDuration);
        Parsers.Parse(section["Delay"u8], ref Delay);
        Parsers.Parse(section["InitialDelay"u8], ref InitialDelay);
        Parsers.Parse(section["Loop"u8], ref Loop);
        StyleTypeParser.Parse(section["Next"u8], ref Next);
        Parsers.Parse(section["Group"u8], ref Group);
        Parsers.Parse(section["Group.MaxCount"u8], ref GroupMaxCount);
        Parsers.Parse(section["Group.Join"u8], StyleOption.SameGroupBehaviorParser, ref GroupJoin);
        
        IniConfig.CreateAndRead(ref DamageSelfModuleData, section);
        IniConfig.CreateAndRead(ref BehaviorMoudleData, section);
        IniConfig.CreateAndRead(ref DestroySelfStateModuleData, section);
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
            .Process(ref Loop)
            .ProcessObject(ref DamageSelfModuleData)
            .ProcessObject(ref BehaviorMoudleData)
            .ProcessObject(ref DestroySelfStateModuleData)
            .ProcessObjectArrayInline(ref Next!)
            .ProcessStringInline(ref Group)
            .Process(ref GroupMaxCount)
            .Process(ref GroupJoin);
    }

    public int SerializeType => SerializeRegister.StyleTypeType;
    public ulong SerializeId { get; } = SerializeIdCreater.NewId();

    public override string ToString()
    {
        return $"{nameof(StyleType)}: {_name}";
    }

    //Module
    private StyleModulesFactory? _modulesFactory;
    public StyleModulesFactory ModulesFactory =>
        _modulesFactory ??= new StyleModulesFactory()
            .Concat(DamageSelfModuleData, DamageSelfModule.Activator)
            .Concat(BehaviorMoudleData, BehaviorMoudle.Activator);


    //State
    private StyleModulesFactory? _stateModulesFactory;
    public StyleModulesFactory StateModulesFactory =>
        _stateModulesFactory ??= new StyleModulesFactory()
            .Concat(DestroySelfStateModuleData, DestroySelfState.Activator);

    public static string Id => nameof(StyleType);
    
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

    public static bool Parse(string? val, ref StyleType[]? scripts)
    {
        if (string.IsNullOrWhiteSpace(val)) return false;
        
        var ids = val.Split(',', StringSplitOptions.RemoveEmptyEntries);
        scripts = new StyleType[ids.Length];

        for (var i = 0; i < scripts.Length; i++)
        {
            scripts[i] = StyleType.ExtMap.FindOrCreate(ids[i], out _);
        }
        return true;
    }
}

