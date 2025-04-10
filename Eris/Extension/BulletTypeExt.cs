using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Eris.Extension.Generic;
using Eris.Serializer;
using Eris.Utilities.Ini;
using NaegleriaSerializer.Streaming;
using PatcherYrSharp;
using PatcherYrSharp.Helpers;

namespace Eris.Extension;

public class BulletTypeExt : CommonTypeExtension<BulletTypeExt, BulletTypeClass>,
    IExtensionActivator<BulletTypeExt, BulletTypeClass>
{
    public BulletTypeExt(Pointer<BulletTypeClass> owner) : base(owner)
    {
    }

    public BulletTypeExt()
    {
    }

    public override void Serialize(INaegleriaStream stream)
    {
    }

    public override int SerializeType => SerializeRegister.BulletTypeExtSerializeType;

    public static BulletTypeExt Create(Pointer<BulletTypeClass> owner)
    {
        return new BulletTypeExt(owner);
    }

    //[Hook(HookType.AresHook, Address = 0x46BDD9, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "BulletTypeClass_CTOR", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 BulletTypeClass_CTOR(Registers* r)
    {
        var pItem = (Pointer<BulletTypeClass>)r->EAX;

        if (!GlobalSerializer.IsLoading)
        {
            ExtMap.FindOrAllocate(pItem);
        }

        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x46C8B6, Size = 6)]
    [UnmanagedCallersOnly(EntryPoint = "BulletTypeClass_SDDTOR", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 BulletTypeClass_SDDTOR(Registers* r)
    {
        var pItem = (Pointer<BulletTypeClass>)r->ESI;

        ExtMap.Remove(pItem);
        return 0;
    }


    //[Hook(HookType.AresHook, Address = 0x46C730, Size = 8)]
    //[Hook(HookType.AresHook, Address = 0x46C6A0, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "BulletTypeClass_SaveLoad_Prefix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 BulletTypeClass_SaveLoad_Prefix(Registers* r)
    {
        var pItem = r->Stack<Pointer<BulletTypeClass>>(0x4);

        ExtMap.Prepare(pItem);
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x46C722, Size = 4)]
    [UnmanagedCallersOnly(EntryPoint = "BulletTypeClass_Load_Suffix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 BulletTypeClass_Load_Suffix(Registers* r)
    {
        ExtMap.Load();
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x46C74A, Size = 3)]
    [UnmanagedCallersOnly(EntryPoint = "BulletTypeClass_Save_Suffix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 BulletTypeClass_Save_Suffix(Registers* r)
    {
        ExtMap.Save();
        return 0;
    }

    public override void LoadFromIni(Pointer<CCINIClass> pIni)
    {
        var ini = IniReader.Default;
        ini.SetCurrentIni(pIni);
    }

    //[Hook(HookType.AresHook, Address = 0x46C429, Size = 0xA)]
    //[Hook(HookType.AresHook, Address = 0x46C41C, Size = 0xA)]
    [UnmanagedCallersOnly(EntryPoint = "BulletTypeClass_LoadFromINI", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 BulletTypeClass_LoadFromINI(Registers* r)
    {
        var pItem = (Pointer<BulletTypeClass>)r->ESI;
        var pIni = r->Stack<Pointer<CCINIClass>>(0x90);

        LoadFromIni(pItem, pIni);
        return 0;
    }

}