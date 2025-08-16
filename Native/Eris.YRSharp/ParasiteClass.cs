namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct ParasiteClass
{
    public unsafe void UpdateSquid()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x6297F0;
        func(this.GetThisPointer());
    }

    public unsafe bool UpdateGrapple()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)0x629720;
        return func(this.GetThisPointer());
    }

    public unsafe void ExitUnit()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x62A4A0;
        func(this.GetThisPointer());
    }

    public unsafe bool CanInfect(Pointer<FootClass> pTarget)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool>)0x62A8E0;
        return func(this.GetThisPointer(), pTarget);
    }

    public unsafe void TryInfect(Pointer<FootClass> pTarget)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x62A980;
        func(this.GetThisPointer(), pTarget);
    }

    public unsafe bool CanExistOnVictimCell()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)0x62AB40;
        return func(this.GetThisPointer());
    }


    [FieldOffset(0)] public AbstractClass Base;
    [FieldOffset(36)] public nint owner;
    public Pointer<FootClass> Owner => owner;
    [FieldOffset(40)] public nint victim;
    public Pointer<FootClass> Victim => victim;
    [FieldOffset(44)] public TimerStruct SuppressionTimer;
    [FieldOffset(56)] public TimerStruct DamageDeliveryTimer;
    [FieldOffset(68)] public nint grappleAnim;
    public Pointer<AnimClass> GrappleAnim => grappleAnim;
    [FieldOffset(72)] public ParasiteState GrappleState;
    [FieldOffset(76)] public int GrappleAnimFrame;
    [FieldOffset(80)] public int GrappleAnimDelay;
    [FieldOffset(84)] public Bool GrappleAnimGotInvalid;

}