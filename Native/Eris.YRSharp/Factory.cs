namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit, Size = 116)]
public struct FactoryClass
{
    public unsafe bool HasProgressChanged()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)0x4C9C60;
        return func(this.GetThisPointer());
    }
    public unsafe bool DemandProduction(Pointer<TechnoTypeClass> pType, Pointer<HouseClass> pOwner, bool shouldQueue)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, bool, bool>)0x4C9C70;
        return func(this.GetThisPointer(), pType, pOwner, shouldQueue);
    }
    public unsafe void SetObject(Pointer<TechnoClass> pObject)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x4C9E10;
        func(this.GetThisPointer(), pObject);
    }
    public unsafe bool Suspend(bool manual)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool, bool>)0x4C9E60;
        return func(this.GetThisPointer(), manual);
    }
    public unsafe bool Unsuspend(bool manual)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool, bool>)0x4C9EA0;
        return func(this.GetThisPointer(), manual);
    }
    public unsafe int GetBuildTimeFrames()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)0x4C9FB0;
        return func(this.GetThisPointer());
    }
    public unsafe bool AbandonProduction()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)0x4C9FF0;
        return func(this.GetThisPointer());
    }
    public unsafe int GetProgress()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)0x4CA120;
        return func(this.GetThisPointer());
    }
    public unsafe bool IsDone()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)0x4CA130;
        return func(this.GetThisPointer());
    }
    public unsafe int GetCostPerStep()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)0x4CA180;
        return func(this.GetThisPointer());
    }
    public unsafe bool CompletedProduction()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)0x4CA1A0;
        return func(this.GetThisPointer());
    }
    public unsafe void StartProduction()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x4CA5A0;
        func(this.GetThisPointer());
    }
    public unsafe bool RemoveOneFromQueue(Pointer<TechnoTypeClass> pItem)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool>)0x4CA620;
        return func(this.GetThisPointer(), pItem);
    }
    public unsafe int CountTotal(Pointer<TechnoTypeClass> pType)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, int>)0x4CA670;
        return func(this.GetThisPointer(), pType);
    }
    public unsafe bool IsQueued(Pointer<TechnoTypeClass> pType)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool>)0x4CA6B0;
        return func(this.GetThisPointer(), pType);
    }


    

    [FieldOffset(0)] public AbstractClass Base;

    [FieldOffset(36)] public ProgressTimer Production;


    [FieldOffset(64)] public byte queuedObjects;
    public ref DynamicVectorClass<Pointer<TechnoTypeClass>> QueuedObjects => ref Pointer<byte>.AsPointer(ref queuedObjects).Convert<DynamicVectorClass<Pointer<TechnoTypeClass>>>().Ref;

    [FieldOffset(88)] public IntPtr _object;
    public Pointer<TechnoClass> Object { get => _object; set => _object = value; }


    [FieldOffset(92)] public byte OnHold;
    [FieldOffset(93)] public byte IsDifferent;
    [FieldOffset(96)] public int Balance;
    [FieldOffset(100)] public int OriginalBalance;
    [FieldOffset(104)] public int SpecialItem;


    [FieldOffset(108)] public nint owner;
    public Pointer<HouseClass> Owner { get => owner; set => owner = value; }


    [FieldOffset(112)] public byte IsSuspended;
    [FieldOffset(113)] public byte IsManual;
}