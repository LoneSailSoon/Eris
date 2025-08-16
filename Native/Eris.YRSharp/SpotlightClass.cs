using Eris.YRSharp.Utilities;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Sequential)]
public struct SpotlightClass
{
    public unsafe void Draw()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x5FF850;
        func(this.GetThisPointer());
    }

    public unsafe void Update()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x5FF320;
        func(this.GetThisPointer());
    }

    public static unsafe void DrawAll()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)NativeCode.FastCallTransferStation;
        func(0x5FFFA0);
    }


    public CoordStruct Coords;
    public int MovementRadius;
    public int Size;
    public SpotlightFlags DisableFlags;

}