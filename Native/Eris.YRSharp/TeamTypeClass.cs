namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct TeamTypeClass
{
    private const nint ArrayPointer = 0xA8ECA0;

    public static readonly GlobalDvcArray<TeamTypeClass> AbstractTypeArray = new(ArrayPointer);

    
    public unsafe Pointer<TeamClass> CreateTeam(Pointer<HouseClass> pHouse)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint>)0x6F09C0;
        return func(this.GetThisPointer(), pHouse);
    }
    public unsafe void DestroyAllInstances()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x6F0A70;
        func(this.GetThisPointer());
    }
    public unsafe int GetGroup()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)0x6F1870;
        return func(this.GetThisPointer());
    }
    public unsafe Pointer<CellStruct> GetWaypoint(Pointer<CellStruct> buffer)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint>)0x6F18A0;
        return func(this.GetThisPointer(), buffer);
    }
    public unsafe Pointer<CellStruct> GetTransportWaypoint(Pointer<CellStruct> buffer)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint>)0x6F18E0;
        return func(this.GetThisPointer(), buffer);
    }
    public unsafe bool CanRecruitUnit(Pointer<FootClass> pUnit, Pointer<HouseClass> pOwner)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, bool>)0x6F1320;
        return func(this.GetThisPointer(), pUnit, pOwner);
    }
    public unsafe void FlashAllInstances(int Duration)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, void>)0x6F1F30;
        func(this.GetThisPointer(), Duration);
    }
    public unsafe Pointer<TeamClass> FindFirstInstance()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint>)0x6F1F70;
        return func(this.GetThisPointer());
    }
    public unsafe void ProcessTaskForce()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x6F1FA0;
        func(this.GetThisPointer());
    }
    public unsafe Pointer<HouseClass> GetHouse()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint>)0x6F2070;
        return func(this.GetThisPointer());
    }

    
    [FieldOffset(0)] public AbstractTypeClass Base;
    [FieldOffset(152)] public int ArrayIndex;
    [FieldOffset(156)] public int Group;
    [FieldOffset(160)] public int VeteranLevel;
    [FieldOffset(164)] public Bool Loadable;
    [FieldOffset(165)] public Bool Full;
    [FieldOffset(166)] public Bool Annoyance;
    [FieldOffset(167)] public Bool GuardSlower;
    [FieldOffset(168)] public Bool Recruiter;
    [FieldOffset(169)] public Bool Autocreate;
    [FieldOffset(170)] public Bool Prebuild;
    [FieldOffset(171)] public Bool Reinforce;
    [FieldOffset(172)] public Bool Whiner;
    [FieldOffset(173)] public Bool Aggressive;
    [FieldOffset(174)] public Bool LooseRecruit;
    [FieldOffset(175)] public Bool Suicide;
    [FieldOffset(176)] public Bool Droppod;
    [FieldOffset(177)] public Bool UseTransportOrigin;
    [FieldOffset(178)] public Bool DropshipLoadout;
    [FieldOffset(179)] public Bool OnTransOnly;
    [FieldOffset(180)] public int Priority;
    [FieldOffset(184)] public int Max;
    [FieldOffset(188)] public int field_BC;
    [FieldOffset(192)] public int MindControlDecision;
    [FieldOffset(196)] public nint owner;
    public Pointer<HouseClass> Owner => owner;
    [FieldOffset(200)] public int idxHouse;
    [FieldOffset(204)] public int TechLevel;
    [FieldOffset(208)] public nint tag;
    public Pointer<TagClass> Tag => tag;
    [FieldOffset(212)] public int Waypoint;
    [FieldOffset(216)] public int TransportWaypoint;
    [FieldOffset(220)] public int cntInstances;
    [FieldOffset(224)] public nint scriptType;
    public Pointer<ScriptTypeClass> ScriptType => scriptType;
    [FieldOffset(228)] public nint taskForce;
    public Pointer<TaskForceClass> TaskForce => taskForce;
    [FieldOffset(232)] public int IsGlobal;
    [FieldOffset(236)] public int field_EC;
    [FieldOffset(240)] public Bool field_F0;
    [FieldOffset(241)] public Bool field_F1;
    [FieldOffset(242)] public Bool AvoidThreats;
    [FieldOffset(243)] public Bool IonImmune;
    [FieldOffset(244)] public Bool TransportsReturnOnUnload;
    [FieldOffset(245)] public Bool AreTeamMembersRecruitable;
    [FieldOffset(246)] public Bool IsBaseDefense;
    [FieldOffset(247)] public Bool OnlyTargetHouseEnemy;
}