using System.Runtime.CompilerServices;
using Eris.YRSharp.GeneralDefinitions;
using Eris.YRSharp.String.Ansi;
using Eris.YRSharp.String.Uni;
using Eris.YRSharp.Vector;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit, Size = 90296)]
public struct HouseClass : IYRObject<HouseClass, HouseTypeClass>
{
    public const nint ArrayPointer = 0xA80228;

    public static ref DynamicVectorClass<Pointer<HouseClass>> Array =>
        ref DynamicVectorClass<Pointer<HouseClass>>.GetDynamicVector(ArrayPointer);

    private const nint player = 0xA83D4C;

    public static Pointer<HouseClass> Player
    {
        get => player.Convert<Pointer<HouseClass>>().Data;
        set => player.Convert<Pointer<HouseClass>>().Ref = value;
    }

    private const nint observer = 0xAC1198;

    public static Pointer<HouseClass> Observer
    {
        get => observer.Convert<Pointer<HouseClass>>().Data;
        set => observer.Convert<Pointer<HouseClass>>().Ref = value;
    }


    static Pointer<HouseTypeClass> IYRObject<HouseClass, HouseTypeClass>.Type(Pointer<HouseClass> pThis) => pThis.Ref.Type;


    // HouseClass is too large that clr could not process. so we user Pointer instead.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Pointer<HouseClass> GetThis() => this.GetThisPointer();

    public Pointer<SuperClass> FindSuperWeapon(Pointer<SuperWeaponTypeClass> pType)
    {
        for (int i = 0; i < Supers.Count; i++)
        {
            var pItem = Supers[i];
            if (pItem.Ref.Type == pType)
            {
                return pItem;
            }
        }

        return Pointer<SuperClass>.Zero;
    }

    public unsafe Pointer<FactoryClass> GetPrimayFactory(AbstractType abs, bool naval, BuildCat buildCat)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, AbstractType, Bool, BuildCat, nint>)0x500510;
        return func(GetThis(), abs, naval, buildCat);
    }

    public readonly bool IsAlliedWith(int idxHouse)
    {
        return ArrayIndex == idxHouse || (idxHouse != -1 && Allies.Contains(idxHouse));
    }

    public readonly bool IsAlliedWith(Pointer<HouseClass> pHouse)
    {
        return pHouse.IsNotNull && (ArrayIndex == pHouse.Ref.ArrayIndex ||
                                    (pHouse.Ref.ArrayIndex != -1 && Allies.Contains(pHouse.Ref.ArrayIndex)));
    }

    public unsafe bool IsAlliedWith(Pointer<ObjectClass> pObject)
    {
        var func = (delegate* unmanaged[Thiscall]<IntPtr, IntPtr, bool>)0x4F9A90;
        return func(GetThis(), pObject);
    }

    public unsafe bool IsAlliedWith(Pointer<AbstractClass> pAbstract)
    {
        var func = (delegate* unmanaged[Thiscall]<IntPtr, IntPtr, bool>)0x4F9AF0;
        return func(GetThis(), pAbstract);
    }

    public void TransactMoney(int amount)
    {
        if (amount > 0)
        {
            GiveMoney(amount);
        }
        else
        {
            TakeMoney(-amount);
        }
    }

    public bool CanTransactMoney(int amount)
    {
        return amount > 0 || Available_Money() >= -amount;
    }


    public static unsafe Pointer<HouseClass> FindByCountryIndex(int houseType)
    {
        var func = (delegate* unmanaged[Thiscall]<int, IntPtr>)0x502D30;
        return func(houseType);
    }

    public static unsafe Pointer<HouseClass> FindByIndex(int idxHouse)
    {
        var func = (delegate* unmanaged[Thiscall]<int, IntPtr>)0x510ED0;
        return func(idxHouse);
    }

    public static unsafe int FindIndexByName(AnsiString name)
    {
        var func = (delegate* unmanaged[Thiscall]<IntPtr, int>)0x50C170;
        return func(name);
    }

    // gets the first house of a type with this name
    public static Pointer<HouseClass> FindByCountryName(AnsiString name)
    {
        var idx = HouseTypeClass.FindIndexOfName(name);
        return FindByCountryIndex(idx);
    }

    // gets the first house of a type with name Neutral
    public static Pointer<HouseClass> FindNeutral()
    {
        return FindByCountryName("Neutral");
    }

    // gets the first house of a type with name Special
    public static Pointer<HouseClass> FindSpecial()
    {
        return FindByCountryName("Special");
    }

    // gets the first house of a side with this name
    public static Pointer<HouseClass> FindBySideIndex(int index)
    {
        foreach (var pHouse in Array)
        {
            if (pHouse.Ref.Type.Ref.SideIndex == index)
            {
                return pHouse;
            }
        }

        return Pointer<HouseClass>.Zero;
    }

    // gets the first house of a type with this name
    // public static Pointer<HouseClass> FindBySideName(AnsiString name)
    // {
    //     var idx = SideClass.ABSTRACTTYPE_ARRAY.FindIndex(name);
    //     return FindBySideIndex(idx);
    // }

    // gets the first house of a type from the Civilian side
    // public static Pointer<HouseClass> FindCivilianSide()
    // {
    //     return FindBySideName("Civilian");
    // }

    public unsafe bool ControlledByHuman()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)0x50B730;
        return func(GetThis());
    }

    // Target ought to be Object, I imagine, but cell doesn't work then
    // public unsafe void SendSpyPlanes(int AircraftTypeIdx, int AircraftAmount, Mission SetMission, Pointer<AbstractClass> Target, Pointer<ObjectClass> Destination)
    // {
    //     var func = (delegate* unmanaged[Thiscall]<int, IntPtr, int, int, Mission, IntPtr, IntPtr, void>)ASM.FastCallTransferStation;
    //     func(0x65EAB0, GetThis(), AircraftTypeIdx, AircraftAmount, SetMission, Target, Destination);
    // }

    public unsafe Edge GetCurrentEdge()
    {
        var func = (delegate* unmanaged[Thiscall]<IntPtr, Edge>)0x50DA80;
        return func(GetThis());
    }

    public Edge GetStartingEdge()
    {
        var edge = StartingEdge;
        if (edge is < Edge.North or > Edge.West)
            edge = GetCurrentEdge();
        return edge;
    }

    public unsafe int Available_Money()
    {
        var func = (delegate* unmanaged[Stdcall]<IntPtr, int>)this.GetVirtualFunctionPointer(6, tableIndex: 9);
        return func(GetThis().RawOffset(36));
    }

    public unsafe bool SetCurrentBuilding(Pointer<BuildingClass> pFactory, Pointer<BuildingClass> pBid)
    {
        return ((delegate* unmanaged[Thiscall]<IntPtr, IntPtr, IntPtr, Bool>)0x4FB840)(GetThis(), pFactory, pBid);
        // func(GetThis(), pFactory, pBid);
    }


    #region IHouse

    public unsafe int ID_Number()
    {
        var func = (delegate* unmanaged[Stdcall]<nint, int>)IHouse[3];
        return func(iHouse.GetThisPointer());
    }

    public unsafe nint Name()
    {
        var func = (delegate* unmanaged[Stdcall]<nint, nint>)IHouse[4];
        return func(iHouse.GetThisPointer());
    }

    public unsafe Pointer<IApplication> Get_Application()
    {
        var func = (delegate* unmanaged[Stdcall]<nint, nint>)IHouse[5];
        return func(iHouse.GetThisPointer());
    }

    public unsafe int Available_Storage()
    {
        var func = (delegate* unmanaged[Stdcall]<nint, int>)IHouse[7];
        return func(iHouse.GetThisPointer());
    }

    public unsafe int Power_Output()
    {
        var func = (delegate* unmanaged[Stdcall]<nint, int>)IHouse[8];
        return func(iHouse.GetThisPointer());
    }

    public unsafe int Power_Drain()
    {
        var func = (delegate* unmanaged[Stdcall]<nint, int>)IHouse[9];
        return func(iHouse.GetThisPointer());
    }

    public unsafe int Category_Quantity(Category category)
    {
        var func = (delegate* unmanaged[Stdcall]<nint, Category, int>)IHouse[10];
        return func(iHouse.GetThisPointer(), category);
    }

    public unsafe int Category_Power(Category category)
    {
        var func = (delegate* unmanaged[Stdcall]<nint, Category, int>)IHouse[11];
        return func(iHouse.GetThisPointer(), category);
    }

    public unsafe CellStruct Base_Center()
    {
        var func = (delegate* unmanaged[Stdcall]<nint, CellStruct>)IHouse[12];
        return func(iHouse.GetThisPointer());
    }

    public unsafe int Fire_Sale()
    {
        var func = (delegate* unmanaged[Stdcall]<nint, int>)IHouse[13];
        return func(iHouse.GetThisPointer());
    }

    public unsafe int All_To_Hunt()
    {
        var func = (delegate* unmanaged[Stdcall]<nint, int>)IHouse[14];
        return func(iHouse.GetThisPointer());
    }

    #endregion

    #region IPublicHouse

    public unsafe int Apparent_Category_Quantity(Category category)
    {
        var func = (delegate* unmanaged[Stdcall]<nint, Category, int>)IPublicHouse[5];
        return func(iPublicHouse.GetThisPointer(), category);
    }

    public unsafe int Apparent_Category_Power(Category category)
    {
        var func = (delegate* unmanaged[Stdcall]<nint, Category, int>)IPublicHouse[6];
        return func(iPublicHouse.GetThisPointer(), category);
    }

    public unsafe CellStruct Apparent_Base_Center()
    {
        var func = (delegate* unmanaged[Stdcall]<nint, CellStruct>)IPublicHouse[7];
        return func(iPublicHouse.GetThisPointer());
    }

    public unsafe bool Is_Powered()
    {
        var func = (delegate* unmanaged[Stdcall]<nint, bool>)IPublicHouse[8];
        return func(iPublicHouse.GetThisPointer());
    }

    #endregion

    #region Method

    public unsafe void MakeAlly(int ihouse, bool bAnnounce)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, bool, void>)0x4F9B50;
        func(this.GetThisPointer(), ihouse, bAnnounce);
    }

    public unsafe void MakeAlly(Pointer<HouseClass> pWho, bool bAnnounce)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool, void>)0x4F9B70;
        func(this.GetThisPointer(), pWho, bAnnounce);
    }

    public unsafe void MakeEnemy(Pointer<HouseClass> pWho, bool bAnnounce)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool, void>)0x4F9F90;
        func(this.GetThisPointer(), pWho, bAnnounce);
    }

    public unsafe void AdjustThreats()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x509400;
        func(this.GetThisPointer());
    }

    public unsafe void UpdateAngerNodes(int nScoreAdd, Pointer<HouseClass> pHouse)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, nint, void>)0x504790;
        func(this.GetThisPointer(), nScoreAdd, pHouse);
    }

    public unsafe void AllyAIHouses()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x501640;
        func(this.GetThisPointer());
    }

    public unsafe void SDDTORAllAndTriggers()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x4FB920;
        func(this.GetThisPointer());
    }

    public unsafe void AcceptDefeat()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x4FC0B0;
        func(this.GetThisPointer());
    }

    public unsafe void DestroyAll()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x4FC6D0;
        func(this.GetThisPointer());
    }

    public unsafe void DestroyAllBuildings()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x4FC790;
        func(this.GetThisPointer());
    }

    public unsafe void DestroyAllNonBuildingsNonNaval()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x4FC820;
        func(this.GetThisPointer());
    }

    public unsafe void DestroyAllNonBuildingsNaval()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x4FC8D0;
        func(this.GetThisPointer());
    }

    public unsafe void RespawnStartingBuildings()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x50D320;
        func(this.GetThisPointer());
    }

    public unsafe void RespawnStartingForces()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x50D440;
        func(this.GetThisPointer());
    }

    public unsafe byte Win(bool bSavourSomething)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool, byte>)0x4FC9E0;
        return func(this.GetThisPointer(), bSavourSomething);
    }

    public unsafe byte Lose(bool bSavourSomething)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool, byte>)0x4FCBD0;
        return func(this.GetThisPointer(), bSavourSomething);
    }

    public unsafe void RegisterJustBuilt(Pointer<TechnoClass> pTechno)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x4FB6B0;
        func(this.GetThisPointer(), pTechno);
    }

    public unsafe bool CanAlly(Pointer<HouseClass> pOther)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool>)0x501540;
        return func(this.GetThisPointer(), pOther);
    }

    public unsafe bool CanOverpower(Pointer<TechnoClass> pTarget)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool>)0x4F9AF0;
        return func(this.GetThisPointer(), pTarget);
    }

    public unsafe void LostPoweredCenter(Pointer<TechnoTypeClass> pTechnoType)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x50E0E0;
        func(this.GetThisPointer(), pTechnoType);
    }

    public unsafe void GainedPoweredCenter(Pointer<TechnoTypeClass> pTechnoType)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x50E1B0;
        func(this.GetThisPointer(), pTechnoType);
    }

    public unsafe int GetInfSelfHealStep()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)0x50D9E0;
        return func(this.GetThisPointer());
    }

    public unsafe int GetUnitSelfHealStep()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)0x50D9F0;
        return func(this.GetThisPointer());
    }

    public unsafe void UpdatePower()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x508C30;
        func(this.GetThisPointer());
    }

    public unsafe void CreatePowerOutage(int duration)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, void>)0x50BC90;
        func(this.GetThisPointer(), duration);
    }

    public unsafe double GetPowerPercentage()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, double>)0x4FCE30;
        return func(this.GetThisPointer());
    }

    public unsafe void CreateRadarOutage(int duration)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, void>)0x50BCD0;
        func(this.GetThisPointer(), duration);
    }

    public unsafe void ReshroudMap()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x50BD10;
        func(this.GetThisPointer());
    }

    public unsafe void Cheer()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x50C8C0;
        func(this.GetThisPointer());
    }

    public unsafe void BuildingUnderAttack(Pointer<BuildingClass> pBld)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x4F93E0;
        func(this.GetThisPointer(), pBld);
    }

    public unsafe void TakeMoney(int amount)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, void>)0x4F9790;
        func(this.GetThisPointer(), amount);
    }

    public unsafe void GiveMoney(int amount)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, void>)0x4F9950;
        func(this.GetThisPointer(), amount);
    }

    public unsafe void GiveTiberium(float amount, int tibType)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, float, int, void>)0x4F9610;
        func(this.GetThisPointer(), amount, tibType);
    }

    public unsafe void UpdateAllSilos(int prevStorage, int prevTotalStorage)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, int, void>)0x4F9970;
        func(this.GetThisPointer(), prevStorage, prevTotalStorage);
    }

    public unsafe double GetStoragePercentage()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, double>)0x4F6E70;
        return func(this.GetThisPointer());
    }

    public unsafe void AcquiredThreatNode()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x509130;
        func(this.GetThisPointer());
    }

    public unsafe Pointer<WaypointClass> GetPlanningWaypointAt(Pointer<CellStruct> coords)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint>)0x5023B0;
        return func(this.GetThisPointer(), coords);
    }

    public unsafe bool GetPlanningWaypointProperties(Pointer<WaypointClass> wpt, Pointer<int> idxPath,
        Pointer<byte> idxWP)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, nint, bool>)0x502460;
        return func(this.GetThisPointer(), wpt, idxPath, idxWP);
    }

    public unsafe void EnsurePlanningPathExists(int idx)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, void>)0x504740;
        func(this.GetThisPointer(), idx);
    }

    public unsafe void Update_FactoriesQueues(AbstractType factoryOf, bool isNaval, BuildCat buildCat)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, AbstractType, bool, BuildCat, void>)0x509140;
        func(this.GetThisPointer(), factoryOf, isNaval, buildCat);
    }

    public unsafe Pointer<FactoryClass> GetFactoryProducing(Pointer<TechnoTypeClass> pItem)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint>)0x4F83C0;
        return func(this.GetThisPointer(), pItem);
    }

    public unsafe void RegisterGain(Pointer<TechnoClass> pTechno, bool ownerChange)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool, void>)0x502A80;
        func(this.GetThisPointer(), pTechno, ownerChange);
    }

    public unsafe void RegisterLoss(Pointer<TechnoClass> pTechno, bool keepTiberium)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool, void>)0x5025F0;
        func(this.GetThisPointer(), pTechno, keepTiberium);
    }

    public unsafe Pointer<BuildingClass> FindBuildingOfType(int idx, int sector = -1)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, int, nint>)0x4FD060;
        return func(this.GetThisPointer(), idx, sector);
    }

    public unsafe bool Fire_LightningStorm(Pointer<SuperClass> pSuper)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool>)0x509E00;
        return func(this.GetThisPointer(), pSuper);
    }

    public unsafe bool Fire_ParaDrop(Pointer<SuperClass> pSuper)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool>)0x509CD0;
        return func(this.GetThisPointer(), pSuper);
    }

    public unsafe bool Fire_PsyDom(Pointer<SuperClass> pSuper)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool>)0x50A150;
        return func(this.GetThisPointer(), pSuper);
    }

    public unsafe bool Fire_GenMutator(Pointer<SuperClass> pSuper)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool>)0x509F60;
        return func(this.GetThisPointer(), pSuper);
    }

    public unsafe bool IonSensitivesShouldBeOffline()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)0x53A130;
        return func(this.GetThisPointer());
    }

    public unsafe CanBuildResult CanBuild(Pointer<TechnoTypeClass> pItem, bool buildLimitOnly, bool allowIfInProduction)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool, bool, CanBuildResult>)0x4F7870;
        return func(this.GetThisPointer(), pItem, buildLimitOnly, allowIfInProduction);
    }

    public unsafe int AI_BaseConstructionUpdate()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)0x4FE3E0;
        return func(this.GetThisPointer());
    }

    public unsafe int AI_VehicleConstructionUpdate()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)0x4FEA60;
        return func(this.GetThisPointer());
    }

    public unsafe void AI_TryFireSW()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x5098F0;
        func(this.GetThisPointer());
    }

    public unsafe bool Fire_SW(int idx, Pointer<CellStruct> coords)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, nint, bool>)0x4FAE50;
        return func(this.GetThisPointer(), idx, coords);
    }

    public unsafe Pointer<CellStruct> PickTargetByType(Pointer<CellStruct> outBuffer, TargetType targetType)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, TargetType, nint>)0x50D170;
        return func(this.GetThisPointer(), outBuffer, targetType);
    }

    public unsafe Pointer<CellStruct> PickIonCannonTarget(Pointer<CellStruct> outBuffer)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint>)0x50CBF0;
        return func(this.GetThisPointer(), outBuffer);
    }

    public unsafe void UpdateFlagCoords(Pointer<UnitClass> NewCarrier, uint dwUnk)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, uint, void>)0x4FBE40;
        func(this.GetThisPointer(), NewCarrier, dwUnk);
    }

    public unsafe void DroppedFlag(Pointer<CellStruct> Where, Pointer<UnitClass> Who)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, void>)0x4FBF60;
        func(this.GetThisPointer(), Where, Who);
    }

    public unsafe byte PickedUpFlag(Pointer<UnitClass> Who, uint dwUnk)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, uint, byte>)0x4FC060;
        return func(this.GetThisPointer(), Who, dwUnk);
    }

    public unsafe Pointer<FactoryClass> GetPrimaryFactory(AbstractType absID, bool naval, BuildCat buildCat)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, AbstractType, bool, BuildCat, nint>)0x500510;
        return func(this.GetThisPointer(), absID, naval, buildCat);
    }

    public unsafe void SetPrimaryFactory(Pointer<FactoryClass> pFactory, AbstractType absID, bool naval,
        BuildCat buildCat)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, AbstractType, bool, BuildCat, void>)0x500850;
        func(this.GetThisPointer(), pFactory, absID, naval, buildCat);
    }

    public unsafe int CalculateCostMultipliers()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)0x50BF60;
        return func(this.GetThisPointer());
    }

    public unsafe void ForceEnd()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x4FCDC0;
        func(this.GetThisPointer());
    }

    public unsafe void RemoveTracking(Pointer<TechnoClass> pTechno)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x4FF550;
        func(this.GetThisPointer(), pTechno);
    }

    public unsafe void AddTracking(Pointer<TechnoClass> pTechno)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x4FF700;
        func(this.GetThisPointer(), pTechno);
    }

    public unsafe double GetWeedStoragePercentage()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, double>)0x4F9750;
        return func(this.GetThisPointer());
    }

    #endregion

    [FieldOffset(0)] public AbstractClass BaseAbstract;
    [FieldOffset(36)] public nint iHouse;
    public readonly Pointer<nint> IHouse => iHouse;
    [FieldOffset(40)] public nint iPublicHouse;
    public readonly Pointer<nint> IPublicHouse => iPublicHouse;
    [FieldOffset(44)] public nint iConnectionPointContainer;
    public readonly Pointer<nint> IConnectionPointContainer => iConnectionPointContainer;
    [FieldOffset(48)] public int ArrayIndex;
    [FieldOffset(52)] public nint type;
    public readonly Pointer<HouseTypeClass> Type => type;
    [FieldOffset(56)] public byte relatedTags;

    public ref DynamicVectorClass<Pointer<TagClass>> RelatedTags =>
        ref Pointer<byte>.AsPointer(ref relatedTags).Convert<DynamicVectorClass<Pointer<TagClass>>>().Ref;

    [FieldOffset(80)] public byte conYards;

    public ref DynamicVectorClass<Pointer<BuildingClass>> ConYards =>
        ref Pointer<byte>.AsPointer(ref conYards).Convert<DynamicVectorClass<Pointer<BuildingClass>>>().Ref;

    [FieldOffset(104)] public byte buildings;

    public ref DynamicVectorClass<Pointer<BuildingClass>> Buildings =>
        ref Pointer<byte>.AsPointer(ref buildings).Convert<DynamicVectorClass<Pointer<BuildingClass>>>().Ref;

    [FieldOffset(128)] public byte unitRepairStations;

    public ref DynamicVectorClass<Pointer<BuildingClass>> UnitRepairStations =>
        ref Pointer<byte>.AsPointer(ref unitRepairStations).Convert<DynamicVectorClass<Pointer<BuildingClass>>>().Ref;

    [FieldOffset(152)] public byte grinders;

    public ref DynamicVectorClass<Pointer<BuildingClass>> Grinders =>
        ref Pointer<byte>.AsPointer(ref grinders).Convert<DynamicVectorClass<Pointer<BuildingClass>>>().Ref;

    [FieldOffset(176)] public byte absorbers;

    public ref DynamicVectorClass<Pointer<BuildingClass>> Absorbers =>
        ref Pointer<byte>.AsPointer(ref absorbers).Convert<DynamicVectorClass<Pointer<BuildingClass>>>().Ref;

    [FieldOffset(200)] public byte bunkers;

    public ref DynamicVectorClass<Pointer<BuildingClass>> Bunkers =>
        ref Pointer<byte>.AsPointer(ref bunkers).Convert<DynamicVectorClass<Pointer<BuildingClass>>>().Ref;

    [FieldOffset(224)] public byte occupiables;

    public ref DynamicVectorClass<Pointer<BuildingClass>> Occupiables =>
        ref Pointer<byte>.AsPointer(ref occupiables).Convert<DynamicVectorClass<Pointer<BuildingClass>>>().Ref;

    [FieldOffset(248)] public byte cloningVats;

    public ref DynamicVectorClass<Pointer<BuildingClass>> CloningVats =>
        ref Pointer<byte>.AsPointer(ref cloningVats).Convert<DynamicVectorClass<Pointer<BuildingClass>>>().Ref;

    [FieldOffset(272)] public byte secretLabs;

    public ref DynamicVectorClass<Pointer<BuildingClass>> SecretLabs =>
        ref Pointer<byte>.AsPointer(ref secretLabs).Convert<DynamicVectorClass<Pointer<BuildingClass>>>().Ref;

    [FieldOffset(296)] public byte psychicDetectionBuildings;

    public ref DynamicVectorClass<Pointer<BuildingClass>> PsychicDetectionBuildings =>
        ref Pointer<byte>.AsPointer(ref psychicDetectionBuildings).Convert<DynamicVectorClass<Pointer<BuildingClass>>>()
            .Ref;

    [FieldOffset(320)] public byte factoryPlants;

    public ref DynamicVectorClass<Pointer<BuildingClass>> FactoryPlants =>
        ref Pointer<byte>.AsPointer(ref factoryPlants).Convert<DynamicVectorClass<Pointer<BuildingClass>>>().Ref;


    [FieldOffset(344)] public int CountResourceGatherers;
    [FieldOffset(348)] public int CountResourceDestinations;
    [FieldOffset(352)] public int CountWarfactories;
    [FieldOffset(356)] public int InfantrySelfHeal;
    [FieldOffset(360)] public int UnitsSelfHeal;
    [FieldOffset(364)] public byte startingUnits;

    public ref DynamicVectorClass<Pointer<StartingTechnoStruct>> StartingUnits =>
        ref Pointer<byte>.AsPointer(ref startingUnits).Convert<DynamicVectorClass<Pointer<StartingTechnoStruct>>>().Ref;

    [FieldOffset(388)] public AIDifficulty AIDifficulty;
    [FieldOffset(392)] public double FirepowerMultiplier;
    [FieldOffset(400)] public double GroundspeedMultiplier;
    [FieldOffset(408)] public double AirspeedMultiplier;
    [FieldOffset(416)] public double ArmorMultiplier;
    [FieldOffset(424)] public double ROFMultiplier;
    [FieldOffset(432)] public double CostMultiplier;
    [FieldOffset(440)] public double BuildTimeMultiplier;
    [FieldOffset(448)] public double RepairDelay;
    [FieldOffset(456)] public double BuildDelay;
    [FieldOffset(464)] public int IQLevel;
    [FieldOffset(468)] public int TechLevel;
    [FieldOffset(472)] public Int32BitSet AltAllies;
    [FieldOffset(476)] public int StartingCredits;
    [FieldOffset(480)] public Edge StartingEdge;
    [FieldOffset(484)] public uint AIState_1E4;
    [FieldOffset(488)] public int SideIndex;
    [FieldOffset(492)] public Bool IsHumanPlayer;
    [FieldOffset(493)] public Bool IsInPlayerControl;
    [FieldOffset(494)] public Bool Production;
    [FieldOffset(495)] public Bool AutocreateAllowed;
    [FieldOffset(496)] public Bool NodeLogic_1F0;
    [FieldOffset(497)] public Bool ShipYardConst_1F1;
    [FieldOffset(498)] public Bool AITriggersActive;
    [FieldOffset(499)] public Bool AutoBaseBuilding;
    [FieldOffset(500)] public Bool DiscoveredByPlayer;
    [FieldOffset(501)] public Bool Defeated;
    [FieldOffset(502)] public Bool IsGameOver;
    [FieldOffset(503)] public Bool IsWinner;
    [FieldOffset(504)] public Bool IsLoser;
    [FieldOffset(505)] public Bool CiviliansEvacuated;
    [FieldOffset(506)] public Bool FirestormActive;
    [FieldOffset(507)] public Bool HasThreatNode;
    [FieldOffset(508)] public Bool RecheckTechTree;
    [FieldOffset(512)] public int IPAddress;
    [FieldOffset(516)] public int TournamentTeamID;
    [FieldOffset(520)] public Bool LostConnection;
    [FieldOffset(524)] public int SelectedPathIndex;
    [FieldOffset(528)] public nint planningPaths;

    public FixedArray<Pointer<WaypointPathClass>> PlanningPaths =>
        new(ref Unsafe.As<nint, Pointer<WaypointPathClass>>(ref planningPaths), 12);

    [FieldOffset(576)] public byte Visionary;
    [FieldOffset(577)] public Bool MapIsClear;
    [FieldOffset(578)] public Bool IsTiberiumShort;
    [FieldOffset(579)] public Bool HasBeenSpied;
    [FieldOffset(580)] public Bool HasBeenThieved;
    [FieldOffset(581)] public Bool Repairing;
    [FieldOffset(582)] public Bool IsBuiltSomething;
    [FieldOffset(583)] public Bool IsResigner;
    [FieldOffset(584)] public Bool IsGiverUpper;
    [FieldOffset(585)] public Bool AllToHunt;
    [FieldOffset(586)] public Bool IsParanoid;
    [FieldOffset(587)] public Bool IsToLook;
    [FieldOffset(588)] public int IQLevel2;
    [FieldOffset(592)] public AiMode AIMode;
    [FieldOffset(596)] public byte supers;

    public ref DynamicVectorClass<Pointer<SuperClass>> Supers =>
        ref Pointer<byte>.AsPointer(ref supers).Convert<DynamicVectorClass<Pointer<SuperClass>>>().Ref;

    [FieldOffset(620)] public int LastBuiltBuildingType;
    [FieldOffset(624)] public int LastBuiltInfantryType;
    [FieldOffset(628)] public int LastBuiltAircraftType;
    [FieldOffset(632)] public int LastBuiltVehicleType;
    [FieldOffset(636)] public int AllowWinBlocks;
    [FieldOffset(640)] public TimerStruct RepairTimer;
    [FieldOffset(652)] public TimerStruct AlertTimer;
    [FieldOffset(664)] public TimerStruct BorrowedTime;
    [FieldOffset(676)] public TimerStruct PowerBlackoutTimer;
    [FieldOffset(688)] public TimerStruct RadarBlackoutTimer;
    [FieldOffset(700)] public Bool Side2TechInfiltrated;
    [FieldOffset(701)] public Bool Side1TechInfiltrated;
    [FieldOffset(702)] public Bool Side0TechInfiltrated;
    [FieldOffset(703)] public Bool BarracksInfiltrated;
    [FieldOffset(704)] public Bool WarFactoryInfiltrated;
    [FieldOffset(708)] public uint InfantryAltOwner;
    [FieldOffset(712)] public uint UnitAltOwner;
    [FieldOffset(716)] public uint AircraftAltOwner;
    [FieldOffset(720)] public uint BuildingAltOwner;
    [FieldOffset(724)] public int AirportDocks;
    [FieldOffset(728)] public int PoweredUnitCenters;
    [FieldOffset(732)] public int CreditsSpent;
    [FieldOffset(736)] public int HarvestedCredits;
    [FieldOffset(740)] public int StolenBuildingsCredits;
    [FieldOffset(744)] public int OwnedUnits;
    [FieldOffset(748)] public int OwnedNavy;
    [FieldOffset(752)] public int OwnedBuildings;
    [FieldOffset(756)] public int OwnedInfantry;
    [FieldOffset(760)] public int OwnedAircraft;
    [FieldOffset(764)] public OwnedTiberiumStruct OwnedTiberium;
    [FieldOffset(780)] public int Balance;
    [FieldOffset(784)] public int TotalStorage;
    [FieldOffset(788)] public OwnedTiberiumStruct OwnedWeed;
    [FieldOffset(804)] public uint unknown_324;
    [FieldOffset(808)] public UnitTrackerClass BuiltAircraftTypes;
    [FieldOffset(2864)] public UnitTrackerClass BuiltInfantryTypes;
    [FieldOffset(4920)] public UnitTrackerClass BuiltUnitTypes;
    [FieldOffset(6976)] public UnitTrackerClass BuiltBuildingTypes;
    [FieldOffset(9032)] public UnitTrackerClass KilledAircraftTypes;
    [FieldOffset(11088)] public UnitTrackerClass KilledInfantryTypes;
    [FieldOffset(13144)] public UnitTrackerClass KilledUnitTypes;
    [FieldOffset(15200)] public UnitTrackerClass KilledBuildingTypes;
    [FieldOffset(17256)] public UnitTrackerClass CapturedBuildings;
    [FieldOffset(19312)] public UnitTrackerClass CollectedCrates;
    [FieldOffset(21368)] public int NumAirpads;
    [FieldOffset(21372)] public int NumBarracks;
    [FieldOffset(21376)] public int NumWarFactories;
    [FieldOffset(21380)] public int NumConYards;
    [FieldOffset(21384)] public int NumShipyards;
    [FieldOffset(21388)] public int NumOrePurifiers;
    [FieldOffset(21392)] public float CostInfantryMult;
    [FieldOffset(21396)] public float CostUnitsMult;
    [FieldOffset(21400)] public float CostAircraftMult;
    [FieldOffset(21404)] public float CostBuildingsMult;
    [FieldOffset(21408)] public float CostDefensesMult;
    [FieldOffset(21412)] public int PowerOutput;
    [FieldOffset(21416)] public int PowerDrain;
    [FieldOffset(21420)] public nint primary_ForAircraft;
    public readonly Pointer<FactoryClass> PrimaryForAircraft => primary_ForAircraft;
    [FieldOffset(21424)] public nint primary_ForInfantry;
    public readonly Pointer<FactoryClass> PrimaryForInfantry => primary_ForInfantry;
    [FieldOffset(21428)] public nint primary_ForVehicles;
    public readonly Pointer<FactoryClass> PrimaryForVehicles => primary_ForVehicles;
    [FieldOffset(21432)] public nint primary_ForShips;
    public readonly Pointer<FactoryClass> PrimaryForShips => primary_ForShips;
    [FieldOffset(21436)] public nint primary_ForBuildings;
    public readonly Pointer<FactoryClass> PrimaryForBuildings => primary_ForBuildings;
    [FieldOffset(21440)] public nint primary_Unused1;
    public readonly Pointer<FactoryClass> PrimaryUnused1 => primary_Unused1;
    [FieldOffset(21444)] public nint primary_Unused2;
    public readonly Pointer<FactoryClass> PrimaryUnused2 => primary_Unused2;
    [FieldOffset(21448)] public nint primary_Unused3;
    public readonly Pointer<FactoryClass> PrimaryUnused3 => primary_Unused3;
    [FieldOffset(21452)] public nint primary_ForDefenses;
    public readonly Pointer<FactoryClass> PrimaryForDefenses => primary_ForDefenses;
    [FieldOffset(21456)] public byte AircraftType_53D0;
    [FieldOffset(21457)] public byte InfantryType_53D1;
    [FieldOffset(21458)] public byte VehicleType_53D2;
    [FieldOffset(21459)] public byte ShipType_53D3;
    [FieldOffset(21460)] public byte BuildingType_53D4;
    [FieldOffset(21461)] public byte unknown_53D5;
    [FieldOffset(21462)] public byte unknown_53D6;
    [FieldOffset(21463)] public byte unknown_53D7;
    [FieldOffset(21464)] public byte DefenseType_53D8;
    [FieldOffset(21465)] public byte unknown_53D9;
    [FieldOffset(21466)] public byte unknown_53DA;
    [FieldOffset(21467)] public byte unknown_53DB;
    [FieldOffset(21468)] public nint ourFlagCarrier;
    public readonly Pointer<UnitClass> OurFlagCarrier => ourFlagCarrier;
    [FieldOffset(21472)] public CellStruct OurFlagCoords;
    [FieldOffset(21476)] public byte killedUnitsOfHouses;
    public FixedArray<int> KilledUnitsOfHouses => new(ref Unsafe.As<byte, int>(ref killedUnitsOfHouses), 20);
    [FieldOffset(21556)] public int TotalKilledUnits;
    [FieldOffset(21560)] public byte killedBuildingsOfHouses;
    public FixedArray<int> KilledBuildingsOfHouses => new(ref Unsafe.As<byte, int>(ref killedBuildingsOfHouses), 20);
    [FieldOffset(21640)] public int TotalKilledBuildings;
    [FieldOffset(21644)] public int WhoLastHurtMe;
    [FieldOffset(21648)] public CellStruct BaseSpawnCell;
    [FieldOffset(21652)] public CellStruct BaseCenter;
    [FieldOffset(21656)] public int Radius;
    [FieldOffset(21660)] public ZoneInfoStruct ZoneInfos;
    [FieldOffset(21720)] public int LATime;
    [FieldOffset(21724)] public int LAEnemy;
    [FieldOffset(21728)] public int ToCapture;
    [FieldOffset(21732)] public Int32BitSet RadarVisibleTo;
    [FieldOffset(21736)] public int SiloMoney;
    [FieldOffset(21740)] public TargetType PreferredTargetType;
    [FieldOffset(21744)] public CellStruct PreferredTargetCell;
    [FieldOffset(21748)] public CellStruct PreferredDefensiveCell;
    [FieldOffset(21752)] public CellStruct PreferredDefensiveCell2;
    [FieldOffset(21756)] public int PreferredDefensiveCellStartTime;
    [FieldOffset(21760)] public CounterClass OwnedBuildingTypes;
    [FieldOffset(21780)] public CounterClass OwnedUnitTypes;
    [FieldOffset(21800)] public CounterClass OwnedInfantryTypes;
    [FieldOffset(21820)] public CounterClass OwnedAircraftTypes;
    [FieldOffset(21840)] public CounterClass ActiveBuildingTypes;
    [FieldOffset(21860)] public CounterClass ActiveUnitTypes;
    [FieldOffset(21880)] public CounterClass ActiveInfantryTypes;
    [FieldOffset(21900)] public CounterClass ActiveAircraftTypes;
    [FieldOffset(21920)] public CounterClass FactoryProducedBuildingTypes;
    [FieldOffset(21940)] public CounterClass FactoryProducedUnitTypes;
    [FieldOffset(21960)] public CounterClass FactoryProducedInfantryTypes;
    [FieldOffset(21980)] public CounterClass FactoryProducedAircraftTypes;
    [FieldOffset(22000)] public TimerStruct AttackTimer;
    [FieldOffset(22012)] public int InitialAttackDelay;
    [FieldOffset(22016)] public int EnemyHouseIndex;
    [FieldOffset(22020)] public byte angerNodes;

    public ref DynamicVectorClass<AngerStruct> AngerNodes =>
        ref Pointer<byte>.AsPointer(ref angerNodes).Convert<DynamicVectorClass<AngerStruct>>().Ref;

    [FieldOffset(22044)] public byte scoutNodes;

    public ref DynamicVectorClass<ScoutStruct> ScoutNodes =>
        ref Pointer<byte>.AsPointer(ref scoutNodes).Convert<DynamicVectorClass<ScoutStruct>>().Ref;

    [FieldOffset(22068)] public TimerStruct AITimer;
    [FieldOffset(22080)] public TimerStruct Unknown_Timer_5640;
    [FieldOffset(22092)] public int ProducingBuildingTypeIndex;
    [FieldOffset(22096)] public int ProducingUnitTypeIndex;
    [FieldOffset(22100)] public int ProducingInfantryTypeIndex;
    [FieldOffset(22104)] public int ProducingAircraftTypeIndex;
    [FieldOffset(22108)] public int RatioAITriggerTeam;
    [FieldOffset(22112)] public int RatioTeamAircraft;
    [FieldOffset(22116)] public int RatioTeamInfantry;
    [FieldOffset(22120)] public int RatioTeamBuildings;
    [FieldOffset(22124)] public int BaseDefenseTeamCount;
    [FieldOffset(22128)] public DropshipStruct DropshipData;
    [FieldOffset(22260)] public int CurrentDropshipIndex;
    [FieldOffset(22264)] public byte HasCloakingRanges;
    [FieldOffset(22265)] public ColorStruct Color;
    [FieldOffset(22268)] public ColorStruct LaserColor;
    [FieldOffset(22272)] public BaseClass Base;
    [FieldOffset(22392)] public Bool RecheckPower;
    [FieldOffset(22393)] public Bool RecheckRadar;
    [FieldOffset(22394)] public Bool SpySatActive;
    [FieldOffset(22395)] public Bool IsBeingDrained;
    [FieldOffset(22396)] public Edge Edge;
    [FieldOffset(22400)] public CellStruct EMPTarget;
    [FieldOffset(22404)] public CellStruct NukeTarget;
    [FieldOffset(22408)] public Int32BitSet Allies;
    [FieldOffset(22412)] public TimerStruct DamageDelayTimer;
    [FieldOffset(22424)] public TimerStruct TeamDelayTimer;
    [FieldOffset(22436)] public TimerStruct TriggerDelayTimer;
    [FieldOffset(22448)] public TimerStruct SpeakAttackDelayTimer;
    [FieldOffset(22460)] public TimerStruct SpeakPowerDelayTimer;
    [FieldOffset(22472)] public TimerStruct SpeakMoneyDelayTimer;
    [FieldOffset(22484)] public TimerStruct SpeakMaxedDelayTimer;
    [FieldOffset(22496)] public nint aIGeneral;
    public readonly Pointer<IAiHouse> AIGeneral => aIGeneral;
    [FieldOffset(22500)] public uint threatPosedEstimates;
    public FixedArray<uint> ThreatPosedEstimates => new(ref threatPosedEstimates, 130 * 130);
    [FieldOffset(90100)] public byte plainName;
    public FixedArray<char> PlainName => new(ref Unsafe.As<byte, char>(ref plainName), 21);
    [FieldOffset(90121)] public byte uINameString;
    public FixedArray<char> UINameString => new(ref Unsafe.As<byte, char>(ref uINameString), 33);
    [FieldOffset(90154)] public char uIName;
    public UniStringPointer UIName => Pointer<char>.AsPointer(ref uIName);
    [FieldOffset(90196)] public int ColorSchemeIndex;
    [FieldOffset(90200)] public CellStruct StartingCell;
    [FieldOffset(90200)] public int StartingPoint;
    [FieldOffset(90204)] public Int32BitSet StartingAllies;
    [FieldOffset(90208)] public uint unknown_16060;
    [FieldOffset(90212)] public byte waypointPath;

    public ref DynamicVectorClass<Pointer<IConnectionPoint>> WaypointPath => ref Pointer<byte>
        .AsPointer(ref waypointPath).Convert<DynamicVectorClass<Pointer<IConnectionPoint>>>().Ref;

    [FieldOffset(90236)] public uint unknown_1607C;
    [FieldOffset(90240)] public uint unknown_16080;
    [FieldOffset(90244)] public uint unknown_16084;
    [FieldOffset(90248)] public double unused_16088;
    [FieldOffset(90256)] public double unused_16090;
    [FieldOffset(90264)] public uint padding_16098;
    [FieldOffset(90268)] public float PredictionEnemyArmor;
    [FieldOffset(90272)] public float PredictionEnemyAir;
    [FieldOffset(90276)] public float PredictionEnemyInfantry;
    [FieldOffset(90280)] public int TotalOwnedInfantryCost;
    [FieldOffset(90284)] public int TotalOwnedVehicleCost;
    [FieldOffset(90288)] public int TotalOwnedAircraftCost;
    [FieldOffset(90292)] public uint unknown_power_160B4;


    public double PowerPercent => PowerOutput != 0 ? PowerDrain / (double)PowerOutput : 1;
    public bool NoPower => PowerPercent >= 1;


    public Pointer<TechnoClass> GetCurrentTechno()
    {
        return PrimaryForBuildings.Ref.Object;
    }
}

[StructLayout(LayoutKind.Explicit)]
public struct StartingTechnoStruct
{
    [FieldOffset(0)] public nint unit;
    public readonly Pointer<TechnoTypeClass> Unit => unit;
    [FieldOffset(4)] public CellStruct Cell;

}

[StructLayout(LayoutKind.Explicit)]
public struct UnitTrackerClass
{
    public unsafe void IncrementUnitCount(int nUnit)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, void>)0x749020;
        func(this.GetThisPointer(), nUnit);
    }
    public unsafe void DecrementUnitCount(int nUnit)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, void>)0x749040;
        func(this.GetThisPointer(), nUnit);
    }
    public unsafe void PopulateUnitCount(int nCount)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, void>)0x749060;
        func(this.GetThisPointer(), nCount);
    }

    
    [FieldOffset(0)] public byte unitTotals;
    public FixedArray<int> UnitTotals => new(ref Unsafe.As<byte, int>(ref unitTotals), 512);
    [FieldOffset(2048)] public int UnitCount;
    [FieldOffset(2052)] public Bool InNetworkFormat;

}

[StructLayout(LayoutKind.Sequential)]
public struct ZoneInfoStruct
{
    public int Aircraft;
    public int Armor;
    public int Infantry;
}

[StructLayout(LayoutKind.Explicit)]
public struct AngerStruct
{
    [FieldOffset(0)] public nint house;
    public readonly Pointer<HouseClass> House => house;
    [FieldOffset(4)] public int AngerLevel;
}

[StructLayout(LayoutKind.Explicit)]
public struct ScoutStruct
{
    [FieldOffset(0)] public nint house;
    public readonly Pointer<HouseClass> House => house;
    [FieldOffset(4)] public Bool IsPreferred;
}

[StructLayout(LayoutKind.Explicit)]
public struct DropshipStruct
{
    [FieldOffset(0)] public TimerStruct Timer;
    [FieldOffset(12)] public byte unknown_C;
    [FieldOffset(16)] public int Count;
    [FieldOffset(20)] public nint types;
    public FixedArray<Pointer<TechnoTypeClass>> Types => new(ref Unsafe.As<nint, Pointer<TechnoTypeClass>>(ref types), 5);
    [FieldOffset(40)] public int TotalCost;

}

[StructLayout(LayoutKind.Explicit)]
public struct BaseClass
{
    [FieldOffset(4)] public byte baseNodes;
    public ref DynamicVectorClass<BaseNodeClass> BaseNodes => ref Pointer<byte>.AsPointer(ref baseNodes).Convert<DynamicVectorClass<BaseNodeClass>>().Ref;
    [FieldOffset(28)] public int PercentBuilt;
    [FieldOffset(32)] public byte cells_24;
    public ref DynamicVectorClass<BaseNodeClass> Cells_24 => ref Pointer<byte>.AsPointer(ref cells_24).Convert<DynamicVectorClass<BaseNodeClass>>().Ref;
    [FieldOffset(56)] public byte cells_38;
    public ref DynamicVectorClass<BaseNodeClass> Cells_38 => ref Pointer<byte>.AsPointer(ref cells_38).Convert<DynamicVectorClass<BaseNodeClass>>().Ref;
    [FieldOffset(80)] public CellStruct Center;
    [FieldOffset(116)] public nint owner;
}

[StructLayout(LayoutKind.Explicit, Size = 16)]
public struct BaseNodeClass
{
    [FieldOffset(0)] public int BuildingTypeIndex;
    [FieldOffset(4)] public CellStruct MapCoords;
    [FieldOffset(8)] public Bool Placed;
    [FieldOffset(12)] public int Attempts;
}