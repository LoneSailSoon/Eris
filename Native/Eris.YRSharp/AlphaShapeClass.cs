using Eris.YRSharp.FileFormats;
using Eris.YRSharp.Vector;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct AlphaShapeClass
{
    public const nint ArrayPointer = 0x88A0F0;

    public static ref DynamicVectorClass<Pointer<AlphaShapeClass>> Array =>
        ref DynamicVectorClass<Pointer<AlphaShapeClass>>.GetDynamicVector(ArrayPointer);

    
    [FieldOffset(0)] public AbstractClass Base;
    [FieldOffset(36)] public nint attachedTo;
    public Pointer<ObjectClass> AttachedTo => attachedTo;
    [FieldOffset(40)] public RectangleStruct Rect;
    [FieldOffset(56)] public nint alphaImage;
    public Pointer<ShpStruct> AlphaImage => alphaImage;
    [FieldOffset(60)] public Bool IsObjectGone;
}