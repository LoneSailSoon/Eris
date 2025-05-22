using System.Runtime.InteropServices;
using Eris.YRSharp;
using Eris.YRSharp.Helpers;

namespace Eris.Ui.NaegleriaUi;

public static partial class NaegleriaUiMissionManager
{
    static NaegleriaUiMissionManager()
    {
        Indexes = [];
        Missions = [];
        
        //Register("consolemission", ConsoleMission, ConsoleMissionParser);
        Register("kill", KillMission, KillMissionParser, true);
        Register("remove", RemoveMission, RemoveMissionParser, true);
        Register("exp", ExpMission, ExpMissionParser, true);
        Register("own", OwnMission, OwnMissionParser, true);
        //Register("givesw", GiveSWMission, GiveSWMissionParser);
        Register("money", MoneyMission, MoneyMissionParser);
        //Register("convert", ConvertMission, ConvertMissionParser, true);
        Register("create", CreateMission, CreateMissionParser);
        Register("firesw", LaunchSWMission, LaunchSWMissionParser);
        Register("fire", DetonateMission, DetonateMissionParser);
        Register("fireeach", DetonateEachMission, DetonateEachMissionParser, true);
        //Register("pop", PopMission, PopMissionParser, true);
        //Register("push", PushMission, PushMissionParser);
        Register("mission", MissionMission, MissionMissionParser, true);
        Register("iron", ICMission, ICMissionParser, true);
        Register("health", HealthMission, HealthMissionParser, true);
        //Register("create8", Create8Mission, Create8MissionParser);
        //Register("helper", HelperMission, HelperMissionParser);
        //Register("develop", DeveloperMission, DeveloperMissionParser);
        //Register("briefingstart", BriefingMission, BriefingMissionParser);
        Register("style", StyleMission, StyleMissionParser, true);
        Register("test", ConsoleTestMission, ConsoleTestMissionParser);
    }

    private static readonly Dictionary<string, int> Indexes;
    private static readonly List<NaegleriaUiMissionData> Missions;

    public static void Register(string id, MissionHandler handler, MissionParser parser, bool forEach = false)
    {
        Indexes[id] = Missions.Count;
        Missions.Add(new NaegleriaUiMissionData(handler, parser, forEach));
    }
    
    public static bool TryFindIndex(string name, out int index)
    {
        return Indexes.TryGetValue(name, out index);
    }


    public static NaegleriaUiMissionData GetMission(int index) => Missions[index];
    public static bool TryGetMission(string id, out NaegleriaUiMissionData mission)
    {
        mission = default;
        if (Indexes.TryGetValue(id, out var index))
        {
            mission = Missions[index];
            return true;
        }
        return false;
    }
    
    internal static int HouseIndex = -1;
    public static Pointer<HouseClass> CurrentHouse => HouseClass.Array[HouseIndex];

    
    
}

[StructLayout(LayoutKind.Sequential)]
public struct NaegleriaUiMissionEventArg
{
    public int MissionIndex;
    public int Value1;
    public int Value2;
    public int Value3;
    public int Value4;
    public int Value5;
}

public record struct NaegleriaUiMissionData(MissionHandler Handler, MissionParser Parser, bool ForEach);

public delegate void MissionHandler(NaegleriaUiMissionEventArg value);

public delegate string? MissionParser(string val, out NaegleriaUiMissionEventArg value);
