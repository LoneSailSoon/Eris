namespace Eris.YRSharp;

public static class Game
{
    public const nint pCurrentFrame = 0xA8ED84; // you should not change it
    public static ref int CurrentFrame => ref pCurrentFrame.Convert<int>().Ref;


    // The height in the middle of a cell with a slope of 30 degrees
    public const int LevelHeight = 104; //89DE70
    public const int BridgeLevels = 4;
    public const int BridgeHeight = LevelHeight * BridgeLevels; //ABC5DC

    public const int CellSize = 256;
    public const int CellHeight = 208;
    public const int CellWidthInPixels = 60;
    public const int CellHeightInPixels = 30;


    public static int IKnowWhatImDoing
    {
        get => new Pointer<int>(_iKnowWhatImDoing).Data;
        set => new Pointer<int>(_iKnowWhatImDoing).Ref = value;
    }

    private const nint _iKnowWhatImDoing = 0xA8E7AC; // you should not change it

    public static int CurrentSwType
    {
        get => new Pointer<int>(_currentSwType).Data;
        set => new Pointer<int>(_currentSwType).Ref = value;
    }

    private const nint _currentSwType = 0x8809A0;




    public const nint ArrayPointer = 0xB0BC88;

    public static ref DynamicVectorClass<uint> COMClasses =>
        ref DynamicVectorClass<uint>.GetDynamicVector(ArrayPointer);



    public const nint savegame_Magic = 0x83D560;
    public static ref uint Savegame_Magic => ref savegame_Magic.Convert<uint>().Ref;
    public const nint wnd = 0xB73550;
    public static ref uint Wnd => ref wnd.Convert<uint>().Ref;
    public const nint instance = 0xB732F0;
    public static ref nint Instance => ref instance.Convert<nint>().Ref;
    public const nint vPLRead = 0x887418;
    public static ref Bool VPLRead => ref vPLRead.Convert<Bool>().Ref;
    public const nint videoBackBuffer = 0x840A6C;
    public static ref Bool VideoBackBuffer => ref videoBackBuffer.Convert<Bool>().Ref;
    public const nint allowVRAMSidebar = 0xA8EB96;
    public static ref Bool AllowVRAMSidebar => ref allowVRAMSidebar.Convert<Bool>().Ref;
    public const nint recordingFlag = 0xA8D5F8;
    public static ref RecordFlag RecordingFlag => ref recordingFlag.Convert<RecordFlag>().Ref;
    public const nint recordFile = 0xA8D58C;
    public static ref CCFileClass RecordFile => ref recordFile.Convert<CCFileClass>().Ref;
    public const nint drawShadow = 0x822CF1;
    public static ref Bool DrawShadow => ref drawShadow.Convert<Bool>().Ref;
    public const nint allowDirect3D = 0x8A0DEF;
    public static ref Bool AllowDirect3D => ref allowDirect3D.Convert<Bool>().Ref;
    public const nint direct3DIsUseable = 0x8A0DF0;
    public static ref Bool Direct3DIsUseable => ref direct3DIsUseable.Convert<Bool>().Ref;
    public const nint isActive = 0xA8E9A0;
    public static ref Bool IsActive => ref isActive.Convert<Bool>().Ref;
    public const nint isFocused = 0xA8ED80;
    public static ref Bool IsFocused => ref isFocused.Convert<Bool>().Ref;
    public const nint specialDialog = 0xA8EDA0;
    public static ref int SpecialDialog => ref specialDialog.Convert<int>().Ref;
    public const nint pCXInitialized = 0xAC48D4;
    public static ref Bool PCXInitialized => ref pCXInitialized.Convert<Bool>().Ref;
    public const nint seed = 0xA8ED94;
    public static ref int Seed => ref seed.Convert<int>().Ref;
    public const nint techLevel = 0x822CF4;
    public static ref int TechLevel => ref techLevel.Convert<int>().Ref;
    public const nint playerCount = 0xA8B54C;
    public static ref int PlayerCount => ref playerCount.Convert<int>().Ref;
    public const nint playerColor = 0xA8B394;
    public static ref int PlayerColor => ref playerColor.Convert<int>().Ref;
    public const nint observerMode = 0xAC10C8;
    public static ref Bool ObserverMode => ref observerMode.Convert<Bool>().Ref;
    public const nint scenarioName = 0xA8B8E0;
    public static ref byte ScenarioName => ref scenarioName.Convert<byte>().Ref;
    public const nint dontSetExceptionHandler = 0xA8F7AC;
    public static ref Bool DontSetExceptionHandler => ref dontSetExceptionHandler.Convert<Bool>().Ref;
    public const nint enableMPSyncDebug = 0xB04880;
    public static ref Bool EnableMPSyncDebug => ref enableMPSyncDebug.Convert<Bool>().Ref;

}


public class InterfaceId
{
    public const nint iUnknown = 0x7F7C90;
    public static ref Guid IUnknown => ref iUnknown.Convert<Guid>().Ref;
    public const nint iPersistStream = 0x7F7C80;
    public static ref Guid IPersistStream => ref iPersistStream.Convert<Guid>().Ref;
    public const nint iPersist = 0x7F7C70;
    public static ref Guid IPersist => ref iPersist.Convert<Guid>().Ref;
    public const nint iRTTITypeInfo = 0x7E9AE0;
    public static ref Guid IRTTITypeInfo => ref iRTTITypeInfo.Convert<Guid>().Ref;
    public const nint iHouse = 0x7EA768;
    public static ref Guid IHouse => ref iHouse.Convert<Guid>().Ref;
    public const nint iPublicHouse = 0x7E9B00;
    public static ref Guid IPublicHouse => ref iPublicHouse.Convert<Guid>().Ref;
    public const nint iEnumConnections = 0x7F7CB0;
    public static ref Guid IEnumConnections => ref iEnumConnections.Convert<Guid>().Ref;
    public const nint iConnectionPoint = 0x7F7CC0;
    public static ref Guid IConnectionPoint => ref iConnectionPoint.Convert<Guid>().Ref;
    public const nint iConnectionPointContainer = 0x7F7CD0;
    public static ref Guid IConnectionPointContainer => ref iConnectionPointContainer.Convert<Guid>().Ref;
    public const nint iEnumConnectionPoints = 0x7F7CE0;
    public static ref Guid IEnumConnectionPoints => ref iEnumConnectionPoints.Convert<Guid>().Ref;
    public const nint iApplication = 0x7E36C0;
    public static ref Guid IApplication => ref iApplication.Convert<Guid>().Ref;
    public const nint iGameMap = 0x7EA6E8;
    public static ref Guid IGameMap => ref iGameMap.Convert<Guid>().Ref;
    public const nint iLocomotion = 0x7ED358;
    public static ref Guid ILocomotion => ref iLocomotion.Convert<Guid>().Ref;
    public const nint iPiggyback = 0x7E9B10;
    public static ref Guid IPiggyback => ref iPiggyback.Convert<Guid>().Ref;
    public const nint iFlyControl = 0x7E9B40;
    public static ref Guid IFlyControl => ref iFlyControl.Convert<Guid>().Ref;
    public const nint iSwizzle = 0x7E9B20;
    public static ref Guid ISwizzle => ref iSwizzle.Convert<Guid>().Ref;

}

public static class Import
{
    [DllImport("winmm")]
    public static extern uint timeGetTime();
}