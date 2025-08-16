namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct EBolt
{
    public const nint ArrayPointer = 0x8A0E88;

    public static ref DynamicVectorClass<Pointer<EBolt>> Array =>
        ref DynamicVectorClass<Pointer<EBolt>>.GetDynamicVector(ArrayPointer);

    
    public static unsafe void Constructor(Pointer<EBolt> pThis)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x4C1E10;
        func(pThis);
    }
    
    public unsafe void SetOwner(Pointer<UnitClass> pOwner, int idxWeapon)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, int, void>)0x4C2BD0;
        func(this.GetThisPointer(), pOwner, idxWeapon);
    }
    public unsafe void ClearOwner()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x4C1E50;
        func(this.GetThisPointer());
    }
    public unsafe Pointer<CoordStruct> GetSourceCoords(Pointer<CoordStruct> outBuffer)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint>)0x4C2B40;
        return func(this.GetThisPointer(), outBuffer);
    }
    public unsafe void Fire(CoordStruct p1, CoordStruct p2, uint arg18)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, CoordStruct, CoordStruct, uint, void>)0x4C2A60;
        func(this.GetThisPointer(), p1, p2, arg18);
    }

    [FieldOffset(0)] public CoordStruct Point1;
    [FieldOffset(12)] public CoordStruct Point2;
    [FieldOffset(24)] public uint unknown_18;
    [FieldOffset(28)] public int Random;
    [FieldOffset(32)] public nint owner;
    public readonly Pointer<TechnoClass> Owner => owner;
    [FieldOffset(36)] public int WeaponSlot;
    [FieldOffset(40)] public int Lifetime;
    [FieldOffset(44)] public Bool AlternateColor;
}