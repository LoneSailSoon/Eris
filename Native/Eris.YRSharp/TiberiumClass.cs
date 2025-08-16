namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct TiberiumLogic
{
    [FieldOffset(0)] public int Count;
    [FieldOffset(4)] public nint queue;
    // public Pointer<PriorityQueueClass<PriorityQueueClassNode>> Queue => queue;
    [FieldOffset(8)] public nint cellIndexesWithTiberium;
    // public Pointer<Bool> CellIndexesWithTiberium => cellIndexesWithTiberium;
    [FieldOffset(12)] public nint nodes;
    // public Pointer<PriorityQueueClassNode> Nodes => nodes;
    [FieldOffset(16)] public TimerStruct Timer;

}


[StructLayout(LayoutKind.Explicit)]
public struct TiberiumClass
{
    private const nint ArrayPointer = 0xB0F4E8;

    public static readonly GlobalDvcArray<TiberiumClass> AbstractTypeArray = new(ArrayPointer);

    
    [FieldOffset(0)] public AbstractTypeClass Base;
    [FieldOffset(152)] public int ArrayIndex;
    [FieldOffset(156)] public int Spread;
    [FieldOffset(160)] public double SpreadPercentage;
    [FieldOffset(168)] public int Growth;
    [FieldOffset(176)] public double GrowthPercentage;
    [FieldOffset(184)] public int Value;
    [FieldOffset(188)] public int Power;
    [FieldOffset(192)] public int Color;
    [FieldOffset(196)] public byte debris;
    public ref TypeList<Pointer<AnimTypeClass>> Debris => ref Pointer<byte>.AsPointer(ref debris).Convert<TypeList<Pointer<AnimTypeClass>>>().Ref;
    [FieldOffset(224)] public nint image;
    public Pointer<OverlayTypeClass> Image => image;
    [FieldOffset(228)] public int NumFrames;
    [FieldOffset(232)] public int NumImages;
    [FieldOffset(236)] public int field_EC;
    [FieldOffset(240)] public TiberiumLogic SpreadLogic;
    [FieldOffset(268)] public TiberiumLogic GrowthLogic;
}