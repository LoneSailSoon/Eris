namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit, Size = 3600)]
public struct AircraftTypeClass
{
    // public static unsafe Pointer<AbstractTypeClass> FindOrAllocate(string ID)
    // {
    //     var func = (delegate* unmanaged[Thiscall]<int, IntPtr, IntPtr>)ASM.FastCallTransferStation;
    //     return func(0x41CEF0, new AnsiString(ID));
    // }


    [FieldOffset(0)] public TechnoTypeClass Base;
    [FieldOffset(0)] public ObjectTypeClass BaseObjectType;
    [FieldOffset(0)] public AbstractTypeClass BaseAbstractType;
    [FieldOffset(3576)] public int ArrayIndex;
    [FieldOffset(3580)] public Bool Carryall;
    [FieldOffset(3584)] public nint trailer;

    public Pointer<AnimTypeClass> Trailer => trailer;
    
    [FieldOffset(3588)] public int SpawnDelay;
    [FieldOffset(3592)] public bool Rotors;
    [FieldOffset(3593)] public bool CustomRotor;
    [FieldOffset(3594)] public bool Landable;
    [FieldOffset(3595)] public bool FlyBy;
    [FieldOffset(3596)] public bool FlyBack;
    [FieldOffset(3597)] public bool AirportBound;
    [FieldOffset(3598)] public bool Fighter;
}