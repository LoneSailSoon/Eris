using System.Runtime.CompilerServices;
using Eris.YRSharp.GeneralDefinitions;
using Eris.YRSharp.String.Ansi;
using Eris.YRSharp.Vector;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit, Size = 1824)]
public struct BuildingClass : IYRObject<BuildingClass, BuildingTypeClass>
{
    [FieldOffset(0)]
    public TechnoClass Base;

    [FieldOffset(0)]
    public RadioClass BaseRadio;

    [FieldOffset(0)]
    public MissionClass BaseMission;

    [FieldOffset(0)]
    public ObjectClass BaseObject;

    [FieldOffset(0)]
    public AbstractClass BaseAbstract;

    [FieldOffset(1312)]
    public Pointer<BuildingTypeClass> Type;

    [FieldOffset(1316)]
    public nint factory;

    [FieldOffset(1320)]
    public TimerStruct C4Timer;

    [FieldOffset(1332)]
    public int BState;

    [FieldOffset(1336)]
    public int QueueBState;

    [FieldOffset(1340)]
    public uint OwnerCountryIndex;

    [FieldOffset(1344)]
    public nint c4AppliedBy;

    [FieldOffset(1348)]
    public uint unknown_544;

    [FieldOffset(1352)]
    public nint firestormAnim;

    [FieldOffset(1356)]
    public nint psiWarnAnim;

    [FieldOffset(1360)]
    public TimerStruct unknown_timer_550;

    [FieldOffset(1372)]
    public nint anims;

    [FieldOffset(1456)]
    public byte animStates;

    [FieldOffset(1480)]
    public nint damageFireAnims;

    [FieldOffset(1512)]
    public Bool RequiresDamageFires;

    [FieldOffset(1516)]
    public nint upgrades;

    [FieldOffset(1528)]
    public int FiringSWType;

    [FieldOffset(1532)]
    public uint unknown_5FC;

    [FieldOffset(1536)]
    public nint spotlight;

    [FieldOffset(1540)]
    public RepeatableTimerStruct GateTimer;

    [FieldOffset(1556)]
    public nint lightSource;

    [FieldOffset(1560)]
    public uint LaserFenceFrame;

    [FieldOffset(1564)]
    public uint FirestormWallFrame;

    [FieldOffset(1568)]
    public ProgressTimer RepairProgress;

    [FieldOffset(1596)]
    public RectangleStruct unknown_rect_63C;

    [FieldOffset(1612)]
    public CoordStruct unknown_coord_64C;

    [FieldOffset(1624)]
    public int unknown_int_658;

    [FieldOffset(1628)]
    public uint unknown_65C;

    [FieldOffset(1632)]
    public Bool HasPower;

    [FieldOffset(1633)]
    public Bool IsOverpowered;

    [FieldOffset(1634)]
    public Bool RegisteredAsPoweredUnitSource;

    [FieldOffset(1636)]
    public uint SupportingPrisms;

    [FieldOffset(1640)]
    public Bool HasExtraPowerBonus;

    [FieldOffset(1641)]
    public Bool HasExtraPowerDrain;

    [FieldOffset(1644)]
    public byte overpowerers;

    [FieldOffset(1668)]
    public byte occupants;

    [FieldOffset(1692)]
    public int FiringOccupantIndex;

    [FieldOffset(1696)]
    public AudioController Audio7;

    [FieldOffset(1716)]
    public AudioController Audio8;

    [FieldOffset(1736)]
    public Bool WasOnline;

    [FieldOffset(1737)]
    public Bool ShowRealName;

    [FieldOffset(1738)]
    public Bool BeingProduced;

    [FieldOffset(1739)]
    public Bool ShouldRebuild;

    [FieldOffset(1740)]
    public Bool HasEngineer;

    [FieldOffset(1744)]
    public TimerStruct CashProductionTimer;

    [FieldOffset(1756)]
    public Bool AI_Sellable;

    [FieldOffset(1757)]
    public Bool IsReadyToCommence;

    [FieldOffset(1758)]
    public Bool NeedsRepairs;

    [FieldOffset(1759)]
    public Bool C4Applied;

    [FieldOffset(1760)]
    public Bool NoCrew;

    [FieldOffset(1761)]
    public Bool unknown_bool_6E1;

    [FieldOffset(1762)]
    public Bool unknown_bool_6E2;

    [FieldOffset(1763)]
    public Bool HasBeenCaptured;

    [FieldOffset(1764)]
    public Bool ActuallyPlacedOnMap;

    [FieldOffset(1765)]
    public Bool unknown_bool_6E5;

    [FieldOffset(1766)]
    public Bool IsDamaged;

    [FieldOffset(1767)]
    public Bool IsFogged;

    [FieldOffset(1768)]
    public Bool IsBeingRepaired;

    [FieldOffset(1769)]
    public Bool HasBuildUp;

    [FieldOffset(1770)]
    public Bool StuffEnabled;

    [FieldOffset(1771)]
    public byte HasCloakingData;

    [FieldOffset(1772)]
    public byte CloakRadius;

    [FieldOffset(1773)]
    public byte Translucency;

    [FieldOffset(1776)]
    public uint StorageFilledSlots;

    [FieldOffset(1780)]
    public nint secretProduction;

    [FieldOffset(1784)]
    public ColorStruct ColorAdd;

    [FieldOffset(1788)]
    public int unknown_int_6FC;

    [FieldOffset(1792)]
    public short unknown_short_700;

    [FieldOffset(1794)]
    public byte UpgradeLevel;

    [FieldOffset(1795)]
    public byte GateStage;

    [FieldOffset(1796)]
    public PrismChargeState PrismStage;

    [FieldOffset(1800)]
    public CoordStruct PrismTargetCoords;

    [FieldOffset(1812)]
    public uint DelayBeforeFiring;

    [FieldOffset(1816)]
    public uint BunkerState;

    static Pointer<BuildingTypeClass> IYRObject<BuildingClass, BuildingTypeClass>.Type(Pointer<BuildingClass> pThis) => pThis.Ref.Type;

    public readonly Pointer<FactoryClass> Factory => factory;

    public readonly Pointer<InfantryClass> C4AppliedBy => c4AppliedBy;

    public readonly Pointer<AnimClass> FirestormAnim => firestormAnim;

    public readonly Pointer<AnimClass> PsiWarnAnim => psiWarnAnim;

    public FixedArray<Pointer<AnimClass>> Anims => new FixedArray<Pointer<AnimClass>>(ref Unsafe.As<nint, Pointer<AnimClass>>(ref anims), 21);

    public FixedArray<byte> AnimStates => new FixedArray<byte>(ref animStates, 21);

    public FixedArray<Pointer<AnimClass>> DamageFireAnims => new FixedArray<Pointer<AnimClass>>(ref Unsafe.As<nint, Pointer<AnimClass>>(ref damageFireAnims), 8);

    public FixedArray<Pointer<BuildingTypeClass>> Upgrades => new FixedArray<Pointer<BuildingTypeClass>>(ref Unsafe.As<nint, Pointer<BuildingTypeClass>>(ref damageFireAnims), 3);

    public readonly Pointer<BuildingLightClass> Spotlight => spotlight;

    public readonly Pointer<LightSourceClass> LightSource => lightSource;

    public ref DynamicVectorClass<Pointer<InfantryClass>> Overpowerers => ref Pointer<byte>.AsPointer(ref overpowerers).Convert<DynamicVectorClass<Pointer<InfantryClass>>>().Ref;

    public ref DynamicVectorClass<Pointer<InfantryClass>> Occupants => ref Pointer<byte>.AsPointer(ref occupants).Convert<DynamicVectorClass<Pointer<InfantryClass>>>().Ref;

    public readonly Pointer<TechnoClass> SecretProduction => secretProduction;

    public unsafe CellStruct FindExitCell(uint dwUnk1, uint dwUnk2)
    {
        var pThis = default(CellStruct);
        ((delegate* unmanaged[Thiscall]<nint, nint, uint, uint, nint>)this.GetVirtualFunctionPointer(309))(this.GetThisPointer(), pThis.GetThisPointer(), dwUnk1, dwUnk2);
        return pThis;
    }

    public unsafe int DistanceToDockingCoord(Pointer<ObjectClass> pObj)
    {
        return ((delegate* unmanaged[Thiscall]<nint, nint, int>)this.GetVirtualFunctionPointer(310))(this.GetThisPointer(), pObj);
    }

    public unsafe void Place(bool captured)
    {
        ((delegate* unmanaged[Thiscall]<nint, bool, void>)this.GetVirtualFunctionPointer(311))(this.GetThisPointer(), captured);
    }

    public unsafe void UpdateConstructionOptions()
    {
        ((delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(312))(this.GetThisPointer());
    }

    public unsafe void Draw(Point2D point, RectangleStruct rect)
    {
        ((delegate* unmanaged[Thiscall]<nint, nint, nint, void>)this.GetVirtualFunctionPointer(313))(this.GetThisPointer(), point.GetThisPointer(), rect.GetThisPointer());
    }

    public unsafe DirStruct FireAngleTo(Pointer<ObjectClass> pObject)
    {
        var pThis = default(DirStruct);
        ((delegate* unmanaged[Thiscall]<nint, nint, nint, nint>)this.GetVirtualFunctionPointer(314))(this.GetThisPointer(), pThis.GetThisPointer(), pObject);
        return pThis;
    }

    public unsafe void Destory(Pointer<TechnoClass> pTechno, bool NoSurvivor, CellStruct cell)
    {
        ((delegate* unmanaged[Thiscall]<nint, nint, nint, nint, nint, void>)this.GetVirtualFunctionPointer(315))(this.GetThisPointer(), 0, pTechno, NoSurvivor ? 1 : 0, cell.GetThisPointer());
    }

    public unsafe void TogglePrimaryFactory()
    {
        ((delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(316))(this.GetThisPointer());
    }

    public unsafe void SensorArrayActivate(CellStruct cell = default(CellStruct))
    {
        ((delegate* unmanaged[Thiscall]<nint, uint, void>)this.GetVirtualFunctionPointer(317))(this.GetThisPointer(), *(uint*)(&cell));
    }

    public unsafe void SensorArrayDeactivate(CellStruct cell = default(CellStruct))
    {
        ((delegate* unmanaged[Thiscall]<nint, uint, void>)this.GetVirtualFunctionPointer(318))(this.GetThisPointer(), *(uint*)(&cell));
    }

    public unsafe void DisguiseDetectorActivate(CellStruct cell = default(CellStruct))
    {
        ((delegate* unmanaged[Thiscall]<nint, uint, void>)this.GetVirtualFunctionPointer(319))(this.GetThisPointer(), *(uint*)(&cell));
    }

    public unsafe void DisguiseDetectorDeactivate(CellStruct cell = default(CellStruct))
    {
        ((delegate* unmanaged[Thiscall]<nint, uint, void>)this.GetVirtualFunctionPointer(320))(this.GetThisPointer(), *(uint*)(&cell));
    }

    public unsafe int AlwaysZero()
    {
        return ((delegate* unmanaged[Thiscall]<nint, int>)this.GetVirtualFunctionPointer(321))(this.GetThisPointer());
    }

    public unsafe void UpdateAnimations()
    {
        ((delegate* unmanaged[Thiscall]<nint, void>)4524496)(this.GetThisPointer());
    }

    public unsafe uint GetCurrentFrame()
    {
        return ((delegate* unmanaged[Thiscall]<nint, uint>)4452240)(this.GetThisPointer());
    }

    public unsafe bool IsAllFogged()
    {
        return ((delegate* unmanaged[Thiscall]<nint, bool>)4553232)(this.GetThisPointer());
    }

    public unsafe void SetRallypoint(Pointer<CellStruct> pTarget, bool bPlayEVA)
    {
        ((delegate* unmanaged[Thiscall]<nint, nint, bool, void>)4470880)(this.GetThisPointer(), pTarget, bPlayEVA);
    }

    public unsafe void FreezeInFog(Pointer<DynamicVectorClass<Pointer<FoggedObjectClass>>> pFoggedArray, Pointer<CellClass> pCell, bool visible)
    {
        ((delegate* unmanaged[Thiscall]<nint, nint, nint, bool, void>)4553376)(this.GetThisPointer(), pFoggedArray, pCell, visible);
    }

    public unsafe void GoOnline()
    {
        ((delegate* unmanaged[Thiscall]<nint, void>)4530784)(this.GetThisPointer());
    }

    public unsafe void GoOffline()
    {
        ((delegate* unmanaged[Thiscall]<nint, void>)4531040)(this.GetThisPointer());
    }

    public unsafe int GetPowerOutput()
    {
        return ((delegate* unmanaged[Thiscall]<nint, int>)4515760)(this.GetThisPointer());
    }

    public unsafe int GetPowerDrain()
    {
        return ((delegate* unmanaged[Thiscall]<nint, int>)4515968)(this.GetThisPointer());
    }

    public unsafe uint GetFWFlags()
    {
        return ((delegate* unmanaged[Thiscall]<nint, uint>)4545424)(this.GetThisPointer());
    }

    public unsafe void CreateEndPost(bool arg)
    {
        ((delegate* unmanaged[Thiscall]<nint, bool, void>)4535200)(this.GetThisPointer(), arg);
    }

    public unsafe void UnloadBunker()
    {
        ((delegate* unmanaged[Thiscall]<nint, void>)4559776)(this.GetThisPointer());
    }

    public unsafe void EmptyBunker()
    {
        ((delegate* unmanaged[Thiscall]<nint, void>)4560320)(this.GetThisPointer());
    }

    public unsafe void AfterDestruction()
    {
        ((delegate* unmanaged[Thiscall]<nint, void>)4464480)(this.GetThisPointer());
    }

    public unsafe bool IsUnitFactory()
    {
        return ((delegate* unmanaged[Thiscall]<nint, bool>)4545952)(this.GetThisPointer());
    }

    public unsafe void DestroyNthAnim(BuildingAnimSlot slot)
    {
        ((delegate* unmanaged[Thiscall]<nint, BuildingAnimSlot, void>)4464480)(this.GetThisPointer(), slot);
    }

    public unsafe void PlayAnim(string animName, BuildingAnimSlot Slot, bool Damaged, bool Garrisoned, int effectDelay = 0)
    {
        using var ansiStringSpan = new AnsiStringSpan(animName);
        ((delegate* unmanaged[Thiscall]<nint, nint, BuildingAnimSlot, bool, bool, int, void>)4528272)(this.GetThisPointer(), ansiStringSpan, Slot, Damaged, Garrisoned, effectDelay);
    }

    public unsafe void ToggleDamagedAnims(bool isDamaged)
    {
        ((delegate* unmanaged[Thiscall]<nint, bool, void>)4529888)(this.GetThisPointer(), isDamaged);
    }

    public unsafe void DisableStuff()
    {
        ((delegate* unmanaged[Thiscall]<nint, void>)4531328)(this.GetThisPointer());
    }

    public unsafe void EnableStuff()
    {
        ((delegate* unmanaged[Thiscall]<nint, void>)4531216)(this.GetThisPointer());
    }

    public unsafe void DisableTemporal()
    {
        ((delegate* unmanaged[Thiscall]<nint, void>)4530624)(this.GetThisPointer());
    }

    public unsafe void EnableTemporal()
    {
        ((delegate* unmanaged[Thiscall]<nint, void>)4530704)(this.GetThisPointer());
    }

    public unsafe int FirstActiveSWIdx()
    {
        return ((delegate* unmanaged[Thiscall]<nint, int>)4552240)(this.GetThisPointer());
    }

    public unsafe int GetShapeNumber()
    {
        return ((delegate* unmanaged[Thiscall]<nint, int>)4452240)(this.GetThisPointer());
    }

    public unsafe void BeginMode(BStateType bType)
    {
        ((delegate* unmanaged[Thiscall]<nint, BStateType, void>)4487040)(this.GetThisPointer(), bType);
    }

    public unsafe int SecondActiveSWIdx()
    {
        return ((delegate* unmanaged[Thiscall]<nint, int>)4552336)(this.GetThisPointer());
    }

    public unsafe void FireLaser(CoordStruct coords)
    {
        ((delegate* unmanaged[Thiscall]<nint, CoordStruct, void>)4487040)(this.GetThisPointer(), coords);
    }

    public unsafe bool IsBeingDrained()
    {
        return ((delegate* unmanaged[Thiscall]<nint, bool>)7405248)(this.GetThisPointer());
    }

    public unsafe bool UpdateBunker()
    {
        return ((delegate* unmanaged[Thiscall]<nint, bool>)4558416)(this.GetThisPointer());
    }

    public unsafe void FireLaser(Pointer<TechnoClass> pAssaulter)
    {
        ((delegate* unmanaged[Thiscall]<nint, nint, void>)4487040)(this.GetThisPointer(), pAssaulter);
    }

    public unsafe bool MakeTraversable()
    {
        return ((delegate* unmanaged[Thiscall]<nint, bool>)4531520)(this.GetThisPointer());
    }

    public unsafe bool CheckFog()
    {
        return ((delegate* unmanaged[Thiscall]<nint, bool>)4553232)(this.GetThisPointer());
    }

    public unsafe Pointer<Matrix3D> GetVoxelBarrelOffsetMatrix(Pointer<Matrix3D> ret)
    {
        return ((delegate* unmanaged[Thiscall]<nint, nint, nint>)4487040)(this.GetThisPointer(), ret);
    }

    public unsafe bool IsTraversable()
    {
        return ((delegate* unmanaged[Thiscall]<nint, bool>)4531696)(this.GetThisPointer());
    }

    public unsafe bool DrawInfoTipAndSpiedSelection(Pointer<Point2D> pLocation, Pointer<RectangleStruct> pRect)
    {
        return ((delegate* unmanaged[Thiscall]<nint, nint, nint, bool>)4450224)(this.GetThisPointer(), pLocation, pRect);
    }

    public unsafe CoordStruct GetTargetCoords()
    {
        var pThis = new CoordStruct(0, 0, 0);
        ((delegate* unmanaged[Thiscall]<nint, nint, nint>)4522144)(this.GetThisPointer(), pThis.GetThisPointer());
        return pThis;
    }

    public unsafe void Sell(uint dwUnk)
    {
        ((delegate* unmanaged[Thiscall]<nint, uint, void>)4485392)(this.GetThisPointer(), dwUnk);
    }
}
public enum BStateType : uint
{
    Construction = 0u,
    Idle = 1u,
    Active = 2u,
    Full = 3u,
    Aux1 = 4u,
    Aux2 = 5u,
    Count = 6u,
    None = uint.MaxValue
}