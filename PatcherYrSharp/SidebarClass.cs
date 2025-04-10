using PatcherYrSharp.GeneralDefinitions;
using PatcherYrSharp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYrSharp;

[StructLayout(LayoutKind.Explicit, Size = 0x5518)]
public struct SidebarClass
{
    public static readonly nint ppInstance = 0x87F7E8;
    public static Pointer<SidebarClass> pInstance { get => ppInstance; }
    public static ref SidebarClass Instance { get => ref pInstance.Ref; }

    public unsafe bool AddCameo(AbstractType absType, int idxType)
        => ((delegate* unmanaged[Thiscall]<nint, AbstractType, int, Bool>)0x6A6300)(this.GetThisPointer(), absType, idxType);

    //public static unsafe int GetObjectTabIdx(AbstractType abs, int idxType, int unused)
    //    => ((delegate* unmanaged[Thiscall]<int, AbstractType, int, int, int>)ASM.FastCallTransferStation)(0x6ABC60, abs, idxType, unused);

    public unsafe void RepaintSidebar(int tab = 0)
        => ((delegate* unmanaged[Thiscall]<nint, int, void>)0x6A60A0)(this.GetThisPointer(), tab);

    [FieldOffset(21404)] public int ActiveTabIndex;
}
