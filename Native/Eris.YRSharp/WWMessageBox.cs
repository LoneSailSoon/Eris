using Eris.YRSharp.String.Uni;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct WWMessageBox
{
    public const nint instance = 0x82083C;
    public static ref WWMessageBox Instance => ref instance.Convert<WWMessageBox>().Ref;


    public unsafe Result Process(UniStringPointer pMsg, UniStringPointer pBtn1, UniStringPointer pBtn2,
        UniStringPointer pBtn3, bool bUkn)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, nint, nint, bool, Result>)0x5D3490;
        return func(this.GetThisPointer(), pMsg, pBtn1, pBtn2, pBtn3, bUkn);
    }

    
    [FieldOffset(0)] public nint captain;
    public UniStringPointer Captain => captain;

}

public enum Result
{
    Button1 = 0, Button2 = 1, Button3 = 2,
    OK = Button1, Cancel = Button2
}