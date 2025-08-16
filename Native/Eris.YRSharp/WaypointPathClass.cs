namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct WaypointClass
{
    [FieldOffset(0)] public CellStruct Coords;
    [FieldOffset(4)] public uint unknown;
}

[StructLayout(LayoutKind.Explicit)]
public struct WaypointPathClass
{
    public unsafe Pointer<WaypointClass> GetWaypoint(int idx)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, nint>)0x763980;
        return func(this.GetThisPointer(), idx);
    }

    public unsafe Pointer<WaypointClass> GetWaypointAfter(int idx)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, nint>)0x763BA0;
        return func(this.GetThisPointer(), idx);
    }

    public unsafe bool WaypointExistsAt(Pointer<WaypointClass> wpt)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool>)0x763A50;
        return func(this.GetThisPointer(), wpt);
    }

    [FieldOffset(0)] public ObjectClass Base;
    [FieldOffset(36)] public int CurrentWaypointIndex;
    [FieldOffset(40)] public byte waypoints;

    public ref DynamicVectorClass<WaypointClass> Waypoints =>
        ref Pointer<byte>.AsPointer(ref waypoints).Convert<DynamicVectorClass<WaypointClass>>().Ref;
}