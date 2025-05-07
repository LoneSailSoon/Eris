using System.Runtime.InteropServices;
using Eris.Serializer;
using Eris.Utilities.Ini;
using Eris.Utilities.Ini.Parsers;
using NaegleriaSerializer.Streaming;

namespace Eris.Extension.Eris.Style.Modules.DamageSelf;

public sealed class DamageSelfModuleData : FilterableConfig
{
    public int Damage;
    public int Rof;
    public WarheadTypePointer WarheadType;
    public bool Peaceful;
    public bool Animation;
    public IntegerMatch Test;
    
    public override void Serialize(INaegleriaStream stream)
    {
        stream
            .Process(ref Damage)
            .Process(ref Rof)
            .Process(ref WarheadType)
            .Process(ref Peaceful)
            .Process(ref Animation)
            ;
    }

    public override int SerializeType => SerializeRegister.DamageSelfModuleDataType;
    
    public override void Read(Section section)
    {
        Parsers.Parse(section["DamageSelf.Damage"u8], ref Damage);
        Parsers.Parse(section["DamageSelf.Rof"u8], ref Rof);
        Parsers.Parse(section["DamageSelf.WarheadType"u8], ref WarheadType);
        Parsers.Parse(section["DamageSelf.Peaceful"u8], ref Peaceful);
        Parsers.Parse(section["DamageSelf.Animation"u8], ref Animation);
        Parsers.ParseMatch(section["DamageSelf.Test"u8], ref Test);
    }

    public override bool Enable => Damage != 0;
}