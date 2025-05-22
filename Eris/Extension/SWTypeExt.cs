
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Eris.Extension.Generic;
using Eris.Serializer;
using Eris.Utilities.Ini;
using Eris.YRSharp;
using Eris.YRSharp.Helpers;
using NaegleriaSerializer.Streaming;

namespace Eris.Extension;

public class SWTypeExt : CommonTypeExtension<SWTypeExt, SuperWeaponTypeClass>,
    IExtensionActivator<SWTypeExt, SuperWeaponTypeClass>
{
    public SWTypeExt(Pointer<SuperWeaponTypeClass> owner) : base(owner)
    {
    }

    public SWTypeExt()
    {
    }

    public override void Serialize(INaegleriaStream stream)
    {
        base.Serialize(stream);
    }

    public override int SerializeType => SerializeRegister.SuperWeaponTypeExtSerializeType;

    public static SWTypeExt Create(Pointer<SuperWeaponTypeClass> owner)
    {
        return new SWTypeExt(owner);
    }

    //[Hook(HookType.AresHook, Address = 0x6CE6F6, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "SuperWeaponTypeClass_CTOR", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint SuperWeaponTypeClass_CTOR(Registers* r)
    {
        var pItem = (Pointer<SuperWeaponTypeClass>)r->EAX;

        if (!GlobalSerializer.IsLoading)
        {
            ExtMap.FindOrAllocate(pItem);
        }
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x6CEFE0, Size = 8)]
    [UnmanagedCallersOnly(EntryPoint = "SuperWeaponTypeClass_DTOR", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint SuperWeaponTypeClass_DTOR(Registers* r)
    {
        var pItem = (Pointer<SuperWeaponTypeClass>)r->ECX;

        ExtMap.Remove(pItem);
        return 0;
    }

    
    //[Hook(HookType.AresHook, Address = 0x6CE8D0, Size = 8)]
    //[Hook(HookType.AresHook, Address = 0x6CE800, Size = 0xA)]
    [UnmanagedCallersOnly(EntryPoint = "SuperWeaponTypeClass_SaveLoad_Prefix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint SuperWeaponTypeClass_SaveLoad_Prefix(Registers* r)
    {
        var pItem = r->Stack<Pointer<SuperWeaponTypeClass>>(0x4);

        ExtMap.Prepare(pItem);
        return 0;
    }
    
    //[Hook(HookType.AresHook, Address = 0x6CE8BE, Size = 7)]
    [UnmanagedCallersOnly(EntryPoint = "SuperWeaponTypeClass_Load_Suffix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint SuperWeaponTypeClass_Load_Suffix(Registers* r)
    {
        ExtMap.Load();
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x6CE8EA, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "SuperWeaponTypeClass_Save_Suffix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint SuperWeaponTypeClass_Save_Suffix(Registers* r)
    {
        ExtMap.Save();
        return 0;
    }

    public override void LoadFromIni(Pointer<CCIniClass> pIni)
    {
        base.LoadFromIni(pIni);
        var ini = IniReader.Default;
        ini.SetCurrentIni(pIni);
    }
    
    //[Hook(HookType.AresHook, Address = 0x6CEE50, Size = 0xA)]
    //[Hook(HookType.AresHook, Address = 0x6CEE43, Size = 0xA)]
    [UnmanagedCallersOnly(EntryPoint = "SuperWeaponTypeClass_LoadFromINI", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint SuperWeaponTypeClass_LoadFromINI(Registers* r)
    {
        var pItem = (Pointer<SuperWeaponTypeClass>)r->EBP;
        var pIni = r->Stack<Pointer<CCIniClass>>(0x3FC);

        LoadFromIni(pItem, pIni);
        return 0;
    }

}