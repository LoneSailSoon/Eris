using Eris.Extension.Core.Scripts;
using Eris.Utilities.Ini;
using Eris.Utilities.Ini.Parsers;
using Eris.YRSharp;
using NaegleriaSerializer.Streaming;

namespace Eris.Scripts;

public sealed class TestScriptData : IniConfig
{
    public override int SerializeType => ScriptsRegister.TestScriptDataType;
    
    public override void Serialize(INaegleriaStream stream)
    {
        stream.Process(ref Data);
    }

    public override void Read(Section section)
    {
        Parsers.Parse(section["TestScript.Data"u8], ref Data);
    }

    public int Data;
}

public sealed class TestScript : TechnoScriptable<TestScriptData>
{
    public override int SerializeType => ScriptsRegister.TestScriptType;

    public override void OnUpdate()
    {
        Console.WriteLine($"OnUpdate {Data.Data} {Game.CurrentFrame}");
    }
}