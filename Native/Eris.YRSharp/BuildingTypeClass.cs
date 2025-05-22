using System.Runtime.InteropServices;
using Eris.YRSharp.GeneralDefinitions;
using Eris.YRSharp.Helpers;
using Eris.YRSharp.Vector;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit, Size = 6040)]
public struct BuildingTypeClass
{
    public unsafe bool CanCreateHere(CellStruct mapCoords, Pointer<HouseClass> pHouse)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, bool>)0x464AC0;
        return func(this.GetThisPointer(), mapCoords.GetThisPointer(), pHouse);
    }

    // public static unsafe Pointer<BuildingTypeClass> FindOrAllocate(string ID)
    // {
    //     var func = (delegate* unmanaged[Thiscall]<int, IntPtr, IntPtr>)ASM.FastCallTransferStation;
    //     return func(0x4653C0, new AnsiString(ID));
    // }

    public unsafe short GetFoundationWidth()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, short>)0x45EC90;
        return func(this.GetThisPointer());
    }
    public unsafe short GetFoundationHeight(bool bIncludeBib)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool, short>)0x45ECA0;
        return func(this.GetThisPointer(), bIncludeBib);
    }

    [FieldOffset(0)] public TechnoTypeClass Base;
    [FieldOffset(0)] public ObjectTypeClass BaseObjectType;
    [FieldOffset(0)] public AbstractTypeClass BaseAbstractType;
    [FieldOffset(3576)] public int ArrayIndex;
    [FieldOffset(3580)] public nint foundationData;
    public readonly Pointer<CellStruct> FoundationData => foundationData;
    [FieldOffset(3764)] public int Adjacent;
    [FieldOffset(3768)] public AbstractType Factory;
    [FieldOffset(3808)] public int PowerBonus;
    [FieldOffset(3812)] public int PowerDrain;
    [FieldOffset(3824)] public int Foundation;
    [FieldOffset(3828)] public int Height;
    [FieldOffset(3832)] public int OccupyHeight;
    [FieldOffset(5408)] public int NormalZAdjust;
    [FieldOffset(5450)] public Bool TogglePower;
    [FieldOffset(5451)] public Bool HasSpotlight;
    [FieldOffset(5452)] public Bool IsTemple;
    [FieldOffset(5453)] public Bool IsPlug;
    [FieldOffset(5454)] public Bool HoverPad;
    [FieldOffset(5455)] public Bool BaseNormal;
    [FieldOffset(5456)] public Bool EligibileForAllyBuilding;
    [FieldOffset(5457)] public Bool EligibleForDelayKill;
    [FieldOffset(5458)] public Bool NeedsEngineer;
    [FieldOffset(5490)] public Bool Capturable;
    [FieldOffset(5495)] public Bool CanC4;
    [FieldOffset(5498)] public Bool ClickRepairable;
    [FieldOffset(5825)] public Bool Hospital;
    [FieldOffset(5835)] public Bool Helipad;
    [FieldOffset(5889)] public Bool InvisibleInGame;
    [FieldOffset(5891)] public Bool PlaceAnywhere;
    [FieldOffset(6016)] public int NumberOfDocks;


}