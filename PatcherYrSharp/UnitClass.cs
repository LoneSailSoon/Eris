using System.Runtime.InteropServices;
using PatcherYrSharp.GeneralStructures;
using PatcherYrSharp.Helpers;

namespace PatcherYrSharp;

[StructLayout(LayoutKind.Explicit, Size = 2280)]
public struct UnitClass
{
    public static readonly IntPtr ArrayPointer = new IntPtr(0x8B4108);
    public static ref DynamicVectorClass<Pointer<UnitClass>> Array { get => ref DynamicVectorClass<Pointer<UnitClass>>.GetDynamicVector(ArrayPointer); }


    [FieldOffset(0)] public FootClass Base;
    [FieldOffset(0)] public TechnoClass BaseTechno;
    [FieldOffset(0)] public RadioClass BaseRadio;
    [FieldOffset(0)] public MissionClass BaseMission;
    [FieldOffset(0)] public ObjectClass BaseObject;
    [FieldOffset(0)] public AbstractClass BaseAbstract;

    [FieldOffset(1732)] public Pointer<UnitTypeClass> Type;
}