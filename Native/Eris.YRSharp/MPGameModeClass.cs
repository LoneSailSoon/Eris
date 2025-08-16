using Eris.YRSharp.String.Ansi;
using Eris.YRSharp.String.Uni;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit, Size = 64)]
public struct MPGameModeClass
{
    private const nint instance = 0xA8B23C;
    public static ref MPGameModeClass Instance => ref instance.Convert<Pointer<MPGameModeClass>>().Ref.Ref;

    public unsafe bool vt_entry_04()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(1);
        return func(this.GetThisPointer());
    }

    public unsafe bool vt_entry_08()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(2);
        return func(this.GetThisPointer());
    }

    public unsafe bool vt_entry_0C(uint dwUnk)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint, bool>)this.GetVirtualFunctionPointer(3);
        return func(this.GetThisPointer(), dwUnk);
    }

    public unsafe bool vt_entry_10()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(4);
        return func(this.GetThisPointer());
    }

    public unsafe bool vt_entry_14(uint dwUnk)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint, bool>)this.GetVirtualFunctionPointer(5);
        return func(this.GetThisPointer(), dwUnk);
    }

    public unsafe bool vt_entry_18()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(6);
        return func(this.GetThisPointer());
    }

    public unsafe bool vt_entry_1C(uint dwUnk)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint, bool>)this.GetVirtualFunctionPointer(7);
        return func(this.GetThisPointer(), dwUnk);
    }

    public unsafe void vt_entry_20()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(8);
        func(this.GetThisPointer());
    }

    public unsafe void vt_entry_24()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(9);
        func(this.GetThisPointer());
    }

    public unsafe int vt_entry_28()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)this.GetVirtualFunctionPointer(10);
        return func(this.GetThisPointer());
    }

    public unsafe int vt_entry_2C()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)this.GetVirtualFunctionPointer(11);
        return func(this.GetThisPointer());
    }

    public unsafe int vt_entry_30()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)this.GetVirtualFunctionPointer(12);
        return func(this.GetThisPointer());
    }

    public unsafe bool CanAllyWith(int idx)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, bool>)this.GetVirtualFunctionPointer(13);
        return func(this.GetThisPointer(), idx);
    }

    public unsafe void vt_entry_38(uint dwUnk)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint, void>)this.GetVirtualFunctionPointer(14);
        func(this.GetThisPointer(), dwUnk);
    }

    public unsafe bool IsAIAllowed()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(15);
        return func(this.GetThisPointer());
    }

    public unsafe bool vt_entry_40()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(16);
        return func(this.GetThisPointer());
    }

    public unsafe int FirstValidMapIndex()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)this.GetVirtualFunctionPointer(17);
        return func(this.GetThisPointer());
    }

//MethodData { Type = void, Name = PopulateTeamDropdown, IsPoionter = False } this.GetVirtualFunctionPointer(18);
//MethodData { Type = void, Name = DrawTeamDropdown, IsPoionter = False } this.GetVirtualFunctionPointer(19);
    public unsafe void PopulateTeamDropdownForPlayer(uint hWnd, int idx)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint, int, void>)this.GetVirtualFunctionPointer(20);
        func(this.GetThisPointer(), hWnd, idx);
    }

    public unsafe bool vt_entry_54(int a1, int a2, Pointer<byte> ptr, int a4, short a5, int a6, int a7)
    {
        var func =
            (delegate* unmanaged[Thiscall]<nint, int, int, nint, int, short, int, int, bool>)this
                .GetVirtualFunctionPointer(21);
        return func(this.GetThisPointer(), a1, a2, ptr, a4, a5, a6, a7);
    }

    public unsafe bool vt_entry_58(int a1, int a2, Pointer<byte> ptr, int a4, short a5, int a6, int a7, int a8, int a9)
    {
        var func =
            (delegate* unmanaged[Thiscall]<nint, int, int, nint, int, short, int, int, int, int, bool>)this
                .GetVirtualFunctionPointer(22);
        return func(this.GetThisPointer(), a1, a2, ptr, a4, a5, a6, a7, a8, a9);
    }

    public unsafe bool vt_entry_5C(uint dwUnk1, uint dwUnk2, uint dwUnk3)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint, uint, uint, bool>)this.GetVirtualFunctionPointer(23);
        return func(this.GetThisPointer(), dwUnk1, dwUnk2, dwUnk3);
    }

    public unsafe bool vt_entry_60()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(24);
        return func(this.GetThisPointer());
    }

    public unsafe bool vt_entry_64()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(25);
        return func(this.GetThisPointer());
    }

    public unsafe bool vt_entry_68()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(26);
        return func(this.GetThisPointer());
    }

    public unsafe int RandomHumanCountryIndex()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)this.GetVirtualFunctionPointer(27);
        return func(this.GetThisPointer());
    }

    public unsafe int RandomAICountryIndex()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)this.GetVirtualFunctionPointer(28);
        return func(this.GetThisPointer());
    }

    public unsafe void vt_entry_74(uint dwUnk1, uint dwUnk2)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint, uint, void>)this.GetVirtualFunctionPointer(29);
        func(this.GetThisPointer(), dwUnk1, dwUnk2);
    }

    public unsafe void vt_entry_78(uint dwUnk1)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint, void>)this.GetVirtualFunctionPointer(30);
        func(this.GetThisPointer(), dwUnk1);
    }

    public unsafe bool UnfixAlliances()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(31);
        return func(this.GetThisPointer());
    }

    public unsafe bool StartingPositionsToHouseBaseCells(byte unused)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, byte, bool>)this.GetVirtualFunctionPointer(32);
        return func(this.GetThisPointer(), unused);
    }

    public unsafe bool StartingPositionsToHouseBaseCells2(bool arg)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool, bool>)this.GetVirtualFunctionPointer(33);
        return func(this.GetThisPointer(), arg);
    }

    public unsafe bool AllyTeams()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(34);
        return func(this.GetThisPointer());
    }

    public unsafe bool vt_entry_8C()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(35);
        return func(this.GetThisPointer());
    }

    public unsafe void vt_entry_90()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(36);
        func(this.GetThisPointer());
    }

    public unsafe void vt_entry_94()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(37);
        func(this.GetThisPointer());
    }

    public unsafe int vt_entry_98()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)this.GetVirtualFunctionPointer(38);
        return func(this.GetThisPointer());
    }

    public unsafe void vt_entry_9C()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(39);
        func(this.GetThisPointer());
    }

    public unsafe void vt_entry_A0(uint dwUnk)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint, void>)this.GetVirtualFunctionPointer(40);
        func(this.GetThisPointer(), dwUnk);
    }

    public unsafe void vt_entry_A4(uint dwUnk)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint, void>)this.GetVirtualFunctionPointer(41);
        func(this.GetThisPointer(), dwUnk);
    }

    public unsafe bool vt_entry_A8()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(42);
        return func(this.GetThisPointer());
    }

    public unsafe void vt_entry_AC()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(43);
        func(this.GetThisPointer());
    }

    public unsafe void vt_entry_B0()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(44);
        func(this.GetThisPointer());
    }

    public unsafe bool vt_entry_B4(int a1, Pointer<byte> ptr, int a3, short a4, int a5, int a6, int a7)
    {
        var func =
            (delegate* unmanaged[Thiscall]<nint, int, nint, int, short, int, int, int, bool>)this
                .GetVirtualFunctionPointer(45);
        return func(this.GetThisPointer(), a1, ptr, a3, a4, a5, a6, a7);
    }

    public unsafe int vt_entry_B8()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)this.GetVirtualFunctionPointer(46);
        return func(this.GetThisPointer());
    }

    public unsafe bool vt_entry_BC()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(47);
        return func(this.GetThisPointer());
    }

    public unsafe void CreateMPTeams(Pointer<DynamicVectorClass<MPTeam>> vecTeams)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)this.GetVirtualFunctionPointer(48);
        func(this.GetThisPointer(), vecTeams);
    }

    public unsafe Pointer<CellStruct> AssignStartingPositionsToHouse(Pointer<CellStruct> result, int idxHouse,
        Pointer<DynamicVectorClass<CellStruct>> vecCoords, Pointer<byte> housesSatisfied)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, int, nint, nint, nint>)this.GetVirtualFunctionPointer(49);
        return func(this.GetThisPointer(), result, idxHouse, vecCoords, housesSatisfied);
    }

    public unsafe bool SpawnBaseUnits(Pointer<HouseClass> House, uint dwUnused)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, uint, bool>)this.GetVirtualFunctionPointer(50);
        return func(this.GetThisPointer(), House, dwUnused);
    }

    public unsafe bool GenerateStartingUnits(Pointer<HouseClass> House, Pointer<int> AmountToSpend)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, bool>)this.GetVirtualFunctionPointer(51);
        return func(this.GetThisPointer(), House, AmountToSpend);
    }





    [FieldOffset(4)] public Bool unknown_4;
    [FieldOffset(8)] public byte mPTeams;

    public ref DynamicVectorClass<Pointer<MPTeam>> MPTeams =>
        ref Pointer<byte>.AsPointer(ref mPTeams).Convert<DynamicVectorClass<Pointer<MPTeam>>>().Ref;

    [FieldOffset(32)] public UniStringPointer CSFTitle;
    [FieldOffset(36)] public UniStringPointer CSFTooltip;
    [FieldOffset(40)] public int MPModeIndex;
    [FieldOffset(44)] public AnsiStringPointer INIFilename;
    [FieldOffset(48)] public AnsiStringPointer MapFilter;
    [FieldOffset(52)] public Bool AIAllowed;
    [FieldOffset(56)] public nint ini;
    public Pointer<CCIniClass> Ini => ini;
    [FieldOffset(60)] public Bool AlliesAllowed;
    [FieldOffset(61)] public Bool wolTourney;
    [FieldOffset(62)] public Bool wolClanTourney;
    [FieldOffset(63)] public Bool MustAlly;
}

[StructLayout(LayoutKind.Explicit)]
public struct MPBattleClass
{
    public static unsafe void Constructor(Pointer<MPBattleClass> pThis,
        Pointer<UniStringPointer> csfTitle,
        Pointer<UniStringPointer> iniFileName,
        Pointer<UniStringPointer> mapfilter,
        bool aiAllowed,
        int mpModeIndex)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, nint, bool, int, nint>)0x5D8170;
        func(pThis, csfTitle, iniFileName, mapfilter, aiAllowed, mpModeIndex);
    }

    [FieldOffset(0)] public MPGameModeClass Base;
}

[StructLayout(LayoutKind.Explicit)]
public struct MPManBattleClass
{
    public static unsafe void Constructor(Pointer<MPManBattleClass> pThis,
        Pointer<UniStringPointer> csfTitle,
        Pointer<UniStringPointer> iniFileName,
        Pointer<UniStringPointer> mapfilter,
        bool aiAllowed,
        int mpModeIndex)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, nint, bool, int, nint>)0x5C6150;
        func(pThis, csfTitle, iniFileName, mapfilter, aiAllowed, mpModeIndex);
    }

    [FieldOffset(0)] public MPGameModeClass Base;
}

[StructLayout(LayoutKind.Explicit)]
public struct MPFreeForAllClass
{
    public static unsafe void Constructor(Pointer<MPFreeForAllClass> pThis,
        Pointer<UniStringPointer> csfTitle,
        Pointer<UniStringPointer> iniFileName,
        Pointer<UniStringPointer> mapfilter,
        bool aiAllowed,
        int mpModeIndex)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, nint, bool, int, nint>)0x5C5CE0;
        func(pThis, csfTitle, iniFileName, mapfilter, aiAllowed, mpModeIndex);
    }


    [FieldOffset(0)] public MPGameModeClass Base;
}

[StructLayout(LayoutKind.Explicit)]
public struct MPMegawealthClass
{
    public static unsafe void Constructor(Pointer<MPMegawealthClass> pThis,
        Pointer<UniStringPointer> csfTitle,
        Pointer<UniStringPointer> iniFileName,
        Pointer<UniStringPointer> mapfilter,
        bool aiAllowed,
        int mpModeIndex)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, nint, bool, int, nint>)0x5C93E0;
        func(pThis, csfTitle, iniFileName, mapfilter, aiAllowed, mpModeIndex);
    }


    [FieldOffset(0)] public MPGameModeClass Base;
}

[StructLayout(LayoutKind.Explicit)]
public struct MPUnholyAllianceClass
{    
    public static unsafe void Constructor(Pointer<MPUnholyAllianceClass> pThis,
        Pointer<UniStringPointer> csfTitle,
        Pointer<UniStringPointer> iniFileName,
        Pointer<UniStringPointer> mapfilter,
        bool aiAllowed,
        int mpModeIndex)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, nint, bool, int, nint>)0x5CB3A0;
        func(pThis, csfTitle, iniFileName, mapfilter, aiAllowed, mpModeIndex);
    }


    [FieldOffset(0)] public MPGameModeClass Base;
}

[StructLayout(LayoutKind.Explicit)]
public struct MPSiegeClass
{
    public static unsafe void Constructor(Pointer<MPSiegeClass> pThis,
        Pointer<UniStringPointer> csfTitle,
        Pointer<UniStringPointer> iniFileName,
        Pointer<UniStringPointer> mapfilter,
        bool aiAllowed,
        int mpModeIndex)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, nint, bool, int, nint>)0x5CA630;
        func(pThis, csfTitle, iniFileName, mapfilter, aiAllowed, mpModeIndex);
    }

    [FieldOffset(0)] public MPGameModeClass Base;
}

