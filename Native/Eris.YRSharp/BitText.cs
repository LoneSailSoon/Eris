namespace Eris.YRSharp;

public struct BitText
{
    public const nint instance = 0x89C4B8;
    public static ref BitText Instance => ref instance.Convert<BitText>().Ref;
    
    public unsafe void Print(Pointer<BitFont> pFont, Pointer<Surface> pSurface, ReadOnlySpan<char> pWideString, int X, int Y, int W, int H)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, nint, int, int, int, int, void>)0x434B90;
        func(this.GetThisPointer(), pFont, pSurface, MemoryMarshal.GetReference(pWideString).GetThisPointer(), X, Y, W, H);
    }
    public unsafe void DrawText(Pointer<BitFont> pFont, Pointer<Surface> pSurface, ReadOnlySpan<char> pWideString, int X, int Y, int W, int H, byte a8, int a9, int nColorAdjust)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, nint, int, int, int, int, byte, int, int, void>)0x434CD0;
        func(this.GetThisPointer(), pFont, pSurface, MemoryMarshal.GetReference(pWideString).GetThisPointer(), X, Y, W, H, a8, a9, nColorAdjust);
    }

}