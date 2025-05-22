using System.Runtime.InteropServices;
using Eris.YRSharp.Helpers;
using Eris.YRSharp.String.Ansi;
using Eris.YRSharp.String.Uni;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit, Size = 64)]
public struct MPGameModeClass
{
    private static IntPtr instance = new IntPtr(0xA8B23C);
    public static ref MPGameModeClass Instance { get => ref instance.Convert<Pointer<MPGameModeClass>>().Ref.Ref; }

    //[FieldOffset(8)] public DynamicVectorClass<Pointer<MPTeam>> MPTeams;
    [FieldOffset(32)] public UniStringPointer CSFTitle;
    [FieldOffset(36)] public UniStringPointer CSFTooltip;
    [FieldOffset(40)] public int MPModeIndex;
    [FieldOffset(44)] public AnsiStringPointer INIFilename;
    [FieldOffset(48)] public AnsiStringPointer MapFilter;
    [FieldOffset(52)] public Bool AIAllowed;

    [FieldOffset(56)] public Pointer<CCIniClass> INI;
    [FieldOffset(60)] public Bool AlliesAllowed;
    [FieldOffset(61)] public Bool wolTourney;
    [FieldOffset(62)] public Bool wolClanTourney;
    [FieldOffset(63)] public Bool MustAlly;
}