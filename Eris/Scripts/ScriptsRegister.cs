using Eris.Extension.Eris.Scripts;
using NaegleriaSerializer;

namespace Eris.Scripts;

public static class ScriptsRegister
{
    private const int ScriptStart = 500;

    public const int TestScriptType = ScriptStart + 0;
    public const int TestScriptDataType = ScriptStart + 1;

    public static void Register()
    {
        ScriptManager.RegisterScript(nameof(TestScript),  static () => new TestScript(), static () => new TestScriptData());
        DeserializeObjectActivator.Register(TestScriptType, static () => new TestScript());
        DeserializeObjectActivator.Register(TestScriptDataType, static () => new TestScriptData());
    }
}