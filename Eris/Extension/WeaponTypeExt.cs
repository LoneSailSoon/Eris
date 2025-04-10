using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Eris.Extension.Generic;
using Eris.Serializer;
using Eris.Utilities.Ini;
using NaegleriaSerializer.Streaming;
using PatcherYrSharp;
using PatcherYrSharp.Helpers;

namespace Eris.Extension;

public class WeaponTypeExt : CommonTypeExtension<WeaponTypeExt, WeaponTypeClass>,
    IExtensionActivator<WeaponTypeExt, WeaponTypeClass>
{
    public WeaponTypeExt(Pointer<WeaponTypeClass> owner) : base(owner)
    {
    }

    public WeaponTypeExt()
    {
    }

    public override void Serialize(INaegleriaStream stream)
    {
    }

    public override int SerializeType => SerializeRegister.WeaponTypeExtSerializeType;

    public static WeaponTypeExt Create(Pointer<WeaponTypeClass> owner)
    {
        return new WeaponTypeExt(owner);
    }

    //[Hook(HookType.AresHook, Address = 0x771EE9, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "WeaponTypeClass_CTOR", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 WeaponTypeClass_CTOR(Registers* r)
    {
        var pItem = (Pointer<WeaponTypeClass>)r->ESI;

        if (!GlobalSerializer.IsLoading)
        {
            ExtMap.FindOrAllocate(pItem);
        }
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x77311D, Size = 6)]
    [UnmanagedCallersOnly(EntryPoint = "WeaponTypeClass_SDDTOR", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 WeaponTypeClass_SDDTOR(Registers* r)
    {
        var pItem = (Pointer<WeaponTypeClass>)r->ESI;

        ExtMap.Remove(pItem);
        return 0;
    }

    
    //[Hook(HookType.AresHook, Address = 0x772EB0, Size = 5)]
    //[Hook(HookType.AresHook, Address = 0x772CD0, Size = 7)]
    [UnmanagedCallersOnly(EntryPoint = "WeaponTypeClass_SaveLoad_Prefix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 WeaponTypeClass_SaveLoad_Prefix(Registers* r)
    {
        var pItem = r->Stack<Pointer<WeaponTypeClass>>(0x4);

        ExtMap.Prepare(pItem);
        return 0;
    }
    
    //[Hook(HookType.AresHook, Address = 0x772EA6, Size = 6)]
    [UnmanagedCallersOnly(EntryPoint = "WeaponTypeClass_Load_Suffix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 WeaponTypeClass_Load_Suffix(Registers* r)
    {
        ExtMap.Load();
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x772F8C, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "WeaponTypeClass_Save_Suffix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 WeaponTypeClass_Save_Suffix(Registers* r)
    {
        ExtMap.Save();
        return 0;
    }
    
    public override void LoadFromIni(Pointer<CCINIClass> pIni)
    {
        var ini = IniReader.Default;
        ini.SetCurrentIni(pIni);
    }

    //[Hook(HookType.AresHook, Address = 0x7729C7, Size = 5)]
    //[Hook(HookType.AresHook, Address = 0x7729D6, Size = 5)]
    //[Hook(HookType.AresHook, Address = 0x7729B0, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "WeaponTypeClass_LoadFromINI", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 WeaponTypeClass_LoadFromINI(Registers* r)
    {
        var pItem = (Pointer<WeaponTypeClass>)r->ESI;
        var pIni = r->Stack<Pointer<CCINIClass>>(0xE4);

        LoadFromIni(pItem, pIni);
        return 0;
    }

}