using Eris.Extension.Eris.Scripts;
using NaegleriaSerializer;

namespace Eris.Scripts;

public static class ScriptsRegister
{
    public const int ScriptStart = 500;

    public const int TestScriptType = ScriptStart + 0;

    public static void Register()
    {
        ScriptManager.RegisterScript(nameof(TestScript),  static () => new TestScript());
        DeserializeObjectActivator.Register(TestScriptType, static () => new TestScript());
    }
}