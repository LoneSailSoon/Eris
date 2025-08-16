namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct ScriptClass
{
    public unsafe Pointer<ScriptActionNode> GetCurrentAction(Pointer<ScriptActionNode> buffer)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint>)0x691500;
        return func(this.GetThisPointer(), buffer);
    }

    public unsafe Pointer<ScriptActionNode> GetNextAction(Pointer<ScriptActionNode> buffer)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint>)0x691540;
        return func(this.GetThisPointer(), buffer);
    }

    public unsafe bool ClearMission()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)0x691590;
        return func(this.GetThisPointer());
    }

    public unsafe bool SetMission(int nLine)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, bool>)0x6915A0;
        return func(this.GetThisPointer(), nLine);
    }

    public unsafe bool HasNextMission()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)0x6915B0;
        return func(this.GetThisPointer());
    }

    [FieldOffset(0)] public AbstractClass Base;
    [FieldOffset(36)] public nint type;
    public Pointer<ScriptTypeClass> Type => type;
    [FieldOffset(40)] public int field_28;
    [FieldOffset(44)] public int CurrentMission;
}

