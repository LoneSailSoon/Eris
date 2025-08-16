using Eris.YRSharp.GeneralDefinitions;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit, Size = 1776)]
public struct InfantryClass
{
    public static readonly IntPtr ArrayPointer = new IntPtr(0xA83DE8);
    public static ref DynamicVectorClass<Pointer<InfantryClass>> Array { get => ref DynamicVectorClass<Pointer<InfantryClass>>.GetDynamicVector(ArrayPointer); }


    [FieldOffset(0)] public FootClass Base;
    [FieldOffset(0)] public TechnoClass BaseTechno;
    [FieldOffset(0)] public RadioClass BaseRadio;
    [FieldOffset(0)] public MissionClass BaseMission;
    [FieldOffset(0)] public ObjectClass BaseObject;
    [FieldOffset(0)] public AbstractClass BaseAbstract;
    [FieldOffset(1728)] public Pointer<InfantryTypeClass> Type;
    [FieldOffset(1732)] public SequenceAnimType SequenceAnim;
    [FieldOffset(1736)] public TimerStruct Comment;
    [FieldOffset(1748)] public int PanicDurationLeft;
    [FieldOffset(1752)] public Bool PermanentBerzerk;
    [FieldOffset(1753)] public Bool Technician;
    [FieldOffset(1754)] public Bool Stoked;
    [FieldOffset(1755)] public Bool Crawling;
    [FieldOffset(1756)] public Bool ZoneCheat;

}