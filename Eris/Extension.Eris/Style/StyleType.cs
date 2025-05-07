using Eris.Extension.Eris.Generic;
using Eris.Extension.Eris.Style.Modules.DamageSelf;
using Eris.Extension.Eris.Style.State.DestroySelf;
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

    public int Duration;

    public bool HoldDuration;

    public int Delay;

    public int InitialDelay;

    public int Loop;

    //Module
    protected DamageSelfModuleData? DamageSelfModuleData;

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

        IniConfig.CreateAndRead(ref DamageSelfModuleData, section);
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
            .ProcessObject(ref DamageSelfModuleData!)
            .ProcessObject(ref DestroySelfStateModuleData!);
    }

    public int SerializeType => SerializeRegister.StyleTypeType;
    public ulong SerializeId { get; } = SerializeIdCreater.NewId();

    public override string ToString()
    {
        return $"{nameof(StyleType)}: {_name}";
    }

    //Module
    private StyleModulesFactory? _modulesFactory;
    public StyleModulesFactory ModulesFactory
    {
        get
        {
            if (_modulesFactory is null)
            {
                List<StyleModuleFactory> modules = [];

                if (DamageSelfModuleData is { Enable : true })
                    modules.Add(
                        new StyleModuleFactory<DamageSelfModule, DamageSelfModuleData>(
                            DamageSelfModule.Activator,
                            DamageSelfModuleData));


                _modulesFactory = new StyleModulesFactory(modules);
            }

            return _modulesFactory;
        }
    }
    
    
    //State
    private StyleModulesFactory? _stateModulesFactory;

    public StyleModulesFactory StateModulesFactory
    {
        get
        {
            if (_stateModulesFactory is null)
            {
                List<StyleModuleFactory> modules = [];

                if (DestroySelfStateModuleData is { Enable : true })
                    modules.Add(
                        new StyleModuleFactory<DestroySelfState, DestroySelfData>(
                            DestroySelfState.Activator,
                            DestroySelfStateModuleData));

                _stateModulesFactory = new StyleModulesFactory(modules);
            }

            return _stateModulesFactory;
        }
    }

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

