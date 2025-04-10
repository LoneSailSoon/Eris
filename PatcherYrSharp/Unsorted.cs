using System.Runtime.InteropServices;
using PatcherYrSharp.Helpers;

namespace PatcherYrSharp;

public static class Game
{
    public static int CurrentFrame
    {
        get => new Pointer<int>(pCurrentFrame).Data;
        set => new Pointer<int>(pCurrentFrame).Ref = value;
    }

    public static IntPtr pCurrentFrame = new IntPtr(0xA8ED84); // you should not change it

    // The height in the middle of a cell with a slope of 30 degrees
    public const int LevelHeight = 104; //89DE70
    public const int BridgeLevels = 4;
    public const int BridgeHeight = LevelHeight * BridgeLevels; //ABC5DC

    public const int CellSize = 256;

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

    public static int SpecialDialog
    {
        get => new Pointer<int>(_specialDialog).Data;
        set => new Pointer<int>(_specialDialog).Ref = value;
    }

    private const nint _specialDialog = 0xA8EDA0;
}

public static class Import
{
    [DllImport("winmm")]
    public static extern uint timeGetTime();
}