using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Eris.BeonSerializer.Streaming;
using Eris.Entity.Generic;
using Eris.Serializer;
using Eris.Utilities.Ini;
using Eris.YRSharp;
using Eris.YRSharp.Helpers;

namespace Eris.Entity;

public class TechnoTypeEntity : CommonTypeEntity<TechnoTypeEntity, TechnoTypeClass>,
    IExtensionActivator<TechnoTypeEntity, TechnoTypeClass>
{
    public TechnoTypeEntity(Pointer<TechnoTypeClass> owner) : base(owner)
    {
    }

    public TechnoTypeEntity()
    {
    }

    public override void Serialize(IBeonStream stream)
    {
        base.Serialize(stream);
    }

    public override int SerializeType => SerializeRegister.TechnoTypeEntitySerializeType;

    public static TechnoTypeEntity Create(Pointer<TechnoTypeClass> owner)
    {
        return new TechnoTypeEntity(owner);
    }

    //[Hook(HookType.AresHook, Address = 0x711835, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "TechnoTypeClass_CTOR", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint TechnoTypeClass_CTOR(Registers* r)
    {
        var pItem = (Pointer<TechnoTypeClass>)r->ESI;

        if (!GlobalSerializer.IsLoading)
        {
            EntityMap.FindOrAllocate(pItem);
        }
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x711AE0, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "TechnoTypeClass_DTOR", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint TechnoTypeClass_DTOR(Registers* r)
    {
        var pItem = (Pointer<TechnoTypeClass>)r->ECX;
        
        EntityMap.Remove(pItem);
        return 0;
    }

    
    //[Hook(HookType.AresHook, Address = 0x716DC0, Size = 5)]
    //[Hook(HookType.AresHook, Address = 0x7162F0, Size = 6)]
    [UnmanagedCallersOnly(EntryPoint = "TechnoTypeClass_SaveLoad_Prefix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint TechnoTypeClass_SaveLoad_Prefix(Registers* r)
    {
        var pItem = r->Stack<Pointer<TechnoTypeClass>>(0x4);

        EntityMap.Prepare(pItem);
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x716DAC, Size = 0xA)]
    [UnmanagedCallersOnly(EntryPoint = "TechnoTypeClass_Load_Suffix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint TechnoTypeClass_Load_Suffix(Registers* r)
    {
        EntityMap.Load();
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x717094, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "TechnoTypeClass_Save_Suffix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint TechnoTypeClass_Save_Suffix(Registers* r)
    {
        EntityMap.Save();
        return 0;
    }

    public override void LoadFromIni(Pointer<CCIniClass> pIni)
    {
        base.LoadFromIni(pIni);
        var ini = IniReader.Read(pIni);

        var section = ini[OwnerRef.BaseAbstractType.ID];

        //Parsers.Parse(ini.Read(OwnerRef.BaseAbstractType.ID, "Strength"), ref _typeTest);
    }

    //[Hook(HookType.AresHook, Address = 0x716132, Size = 5)]
    //[Hook(HookType.AresHook, Address = 0x716123, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "TechnoTypeClass_LoadFromINI", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint TechnoTypeClass_LoadFromINI(Registers* r)
    {
        var pItem = (Pointer<TechnoTypeClass>)r->EBP;
        var pIni = r->Stack<Pointer<CCIniClass>>(0x380);

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