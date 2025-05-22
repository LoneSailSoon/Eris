using System.Runtime.InteropServices;
using Eris.YRSharp.GeneralStructures;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Sequential, Size = 0x14)]
public struct CounterClass
{
    private IntPtr Vfptr;
    public Vector<int> Base;
    public int Total;

    public unsafe int GetCount(int index)
    {
        var func = (delegate* unmanaged[Thiscall]<ref CounterClass, int, int>)0x49FAE0;// 0x49FA00;
        return func(ref this, index);
    }

    public unsafe int Increment(int index)
    {
        var func = (delegate* unmanaged[Thiscall]<ref CounterClass, int, int>)0x49FA00;// 0x49FA00;
        return func(ref this, index);
    }

    public unsafe int Decrement(int index)
    {
        var func = (delegate* unmanaged[Thiscall]<ref CounterClass, int, int>)0x49FA70;// 0x49FA00;
        return func(ref this, index);
    }
}
