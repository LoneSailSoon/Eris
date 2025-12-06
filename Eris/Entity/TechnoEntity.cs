using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Eris.BeonSerializer.Streaming;
using Eris.Entity.Generic;
using Eris.Serializer;
using Eris.YRSharp;
using Eris.YRSharp.Helpers;

namespace Eris.Entity;

public class TechnoEntity : CommonInstanceEntity<TechnoEntity, TechnoClass, TechnoTypeEntity, TechnoTypeClass>,
    IExtensionActivator<TechnoEntity, TechnoClass>
{
    private TechnoEntity(Pointer<TechnoClass> owner) : base(owner)
    {
    }

    public TechnoEntity()
    {
    }

    public override void Serialize(IBeonStream stream)
    {
        base.Serialize(stream);
    }

    public override int SerializeType => SerializeRegister.TechnoEntitySerializeType;

    public static TechnoEntity Create(Pointer<TechnoClass> owner)
    {
        return new TechnoEntity(owner);
    }
    
    //[Hook(HookType.AresHook, Address = 0x6F3260, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "TechnoClass_CTOR", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint TechnoClass_CTOR(Registers* r)
    {
        var pItem = (Pointer<TechnoClass>)r->ESI;

        if (!GlobalSerializer.IsLoading)
        {
            EntityMap.FindOrAllocate(pItem);
        }
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x6F4500, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "TechnoClass_DTOR", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint TechnoClass_DTOR(Registers* r)
    {
        var pItem = (Pointer<TechnoClass>)r->ECX;
        EntityMap.Remove(pItem);
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x70C250, Size = 8)]
    //[Hook(HookType.AresHook, Address = 0x70BF50, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "TechnoClass_SaveLoad_Prefix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint TechnoClass_SaveLoad_Prefix(Registers* r)
    {
        var pItem = r->Stack<Pointer<TechnoClass>>(0x4);

        TechnoEntity.EntityMap.Prepare(pItem);
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x70C249, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "TechnoClass_Load_Suffix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint TechnoClass_Load_Suffix(Registers* r)
    {
        TechnoEntity.EntityMap.Load();
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x70C264, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "TechnoClass_Save_Suffix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint TechnoClass_Save_Suffix(Registers* r)
    {
        TechnoEntity.EntityMap.Save();
        return 0;
    }

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void OnExpire()
    {
        base.OnExpire();
    }
}