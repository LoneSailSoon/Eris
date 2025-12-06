using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Eris.BeonSerializer.Streaming;
using Eris.Entity.Generic;
using Eris.Serializer;
using Eris.Utilities.Ini;
using Eris.YRSharp;
using Eris.YRSharp.Helpers;

namespace Eris.Entity;

public class BulletTypeEntity : CommonTypeEntity<BulletTypeEntity, BulletTypeClass>,
    IExtensionActivator<BulletTypeEntity, BulletTypeClass>
{
    public BulletTypeEntity(Pointer<BulletTypeClass> owner) : base(owner)
    {
    }

    public BulletTypeEntity()
    {
    }

    public override void Serialize(IBeonStream stream)
    {
        base.Serialize(stream);
    }

    public override int SerializeType => SerializeRegister.BulletTypeEntitySerializeType;

    public static BulletTypeEntity Create(Pointer<BulletTypeClass> owner)
    {
        return new BulletTypeEntity(owner);
    }

    //[Hook(HookType.AresHook, Address = 0x46BDD9, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "BulletTypeClass_CTOR", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint BulletTypeClass_CTOR(Registers* r)
    {
        var pItem = (Pointer<BulletTypeClass>)r->EAX;

        if (!GlobalSerializer.IsLoading)
        {
            EntityMap.FindOrAllocate(pItem);
        }

        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x46C8B6, Size = 6)]
    [UnmanagedCallersOnly(EntryPoint = "BulletTypeClass_SDDTOR", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint BulletTypeClass_SDDTOR(Registers* r)
    {
        var pItem = (Pointer<BulletTypeClass>)r->ESI;

        EntityMap.Remove(pItem);
        return 0;
    }


    //[Hook(HookType.AresHook, Address = 0x46C730, Size = 8)]
    //[Hook(HookType.AresHook, Address = 0x46C6A0, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "BulletTypeClass_SaveLoad_Prefix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint BulletTypeClass_SaveLoad_Prefix(Registers* r)
    {
        var pItem = r->Stack<Pointer<BulletTypeClass>>(0x4);

        EntityMap.Prepare(pItem);
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x46C722, Size = 4)]
    [UnmanagedCallersOnly(EntryPoint = "BulletTypeClass_Load_Suffix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint BulletTypeClass_Load_Suffix(Registers* r)
    {
        EntityMap.Load();
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x46C74A, Size = 3)]
    [UnmanagedCallersOnly(EntryPoint = "BulletTypeClass_Save_Suffix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint BulletTypeClass_Save_Suffix(Registers* r)
    {
        EntityMap.Save();
        return 0;
    }

    public override void LoadFromIni(Pointer<CCIniClass> pIni)
    {
        base.LoadFromIni(pIni);
        var ini = IniReader.Read(pIni);
    }

    //[Hook(HookType.AresHook, Address = 0x46C429, Size = 0xA)]
    //[Hook(HookType.AresHook, Address = 0x46C41C, Size = 0xA)]
    [UnmanagedCallersOnly(EntryPoint = "BulletTypeClass_LoadFromINI", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint BulletTypeClass_LoadFromINI(Registers* r)
    {
        var pItem = (Pointer<BulletTypeClass>)r->ESI;
        var pIni = r->Stack<Pointer<CCIniClass>>(0x90);

        LoadFromIni(pItem, pIni);
        return 0;
    }

    public override bool GetSection(IniReader reader, out IniSection section)
    {
        section = reader[OwnerRef.BaseAbstractType.ID];
        return true;
    }

    public override bool GetArtSection(IniReader reader, out IniSection section)
    {
        section = reader[OwnerRef.Base.ImageFile];
        return true;
    }
}