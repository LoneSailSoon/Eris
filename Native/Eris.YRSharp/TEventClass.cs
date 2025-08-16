using System.Runtime.CompilerServices;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct TEventClass
{
    public const nint array = 0xB0F1A0;
    public static ref DynamicVectorClass<Pointer<TEventClass>> Array => ref array.Convert<DynamicVectorClass<Pointer<TEventClass>>>().Ref;
    
    
    public unsafe bool GetStateA()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)0x71F950;
        return func(this.GetThisPointer());
    }

    public unsafe bool GetStateB()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)0x71F9C0;
        return func(this.GetThisPointer());
    }

    public unsafe bool HasOccured(int eventKind, Pointer<HouseClass> pHouse, Pointer<ObjectClass> Object,
        Pointer<TimerStruct> ActivationFrame, Pointer<bool> isRepeating)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, nint, nint, nint, nint, bool>)0x71E940;
        return func(this.GetThisPointer(), eventKind, pHouse, Object, ActivationFrame, isRepeating);
    }


    [FieldOffset(0)] public AbstractClass Base;
    [FieldOffset(36)] public int ArrayIndex;
    [FieldOffset(40)] public nint nextEvent;
    public Pointer<TEventClass> NextEvent => nextEvent;
    [FieldOffset(44)] public TriggerEvent EventKind;
    [FieldOffset(48)] public nint teamType;
    public Pointer<TeamTypeClass> TeamType => teamType;
    [FieldOffset(52)] public int Value;
    [FieldOffset(56)] public byte @string;
    public FixedArray<byte> String_ => new(ref Unsafe.As<byte, byte>(ref @string), 28);
    [FieldOffset(84)] public nint house;
    public Pointer<HouseClass> House => house;

}