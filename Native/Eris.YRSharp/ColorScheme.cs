using Eris.YRSharp.String.Ansi;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct ColorScheme
{
    public enum ColorSchemeType
    {
        //ColorScheme indices, since they are hardcoded all over the exe, why shan't we do it as well?
        Yellow = 3,
        White = 5,
        Grey = 7,
        Red = 11,
        Orange = 13,
        Pink = 15,
        Purple = 17,
        Blue = 21,
        Green = 29
    }

    public const nint ArrayPointer = 0xB054D0;
    public ref DynamicVectorClass<Pointer<ColorScheme>> Array =>  ref DynamicVectorClass<Pointer<ColorScheme>>.GetDynamicVector(ArrayPointer);
    
    [FieldOffset(0)] public int ArrayIndex;
    [FieldOffset(4)] public BytePalette Colors;
    [FieldOffset(772)] public nint iD;
    public readonly AnsiStringPointer ID => iD;
    [FieldOffset(776)] public ColorStruct BaseColor;
    [FieldOffset(780)] public nint lightConvert;
    public readonly Pointer<LightConvertClass> LightConvert => lightConvert;
    [FieldOffset(784)] public int ShadeCount;
    [FieldOffset(816)] public int MainShadeIndex;

}