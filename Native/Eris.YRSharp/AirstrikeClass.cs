namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit, Size = 96)]
public struct AirstrikeClass
{
    public unsafe void StartMission(Pointer<ObjectClass> pTarget)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x41D830;
        func(this.GetThisPointer(), pTarget);
    }

    public static unsafe void Constructor(Pointer<AirstrikeClass> pThis, Pointer<TechnoClass> pOwner)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x41D380;
        func(pThis, pOwner);
    }

    [FieldOffset(0)] public AbstractClass Base;
    [FieldOffset(36)] public int AirstrikeTeam; //As in the INI files.
    [FieldOffset(40)] public int EliteAirstrikeTeam; //As in the INI files.
    [FieldOffset(44)] public int AirstrikeTeamTypeIndex;	//As in the INI files.
    [FieldOffset(48)] public int EliteAirstrikeTeamTypeIndex;	//As in the INI files.
    [FieldOffset(52)] public uint unknown_34;
    [FieldOffset(56)] public uint unknown_38;	//unused?
    [FieldOffset(60)] public Bool IsOnMission;	//Is the Aircraft on its way?
    [FieldOffset(61)] public Bool unknown_bool_3D;
    [FieldOffset(64)] public uint TeamDissolveFrame;	//when was the last time this team was invoked and subsequently dissolved
    [FieldOffset(68)] public int AirstrikeRechargeTime;	//As in the INI files.
    [FieldOffset(72)] public int EliteAirstrikeRechargeTime;	//As in the INI files.
    [FieldOffset(76)] public nint owner;		//The unit that called the Airstrike (usually Boris).
    public readonly Pointer<TechnoClass> Owner => owner;
    
    [FieldOffset(80)] public nint target;	//The Airstrike's target.
    public readonly Pointer<ObjectClass> Target => target;
    
    [FieldOffset(84)] public nint airstrikeTeamType;	//As in the INI files.
    public readonly Pointer<AircraftTypeClass> AirstrikeTeamType => airstrikeTeamType;
    
    [FieldOffset(88)] public nint eliteAirstrikeTeamType;	//As in the INI files.
    public readonly Pointer<AircraftTypeClass> EliteAirstrikeTeamType => eliteAirstrikeTeamType;
    
    [FieldOffset(92)] public nint firstObject;
    public readonly Pointer<AircraftTypeClass> FirstObject => firstObject;
}