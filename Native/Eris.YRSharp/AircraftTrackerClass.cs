using System.Runtime.CompilerServices;
using Eris.YRSharp.Vector;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit, Size = 9624)]
public struct AircraftTrackerClass
{
    public const nint pInstance = 0x887888;
    
    public static ref AircraftTrackerClass Instance => ref pInstance.Convert<AircraftTrackerClass>().Ref;
    
    public unsafe int SetArea(Pointer<CellClass> pCell, int range)
    {
        var func = (delegate*unmanaged[Thiscall]<nint, nint, int, int>)0x412B40;
        return func(this.GetThisPointer(),pCell, range);
    }

    public unsafe Pointer<TechnoClass> Get()
    {
        var func = (delegate*unmanaged[Thiscall]<nint, nint>)0x4137A0;
        return func(this.GetThisPointer());
    }

    public unsafe void Add(Pointer<TechnoClass> entry)
    {
        var func = (delegate*unmanaged[Thiscall]<nint, nint, int>)0x4134A0;
        func(this.GetThisPointer(), entry);
    }
    
    public unsafe void Update(Pointer<TechnoClass> entry, CellStruct oldPos, CellStruct newPos)
    {
        var func = (delegate*unmanaged[Thiscall]<nint, nint, uint, uint, int>)0x4138C0;
        func(this.GetThisPointer(), entry, *(uint*)&oldPos, *(uint*)&newPos);
    }
    
    public unsafe void Remove(Pointer<TechnoClass> entry)
    {
        var func = (delegate*unmanaged[Thiscall]<nint, nint, int>)0x4135D0;
        func(this.GetThisPointer(), entry);
    }
    
    public unsafe bool Clear()
    {
        var func = (delegate*unmanaged[Thiscall]<nint, bool>)0x413800;
        return func(this.GetThisPointer());
    }
    
    public unsafe bool IsJumpjet(Pointer<TechnoClass> entry)
    {
        var func = (delegate*unmanaged[Thiscall]<nint, nint, bool>)0x4135A0;
        return func(this.GetThisPointer(), entry);
    }

    public unsafe int GetVectorIndex(CellStruct entry)
    {
        var func = (delegate*unmanaged[Thiscall]<nint, uint, int>)0x412AC0;
        return func(this.GetThisPointer(), *(uint*)&entry);
    }



    [FieldOffset(0)] public byte trackerVectors;

    public FixedArray<DynamicVectorClass<Pointer<TechnoClass>>> TrackerVectors =>
        new(ref Unsafe.As<byte, DynamicVectorClass<Pointer<TechnoClass>>>(ref trackerVectors), 400);
    
    [FieldOffset(9600)] public byte currentVector;
    
    public ref DynamicVectorClass<Pointer<TechnoClass>> CurrentVector => ref Pointer<byte>.AsPointer(ref currentVector).Convert<DynamicVectorClass<Pointer<TechnoClass>>>().Ref;
}