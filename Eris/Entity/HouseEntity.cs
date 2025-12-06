using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Eris.BeonSerializer.Streaming;
using Eris.Entity.Generic;
using Eris.Serializer;
using Eris.YRSharp;
using Eris.YRSharp.Helpers;

namespace Eris.Entity;

public class HouseEntity: CommonInstanceEntity<HouseEntity, HouseClass, HouseTypeEntity, HouseTypeClass>,
    IExtensionActivator<HouseEntity, HouseClass>
{
    public HouseEntity(Pointer<HouseClass> owner) : base(owner)
    {
    }

    public HouseEntity()
    {
    }

    public override void Serialize(IBeonStream stream)
    {
        base.Serialize(stream);
    }

    public override int SerializeType => SerializeRegister.HouseEntitySerializeType;

    public static HouseEntity Create(Pointer<HouseClass> owner)
    {
        return new HouseEntity(owner);
    }
    
    //[Hook(HookType.AresHook, Address = 0x4F6532, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "HouseClass_CTOR", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint HouseClass_CTOR(Registers* r)
    {
        var pItem = (Pointer<HouseClass>)r->EAX;

        if (!GlobalSerializer.IsLoading)
        {
            EntityMap.FindOrAllocate(pItem);
        }
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x4F7140, Size = 6)]
    [UnmanagedCallersOnly(EntryPoint = "HouseClass_DTOR", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint HouseClass_DTOR(Registers* r)
    {
        var pItem = (Pointer<HouseClass>)r->ECX;
        
        EntityMap.Remove(pItem);
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x504080, Size = 5)]
    //[Hook(HookType.AresHook, Address = 0x503040, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "HouseClass_SaveLoad_Prefix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint HouseClass_SaveLoad_Prefix(Registers* r)
    {
        var pItem = r->Stack<Pointer<HouseClass>>(0x4);

        EntityMap.Prepare(pItem);
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x504069, Size = 7)]
    [UnmanagedCallersOnly(EntryPoint = "HouseClass_Load_Suffix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint HouseClass_Load_Suffix(Registers* r)
    {
        EntityMap.Load();
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x5046DE, Size = 7)]
    [UnmanagedCallersOnly(EntryPoint = "HouseClass_Save_Suffix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint HouseClass_Save_Suffix(Registers* r)
    {
        EntityMap.Save();
        return 0;
    }
    
}