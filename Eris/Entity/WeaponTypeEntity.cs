using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Eris.BeonSerializer.Streaming;
using Eris.Entity.Generic;
using Eris.Serializer;
using Eris.Utilities.Ini;
using Eris.YRSharp;
using Eris.YRSharp.Helpers;

namespace Eris.Entity;

public class WeaponTypeEntity : CommonTypeEntity<WeaponTypeEntity, WeaponTypeClass>,
    IExtensionActivator<WeaponTypeEntity, WeaponTypeClass>
{
    public WeaponTypeEntity(Pointer<WeaponTypeClass> owner) : base(owner)
    {
    }

    public WeaponTypeEntity()
    {
    }

    public override void Serialize(IBeonStream stream)
    {
        base.Serialize(stream);
    }

    public override int SerializeType => SerializeRegister.WeaponTypeEntitySerializeType;

    public static WeaponTypeEntity Create(Pointer<WeaponTypeClass> owner)
    {
        return new WeaponTypeEntity(owner);
    }

    //[Hook(HookType.AresHook, Address = 0x771EE9, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "WeaponTypeClass_CTOR", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint WeaponTypeClass_CTOR(Registers* r)
    {
        var pItem = (Pointer<WeaponTypeClass>)r->ESI;

        if (!GlobalSerializer.IsLoading)
        {
            EntityMap.FindOrAllocate(pItem);
        }
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x77311D, Size = 6)]
    [UnmanagedCallersOnly(EntryPoint = "WeaponTypeClass_SDDTOR", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint WeaponTypeClass_SDDTOR(Registers* r)
    {
        var pItem = (Pointer<WeaponTypeClass>)r->ESI;

        EntityMap.Remove(pItem);
        return 0;
    }

    
    //[Hook(HookType.AresHook, Address = 0x772EB0, Size = 5)]
    //[Hook(HookType.AresHook, Address = 0x772CD0, Size = 7)]
    [UnmanagedCallersOnly(EntryPoint = "WeaponTypeClass_SaveLoad_Prefix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint WeaponTypeClass_SaveLoad_Prefix(Registers* r)
    {
        var pItem = r->Stack<Pointer<WeaponTypeClass>>(0x4);

        EntityMap.Prepare(pItem);
        return 0;
    }
    
    //[Hook(HookType.AresHook, Address = 0x772EA6, Size = 6)]
    [UnmanagedCallersOnly(EntryPoint = "WeaponTypeClass_Load_Suffix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint WeaponTypeClass_Load_Suffix(Registers* r)
    {
        EntityMap.Load();
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x772F8C, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "WeaponTypeClass_Save_Suffix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint WeaponTypeClass_Save_Suffix(Registers* r)
    {
        EntityMap.Save();
        return 0;
    }
    
    public override void LoadFromIni(Pointer<CCIniClass> pIni)
    {
        base.LoadFromIni(pIni);
        var ini = IniReader.Read(pIni);
    }

    //[Hook(HookType.AresHook, Address = 0x7729C7, Size = 5)]
    //[Hook(HookType.AresHook, Address = 0x7729D6, Size = 5)]
    //[Hook(HookType.AresHook, Address = 0x7729B0, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "WeaponTypeClass_LoadFromINI", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint WeaponTypeClass_LoadFromINI(Registers* r)
    {
        var pItem = (Pointer<WeaponTypeClass>)r->ESI;
        var pIni = r->Stack<Pointer<CCIniClass>>(0xE4);

        LoadFromIni(pItem, pIni);
        return 0;
    }

    public override bool GetSection(IniReader reader, out IniSection section)
    {
        section = reader[OwnerRef.Base.ID];
        return true;
    }

    public override bool GetArtSection(IniReader reader, out IniSection section)
    {
        section = default;
        return false;
    }

}