using Eris.BeonSerializer.Streaming;
using Eris.Component.Scripts;
using Eris.Utilities.Data;
using Eris.Utilities.Ini;
using Eris.Utilities.Ini.Parsers;
using Eris.YRSharp;

namespace Eris.Scripts;

[Desc("Ini数据，脚本中为'Data'，需要和脚本一起注册")]
public sealed class TestScriptData : IniConfig
{
    [Desc("序列化索引，类型不同则不同，需要注册")]
    public override int SerializeType => ScriptsRegister.TestScriptDataType;

    [Desc("序列化与反序列化函数")]
    public override void Serialize(IBeonStream stream)
    {
        stream.Process(ref Data)
            .ProcessStringInline(ref ArtData);
    }

    [Desc("Ini读取函数，推荐使用u8字符串")]
    public override void Read(IniSection section, IIniId id)
    {
        Parsers.Parse(section["TestScript.Data"u8], ref Data);

        if(!IniReader.Art(id, out var art))
            return;

        Parsers.Parse(art["Cameo"u8], ref ArtData);
    }

    [Desc("Ini参数，不能写指针")]
    public int Data;

    public string? ArtData;
}

[Desc("脚本，需要注册")]
public sealed class TestScript : TechnoScriptable<TestScriptData>
{
    [Desc($"同上{nameof(TestScriptData)}")]
    public override int SerializeType => ScriptsRegister.TestScriptType;

    [Desc("逻辑函数")]
    public override void OnUpdate()
    {
        if (Game.CurrentFrame % 120 == 0)
            Console.WriteLine($"OnUpdate {Data.ArtData} {Game.CurrentFrame}");
    }
}