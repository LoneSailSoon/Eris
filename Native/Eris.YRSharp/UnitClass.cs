using System.Runtime.CompilerServices;
using Eris.YRSharp.String.Uni;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit, Size = 2280)]
public struct UnitClass
{
    public const nint array = 0x8B4108;

    public static ref DynamicVectorClass<Pointer<UnitClass>> Array =>
        ref array.Convert<DynamicVectorClass<Pointer<UnitClass>>>().Ref;

    public unsafe bool IsDeactivated()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)0x70FBD0;
        return func(this.GetThisPointer());
    }

    public unsafe void UpdateTube()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x7359F0;
        func(this.GetThisPointer());
    }

    public unsafe void UpdateRotation()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x736990;
        func(this.GetThisPointer());
    }

    public unsafe void UpdateEdgeOfWorld()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x736C10;
        func(this.GetThisPointer());
    }

    public unsafe void UpdateFiring()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x736DF0;
        func(this.GetThisPointer());
    }

    public unsafe void UpdateVisceroid()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x737180;
        func(this.GetThisPointer());
    }

    public unsafe void UpdateDisguise()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x7468C0;
        func(this.GetThisPointer());
    }

    public unsafe void Explode()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x738680;
        func(this.GetThisPointer());
    }

    public unsafe bool GotoClearSpot()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)0x738D30;
        return func(this.GetThisPointer());
    }

    public unsafe bool TryToDeploy()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)0x7393C0;
        return func(this.GetThisPointer());
    }

    public unsafe void Deploy()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x739AC0;
        func(this.GetThisPointer());
    }

    public unsafe void Undeploy()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x739CD0;
        func(this.GetThisPointer());
    }

    public unsafe bool Harvesting()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)0x73D450;
        return func(this.GetThisPointer());
    }

    public unsafe bool FlagAttach(int nHouseIdx)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, bool>)0x740DF0;
        return func(this.GetThisPointer(), nHouseIdx);
    }

    public unsafe bool FlagRemove()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)0x740E20;
        return func(this.GetThisPointer());
    }

    public unsafe void APCCloseDoor()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x740E60;
        func(this.GetThisPointer());
    }

    public unsafe void APCOpenDoor()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x740E80;
        func(this.GetThisPointer());
    }


    [FieldOffset(0)] public FootClass Base;
    [FieldOffset(0)] public TechnoClass BaseTechno;
    [FieldOffset(0)] public RadioClass BaseRadio;
    [FieldOffset(0)] public MissionClass BaseMission;
    [FieldOffset(0)] public ObjectClass BaseObject;
    [FieldOffset(0)] public AbstractClass BaseAbstract;



    [FieldOffset(1728)] public int unknown_int_6C0;
    [FieldOffset(1732)] public nint type;
    public Pointer<UnitTypeClass> Type => type;
    [FieldOffset(1736)] public nint followerCar;
    public Pointer<UnitClass> FollowerCar => followerCar;
    [FieldOffset(1740)] public int FlagHouseIndex;
    [FieldOffset(1744)] public Bool HasFollowerCar;
    [FieldOffset(1745)] public Bool Unloading;
    [FieldOffset(1746)] public Bool IsHarvesting;
    [FieldOffset(1747)] public Bool TerrainPalette;
    [FieldOffset(1748)] public int unknown_int_6D4;
    [FieldOffset(1752)] public int DeathFrameCounter;
    [FieldOffset(1756)] public nint electricBolt;
    public Pointer<EBolt> ElectricBolt => electricBolt;
    [FieldOffset(1760)] public Bool Deployed;
    [FieldOffset(1761)] public Bool Deploying;
    [FieldOffset(1762)] public Bool Undeploying;
    [FieldOffset(1764)] public int NonPassengerCount;
    [FieldOffset(1768)] public byte toolTipText;
    public UniStringPointer ToolTipText => new(ref Unsafe.As<byte, char>(ref toolTipText), 256);
}