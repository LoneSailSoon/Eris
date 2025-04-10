using System.Runtime.InteropServices;
using PatcherYrSharp.GeneralStructures;
using PatcherYrSharp.Helpers;

namespace PatcherYrSharp;

[StructLayout(LayoutKind.Explicit, Size = 1824)]
public struct BuildingClass : IYrObject<BuildingTypeClass>
{
    Pointer<BuildingTypeClass> IYrObject<BuildingTypeClass>.Type => Type;

    public unsafe uint GetCurrentFrame()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint>)0x43EF90;
        return func(this.GetThisPointer());
    }

    public unsafe uint GetFWFlags()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint>)0x455B90;
        return func(this.GetThisPointer());
    }

    public unsafe bool IsUnitFactory()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)0x455DA0;
        return func(this.GetThisPointer());
    }

    public unsafe CoordStruct GetTargetCoords()
    {
        var temp = new CoordStruct(0, 0, 0);
        ((delegate* unmanaged[Thiscall]<nint, nint, nint>)0x4500A0)(this.GetThisPointer(), temp.GetThisPointer());

        return temp;
    }

    public unsafe void UpdateAnimations()
    {
        ((delegate* unmanaged[Thiscall]<nint, void>)0x4509D0)(this.GetThisPointer());

    }

    public unsafe void Sell(uint dwUnk)
    {
        ((delegate* unmanaged[Thiscall]<nint, uint, void>)0x447110)(this.GetThisPointer(), dwUnk);

    }


    [FieldOffset(0)] public TechnoClass Base;
    [FieldOffset(0)] public RadioClass BaseRadio;
    [FieldOffset(0)] public MissionClass BaseMission;
    [FieldOffset(0)] public ObjectClass BaseObject;
    [FieldOffset(0)] public AbstractClass BaseAbstract;

    [FieldOffset(1312)] public Pointer<BuildingTypeClass> Type;
    [FieldOffset(1316)] public nint factory;
    public readonly Pointer<FactoryClass> Factory => factory;
    [FieldOffset(1632)] public Bool HasPower;
    [FieldOffset(1633)] public Bool IsOverpowered;

    [FieldOffset(1757)] public Bool unknown_bool_6DD;
    [FieldOffset(1768)] public Bool IsBeingRepaired;

}