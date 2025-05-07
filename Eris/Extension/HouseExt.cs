using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Eris.Extension.Generic;
using Eris.Serializer;
using NaegleriaSerializer.Streaming;
using PatcherYrSharp;
using PatcherYrSharp.Helpers;

namespace Eris.Extension;

public class HouseExt: CommonInstanceExtension<HouseExt, HouseClass, HouseTypeExt, HouseTypeClass>,
    IExtensionActivator<HouseExt, HouseClass>
{
    public HouseExt(Pointer<HouseClass> owner) : base(owner)
    {
    }

    public HouseExt()
    {
    }

    public override void Serialize(INaegleriaStream stream)
    {
        base.Serialize(stream);
    }

    public override int SerializeType => SerializeRegister.HouseExtSerializeType;

    public static HouseExt Create(Pointer<HouseClass> owner)
    {
        return new HouseExt(owner);
    }
    
    //[Hook(HookType.AresHook, Address = 0x4F6532, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "HouseClass_CTOR", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 HouseClass_CTOR(Registers* r)
    {
        var pItem = (Pointer<HouseClass>)r->EAX;

        if (!GlobalSerializer.IsLoading)
        {
            ExtMap.FindOrAllocate(pItem);
        }
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x4F7140, Size = 6)]
    [UnmanagedCallersOnly(EntryPoint = "HouseClass_DTOR", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 HouseClass_DTOR(Registers* r)
    {
        var pItem = (Pointer<HouseClass>)r->ECX;
        
        ExtMap.Remove(pItem);
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x504080, Size = 5)]
    //[Hook(HookType.AresHook, Address = 0x503040, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "HouseClass_SaveLoad_Prefix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 HouseClass_SaveLoad_Prefix(Registers* r)
    {
        var pItem = r->Stack<Pointer<HouseClass>>(0x4);

        ExtMap.Prepare(pItem);
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x504069, Size = 7)]
    [UnmanagedCallersOnly(EntryPoint = "HouseClass_Load_Suffix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 HouseClass_Load_Suffix(Registers* r)
    {
        ExtMap.Load();
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x5046DE, Size = 7)]
    [UnmanagedCallersOnly(EntryPoint = "HouseClass_Save_Suffix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 HouseClass_Save_Suffix(Registers* r)
    {
        ExtMap.Save();
        return 0;
    }
    
}