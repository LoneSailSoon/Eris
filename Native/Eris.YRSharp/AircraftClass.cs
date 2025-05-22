using System.Runtime.InteropServices;
using Eris.YRSharp.GeneralStructures;
using Eris.YRSharp.Helpers;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit, Size = 1752)]
public struct AircraftClass
{
    public const nint ArrayPointer = 0xA8E390;
    public static ref DynamicVectorClass<Pointer<AircraftClass>> Array => ref DynamicVectorClass<Pointer<AircraftClass>>.GetDynamicVector(ArrayPointer);

    [FieldOffset(0)] public FootClass Base;
    [FieldOffset(0)] public TechnoClass BaseTechno;
    [FieldOffset(0)] public RadioClass BaseRadio;
    [FieldOffset(0)] public MissionClass BaseMission;
    [FieldOffset(0)] public ObjectClass BaseObject;
    [FieldOffset(0)] public AbstractClass BaseAbstract;
    [FieldOffset(1732)] public Pointer<AircraftTypeClass> Type;
}