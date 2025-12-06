using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Eris.BeonSerializer.Streaming;
using Eris.Entity.Generic;
using Eris.Serializer;
using Eris.Utilities.Ini;
using Eris.YRSharp;
using Eris.YRSharp.Helpers;

namespace Eris.Entity;


public class HouseTypeEntity : CommonTypeEntity<HouseTypeEntity, HouseTypeClass>,
    IExtensionActivator<HouseTypeEntity, HouseTypeClass>
{
    public HouseTypeEntity(Pointer<HouseTypeClass> owner) : base(owner)
    {
    }

    public HouseTypeEntity()
    {
    }

    public override void Serialize(IBeonStream stream)
    {
        base.Serialize(stream);
    }

    public override int SerializeType => SerializeRegister.HouseTypeEntitySerializeType;

    public static HouseTypeEntity Create(Pointer<HouseTypeClass> owner)
    {
        return new HouseTypeEntity(owner);
    }


    //[Hook(HookType.AresHook, Address = 0x511635, Size = 5)]
    //[Hook(HookType.AresHook, Address = 0x511643, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "HouseTypeClass_CTOR", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint HouseTypeClass_CTOR(Registers* r)
    {
        var pItem = (Pointer<HouseTypeClass>)r->EAX;

        if (!GlobalSerializer.IsLoading)
        {
            EntityMap.FindOrAllocate(pItem);
        }
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x512760, Size = 6)]
    [UnmanagedCallersOnly(EntryPoint = "HouseTypeClass_DTOR", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint HouseTypeClass_DTOR(Registers* r)
    {
        var pItem = (Pointer<HouseTypeClass>)r->ECX;

        EntityMap.Remove(pItem);
        return 0;
    }

    
    //[Hook(HookType.AresHook, Address = 0x512480, Size = 5)]
    //[Hook(HookType.AresHook, Address = 0x512290, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "HouseTypeClass_SaveLoad_Prefix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint HouseTypeClass_SaveLoad_Prefix(Registers* r)
    {
        var pItem = r->Stack<Pointer<HouseTypeClass>>(0x4);

        EntityMap.Prepare(pItem);
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x51246D, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "HouseTypeClass_Load_Suffix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint HouseTypeClass_Load_Suffix(Registers* r)
    {
        EntityMap.Load();
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x51255C, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "HouseTypeClass_Save_Suffix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint HouseTypeClass_Save_Suffix(Registers* r)
    {
        EntityMap.Save();
        return 0;
    }

    public override void LoadFromIni(Pointer<CCIniClass> pIni)
    {
        base.LoadFromIni(pIni);
        var ini = IniReader.Read(pIni);
    }
    
    //[Hook(HookType.AresHook, Address = 0x51215A, Size = 5)]
    //[Hook(HookType.AresHook, Address = 0x51214F, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "HouseTypeClass_LoadFromINI", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint HouseTypeClass_LoadFromINI(Registers* r)
    {
        var pItem = (Pointer<HouseTypeClass>)r->EBX;
        var pIni = r->Base<Pointer<CCIniClass>>(0x8);

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