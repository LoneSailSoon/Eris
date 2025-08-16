namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct PreviewClass
{
    public unsafe void DrawStartPoints(uint hWnd)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint, void>)0x640710;
        func(this.GetThisPointer(), hWnd);
    }

    public unsafe bool DrawMap(Pointer<DSurface> surface)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool>)0x640A40;
        return func(this.GetThisPointer(), surface);
    }

    public unsafe void GeneratePreviewImage()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x641140;
        func(this.GetThisPointer());
    }

    public unsafe bool WritePreviewPack(Pointer<IniClass> ini)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool>)0x6418B0;
        return func(this.GetThisPointer(), ini);
    }

    public unsafe bool ReadPreviewPack(Pointer<IniClass> ini)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool>)0x641B00;
        return func(this.GetThisPointer(), ini);
    }

    public unsafe bool ReadPCXPreview(Pointer<char> lpFile)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool>)0x641DB0;
        return func(this.GetThisPointer(), lpFile);
    }

    public unsafe bool ReadPreview(Pointer<char> lpFile)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool>)0x641EE0;
        return func(this.GetThisPointer(), lpFile);
    }

    public unsafe Pointer<byte> CreatePalettedPreview(int nResolution, Pointer<int> BytesWritten)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, nint, nint>)0x642130;
        return func(this.GetThisPointer(), nResolution, BytesWritten);
    }

    public unsafe void CreatePreviewSurface(Pointer<byte> pData)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x6425F0;
        func(this.GetThisPointer(), pData);
    }

    [FieldOffset(0)] public nint imageSurface;
    public Pointer<DSurface> ImageSurface => imageSurface;
}