namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct LinkClass
{
    public unsafe Pointer<LinkClass> GetNext()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint>)this.GetVirtualFunctionPointer(1);
        return func(this.GetThisPointer());
    }
    public unsafe Pointer<LinkClass> GetPrev()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint>)this.GetVirtualFunctionPointer(2);
        return func(this.GetThisPointer());
    }
    public unsafe Pointer<LinkClass> Add(Pointer<LinkClass> another)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint>)this.GetVirtualFunctionPointer(3);
        return func(this.GetThisPointer(), another);
    }
    public unsafe Pointer<LinkClass> AddTail(Pointer<LinkClass> another)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint>)this.GetVirtualFunctionPointer(4);
        return func(this.GetThisPointer(), another);
    }
    public unsafe Pointer<LinkClass> AddHead(Pointer<LinkClass> another)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint>)this.GetVirtualFunctionPointer(5);
        return func(this.GetThisPointer(), another);
    }
    public unsafe Pointer<LinkClass> HeadOfList(Pointer<LinkClass> another)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint>)this.GetVirtualFunctionPointer(6);
        return func(this.GetThisPointer(), another);
    }
    public unsafe Pointer<LinkClass> TailOfList(Pointer<LinkClass> another)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint>)this.GetVirtualFunctionPointer(7);
        return func(this.GetThisPointer(), another);
    }
    public unsafe void Zap()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(8);
        func(this.GetThisPointer());
    }
    public unsafe Pointer<LinkClass> Remove()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint>)this.GetVirtualFunctionPointer(9);
        return func(this.GetThisPointer());
    }

    [FieldOffset(0)] public nint vftable;
    [FieldOffset(4)] public nint next;
    public Pointer<LinkClass> Next => next;
    [FieldOffset(8)] public nint previous;
    public Pointer<LinkClass> Previous => previous;
}