using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Eris.Extension.Generic;
using Eris.Serializer;
using Eris.Utilities.Ini;
using NaegleriaSerializer.Streaming;
using PatcherYrSharp;
using PatcherYrSharp.Helpers;

namespace Eris.Extension;


public class HouseTypeExt : CommonTypeExtension<HouseTypeExt, HouseTypeClass>,
    IExtensionActivator<HouseTypeExt, HouseTypeClass>
{
    public HouseTypeExt(Pointer<HouseTypeClass> owner) : base(owner)
    {
    }

    public HouseTypeExt()
    {
    }

    public override void Serialize(INaegleriaStream stream)
    {
        base.Serialize(stream);
    }

    public override int SerializeType => SerializeRegister.HouseTypeExtSerializeType;

    public static HouseTypeExt Create(Pointer<HouseTypeClass> owner)
    {
        return new HouseTypeExt(owner);
    }


    //[Hook(HookType.AresHook, Address = 0x511635, Size = 5)]
    //[Hook(HookType.AresHook, Address = 0x511643, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "HouseTypeClass_CTOR", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 HouseTypeClass_CTOR(Registers* r)
    {
        var pItem = (Pointer<HouseTypeClass>)r->EAX;

        if (!GlobalSerializer.IsLoading)
        {
            ExtMap.FindOrAllocate(pItem);
        }
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x512760, Size = 6)]
    [UnmanagedCallersOnly(EntryPoint = "HouseTypeClass_DTOR", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 HouseTypeClass_DTOR(Registers* r)
    {
        var pItem = (Pointer<HouseTypeClass>)r->ECX;

        ExtMap.Remove(pItem);
        return 0;
    }

    
    //[Hook(HookType.AresHook, Address = 0x512480, Size = 5)]
    //[Hook(HookType.AresHook, Address = 0x512290, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "HouseTypeClass_SaveLoad_Prefix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 HouseTypeClass_SaveLoad_Prefix(Registers* r)
    {
        var pItem = r->Stack<Pointer<HouseTypeClass>>(0x4);

        ExtMap.Prepare(pItem);
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x51246D, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "HouseTypeClass_Load_Suffix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 HouseTypeClass_Load_Suffix(Registers* r)
    {
        ExtMap.Load();
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x51255C, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "HouseTypeClass_Save_Suffix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 HouseTypeClass_Save_Suffix(Registers* r)
    {
        ExtMap.Save();
        return 0;
    }

    public override void LoadFromIni(Pointer<CCINIClass> pIni)
    {
        base.LoadFromIni(pIni);
        var ini = IniReader.Default;
        ini.SetCurrentIni(pIni);
    }
    
    //[Hook(HookType.AresHook, Address = 0x51215A, Size = 5)]
    //[Hook(HookType.AresHook, Address = 0x51214F, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "HouseTypeClass_LoadFromINI", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 HouseTypeClass_LoadFromINI(Registers* r)
    {
        var pItem = (Pointer<HouseTypeClass>)r->EBX;
        var pIni = r->Base<Pointer<CCINIClass>>(0x8);

        LoadFromIni(pItem, pIni);
        return 0;
    }

}