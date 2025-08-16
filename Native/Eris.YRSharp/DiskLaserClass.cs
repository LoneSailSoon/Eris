namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct DiskLaserClass
{
    public const nint ArrayPointer = 0x8A0208;
    public static ref DynamicVectorClass<Pointer<DiskLaserClass>> Array => ref DynamicVectorClass<Pointer<DiskLaserClass>>.GetDynamicVector(ArrayPointer);

    public const nint drawCoords = 0x8A0180;
    public static readonly FixedArray<CoordStruct> DrawCoords = new(0x8A0180, 16);
    
    public unsafe void Fire(Pointer<TechnoClass> pOwner, Pointer<TechnoClass> pTarget, Pointer<WeaponTypeClass> pWeapon, int nDamage)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, nint, int, void>)0x4A71A0;
        func(this.GetThisPointer(), pOwner, pTarget, pWeapon, nDamage);
    }
    public unsafe void PointerGotInvalid(Pointer<AbstractClass> pInvalid)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x4A7900;
        func(this.GetThisPointer(), pInvalid);
    }


    [FieldOffset(0)] public AbstractClass Base;
    
    [FieldOffset(36)] public nint owner;
    public readonly Pointer<TechnoClass> Owner => owner;
    [FieldOffset(40)] public nint target;
    public readonly Pointer<TechnoClass> Target => target;
    [FieldOffset(44)] public nint weapon;
    public readonly Pointer<WeaponTypeClass> Weapon => weapon;
    [FieldOffset(48)] public uint unknown_30;
    [FieldOffset(52)] public uint unknown_34;
    [FieldOffset(56)] public uint unknown_38;
    [FieldOffset(60)] public int Damage;
}