namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct TriggerClass
{
    public const nint array = 0xA8EAE8;

    public static ref DynamicVectorClass<Pointer<TriggerClass>> Array =>
        ref array.Convert<DynamicVectorClass<Pointer<TriggerClass>>>().Ref;


    public unsafe bool HasCrossesHorizontalLineEvent()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)0x726250;
        return func(this.GetThisPointer());
    }

    public unsafe bool HasCrossesVerticalLineEvent()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)0x726290;
        return func(this.GetThisPointer());
    }

    public unsafe bool HasZoneEntryByEvent()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)0x7262D0;
        return func(this.GetThisPointer());
    }

    public unsafe bool HasAllowWinAction()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)0x726310;
        return func(this.GetThisPointer());
    }

    public unsafe bool HasGlobalSetOrClearedEvent(int idxGlobal)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, bool>)0x726350;
        return func(this.GetThisPointer(), idxGlobal);
    }

    public unsafe void NotifyGlobalChanged(int idxGlobal)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, void>)0x7263A0;
        func(this.GetThisPointer(), idxGlobal);
    }

    public unsafe void NotifyLocalChanged(int idxLocal)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, void>)0x7263D0;
        func(this.GetThisPointer(), idxLocal);
    }

    public unsafe void ResetTimers()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x726400;
        func(this.GetThisPointer());
    }

    public unsafe void Destroy()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x726720;
        func(this.GetThisPointer());
    }

    public unsafe bool RegisterEvent(TriggerEvent @event, Pointer<ObjectClass> pObject, bool forceFire, bool persistent,
        Pointer<TechnoClass> pSource)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, TriggerEvent, nint, bool, bool, nint, bool>)0x7264C0;
        return func(this.GetThisPointer(), @event, pObject, forceFire, persistent, pSource);
    }

    public unsafe bool FireActions(Pointer<ObjectClass> pObj, CellStruct location)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, CellStruct, bool>)0x7265C0;
        return func(this.GetThisPointer(), pObj, location);
    }

    [FieldOffset(0)] public AbstractClass Base;
    [FieldOffset(36)] public nint type;
    public Pointer<TriggerTypeClass> Type => type;
    [FieldOffset(40)] public nint nextTrigger;
    public Pointer<TriggerClass> NextTrigger => nextTrigger;
    [FieldOffset(44)] public nint house;
    public Pointer<HouseClass> House => house;
    [FieldOffset(48)] public Bool Destoryed;
    [FieldOffset(52)] public TimerStruct Timer;
    [FieldOffset(64)] public uint OccuredEvents;
    [FieldOffset(68)] public Bool Enabled;
}