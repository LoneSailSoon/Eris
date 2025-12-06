using Eris.Component.Scripts;
using Eris.BeonSerializer;
using Eris.Utilities.Ini;

namespace Eris.Scripts;

public static class ScriptsRegister
{
    private const int ScriptStart = 500;

    public const int TestScriptType = ScriptStart + 0;
    public const int TestScriptDataType = ScriptStart + 1;
    public const int WipParallelFactoryScriptType = ScriptStart + 2;
    public const int WipParallelFactoryDataType = ScriptStart + 3;

    public static void RegisterScript<TScript>(string name, int scriptType) where TScript : Component.Generic.Component, new()
    {
        ScriptManager.RegisterScript(name, static () => new TScript());
        DeserializeObjectActivator.Register(scriptType, static () => new TScript());
    } 

    public static void RegisterScript<TScript, TData>(string name, int scriptType, int dataType) where TScript : Component.Generic.Component, new() where TData : IniConfig, new()
    {
        ScriptManager.RegisterScript(name, static () => new TScript(), static () => new TData());
        DeserializeObjectActivator.Register(scriptType, static () => new TScript());
        DeserializeObjectActivator.Register(dataType, static () => new TData());
    }

    public static void Register()
    {
        RegisterScript<TestScript, TestScriptData>(nameof(TestScript), TestScriptType, TestScriptDataType);
        RegisterScript<WipParallelFactoryScript, WipParallelFactoryData>(nameof(WipParallelFactoryScript), WipParallelFactoryScriptType, WipParallelFactoryDataType);
    }
}