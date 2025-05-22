using System.Runtime.InteropServices;
using Eris.YRSharp.Helpers;
using Eris.YRSharp.String.Ansi;
using Eris.YRSharp.String.Uni;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit, Size = 41)]
public struct Variable
{
    [FieldOffset(0)] public byte Name_first;
    public AnsiStringPointer Name => Pointer<byte>.AsPointer(ref Name_first);
    [FieldOffset(40)] public byte Value;
};

[StructLayout(LayoutKind.Explicit, Size = 14144)]
public struct ScenarioClass
{
    public static IntPtr ppInstance = new IntPtr(0xA8B230);
    public static IntPtr pInstance = ppInstance.Convert<Pointer<ScenarioClass>>().Ref;
    public static ref ScenarioClass Instance { get => ref ppInstance.Convert<Pointer<ScenarioClass>>().Ref.Ref; }


    [FieldOffset(0)] public uint SpecialFlags;
    [FieldOffset(4700)] public byte FileName_first;
    public AnsiStringPointer FileName => Pointer<byte>.AsPointer(ref FileName_first);

    [FieldOffset(5200)] public char Briefing_first;
    public UniStringPointer Briefing => Pointer<char>.AsPointer(ref Briefing_first);

    [FieldOffset(7304)] public Variable GlobalVariables_first;
    public Pointer<Variable> GlobalVariables => Pointer<Variable>.AsPointer(ref GlobalVariables_first);
    [FieldOffset(9354)] public Variable LocalVariables_first;
    public Pointer<Variable> LocalVariables => Pointer<Variable>.AsPointer(ref LocalVariables_first);


}