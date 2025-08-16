using System.Numerics;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct BounceClass
{
    public enum Status : int {
        None = 0,
        Bounce = 1,
        Impact = 2
    };
    
    public unsafe void Initialize(Pointer<CoordStruct> coords, double elasticity, double gravity, double maxVelocity, Pointer<Vector3> velocity, double angularVelocity)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, double, double, double, nint, double, void>)0x4397E0;
        func(this.GetThisPointer(), coords, elasticity, gravity, maxVelocity, velocity, angularVelocity);
    }
    public unsafe Pointer<CoordStruct> GetCoords(Pointer<CoordStruct> pBuffer)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint>)0x4399A0;
        return func(this.GetThisPointer(), pBuffer);
    }
    public unsafe Pointer<Matrix3D> GetDrawingMatrix(Pointer<Matrix3D> pBuffer)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint>)0x4399E0;
        return func(this.GetThisPointer(), pBuffer);
    }
    public unsafe Status Update()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, Status>)0x439B00;
        return func(this.GetThisPointer());
    }

    
    
    [FieldOffset(0)] public double Elasticity;
    [FieldOffset(8)] public double Gravity;
    [FieldOffset(16)] public double MaxVelocity;
    [FieldOffset(24)] public Vector3 Coords;
    [FieldOffset(36)] public Vector3 Velocity;
    [FieldOffset(48)] public Quaternion CurrentAngle;
    [FieldOffset(64)] public Quaternion AngularVelocity;
}

