using Eris.YRSharp.String.Uni;
using Eris.YRSharp.Vector;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct BitFont
{
    public const nint instance = 0x89C4D0;
    public static ref BitFont Instance => ref instance.Convert<BitFont>().Ref;
    
    public unsafe bool GetTextDimension(ReadOnlySpan<char> pText, Pointer<int> pWidth, Pointer<int> pHeight, int nMaxWidth)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, nint, int, bool>)0x433CF0;
        return func(this.GetThisPointer(), MemoryMarshal.GetReference(pText).GetThisPointer(), pWidth, pHeight, nMaxWidth);
    }
    public unsafe int Blit(byte wch, int X, int Y, int nColor)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, byte, int, int, int, int>)0x434120;
        return func(this.GetThisPointer(), wch, X, Y, nColor);
    }
    public unsafe bool Lock(Pointer<Surface> pSurface)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool>)0x4348F0;
        return func(this.GetThisPointer(), pSurface);
    }
    public unsafe bool UnLock(Pointer<Surface> pSurface)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool>)0x434990;
        return func(this.GetThisPointer(), pSurface);
    }
    public unsafe Pointer<sbyte> GetCharacterBitmap(byte wch)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, byte, nint>)0x4346C0;
        return func(this.GetThisPointer(), wch);
    }

    
    
    [FieldOffset(0)] public nint vftable;
    [FieldOffset(4)] public nint internalPTR;
    public readonly Pointer<InternalData> InternalPTR => internalPTR;

    [FieldOffset(8)] public nint Pointer_8;
    [FieldOffset(12)] public nint graphBuffer;
    public readonly Pointer<short> pGraphBuffer => graphBuffer;
    [FieldOffset(16)] public int PitchDiv2;
    [FieldOffset(20)] public int Unknown_14;
    [FieldOffset(24)] public nint field_18;
    public readonly UniStringPointer Field_18 => field_18;
    [FieldOffset(28)] public int field_1C;
    [FieldOffset(32)] public int field_20;
    [FieldOffset(36)] public ushort Color;
    [FieldOffset(38)] public short DefaultColor2;
    [FieldOffset(40)] public int Unknown_28;
    [FieldOffset(44)] public int State_2C;
    [FieldOffset(48)] public LtrbStruct Bounds;
    [FieldOffset(64)] public Bool Bool_40;
    [FieldOffset(65)] public Bool field_41;
    [FieldOffset(66)] public Bool field_42;
    [FieldOffset(67)] public Bool field_43;
    
    [StructLayout(LayoutKind.Explicit)]
    public struct InternalData
    {
        [FieldOffset(0)] public int FontWidth;
        [FieldOffset(4)] public int Stride;
        [FieldOffset(8)] public int FontHeight;
        [FieldOffset(12)] public int Lines;
        [FieldOffset(16)] public int Count;
        [FieldOffset(20)] public int SymbolDataSize;
        [FieldOffset(24)] public nint symbolTable;
        public readonly Pointer<short> SymbolTable => symbolTable;
        [FieldOffset(28)] public nint bitmaps;
        public readonly Pointer<byte> Bitmaps => bitmaps;
        [FieldOffset(32)] public int ValidSymbolCount;
    }

}