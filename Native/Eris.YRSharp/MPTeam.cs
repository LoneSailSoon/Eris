using Eris.YRSharp.String.Uni;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct MPTeam
{
    public unsafe bool IsTeamIncluded(int idx)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, bool>)this.GetVirtualFunctionPointer(1);
        return func(this.GetThisPointer(), idx);
    }

    public unsafe bool SetPlayerTeam(int idxPlayer)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, bool>)this.GetVirtualFunctionPointer(2);
        return func(this.GetThisPointer(), idxPlayer);
    }

    [FieldOffset(4)] public nint title;
    public UniStringPointer Title => title;
    [FieldOffset(8)] public int Index;
}

[StructLayout(LayoutKind.Explicit)]
public struct MPSiegeDefenderTeam
{
    public static unsafe void Constructor(Pointer<MPSiegeDefenderTeam> pThis)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint>)0x5CAE10;
        func(pThis);
    }

    [FieldOffset(0)] public MPTeam Base;
}

[StructLayout(LayoutKind.Explicit)]
public struct MPSiegeAttackerTeam
{
    public static unsafe void Constructor(Pointer<MPSiegeAttackerTeam> pThis)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint>)0x5CAEB0;
        func(pThis);
    }

    [FieldOffset(0)] public MPTeam Base;
}

[StructLayout(LayoutKind.Explicit)]
public struct MPObserverTeam
{
    public static unsafe void Constructor(Pointer<MPObserverTeam> pThis)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint>)0x5C9470;
        func(pThis);
    }

    [FieldOffset(0)] public MPTeam Base;
}