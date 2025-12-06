using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Eris.BeonSerializer.Streaming;
using Eris.Entity.Generic;
using Eris.Serializer;
using Eris.Utilities.Ini;
using Eris.Utilities.Ini.Parsers;
using Eris.YRSharp;
using Eris.YRSharp.Helpers;

namespace Eris.Entity;

public class WarheadTypeEntity : CommonTypeEntity<WarheadTypeEntity, WarheadTypeClass>,
    IExtensionActivator<WarheadTypeEntity, WarheadTypeClass>
{
    private WarheadTypeEntity(Pointer<WarheadTypeClass> owner) : base(owner)
    {
    }

    public WarheadTypeEntity()
    {
    }

    public override void Serialize(IBeonStream stream)
    {
        base.Serialize(stream);
        stream
            .Process(ref AllowZeroDamage)
            .Process(ref AffectsEnemies);

    }

    public override int SerializeType => SerializeRegister.WarheadTypeEntitySerializeType;

    public static WarheadTypeEntity Create(Pointer<WarheadTypeClass> owner)
    {
        return new WarheadTypeEntity(owner);
    }

    //[Hook(HookType.AresHook, Address = 0x75D1A9, Size = 7)]
    [UnmanagedCallersOnly(EntryPoint = "WarheadTypeClass_CTOR", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint WarheadTypeClass_CTOR(Registers* r)
    {
        var pItem = (Pointer<WarheadTypeClass>)r->EBP;

        if (!GlobalSerializer.IsLoading)
        {
            EntityMap.FindOrAllocate(pItem);
        }
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x75E5C8, Size = 6)]
    [UnmanagedCallersOnly(EntryPoint = "WarheadTypeClass_SDDTOR", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint WarheadTypeClass_SDDTOR(Registers* r)
    {
        var pItem = (Pointer<WarheadTypeClass>)r->ESI;

        EntityMap.Remove(pItem);
        return 0;
    }

    
    //[Hook(HookType.AresHook, Address = 0x75E2C0, Size = 5)]
    //[Hook(HookType.AresHook, Address = 0x75E0C0, Size = 8)]
    [UnmanagedCallersOnly(EntryPoint = "WarheadTypeClass_SaveLoad_Prefix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint WarheadTypeClass_SaveLoad_Prefix(Registers* r)
    {
        var pItem = r->Stack<Pointer<WarheadTypeClass>>(0x4);

        EntityMap.Prepare(pItem);
        return 0;
    }
    
    //[Hook(HookType.AresHook, Address = 0x75E2AE, Size = 7)]
    [UnmanagedCallersOnly(EntryPoint = "WarheadTypeClass_Load_Suffix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint WarheadTypeClass_Load_Suffix(Registers* r)
    {
        EntityMap.Load();
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x75E39C, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "WarheadTypeClass_Save_Suffix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint WarheadTypeClass_Save_Suffix(Registers* r)
    {
        EntityMap.Save();
        return 0;
    }

    public override void LoadFromIni(Pointer<CCIniClass> pIni)
    {
        base.LoadFromIni(pIni);
        var ini = IniReader.Read(pIni);


        var section = ini[OwnerRef.Base.ID];
        Parsers.Parse(section["AllowZeroDamage"u8], ref AllowZeroDamage);
        Parsers.Parse(section["AffectsEnemies"u8], ref AffectsEnemies);
    }
    
    //[Hook(HookType.AresHook, Address = 0x75DEAF, Size = 5)]
    //[Hook(HookType.AresHook, Address = 0x75DEA0, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "WarheadTypeClass_LoadFromINI", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint WarheadTypeClass_LoadFromINI(Registers* r)
    {
        var pItem = (Pointer<WarheadTypeClass>)r->ESI;
        var pIni = r->Stack<Pointer<CCIniClass>>(0x150);

        LoadFromIni(pItem, pIni);
        return 0;
    }
    public bool AllowZeroDamage;
    public bool AffectsEnemies = true;

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