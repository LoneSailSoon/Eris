namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct TerrainTypeClass
{
    private const nint ArrayPointer = 0xA8E318;

    public static readonly GlobalDvcArray<TerrainTypeClass> AbstractTypeArray = new(ArrayPointer);

    
    [FieldOffset(0)] public ObjectTypeClass Base;
    [FieldOffset(660)] public int ArrayIndex;
    [FieldOffset(664)] public int Foundation;
    [FieldOffset(668)] public ColorStruct RadarColor;
    [FieldOffset(672)] public int AnimationRate;
    [FieldOffset(676)] public float AnimationProbability;
    [FieldOffset(680)] public int TemperateOccupationBits;
    [FieldOffset(684)] public int SnowOccupationBits;
    [FieldOffset(688)] public Bool WaterBound;
    [FieldOffset(689)] public Bool SpawnsTiberium;
    [FieldOffset(690)] public Bool IsFlammable;
    [FieldOffset(691)] public Bool IsAnimated;
    [FieldOffset(692)] public Bool IsVeinhole;
    [FieldOffset(696)] public nint foundationData;
    public Pointer<CellStruct> FoundationData => foundationData;

}