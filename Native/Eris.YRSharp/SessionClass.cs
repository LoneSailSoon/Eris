using System.Runtime.InteropServices;
using Eris.YRSharp.GeneralDefinitions;
using Eris.YRSharp.Helpers;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit, Size = 12508)]
public struct SessionClass
{
    private static IntPtr instance = new IntPtr(0xA8B238);
    public static ref SessionClass Instance => ref instance.Convert<SessionClass>().Ref;

    public unsafe void Resume()
    {
        var func = (delegate* unmanaged[Thiscall]<ref SessionClass, byte>)0x69BAB0;
        func(ref this);
    }


    [FieldOffset(0)] public GameMode GameMode;
    [FieldOffset(4)] public Pointer<MPGameModeClass> MPGameMode;
}