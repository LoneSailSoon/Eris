namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct TagClass
{
    public const nint array = 0xB0E720;
    public static ref DynamicVectorClass<Pointer<TagClass>> Array => ref array.Convert<DynamicVectorClass<Pointer<TagClass>>>().Ref;
    
    public unsafe bool HasCrossesHorizontalLineEvent()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)0x6E5320;
        return func(this.GetThisPointer());
    }

    public unsafe bool HasCrossesVerticalLineEvent()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)0x6E5300;
        return func(this.GetThisPointer());
    }

    public unsafe bool HasZoneEntryByEvent()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)0x6E5340;
        return func(this.GetThisPointer());
    }

    public unsafe bool HasAllowWinAction()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)0x6E5360;
        return func(this.GetThisPointer());
    }

    public unsafe void GlobalChanged(int idxGlobal)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, void>)0x6E55A0;
        func(this.GetThisPointer(), idxGlobal);
    }

    public unsafe void LocalChanged(int idxLocal)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, void>)0x6E55B0;
        func(this.GetThisPointer(), idxLocal);
    }

    public unsafe bool IsOnlyInstanceOfType()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)0x6E5850;
        return func(this.GetThisPointer());
    }

    public unsafe bool RaiseEvent(TriggerEvent @event, Pointer<ObjectClass> pTagOwner, CellStruct location,
        bool forceAllOccured = false, Pointer<TechnoClass> pSource = default)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, TriggerEvent, nint, CellStruct, bool, nint, bool>)0x6E53A0;
        return func(this.GetThisPointer(), @event, pTagOwner, location, forceAllOccured, pSource);
    }

    public unsafe bool ShouldReplace()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)0x6E57C0;
        return func(this.GetThisPointer());
    }

    public unsafe void Destroy()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x6E5230;
        func(this.GetThisPointer());
    }

    public unsafe void AddTrigger(Pointer<TriggerClass> pTrigger)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x6E55C0;
        func(this.GetThisPointer(), pTrigger);
    }

    public unsafe bool RemoveTrigger(Pointer<TriggerClass> pTrigger)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool>)0x6E55D0;
        return func(this.GetThisPointer(), pTrigger);
    }

    public unsafe bool ContainsTrigger(Pointer<TriggerClass> pTrigger)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool>)0x6E5380;
        return func(this.GetThisPointer(), pTrigger);
    }


    [FieldOffset(0)] public AbstractClass Base;
    [FieldOffset(36)] public nint type;
    public Pointer<TagTypeClass> Type => type;
    [FieldOffset(40)] public nint firstTrigger;
    public Pointer<TriggerClass> FirstTrigger => firstTrigger;

    [FieldOffset(44)] public int InstanceCount;
    [FieldOffset(48)] public CellStruct DefaultCoords;
    [FieldOffset(52)] public Bool Destoryed;
    [FieldOffset(53)] public Bool IsExecuting;

}