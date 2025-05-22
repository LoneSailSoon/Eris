using Eris.Serializer;
using Eris.Utilities.Ini;
using Eris.Utilities.Ini.Parsers;
using Eris.YRSharp.Helpers;
using NaegleriaSerializer.Streaming;

namespace Eris.Extension.Core.Style.State.DestroySelf;

public class DestroySelfData : FilterableConfig
{
    public override void Serialize(INaegleriaStream stream)
    {
        stream
            .Process(ref Behavior)
            .Process(ref Ammo)
            .Process(ref AfterDelay)
            ;
    }

    public override int SerializeType => SerializeRegister.DestroySelfDataType;

    public DestroySelfBehavior Behavior;
    public IntegerMatch Ammo;
    public int AfterDelay = -1;
    
    public override void Read(Section section)
    {
        ParserDestroySelfBehavior(section["DestroySelf.Behavior"u8], ref Behavior);
        Parsers.ParseMatch(section["DestroySelf.Ammo"u8], ref Ammo);
        Parsers.Parse(section["DestroySelf.AfterDelay"u8], ref AfterDelay);
    }

    public enum DestroySelfBehavior
    {
        None,
        Kill,
        Vanish,
        Sell
    }

    private bool ParserDestroySelfBehavior(string? val, ref DestroySelfBehavior destroySelfBehavior)
    {
        if (string.IsNullOrWhiteSpace(val)) return false;
        if (Is.Any(val, StringComparison.OrdinalIgnoreCase, "kill", "k"))
        {
            destroySelfBehavior = DestroySelfBehavior.Kill;
            return true;
        }

        if (Is.Any(val, StringComparison.OrdinalIgnoreCase, "vanish", "v"))
        {
            destroySelfBehavior = DestroySelfBehavior.Vanish;
            return true;
        }

        if (Is.Any(val, StringComparison.OrdinalIgnoreCase, "sell", "s"))
        {
            destroySelfBehavior = DestroySelfBehavior.Sell;
            return true;
        }
        return false;
    }

    public override bool Enable => Behavior != DestroySelfBehavior.None;
}