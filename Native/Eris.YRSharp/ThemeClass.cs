using Eris.YRSharp.String.Uni;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct ThemeClass
{
    public const nint instance = 0xA83D10;
    public static ref ThemeClass Instance => ref instance.Convert<ThemeClass>().Ref;
    public const nint scoresPresen = 0xA8EC74;
    public static ref Bool ScoresPresen => ref scoresPresen.Convert<Bool>().Ref;

    
    public unsafe Pointer<char> GetID(uint index)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint, nint>)0x721270;
        return func(this.GetThisPointer(), index);
    }

    public unsafe Pointer<char> GetName(uint index)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint, nint>)0x720940;
        return func(this.GetThisPointer(), index);
    }

    public unsafe Pointer<char> GetFilename(uint index)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint, nint>)0x720E10;
        return func(this.GetThisPointer(), index);
    }

    public unsafe UniStringPointer GetUIName(uint index)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint, nint>)0x7209B0;
        return func(this.GetThisPointer(), index);
    }

    public unsafe int GetLength(uint index)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint, int>)0x720E50;
        return func(this.GetThisPointer(), index);
    }

    public unsafe bool IsAvailable(int index)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, bool>)0x721140;
        return func(this.GetThisPointer(), index);
    }

    public unsafe bool IsNormal(int index)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, bool>)0x7211E0;
        return func(this.GetThisPointer(), index);
    }

    public unsafe int FindIndex(Pointer<char> pID)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, int>)0x721210;
        return func(this.GetThisPointer(), pID);
    }

    public unsafe int GetRandomIndex(uint lastTheme)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint, int>)0x720A80;
        return func(this.GetThisPointer(), lastTheme);
    }

    public unsafe void Queue(int index)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, void>)0x720B20;
        func(this.GetThisPointer(), index);
    }

    public unsafe int Play(int index)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, int>)0x720BB0;
        return func(this.GetThisPointer(), index);
    }

    public unsafe void Stop(bool fade = true)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool, void>)0x720EA0;
        func(this.GetThisPointer(), fade);
    }

    public unsafe void Suspend()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x720F70;
        func(this.GetThisPointer());
    }

    public unsafe void AI()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x7209D0;
        func(this.GetThisPointer());
    }

    public unsafe void Scan()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x7207F0;
        func(this.GetThisPointer());
    }

    [FieldOffset(0)] public int CurrentTheme;
    [FieldOffset(4)] public int LastTheme;
    [FieldOffset(8)] public int QueuedTheme;
    [FieldOffset(12)] public int Volume;
    [FieldOffset(16)] public Bool IsScoreRepeat;
    [FieldOffset(17)] public Bool IsFading;
    [FieldOffset(18)] public Bool IsScoreShuffle;
    [FieldOffset(20)] public byte themes;

    public ref DynamicVectorClass<Pointer<ThemeClass>> Themes => ref Pointer<byte>.AsPointer(ref themes)
        .Convert<DynamicVectorClass<Pointer<ThemeClass>>>().Ref;

    [FieldOffset(44)] public nint stream;
    // public Pointer<AudioStream> Stream => stream;
}