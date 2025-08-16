

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct BuildingLightClass
{
    public unsafe void SetBehaviour(SpotlightBehaviour mode)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, SpotlightBehaviour, void>)0x436BE0;
        func(this.GetThisPointer(), mode);
    }

    [FieldOffset(0)] public ObjectClass Base;
    [FieldOffset(0)] public AbstractClass BaseAbstract;
    
    [FieldOffset(176)] public double Speed;
    [FieldOffset(184)] public CoordStruct field_B8;
    [FieldOffset(196)] public CoordStruct field_C4;
    [FieldOffset(208)] public double Acceleration;
    [FieldOffset(216)] public Bool Direction;
    [FieldOffset(220)] public SpotlightBehaviour BehaviourMode;
    [FieldOffset(224)] public nint followingObject;
    public readonly Pointer<ObjectClass> FollowingObject => followingObject;
    [FieldOffset(228)] public nint ownerObject;
    public readonly Pointer<TechnoClass> OwnerObject => ownerObject;

}