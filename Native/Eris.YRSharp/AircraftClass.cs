namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit, Size = 1752)]
public struct AircraftClass
{
    public const nint ArrayPointer = 0xA8E390;
    public static ref DynamicVectorClass<Pointer<AircraftClass>> Array => ref DynamicVectorClass<Pointer<AircraftClass>>.GetDynamicVector(ArrayPointer);

    public unsafe int IFlyControlLandingAltitude(Pointer<ObjectClass> pObj)
    {
        var func = (delegate* unmanaged[Stdcall]<nint, int>)FlyControl[3];
        return func(flyControl.GetThisPointer());
    }

    public unsafe int IFlyControlLandingDirection(Pointer<ObjectClass> pObj)
    {
        var func = (delegate* unmanaged[Stdcall]<nint, int>)FlyControl[4];
        return func(flyControl.GetThisPointer());
    }

    public unsafe int IFlyControlIsLoaded(Pointer<ObjectClass> pObj)
    {
        var func = (delegate* unmanaged[Stdcall]<nint, int>)FlyControl[5];
        return func(flyControl.GetThisPointer());
    }

    public unsafe int IFlyControlIsStrafe(Pointer<ObjectClass> pObj)
    {
        var func = (delegate* unmanaged[Stdcall]<nint, int>)FlyControl[6];
        return func(flyControl.GetThisPointer());
    }

    public unsafe int IFlyControlIsFighter(Pointer<ObjectClass> pObj)
    {
        var func = (delegate* unmanaged[Stdcall]<nint, int>)FlyControl[7];
        return func(flyControl.GetThisPointer());
    }

    public unsafe int IFlyControlIsLocked(Pointer<ObjectClass> pObj)
    {
        var func = (delegate* unmanaged[Stdcall]<nint, int>)FlyControl[8];
        return func(flyControl.GetThisPointer());
    }



    [FieldOffset(0)] public FootClass Base;
    [FieldOffset(0)] public TechnoClass BaseTechno;
    [FieldOffset(0)] public RadioClass BaseRadio;
    [FieldOffset(0)] public MissionClass BaseMission;
    [FieldOffset(0)] public ObjectClass BaseObject;
    [FieldOffset(0)] public AbstractClass BaseAbstract;
    [FieldOffset(1728)] public nint flyControl;
    public Pointer<nint> FlyControl => flyControl;
    [FieldOffset(1732)] public nint type;
    public Pointer<AircraftTypeClass> Type => type;
    
    [FieldOffset(1736)] public Bool ShouldLoseAmmo; // Whether or not to deduct ammo after firing run (strafing) is over
    [FieldOffset(1737)] public Bool HasPassengers;
    [FieldOffset(1738)] public Bool IsKamikaze; // when crashing down, duh
    [FieldOffset(1740)] public nint dockNowHeadingTo;
    public Pointer<BuildingClass> DockNowHeadingTo => dockNowHeadingTo;
    
    [FieldOffset(1744)] public Bool unknown_bool_6D0;
    [FieldOffset(1745)] public Bool unknown_bool_6D1;
    [FieldOffset(1746)] public Bool IsLocked; // Whether or not aircraft is locked to a firing run (strafing)
    [FieldOffset(1747)] public byte NumParadropsLeft;
    [FieldOffset(1748)] public Bool IsCarryallNotLanding;
    [FieldOffset(1749)] public Bool IsReturningFromAttackRun; // Aircraft finished attack run and/or went idle and is now returning from it

}