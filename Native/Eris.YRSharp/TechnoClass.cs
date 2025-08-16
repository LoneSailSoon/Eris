using System.Runtime.CompilerServices;
using Eris.YRSharp.GeneralDefinitions;
using Eris.YRSharp.Vector;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit, Size = 1312)]
public struct TechnoClass : IYRObject<TechnoClass, TechnoTypeClass>
{
    static Pointer<TechnoTypeClass> IYRObject<TechnoClass, TechnoTypeClass>.Type(Pointer<TechnoClass> pThis) => pThis.Ref.Base.GetTechnoType();
    
    public Pointer<TechnoTypeClass> Type => Base.GetTechnoType();
    
    public const nint ArrayPointer = 0xA8EC78;

    public static ref DynamicVectorClass<Pointer<TechnoClass>> Array =>
        ref DynamicVectorClass<Pointer<TechnoClass>>.GetDynamicVector(ArrayPointer);
    
    public unsafe bool IsUnitFactory()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(161);
        return func(this.GetThisPointer());
    }

    public unsafe bool IsCloakable()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(162);
        return func(this.GetThisPointer());
    }

    public unsafe bool CanScatter()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(163);
        return func(this.GetThisPointer());
    }

    public unsafe bool BelongsToATeam()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(164);
        return func(this.GetThisPointer());
    }

    public unsafe bool ShouldSelfHealOneStep()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(165);
        return func(this.GetThisPointer());
    }

    public unsafe bool IsVoxel()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(166);
        return func(this.GetThisPointer());
    }

    public unsafe bool vt_entry_29C()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(167);
        return func(this.GetThisPointer());
    }

    public unsafe bool IsReadyToCloak()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(168);
        return func(this.GetThisPointer());
    }

    public unsafe bool ShouldNotBeCloaked()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(169);
        return func(this.GetThisPointer());
    }

    public unsafe Pointer<DirStruct> GetTurretFacing(Pointer<DirStruct> pBuffer)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint>)this.GetVirtualFunctionPointer(170);
        return func(this.GetThisPointer(), pBuffer);
    }

    public unsafe bool IsArmed()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(171);
        return func(this.GetThisPointer());
    }

    public unsafe bool vt_entry_2B0()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(172);
        return func(this.GetThisPointer());
    }

    public unsafe double GetStoragePercentage()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, double>)this.GetVirtualFunctionPointer(173);
        return func(this.GetThisPointer());
    }

    public unsafe int GetPipFillLevel()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)this.GetVirtualFunctionPointer(174);
        return func(this.GetThisPointer());
    }

    public unsafe int GetRefund()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)this.GetVirtualFunctionPointer(175);
        return func(this.GetThisPointer());
    }

    public unsafe int GetThreatValue()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)this.GetVirtualFunctionPointer(176);
        return func(this.GetThisPointer());
    }

    public unsafe bool IsInSameZoneAs(Pointer<AbstractClass> pTarget)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool>)this.GetVirtualFunctionPointer(177);
        return func(this.GetThisPointer(), pTarget);
    }

    public unsafe uint vt_entry_2C8(uint dwUnk, uint dwUnk2)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint, uint, uint>)this.GetVirtualFunctionPointer(178);
        return func(this.GetThisPointer(), dwUnk, dwUnk2);
    }

    public unsafe bool IsInSameZoneAsCoords(Pointer<CoordStruct> coord)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool>)this.GetVirtualFunctionPointer(179);
        return func(this.GetThisPointer(), coord);
    }

    public unsafe int GetCrewCount()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)this.GetVirtualFunctionPointer(180);
        return func(this.GetThisPointer());
    }

    public unsafe int GetAntiAirValue()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)this.GetVirtualFunctionPointer(181);
        return func(this.GetThisPointer());
    }

    public unsafe int GetAntiArmorValue()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)this.GetVirtualFunctionPointer(182);
        return func(this.GetThisPointer());
    }

    public unsafe int GetAntiInfantryValue()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)this.GetVirtualFunctionPointer(183);
        return func(this.GetThisPointer());
    }

    public unsafe void GotHijacked()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(184);
        func(this.GetThisPointer());
    }

    public unsafe int SelectWeapon(Pointer<AbstractClass> pTarget)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, int>)this.GetVirtualFunctionPointer(185);
        return func(this.GetThisPointer(), pTarget);
    }

    public unsafe int SelectNavalTargeting(Pointer<AbstractClass> pTarget)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, int>)this.GetVirtualFunctionPointer(186);
        return func(this.GetThisPointer(), pTarget);
    }

    public unsafe int GetZAdjustment()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)this.GetVirtualFunctionPointer(187);
        return func(this.GetThisPointer());
    }

    public unsafe ZGradient GetZGradient()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, ZGradient>)this.GetVirtualFunctionPointer(188);
        return func(this.GetThisPointer());
    }

    public unsafe CellStruct GetLastFlightMapCoords()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, CellStruct>)this.GetVirtualFunctionPointer(189);
        return func(this.GetThisPointer());
    }

    public unsafe void SetLastFlightMapCoords(CellStruct coord)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, CellStruct, void>)this.GetVirtualFunctionPointer(190);
        func(this.GetThisPointer(), coord);
    }

    public unsafe Pointer<CellStruct> vt_entry_2FC(Pointer<CellStruct> Buffer, uint dwUnk2, uint dwUnk3)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, uint, uint, nint>)this.GetVirtualFunctionPointer(191);
        return func(this.GetThisPointer(), Buffer, dwUnk2, dwUnk3);
    }

    public unsafe Pointer<CoordStruct> vt_entry_300(Pointer<CoordStruct> Buffer, uint dwUnk2)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, uint, nint>)this.GetVirtualFunctionPointer(192);
        return func(this.GetThisPointer(), Buffer, dwUnk2);
    }

    public unsafe uint vt_entry_304(uint dwUnk, uint dwUnk2)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint, uint, uint>)this.GetVirtualFunctionPointer(193);
        return func(this.GetThisPointer(), dwUnk, dwUnk2);
    }

    public unsafe Pointer<DirStruct> GetRealFacing(Pointer<DirStruct> pBuffer)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint>)this.GetVirtualFunctionPointer(194);
        return func(this.GetThisPointer(), pBuffer);
    }

    public unsafe Pointer<InfantryTypeClass> GetCrew()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint>)this.GetVirtualFunctionPointer(195);
        return func(this.GetThisPointer());
    }

    public unsafe bool vt_entry_310()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(196);
        return func(this.GetThisPointer());
    }

    public unsafe bool CanDeploySlashUnload()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(197);
        return func(this.GetThisPointer());
    }

    public unsafe int GetROF(int nWeapon)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, int>)this.GetVirtualFunctionPointer(198);
        return func(this.GetThisPointer(), nWeapon);
    }

    public unsafe int GetGuardRange(int dwUnk)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, int>)this.GetVirtualFunctionPointer(199);
        return func(this.GetThisPointer(), dwUnk);
    }

    public unsafe bool vt_entry_320()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(200);
        return func(this.GetThisPointer());
    }

    public unsafe bool IsRadarVisible(Pointer<int> pOutDetection)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool>)this.GetVirtualFunctionPointer(201);
        return func(this.GetThisPointer(), pOutDetection);
    }

    public unsafe bool IsSensorVisibleToPlayer()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(202);
        return func(this.GetThisPointer());
    }

    public unsafe bool IsSensorVisibleToHouse(Pointer<HouseClass> House)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool>)this.GetVirtualFunctionPointer(203);
        return func(this.GetThisPointer(), House);
    }

    public unsafe bool IsEngineer()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(204);
        return func(this.GetThisPointer());
    }

    public unsafe void ProceedToNextPlanningWaypoint()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(205);
        func(this.GetThisPointer());
    }

    public unsafe uint ScanForTiberium(uint dwUnk, uint dwUnk2, uint dwUnk3)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint, uint, uint, uint>)this.GetVirtualFunctionPointer(206);
        return func(this.GetThisPointer(), dwUnk, dwUnk2, dwUnk3);
    }

    public unsafe bool EnterGrinder()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(207);
        return func(this.GetThisPointer());
    }

    public unsafe bool EnterBioReactor()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(208);
        return func(this.GetThisPointer());
    }

    public unsafe bool EnterTankBunker()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(209);
        return func(this.GetThisPointer());
    }

    public unsafe bool EnterBattleBunker()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(210);
        return func(this.GetThisPointer());
    }

    public unsafe bool GarrisonStructure()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(211);
        return func(this.GetThisPointer());
    }

    public unsafe bool IsPowerOnline()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(212);
        return func(this.GetThisPointer());
    }

    public unsafe void QueueVoice(int idxVoc)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, void>)this.GetVirtualFunctionPointer(213);
        func(this.GetThisPointer(), idxVoc);
    }

    public unsafe int VoiceEnter()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)this.GetVirtualFunctionPointer(214);
        return func(this.GetThisPointer());
    }

    public unsafe int VoiceHarvest()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)this.GetVirtualFunctionPointer(215);
        return func(this.GetThisPointer());
    }

    public unsafe int VoiceSelect()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)this.GetVirtualFunctionPointer(216);
        return func(this.GetThisPointer());
    }

    public unsafe int VoiceCapture()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)this.GetVirtualFunctionPointer(217);
        return func(this.GetThisPointer());
    }

    public unsafe int VoiceMove()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)this.GetVirtualFunctionPointer(218);
        return func(this.GetThisPointer());
    }

    public unsafe int VoiceDeploy()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)this.GetVirtualFunctionPointer(219);
        return func(this.GetThisPointer());
    }

    public unsafe int VoiceAttack(Pointer<ObjectClass> pTarget)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, int>)this.GetVirtualFunctionPointer(220);
        return func(this.GetThisPointer(), pTarget);
    }

    public unsafe bool ClickedEvent(EventType @event)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, EventType, bool>)this.GetVirtualFunctionPointer(221);
        return func(this.GetThisPointer(), @event);
    }

    public unsafe bool ClickedMission(Mission Mission, Pointer<ObjectClass> pTarget, Pointer<CellClass> TargetCell,
        Pointer<CellClass> NearestTargetCellICanEnter)
    {
        var func =
            (delegate* unmanaged[Thiscall]<nint, Mission, nint, nint, nint, bool>)this.GetVirtualFunctionPointer(222);
        return func(this.GetThisPointer(), Mission, pTarget, TargetCell, NearestTargetCellICanEnter);
    }

    public unsafe bool IsUnderEMP()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(223);
        return func(this.GetThisPointer());
    }

    public unsafe bool IsParalyzed()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(224);
        return func(this.GetThisPointer());
    }

    public unsafe bool CanCheer()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(225);
        return func(this.GetThisPointer());
    }

    public unsafe void Cheer(bool Force)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool, void>)this.GetVirtualFunctionPointer(226);
        func(this.GetThisPointer(), Force);
    }

    public unsafe int GetDefaultSpeed()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)this.GetVirtualFunctionPointer(227);
        return func(this.GetThisPointer());
    }

    public unsafe void DecreaseAmmo()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(228);
        func(this.GetThisPointer());
    }

    public unsafe void AddPassenger(Pointer<FootClass> pPassenger)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)this.GetVirtualFunctionPointer(229);
        func(this.GetThisPointer(), pPassenger);
    }

    public unsafe bool CanDisguiseAs(Pointer<AbstractClass> pTarget)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool>)this.GetVirtualFunctionPointer(230);
        return func(this.GetThisPointer(), pTarget);
    }

    public unsafe bool TargetAndEstimateDamage(uint dwUnk, uint dwUnk2)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint, uint, bool>)this.GetVirtualFunctionPointer(231);
        return func(this.GetThisPointer(), dwUnk, dwUnk2);
    }

    public unsafe void Stun()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(232);
        func(this.GetThisPointer());
    }

    public unsafe bool TriggersCellInset(Pointer<AbstractClass> pTarget)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool>)this.GetVirtualFunctionPointer(233);
        return func(this.GetThisPointer(), pTarget);
    }

    public unsafe bool IsCloseEnough(Pointer<AbstractClass> pTarget, int idxWeapon)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, int, bool>)this.GetVirtualFunctionPointer(234);
        return func(this.GetThisPointer(), pTarget, idxWeapon);
    }

    public unsafe bool IsCloseEnoughToAttack(Pointer<AbstractClass> pTarget)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool>)this.GetVirtualFunctionPointer(235);
        return func(this.GetThisPointer(), pTarget);
    }

    public unsafe bool IsCloseEnoughToAttackCoords(Pointer<CoordStruct> Coords)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool>)this.GetVirtualFunctionPointer(236);
        return func(this.GetThisPointer(), Coords);
    }

    public unsafe uint vt_entry_3B4(uint dwUnk)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint, uint>)this.GetVirtualFunctionPointer(237);
        return func(this.GetThisPointer(), dwUnk);
    }

    public unsafe void Destroyed(Pointer<ObjectClass> Killer)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)this.GetVirtualFunctionPointer(238);
        func(this.GetThisPointer(), Killer);
    }

    public unsafe FireError GetFireErrorWithoutRange(Pointer<AbstractClass> pTarget, int nWeaponIndex)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, int, FireError>)this.GetVirtualFunctionPointer(239);
        return func(this.GetThisPointer(), pTarget, nWeaponIndex);
    }

    public unsafe FireError GetFireError(Pointer<AbstractClass> pTarget, int nWeaponIndex, bool ignoreRange)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, int, bool, FireError>)this.GetVirtualFunctionPointer(240);
        return func(this.GetThisPointer(), pTarget, nWeaponIndex, ignoreRange);
    }

    public unsafe Pointer<CellClass> SelectAutoTarget(TargetFlags TargetFlags, int CurrentThreat,
        bool OnlyTargetHouseEnemy)
    {
        var func =
            (delegate* unmanaged[Thiscall]<nint, TargetFlags, int, bool, nint>)this.GetVirtualFunctionPointer(241);
        return func(this.GetThisPointer(), TargetFlags, CurrentThreat, OnlyTargetHouseEnemy);
    }

    public unsafe void SetTarget(Pointer<AbstractClass> pTarget)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)this.GetVirtualFunctionPointer(242);
        func(this.GetThisPointer(), pTarget);
    }

    public unsafe Pointer<BulletClass> Fire(Pointer<AbstractClass> pTarget, int nWeaponIndex)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, int, nint>)this.GetVirtualFunctionPointer(243);
        return func(this.GetThisPointer(), pTarget, nWeaponIndex);
    }

    public unsafe void Guard()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(244);
        func(this.GetThisPointer());
    }

    public unsafe bool SetOwningHouse(Pointer<HouseClass> pHouse, bool announce = true)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool, bool>)this.GetVirtualFunctionPointer(245);
        return func(this.GetThisPointer(), pHouse, announce);
    }

    public unsafe void vt_entry_3D8(uint dwUnk, uint dwUnk2, uint dwUnk3)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint, uint, uint, void>)this.GetVirtualFunctionPointer(246);
        func(this.GetThisPointer(), dwUnk, dwUnk2, dwUnk3);
    }

    public unsafe bool Crash(Pointer<ObjectClass> Killer)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool>)this.GetVirtualFunctionPointer(247);
        return func(this.GetThisPointer(), Killer);
    }

    public unsafe bool IsAreaFire()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(248);
        return func(this.GetThisPointer());
    }

    public unsafe int IsNotSprayAttack()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)this.GetVirtualFunctionPointer(249);
        return func(this.GetThisPointer());
    }

    public unsafe int vt_entry_3E8()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)this.GetVirtualFunctionPointer(250);
        return func(this.GetThisPointer());
    }

    public unsafe int IsNotSprayAttack2()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)this.GetVirtualFunctionPointer(251);
        return func(this.GetThisPointer());
    }

    public unsafe Pointer<WeaponStruct> GetDeployWeapon()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint>)this.GetVirtualFunctionPointer(252);
        return func(this.GetThisPointer());
    }

    public unsafe Pointer<WeaponStruct> GetTurretWeapon()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint>)this.GetVirtualFunctionPointer(253);
        return func(this.GetThisPointer());
    }

    public unsafe Pointer<WeaponStruct> GetWeapon(int nWeaponIndex)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, nint>)this.GetVirtualFunctionPointer(254);
        return func(this.GetThisPointer(), nWeaponIndex);
    }

    public unsafe bool HasTurret()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(255);
        return func(this.GetThisPointer());
    }

    public unsafe bool CanOccupyFire()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(256);
        return func(this.GetThisPointer());
    }

    public unsafe int GetOccupyRangeBonus()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)this.GetVirtualFunctionPointer(257);
        return func(this.GetThisPointer());
    }

    public unsafe int GetOccupantCount()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)this.GetVirtualFunctionPointer(258);
        return func(this.GetThisPointer());
    }

    public unsafe void OnFinishRepair()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(259);
        func(this.GetThisPointer());
    }

    public unsafe void UpdateCloak(bool bUnk = true)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool, void>)this.GetVirtualFunctionPointer(260);
        func(this.GetThisPointer(), bUnk);
    }

    public unsafe void CreateGap()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(261);
        func(this.GetThisPointer());
    }

    public unsafe void DestroyGap()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(262);
        func(this.GetThisPointer());
    }

    public unsafe void vt_entry_41C()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(263);
        func(this.GetThisPointer());
    }

    public unsafe void Sensed()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(264);
        func(this.GetThisPointer());
    }

    public unsafe void Reload()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(265);
        func(this.GetThisPointer());
    }

    public unsafe void vt_entry_428()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(266);
        func(this.GetThisPointer());
    }

    public unsafe Pointer<CoordStruct> GetAttackCoordinates(Pointer<CoordStruct> pCrd)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint>)this.GetVirtualFunctionPointer(267);
        return func(this.GetThisPointer(), pCrd);
    }

    public unsafe bool IsNotWarpingIn()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(268);
        return func(this.GetThisPointer());
    }

    public unsafe bool vt_entry_434(uint dwUnk)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint, bool>)this.GetVirtualFunctionPointer(269);
        return func(this.GetThisPointer(), dwUnk);
    }

    public unsafe void DrawActionLines(bool Force, uint dwUnk2)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool, uint, void>)this.GetVirtualFunctionPointer(270);
        func(this.GetThisPointer(), Force, dwUnk2);
    }

    public unsafe uint GetDisguiseFlags(uint existingFlags)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint, uint>)this.GetVirtualFunctionPointer(271);
        return func(this.GetThisPointer(), existingFlags);
    }

    public unsafe bool IsClearlyVisibleTo(Pointer<HouseClass> House)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool>)this.GetVirtualFunctionPointer(272);
        return func(this.GetThisPointer(), House);
    }
    
    
    public unsafe void vt_entry_448(uint dwUnk, uint dwUnk2)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint, uint, void>)this.GetVirtualFunctionPointer(274);
        func(this.GetThisPointer(), dwUnk, dwUnk2);
    }

    public unsafe void DrawHealthBar(Pointer<Point2D> pLocation, Pointer<RectangleStruct> pBounds, bool bUnk3)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, bool, void>)this.GetVirtualFunctionPointer(275);
        func(this.GetThisPointer(), pLocation, pBounds, bUnk3);
    }

    public unsafe void DrawPipScalePips(Pointer<Point2D> pLocation, Pointer<Point2D> pOriginalLocation,
        Pointer<RectangleStruct> pBounds)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, nint, void>)this.GetVirtualFunctionPointer(276);
        func(this.GetThisPointer(), pLocation, pOriginalLocation, pBounds);
    }

    public unsafe void DrawVeterancyPips(Pointer<Point2D> pLocation, Pointer<RectangleStruct> pBounds)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, void>)this.GetVirtualFunctionPointer(277);
        func(this.GetThisPointer(), pLocation, pBounds);
    }

    public unsafe void DrawExtraInfo(Pointer<Point2D> location, Pointer<Point2D> originalLocation,
        Pointer<RectangleStruct> bounds)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, nint, void>)this.GetVirtualFunctionPointer(278);
        func(this.GetThisPointer(), location, originalLocation, bounds);
    }

    public unsafe void Uncloak(bool bPlaySound)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool, void>)this.GetVirtualFunctionPointer(279);
        func(this.GetThisPointer(), bPlaySound);
    }

    public unsafe void Cloak(bool bPlaySound)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool, void>)this.GetVirtualFunctionPointer(280);
        func(this.GetThisPointer(), bPlaySound);
    }

    public unsafe uint vt_entry_464(uint dwUnk)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint, uint>)this.GetVirtualFunctionPointer(281);
        return func(this.GetThisPointer(), dwUnk);
    }

    public unsafe void UpdateRefinerySmokeSystems()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(282);
        func(this.GetThisPointer());
    }

    public unsafe uint DisguiseAs(Pointer<AbstractClass> pTarget)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, uint>)this.GetVirtualFunctionPointer(283);
        return func(this.GetThisPointer(), pTarget);
    }

    public unsafe void ClearDisguise()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(284);
        func(this.GetThisPointer());
    }

    public unsafe bool IsItTimeForIdleActionYet()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(285);
        return func(this.GetThisPointer());
    }

    public unsafe bool UpdateIdleAction()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(286);
        return func(this.GetThisPointer());
    }

    public unsafe void vt_entry_47C(uint dwUnk)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint, void>)this.GetVirtualFunctionPointer(287);
        func(this.GetThisPointer(), dwUnk);
    }

    public unsafe void SetDestination(Pointer<AbstractClass> pDest, bool bUnk)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool, void>)this.GetVirtualFunctionPointer(288);
        func(this.GetThisPointer(), pDest, bUnk);
    }

    public unsafe bool EnterIdleMode(bool initial, bool unused)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool, bool, bool>)this.GetVirtualFunctionPointer(289);
        return func(this.GetThisPointer(), initial, unused);
    }

    public unsafe void UpdateSight(uint dwUnk, uint dwUnk2, uint dwUnk3, uint dwUnk4, uint dwUnk5)
    {
        var func =
            (delegate* unmanaged[Thiscall]<nint, uint, uint, uint, uint, uint, void>)this
                .GetVirtualFunctionPointer(290);
        func(this.GetThisPointer(), dwUnk, dwUnk2, dwUnk3, dwUnk4, dwUnk5);
    }

    public unsafe void vt_entry_48C(uint dwUnk, uint dwUnk2, uint dwUnk3, uint dwUnk4)
    {
        var func =
            (delegate* unmanaged[Thiscall]<nint, uint, uint, uint, uint, void>)this.GetVirtualFunctionPointer(291);
        func(this.GetThisPointer(), dwUnk, dwUnk2, dwUnk3, dwUnk4);
    }

    public unsafe bool ForceCreate(Pointer<CoordStruct> coord, uint dwUnk = 0)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, uint, bool>)this.GetVirtualFunctionPointer(292);
        return func(this.GetThisPointer(), coord, dwUnk);
    }

    public unsafe void RadarTrackingStart()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(293);
        func(this.GetThisPointer());
    }

    public unsafe void RadarTrackingStop()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(294);
        func(this.GetThisPointer());
    }

    public unsafe void RadarTrackingFlash()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(295);
        func(this.GetThisPointer());
    }

    public unsafe void RadarTrackingUpdate(bool bUnk)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool, void>)this.GetVirtualFunctionPointer(296);
        func(this.GetThisPointer(), bUnk);
    }

    public unsafe void vt_entry_4A4(uint dwUnk)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint, void>)this.GetVirtualFunctionPointer(297);
        func(this.GetThisPointer(), dwUnk);
    }

    public unsafe void vt_entry_4A8()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(298);
        func(this.GetThisPointer());
    }

    public unsafe bool vt_entry_4AC()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(299);
        return func(this.GetThisPointer());
    }

    public unsafe bool vt_entry_4B0()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(300);
        return func(this.GetThisPointer());
    }

    public unsafe int vt_entry_4B4()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)this.GetVirtualFunctionPointer(301);
        return func(this.GetThisPointer());
    }

    public unsafe Pointer<CoordStruct> vt_entry_4B8(Pointer<CoordStruct> pCrd)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint>)this.GetVirtualFunctionPointer(302);
        return func(this.GetThisPointer(), pCrd);
    }

    public unsafe bool CanUseWaypoint()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(303);
        return func(this.GetThisPointer());
    }

    public unsafe bool CanAttackOnTheMove()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(304);
        return func(this.GetThisPointer());
    }

    public unsafe bool vt_entry_4C4()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(305);
        return func(this.GetThisPointer());
    }

    public unsafe bool vt_entry_4C8()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(306);
        return func(this.GetThisPointer());
    }

    public unsafe void vt_entry_4CC()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(307);
        func(this.GetThisPointer());
    }

    public unsafe bool vt_entry_4D0()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(308);
        return func(this.GetThisPointer());
    }
    
    public unsafe void SetFocus(Pointer<AbstractClass> pTarget)
    {
        var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, IntPtr, void>)0x70C610;
        func(ref this, pTarget);
    }


    public unsafe bool IsMindControlled()
    {
        var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, Bool>)0x7105E0;
        return func(ref this);
    }

    public unsafe bool CanBePermMindControlled()
    {
        var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, Bool>)0x53C450;
        return func(ref this);
    }


    public unsafe void SetTargetForPassengers(Pointer<AbstractClass> pTarget)
    {
        var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, IntPtr, void>)0x710550;
        func(ref this, pTarget);
    }

    public unsafe Pointer<HouseClass> GetOriginalOwner()
    {
        var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, IntPtr>)0x70F820;
        return func(ref this);
    }

    public unsafe int GetDistanceToTarget(Pointer<AbstractClass> pTarget)
    {
        var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, IntPtr, int>)0x5F6360;
        return func(ref this, pTarget);
    }

    // public unsafe void Sensed()
    // {
    //     var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, void>)0x6F4EB0;
    //     func(ref this);
    // }

    public unsafe bool HasAbility(Ability ability)
    {
        var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, Ability, Bool>)0x70D0D0;
        return func(ref this, ability);
    }

    public unsafe void EnteredOpenTopped(Pointer<TechnoClass> pPayload)
    {
        var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, IntPtr, void>)0x710470;
        func(ref this, pPayload);
    }

    public unsafe void KillPassengers(Pointer<TechnoClass> pSource)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x707CB0;
        func(this.GetThisPointer(), pSource);
    }


    public unsafe Pointer<LaserDrawClass> CreateLaser(Pointer<AbstractClass> pTarget, int weaponIndex,
        Pointer<WeaponTypeClass> pWeapon, CoordStruct sourceCoord)
    {
        var func =
            (delegate* unmanaged[Thiscall]<ref TechnoClass, IntPtr, int, IntPtr, ref CoordStruct, IntPtr>)0x6FD210;
        return func(ref this, pTarget, weaponIndex, pWeapon, ref sourceCoord);
    }


    [FieldOffset(0)] public RadioClass BaseRadio;
    [FieldOffset(0)] public MissionClass BaseMission;
    [FieldOffset(0)] public ObjectClass Base;
    [FieldOffset(0)] public AbstractClass BaseAbstract;

    [FieldOffset(240)] public FlashData Flashing;
    [FieldOffset(248)] public ProgressTimer Animation;
    [FieldOffset(276)] public PassengersClass Passengers;
    [FieldOffset(284)] public nint transporter;
    public readonly Pointer<TechnoClass> Transporter => transporter;
    [FieldOffset(288)] public int unknown_int_120;
    [FieldOffset(292)] public int CurrentTurretNumber;
    [FieldOffset(296)] public int unknown_int_128;
    [FieldOffset(300)] public nint behindAnim;
    public readonly Pointer<AnimClass> BehindAnim => behindAnim;
    [FieldOffset(304)] public nint deployAnim;
    public readonly Pointer<AnimClass> DeployAnim => deployAnim;
    [FieldOffset(308)] public Bool InAir;
    [FieldOffset(312)] public int CurrentWeaponNumber;
    [FieldOffset(316)] public Rank CurrentRanking;
    [FieldOffset(320)] public int CurrentGattlingStage;
    [FieldOffset(324)] public int GattlingValue;
    [FieldOffset(328)] public int TurretAnimFrame;
    [FieldOffset(332)] public nint initialOwner;
    public readonly Pointer<HouseClass> InitialOwner => initialOwner;
    [FieldOffset(336)] public VeterancyStruct Veterancy;
    [FieldOffset(344)] public double ArmorMultiplier;
    [FieldOffset(352)] public double FirepowerMultiplier;
    [FieldOffset(360)] public TimerStruct IdleActionTimer;
    [FieldOffset(372)] public TimerStruct RadarFlashTimer;
    [FieldOffset(384)] public TimerStruct TargetingTimer;
    [FieldOffset(396)] public TimerStruct IronCurtainTimer;
    [FieldOffset(408)] public TimerStruct IronTintTimer;
    [FieldOffset(420)] public int IronTintStage;
    [FieldOffset(424)] public TimerStruct AirstrikeTimer;
    [FieldOffset(436)] public TimerStruct AirstrikeTintTimer;
    [FieldOffset(448)] public uint AirstrikeTintStage;
    [FieldOffset(452)] public int ForceShielded;
    [FieldOffset(456)] public Bool Deactivated;
    [FieldOffset(460)] public nint drainTarget;
    public readonly Pointer<TechnoClass> DrainTarget => drainTarget;
    [FieldOffset(464)] public nint drainingMe;
    public readonly Pointer<TechnoClass> DrainingMe => drainingMe;
    [FieldOffset(468)] public nint drainAnim;
    public readonly Pointer<AnimClass> DrainAnim => drainAnim;
    [FieldOffset(472)] public Bool Disguised;
    [FieldOffset(476)] public uint DisguiseCreationFrame;
    [FieldOffset(480)] public TimerStruct InfantryBlinkTimer;
    [FieldOffset(492)] public TimerStruct DisguiseBlinkTimer;
    [FieldOffset(504)] public Bool UnlimboingInfantry;
    [FieldOffset(508)] public TimerStruct ReloadTimer;
    [FieldOffset(520)] public uint unknown_208;
    [FieldOffset(524)] public uint unknown_20C;
    [FieldOffset(528)] public Int32BitSet DisplayProductionTo;
    [FieldOffset(532)] public int Group;
    [FieldOffset(536)] public nint focus;
    public readonly Pointer<AbstractClass> Focus => focus;
    [FieldOffset(540)] public nint owner;
    public readonly Pointer<HouseClass> Owner => owner;
    [FieldOffset(544)] public CloakStates CloakState;
    [FieldOffset(548)] public ProgressTimer CloakProgress;
    [FieldOffset(576)] public TimerStruct CloakDelayTimer;
    [FieldOffset(588)] public float WarpFactor;
    [FieldOffset(592)] public Bool unknown_bool_250;
    [FieldOffset(596)] public CoordStruct LastSightCoords;
    [FieldOffset(608)] public int LastSightRange;
    [FieldOffset(612)] public int LastSightHeight;
    [FieldOffset(616)] public Bool GapSuperCharged;
    [FieldOffset(617)] public Bool GeneratingGap;
    [FieldOffset(620)] public int GapRadius;
    [FieldOffset(624)] public Bool BeingWarpedOut;
    [FieldOffset(625)] public Bool WarpingOut;
    [FieldOffset(626)] public Bool unknown_bool_272;
    [FieldOffset(627)] public byte unused_273;
    [FieldOffset(628)] public nint temporalImUsing;
    public readonly Pointer<TemporalClass> TemporalImUsing => temporalImUsing;
    [FieldOffset(632)] public nint temporalTargetingMe;
    public readonly Pointer<TemporalClass> TemporalTargetingMe => temporalTargetingMe;
    [FieldOffset(636)] public Bool IsImmobilized;
    [FieldOffset(640)] public uint unknown_280;
    [FieldOffset(644)] public int ChronoLockRemaining;
    [FieldOffset(648)] public CoordStruct ChronoDestCoords;
    [FieldOffset(660)] public nint airstrike;
    public readonly Pointer<AirstrikeClass> Airstrike => airstrike;
    [FieldOffset(664)] public Bool Berzerk;
    [FieldOffset(668)] public uint BerzerkDurationLeft;
    [FieldOffset(672)] public uint SprayOffsetIndex;
    [FieldOffset(676)] public Bool Uncrushable;
    [FieldOffset(680)] public nint directRockerLinkedUnit;
    public readonly Pointer<FootClass> DirectRockerLinkedUnit => directRockerLinkedUnit;
    [FieldOffset(684)] public nint locomotorTarget;
    public readonly Pointer<FootClass> LocomotorTarget => locomotorTarget;
    [FieldOffset(688)] public nint locomotorSource;
    public readonly Pointer<FootClass> LocomotorSource => locomotorSource;
    [FieldOffset(692)] public nint target;
    public readonly Pointer<AbstractClass> Target => target;
    [FieldOffset(696)] public nint lastTarget;
    public readonly Pointer<AbstractClass> LastTarget => lastTarget;
    [FieldOffset(700)] public nint captureManager;
    public readonly Pointer<CaptureManagerClass> CaptureManager => captureManager;
    [FieldOffset(704)] public nint mindControlledBy;
    public readonly Pointer<TechnoClass> MindControlledBy => mindControlledBy;
    [FieldOffset(708)] public Bool MindControlledByAUnit;
    [FieldOffset(712)] public nint mindControlRingAnim;
    public readonly Pointer<AnimClass> MindControlRingAnim => mindControlRingAnim;
    [FieldOffset(716)] public nint mindControlledByHouse;
    public readonly Pointer<HouseClass> MindControlledByHouse => mindControlledByHouse;
    [FieldOffset(720)] public nint spawnManager;
    public readonly Pointer<SpawnManagerClass> SpawnManager => spawnManager;
    [FieldOffset(724)] public nint spawnOwner;
    public readonly Pointer<TechnoClass> SpawnOwner => spawnOwner;
    [FieldOffset(728)] public nint slaveManager;
    public readonly Pointer<SlaveManagerClass> SlaveManager => slaveManager;
    [FieldOffset(732)] public nint slaveOwner;
    public readonly Pointer<TechnoClass> SlaveOwner => slaveOwner;
    [FieldOffset(736)] public nint originallyOwnedByHouse;
    public readonly Pointer<HouseClass> OriginallyOwnedByHouse => originallyOwnedByHouse;
    [FieldOffset(740)] public nint bunkerLinkedItem;
    public readonly Pointer<TechnoClass> BunkerLinkedItem => bunkerLinkedItem;
    [FieldOffset(744)] public float PitchAngle;
    [FieldOffset(748)] public TimerStruct DiskLaserTimer;
    [FieldOffset(760)] public int ChargeTurretDelay;
    [FieldOffset(764)] public int Ammo;
    [FieldOffset(768)] public int Value;
    [FieldOffset(772)] public nint fireParticleSystem;
    public readonly Pointer<ParticleSystemClass> FireParticleSystem => fireParticleSystem;
    [FieldOffset(776)] public nint sparkParticleSystem;
    public readonly Pointer<ParticleSystemClass> SparkParticleSystem => sparkParticleSystem;
    [FieldOffset(780)] public nint naturalParticleSystem;
    public readonly Pointer<ParticleSystemClass> NaturalParticleSystem => naturalParticleSystem;
    [FieldOffset(784)] public nint damageParticleSystem;
    public readonly Pointer<ParticleSystemClass> DamageParticleSystem => damageParticleSystem;
    [FieldOffset(788)] public nint railgunParticleSystem;
    public readonly Pointer<ParticleSystemClass> RailgunParticleSystem => railgunParticleSystem;
    [FieldOffset(792)] public nint unk1ParticleSystem;
    public readonly Pointer<ParticleSystemClass> Unk1ParticleSystem => unk1ParticleSystem;
    [FieldOffset(796)] public nint unk2ParticleSystem;
    public readonly Pointer<ParticleSystemClass> Unk2ParticleSystem => unk2ParticleSystem;
    [FieldOffset(800)] public nint firingParticleSystem;
    public readonly Pointer<ParticleSystemClass> FiringParticleSystem => firingParticleSystem;
    [FieldOffset(804)] public nint wave;
    public readonly Pointer<WaveClass> Wave => wave;
    [FieldOffset(808)] public float AngleRotatedSideways;
    [FieldOffset(812)] public float AngleRotatedForwards;
    [FieldOffset(816)] public float RockingSidewaysPerFrame;
    [FieldOffset(820)] public float RockingForwardsPerFrame;
    [FieldOffset(824)] public int HijackerInfantryType;
    [FieldOffset(828)] public OwnedTiberiumStruct Tiberium;
    [FieldOffset(844)] public uint unknown_34C;
    [FieldOffset(848)] public TransitionTimer UnloadTimer;
    [FieldOffset(880)] public FacingStruct BarrelFacing;
    [FieldOffset(904)] public FacingStruct Facing;
    [FieldOffset(928)] public FacingStruct TurretFacing;
    [FieldOffset(952)] public int CurrentBurstIndex;
    [FieldOffset(956)] public TimerStruct TargetLaserTimer;
    [FieldOffset(968)] public short unknown_short_3C8;
    [FieldOffset(970)] public ushort unknown_3CA;
    [FieldOffset(972)] public Bool CountedAsOwned;
    [FieldOffset(973)] public Bool IsSinking;
    [FieldOffset(974)] public Bool WasSinkingAlready;
    [FieldOffset(975)] public Bool unknown_bool_3CF;
    [FieldOffset(976)] public Bool unknown_bool_3D0;
    [FieldOffset(977)] public Bool HasBeenAttacked;
    [FieldOffset(978)] public Bool Cloakable;
    [FieldOffset(979)] public Bool IsPrimaryFactory;
    [FieldOffset(980)] public Bool Spawned;
    [FieldOffset(981)] public Bool IsInPlayfield;
    [FieldOffset(984)] public RecoilData TurretRecoil;
    [FieldOffset(1016)] public RecoilData BarrelRecoil;
    [FieldOffset(1048)] public Bool unknown_bool_418;
    [FieldOffset(1049)] public Bool unknown_bool_419;
    [FieldOffset(1050)] public Bool IsHumanControlled;
    [FieldOffset(1051)] public Bool DiscoveredByPlayer;
    [FieldOffset(1052)] public Bool DiscoveredByComputer;
    [FieldOffset(1053)] public Bool unknown_bool_41D;
    [FieldOffset(1054)] public Bool unknown_bool_41E;
    [FieldOffset(1055)] public Bool unknown_bool_41F;
    [FieldOffset(1056)] public byte SightIncrease;
    [FieldOffset(1057)] public Bool RecruitableA;
    [FieldOffset(1058)] public Bool RecruitableB;
    [FieldOffset(1059)] public Bool IsRadarTracked;
    [FieldOffset(1060)] public Bool IsOnCarryall;
    [FieldOffset(1061)] public Bool IsCrashing;
    [FieldOffset(1062)] public Bool WasCrashingAlready;
    [FieldOffset(1063)] public Bool IsBeingManipulated;
    [FieldOffset(1064)] public nint beingManipulatedBy;
    public readonly Pointer<TechnoClass> BeingManipulatedBy => beingManipulatedBy;
    [FieldOffset(1068)] public nint chronoWarpedByHouse;
    public readonly Pointer<HouseClass> ChronoWarpedByHouse => chronoWarpedByHouse;
    [FieldOffset(1072)] public Bool unknown_bool_430;
    [FieldOffset(1073)] public Bool IsMouseHovering;
    [FieldOffset(1074)] public Bool unknown_bool_432;
    [FieldOffset(1076)] public nint oldTeam;
    public readonly Pointer<TeamClass> OldTeam => oldTeam;
    [FieldOffset(1080)] public Bool CountedAsOwnedSpecial;
    [FieldOffset(1081)] public Bool Absorbed;
    [FieldOffset(1082)] public Bool unknown_bool_43A;
    [FieldOffset(1084)] public uint unknown_43C;
    [FieldOffset(1088)] public byte currentTargetThreatValues;

    public ref DynamicVectorClass<int> CurrentTargetThreatValues =>
        ref Pointer<byte>.AsPointer(ref currentTargetThreatValues).Convert<DynamicVectorClass<int>>().Ref;


    [FieldOffset(1112)] public byte currentTargets;

    public ref DynamicVectorClass<Pointer<AbstractClass>> CurrentTargets =>
        ref Pointer<byte>.AsPointer(ref currentTargets).Convert<DynamicVectorClass<Pointer<AbstractClass>>>().Ref;


    [FieldOffset(1136)] public byte attackedTargets;

    public ref DynamicVectorClass<Pointer<AbstractClass>> AttackedTargets =>
        ref Pointer<byte>.AsPointer(ref attackedTargets).Convert<DynamicVectorClass<Pointer<AbstractClass>>>().Ref;

    [FieldOffset(1160)] public AudioController Audio3;
    [FieldOffset(1180)] public uint unknown_49C;
    [FieldOffset(1184)] public uint turretIsRotating;

    public bool TurretIsRotating
    {
        get => turretIsRotating != 0;
        set => turretIsRotating = value ? 1u : 0u;
    }

    [FieldOffset(1188)] public AudioController Audio4;
    [FieldOffset(1208)] public Bool unknown_bool_4B8;
    [FieldOffset(1212)] public uint unknown_4BC;
    [FieldOffset(1216)] public AudioController Audio5;
    [FieldOffset(1236)] public Bool unknown_bool_4D4;
    [FieldOffset(1240)] public uint unknown_4D8;
    [FieldOffset(1244)] public AudioController Audio6;
    [FieldOffset(1264)] public uint QueuedVoiceIndex;
    [FieldOffset(1268)] public uint unknown_4F4;
    [FieldOffset(1272)] public Bool unknown_bool_4F8;
    [FieldOffset(1276)] public uint unknown_4FC;
    [FieldOffset(1280)] public nint enterTarget;
    public readonly Pointer<TechnoClass> EnterTarget => enterTarget;
    [FieldOffset(1284)] public uint EMPLockRemaining;
    [FieldOffset(1288)] public uint ThreatPosed;
    [FieldOffset(1292)] public uint ShouldLoseTargetNow;
    [FieldOffset(1296)] public nint firingRadBeam;
    public readonly Pointer<RadBeam> FiringRadBeam => firingRadBeam;
    [FieldOffset(1300)] public nint planningToken;
    public readonly Pointer<PlanningTokenClass> PlanningToken => planningToken;
    [FieldOffset(1304)] public nint disguise;
    public readonly Pointer<ObjectTypeClass> Disguise => disguise;
    [FieldOffset(1308)] public nint disguisedAsHouse;
    public readonly Pointer<HouseClass> DisguisedAsHouse => disguisedAsHouse;
}