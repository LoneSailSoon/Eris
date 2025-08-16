using System.Runtime.CompilerServices;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct TriggerTypeClass
{
    private const nint ArrayPointer = 0x8B4178;

    public static readonly GlobalDvcArray<TriggerTypeClass> AbstractTypeArray = new(ArrayPointer);

    
    public unsafe byte GetFlags()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, byte>)0x7271E0;
        return func(this.GetThisPointer());
    }

    public unsafe bool HasAllowWinAction()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)0x726FE0;
        return func(this.GetThisPointer());
    }

    public unsafe bool HasGlobalSetOrClearedEvent(int idxGlobal)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, bool>)0x727010;
        return func(this.GetThisPointer(), idxGlobal);
    }

    public unsafe bool HasLocalSetOrClearedEvent(int idxLocal)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, bool>)0x727050;
        return func(this.GetThisPointer(), idxLocal);
    }

    public unsafe bool HasCrossesHorizontalLineEvent()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)0x726F80;
        return func(this.GetThisPointer());
    }

    public unsafe bool HasCrossesVerticalLineEvent()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)0x726F50;
        return func(this.GetThisPointer());
    }

    public unsafe bool HasZoneEntryByEvent()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)0x726FB0;
        return func(this.GetThisPointer());
    }

    public unsafe bool RemoveAction(Pointer<TActionClass> pAction)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool>)0x7279E0;
        return func(this.GetThisPointer(), pAction);
    }

    public unsafe bool RemoveEvent(Pointer<TEventClass> pEvent)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool>)0x727A40;
        return func(this.GetThisPointer(), pEvent);
    }

    [FieldOffset(152)] public int ArrayIndex;
    [FieldOffset(156)] public byte difficulty;
    public FixedArray<Bool> Difficulty => new(ref Unsafe.As<byte, Bool>(ref difficulty), 3);
    [FieldOffset(159)] public Bool Enabled;
    [FieldOffset(160)] public Bool MustTransfer;
    [FieldOffset(164)] public nint house;
    public Pointer<HouseTypeClass> House => house;
    [FieldOffset(168)] public nint nextTrigger;
    public Pointer<TriggerTypeClass> NextTrigger => nextTrigger;
    [FieldOffset(172)] public nint firstEvent;
    public Pointer<TEventClass> FirstEvent => firstEvent;
    [FieldOffset(176)] public nint firstAction;
    public Pointer<TActionClass> FirstAction => firstAction;
}