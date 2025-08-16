namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct TagTypeClass
{
    private const nint ArrayPointer = 0xB0E780;

    public static readonly GlobalDvcArray<TagTypeClass> AbstractTypeArray = new(ArrayPointer);

    public unsafe byte GetFlags()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, byte>)0x6E61F0;
        return func(this.GetThisPointer());
    }

    public unsafe bool HasAllowWinAction()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)0x6E6220;
        return func(this.GetThisPointer());
    }

    public unsafe bool HasCrossesHorizontalLineEvent()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)0x6E6250;
        return func(this.GetThisPointer());
    }

    public unsafe bool HasCrossesVerticalLineEvent()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)0x6E6280;
        return func(this.GetThisPointer());
    }

    public unsafe bool HasZoneEntryByEvent()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)0x6E62B0;
        return func(this.GetThisPointer());
    }

    public unsafe bool AddTrigger(Pointer<TriggerTypeClass> pTrigger)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool>)0x6E5DD0;
        return func(this.GetThisPointer(), pTrigger);
    }

    public unsafe bool RemoveTrigger(Pointer<TriggerTypeClass> pTrigger)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool>)0x6E5E00;
        return func(this.GetThisPointer(), pTrigger);
    }

    public unsafe bool ContainsTrigger(Pointer<TriggerTypeClass> pTrigger)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool>)0x6E62E0;
        return func(this.GetThisPointer(), pTrigger);
    }



    [FieldOffset(0)] public AbstractTypeClass Base;

    [FieldOffset(152)] public int ArrayIndex;
    [FieldOffset(156)] public TriggerPersistence Persistence;
    [FieldOffset(160)] public nint firstTrigger;
    public Pointer<TriggerTypeClass> FirstTrigger => firstTrigger;

}