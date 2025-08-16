namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct BombListClass
{
    public const nint instance = 0x87F5D8;
    public static ref BombListClass Instance => ref instance.Convert<BombListClass>().Ref;
    
    
    public unsafe void Update()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x438BF0;
        func(this.GetThisPointer());
    }
    public unsafe void Plant(Pointer<TechnoClass> SourceObject, Pointer<ObjectClass> TargetObject)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, void>)0x438E70;
        func(this.GetThisPointer(), SourceObject, TargetObject);
    }
    public unsafe void AddDetector(Pointer<TechnoClass> Detector)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x439080;
        func(this.GetThisPointer(), Detector);
    }
    public unsafe void RemoveDetector(Pointer<TechnoClass> Detector)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x4390D0;
        func(this.GetThisPointer(), Detector);
    }
    public unsafe void PointerGotInvalid(Pointer<AbstractClass> pInvalid)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x439150;
        func(this.GetThisPointer(), pInvalid);
    }

    
    [FieldOffset(0)] public byte bombs;

    public ref DynamicVectorClass<Pointer<BombClass>> Bombs =>
        ref Pointer<byte>.AsPointer(ref bombs).Convert<DynamicVectorClass<Pointer<BombClass>>>().Ref;

    [FieldOffset(24)] public byte detectors;

    public ref DynamicVectorClass<Pointer<TechnoClass>> Detectors =>
        ref Pointer<byte>.AsPointer(ref detectors).Convert<DynamicVectorClass<Pointer<TechnoClass>>>().Ref;

    [FieldOffset(48)] public int UpdateDelay;
}