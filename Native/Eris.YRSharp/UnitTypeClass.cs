using System.Runtime.InteropServices;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit, Size = 3704)]
public struct UnitTypeClass
{

    [FieldOffset(0)] public TechnoTypeClass Base;
    [FieldOffset(0)] public ObjectTypeClass BaseObjectType;
    [FieldOffset(0)] public AbstractTypeClass BaseAbstractType;
    [FieldOffset(3576)] public int ArrayIndex;
        
}