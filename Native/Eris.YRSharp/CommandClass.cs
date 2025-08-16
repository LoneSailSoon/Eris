namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit, Size = 8)]
public struct CommandClass
{
    public const nint ArrayPointer = 0x87F658;

    public static ref DynamicVectorClass<Pointer<CommandClass>> Array =>
        ref DynamicVectorClass<Pointer<CommandClass>>.GetDynamicVector(ArrayPointer);

}