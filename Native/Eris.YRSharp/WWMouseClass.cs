﻿using System.Runtime.InteropServices;
using Eris.YRSharp.Helpers;
using Eris.YRSharp.Vector;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit, Size = 152)]
public struct WWMouseClass
{
    // private static IntPtr instance = new IntPtr(0x887640);
    public static ref WWMouseClass Instance => ref new Pointer<Pointer<WWMouseClass>>(0x887640).Ref.Ref;

    public unsafe int GetX()
    {
        var func = (delegate* unmanaged[Thiscall]<ref WWMouseClass, int>)this.GetVirtualFunctionPointer(11);
        return func(ref this);
    }

    public unsafe int GetY()
    {
        var func = (delegate* unmanaged[Thiscall]<ref WWMouseClass, int>)this.GetVirtualFunctionPointer(12);
        return func(ref this);
    }

    public unsafe Point2D GetCoords()
    {
        Point2D pBuffer = default;
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint>)this.GetVirtualFunctionPointer(13);
        func(this.GetThisPointer(), Pointer<Point2D>.AsPointer(ref pBuffer));
        return pBuffer;
    }

}