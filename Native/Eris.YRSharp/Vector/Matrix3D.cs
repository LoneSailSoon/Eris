using System.Numerics;
using System.Runtime.InteropServices;
using Eris.YRSharp.Helpers;

namespace Eris.YRSharp.Vector;

[StructLayout(LayoutKind.Explicit, Size = 48)]
public struct Matrix3D(
    float i1 = 0, float i2 = 0, float i3 = 0, 
    float j1 = 0, float j2 = 0, float j3 = 0,
    float k1 = 0, float k2 = 0, float k3 = 0, 
    float o1 = 0, float o2 = 0, float o3 = 0)
{
    
    [FieldOffset(0)]public Vector3 I;
    [FieldOffset(0)]public float I1 = i1;
    [FieldOffset(4)]public float I2 = i2;
    [FieldOffset(8)]public float I3 = i3;
    
    
    [FieldOffset(12)]public Vector3 J;
    [FieldOffset(12)]public float J1 = j1;
    [FieldOffset(16)]public float J2 = j2;
    [FieldOffset(20)]public float J3 = j3;
    
    [FieldOffset(24)]public Vector3 K;
    [FieldOffset(24)]public float K1 = k1;
    [FieldOffset(28)]public float K2 = k2;
    [FieldOffset(32)]public float K3 = k3;
    
    
    [FieldOffset(36)]public Vector3 O;
    [FieldOffset(36)]public float O1 = o1;
    [FieldOffset(40)]public float O2 = o2;
    [FieldOffset(44)]public float O3 = o3;


    public Matrix3D(Vector3 i = default, Vector3 j = default, Vector3 k = default, Vector3 o = default) :
        this(
            i.X, i.Y, i.Z,
            j.X, j.Y, j.Z,
            k.X, k.Y, k.Z,
            o.X, o.Y, o.Z)
    {
        
    }

    public static readonly Matrix3D Empty = new();
    public static readonly Matrix3D Identity = new(1, 0, 0, 0, 1, 0, 0, 0, 1);

    public unsafe void MakeIdentity()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x5AE860;
        func(this.GetThisPointer());
    }

    public unsafe void Translate(float x, float y, float z)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, float, float, float, void>)0x5AE890;
        func(this.GetThisPointer(), x, y, z);
    }

    public unsafe void Translate(Vector3 vector3D)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x5AE8F0;
        func(this.GetThisPointer(), vector3D.GetThisPointer());
    }

    public unsafe void TranslateX(float x)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, float, void>)0x5AE980;
        func(this.GetThisPointer(), x);
    }

    public unsafe void TranslateY(float y)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, float, void>)0x5AE9B0;
        func(this.GetThisPointer(), y);
    }

    public unsafe void TranslateZ(float z)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, float, void>)0x5AE9E0;
        func(this.GetThisPointer(), z);
    }

    public unsafe void Scale(float factor)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, float, void>)0x5AEA10;
        func(this.GetThisPointer(), factor);
    }

    public unsafe void Scale(float x, float y, float z)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, float, float, float, void>)0x5AEA70;
        func(this.GetThisPointer(), z, y, z);
    }

    public unsafe void ScaleX(float x)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, float, void>)0x5AEAD0;
        func(this.GetThisPointer(), x);
    }

    public unsafe void ScaleY(float y)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, float, void>)0x5AEAF0;
        func(this.GetThisPointer(), y);
    }

    public unsafe void ScaleZ(float z)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, float, void>)0x5AEB20;
        func(this.GetThisPointer(), z);
    }

    public unsafe void ShearYz(float y, float z)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, float, float, void>)0x5AEB50;
        func(this.GetThisPointer(), y, z);
    }

    public unsafe void ShearXy(float x, float y)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, float, float, void>)0x5AEBA0;
        func(this.GetThisPointer(), x, y);
    }

    public unsafe void ShearXz(float x, float z)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, float, float, void>)0x5AEBF0;
        func(this.GetThisPointer(), x, z);
    }

    public unsafe void PreRotateX(float theta)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, float, void>)0x5AEC40;
        func(this.GetThisPointer(), theta);
    }

    public unsafe void PreRotateY(float theta)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, float, void>)0x5AED50;
        func(this.GetThisPointer(), theta);
    }

    public unsafe void PreRotateZ(float theta)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, float, void>)0x5AEE50;
        func(this.GetThisPointer(), theta);
    }

    public unsafe void RotateX(float theta)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, float, void>)0x5AEF60;
        func(this.GetThisPointer(), theta);
    }

    public unsafe void RotateX(float sin, float cos)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, float, float, void>)0x5AF000;
        func(this.GetThisPointer(), sin, cos);
    }

    public unsafe void RotateY(float theta)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, float, void>)0x5AF080;
        func(this.GetThisPointer(), theta);
    }

    public unsafe void RotateY(float sin, float cos)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, float, float, void>)0x5AF120;
        func(this.GetThisPointer(), sin, cos);
    }

    public unsafe void RotateZ(float theta)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, float, void>)0x5AF1A0;
        func(this.GetThisPointer(), theta);
    }

    public unsafe void RotateZ(float sin, float cos)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, float, float, void>)0x5AF240;
        func(this.GetThisPointer(), sin, cos);
    }

    public unsafe float GetXVal()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, float>)0x5AF2C0;
        return func(this.GetThisPointer());
    }

    public unsafe float GetYVal()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, float>)0x5AF310;
        return func(this.GetThisPointer());
    }

    public unsafe float GetZVal()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, float>)0x5AF360;
        return func(this.GetThisPointer());
    }

    public unsafe float GetXRotation()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, float>)0x5AF3B0;
        return func(this.GetThisPointer());
    }

    public unsafe float GetYRotation()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, float>)0x5AF410;
        return func(this.GetThisPointer());
    }

    public unsafe float GetZRotation()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, float>)0x5AF470;
        return func(this.GetThisPointer());
    }

    public unsafe Pointer<Vector3> RotateVector(Pointer<Vector3> ret, Pointer<Vector3> rotate)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, nint>)0x5AF4D0;
        return func(this.GetThisPointer(), ret, rotate);
    }

    public Vector3 RotateVector(ref Vector3 rotate)
    {
        Vector3 buffer = default;
        RotateVector(Pointer<Vector3>.AsPointer(ref buffer), Pointer<Vector3>.AsPointer(ref rotate));
        return buffer;
    }

    public unsafe void LookAt1(Vector3 p, Vector3 t, float roll)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, float, void>)0x5AF550;
        func(this.GetThisPointer(), p.GetThisPointer(), t.GetThisPointer(), roll);
    }

    public unsafe void LookAt2(Vector3 p, Vector3 t, float roll)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, float, void>)0x5AF710;
        func(this.GetThisPointer(), p.GetThisPointer(), t.GetThisPointer(), roll);
    }

    public void Deconstruct(out Vector3 i, out Vector3 j, out Vector3 k, out Vector3 o)
    {
        i = I;
        j = J;
        k = K;
        o = O;
    }

    public override string ToString()
    {
        return $"""
             |{I1}, {J1}, {K1}, {O1}|
             |{I2}, {J2}, {K2}, {O2}|
             |{I3}, {J3}, {K3}, {O3}|
             """;
    }
}