namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct OverlayTypeClass
{    
    private const nint ArrayPointer = 0xA83D80;

    public static readonly GlobalDvcArray<OverlayTypeClass> AbstractTypeArray = new(ArrayPointer);

    public unsafe void Draw(Pointer<Point2D> pClientCoords, Pointer<RectangleStruct> pClipRect, int nFrame)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, int, void>)this.GetVirtualFunctionPointer(40);
        func(this.GetThisPointer(), pClientCoords, pClipRect, nFrame);
    }


    [FieldOffset(0)] public ObjectTypeClass Base;
    [FieldOffset(0)] public int ArrayIndex;
    [FieldOffset(4)] public LandType LandType;
    [FieldOffset(8)] public nint cellAnim;
    public Pointer<AnimTypeClass> CellAnim => cellAnim;
    [FieldOffset(12)] public int DamageLevels;
    [FieldOffset(16)] public int Strength;
    [FieldOffset(20)] public Bool Wall;
    [FieldOffset(21)] public Bool Tiberium;
    [FieldOffset(22)] public Bool Crate;
    [FieldOffset(23)] public Bool CrateTrigger;
    [FieldOffset(24)] public Bool NoUseTileLandType;
    [FieldOffset(25)] public Bool IsVeinholeMonster;
    [FieldOffset(26)] public Bool IsVeins;
    [FieldOffset(27)] public Bool ImageLoaded;
    [FieldOffset(28)] public Bool Explodes;
    [FieldOffset(29)] public Bool ChainReaction;
    [FieldOffset(30)] public Bool Overrides;
    [FieldOffset(31)] public Bool DrawFlat;
    [FieldOffset(32)] public Bool IsRubble;
    [FieldOffset(33)] public Bool IsARock;
    [FieldOffset(34)] public ColorStruct RadarColor;

}