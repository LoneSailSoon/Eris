using System.Runtime.CompilerServices;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct TActionClass
{
    public const nint array = 0xB0E658;
    public static ref DynamicVectorClass<Pointer<TActionClass>> Array => ref array.Convert<DynamicVectorClass<Pointer<TActionClass>>>().Ref;
    
    [FieldOffset(0)] public AbstractClass Base;
    [FieldOffset(36)] public int ArrayIndex;
    [FieldOffset(40)] public nint nextAction;
    public Pointer<TActionClass> NextAction => nextAction;
    [FieldOffset(44)] public TriggerAction ActionKind;
    [FieldOffset(48)] public nint teamType;
    public Pointer<TeamTypeClass> TeamType => teamType;
    // [FieldOffset(52)] public _ ParmElement;
    [FieldOffset(68)] public int Waypoint;
    [FieldOffset(72)] public int Value2;
    [FieldOffset(76)] public nint tagType;
    public Pointer<TagTypeClass> TagType => tagType;
    [FieldOffset(80)] public nint triggerType;
    public Pointer<TriggerTypeClass> TriggerType => triggerType;
    [FieldOffset(84)] public byte technoID;
    public FixedArray<byte> TechnoID => new(ref Unsafe.As<byte, byte>(ref technoID), 25);
    [FieldOffset(109)] public byte text;
    public FixedArray<byte> Text => new(ref Unsafe.As<byte, byte>(ref text), 32);
    [FieldOffset(144)] public int Value;

}