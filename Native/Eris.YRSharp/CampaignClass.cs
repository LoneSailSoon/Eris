using Eris.YRSharp.String.Ansi;
using Eris.YRSharp.String.Uni;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct CampaignClass
{
    [FieldOffset(0)] public AbstractTypeClass Base;
    [FieldOffset(152)] public int idxCD;
    [FieldOffset(156)] public byte scenario;
    public AnsiStringPointer Scenario => scenario.GetThisPointer();
    [FieldOffset(668)] public int FinalMovie;
    [FieldOffset(672)] public char description;
    public UniStringPointer Description => description.GetThisPointer();
}