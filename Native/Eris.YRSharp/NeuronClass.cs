namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct NeuronClass
{
    [FieldOffset(0)] public AbstractClass Base;
    [FieldOffset(36)] public nint unknown_ptr_24;
    public Pointer<byte> Unknown_ptr_24 => unknown_ptr_24;
    [FieldOffset(40)] public nint unknown_ptr_28;
    public Pointer<byte> Unknown_ptr_28 => unknown_ptr_28;
    [FieldOffset(44)] public nint unknown_ptr_2C;
    public Pointer<byte> Unknown_ptr_2C => unknown_ptr_2C;
    [FieldOffset(48)] public TimerStruct unknown_time_30;
}

[StructLayout(LayoutKind.Explicit)]
public struct BrainClass
{
    [FieldOffset(4)] public byte neurons;
    public ref DynamicVectorClass<Pointer<NeuronClass>> Neurons => ref Pointer<byte>.AsPointer(ref neurons).Convert<DynamicVectorClass<Pointer<NeuronClass>>>().Ref;
}