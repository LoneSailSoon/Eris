using Eris.Extension.Eris.Scripts;
using PatcherYrSharp;

namespace Eris.Scripts;

public class TestScript : TechnoScriptable
{
    public override int SerializeType => ScriptsRegister.TestScriptType;

    public override void OnUpdate()
    {
        Console.WriteLine($"TestScript: {Game.CurrentFrame}");
    }
}