using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Eris.BeonSerializer.Streaming;
using Eris.Entity.Generic;
using Eris.Serializer;
using Eris.YRSharp;
using Eris.YRSharp.Helpers;

namespace Eris.Entity;

public class BulletEntity : CommonInstanceEntity<BulletEntity, BulletClass, BulletTypeEntity, BulletTypeClass>,
    IExtensionActivator<BulletEntity, BulletClass>
{
    public BulletEntity(Pointer<BulletClass> owner) : base(owner)
    {
    }

    public BulletEntity()
    {
    }

    public override void Serialize(IBeonStream stream)
    {
        base.Serialize(stream);
    }

    public override int SerializeType => SerializeRegister.BulletEntitySerializeType;

    public static BulletEntity Create(Pointer<BulletClass> owner)
    {
        return new BulletEntity(owner);
    }
    
    //[Hook(HookType.AresHook, Address = 0x4664BA, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "BulletClass_CTOR", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint BulletClass_CTOR(Registers* r)
    {
        var pItem = (Pointer<BulletClass>)r->ESI;

        BulletEntity.EntityMap.FindOrAllocate(pItem);
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x4665E9, Size = 0xA)]
    [UnmanagedCallersOnly(EntryPoint = "BulletClass_DTOR", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint BulletClass_DTOR(Registers* r)
    {
        var pItem = (Pointer<BulletClass>)r->ESI;

        BulletEntity.EntityMap.Remove(pItem);
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x46AFB0, Size = 8)]
    //[Hook(HookType.AresHook, Address = 0x46AE70, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "BulletClass_SaveLoad_Prefix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint BulletClass_SaveLoad_Prefix(Registers* r)
    {
        var pItem = r->Stack<Pointer<BulletClass>>(0x4);

        BulletEntity.EntityMap.Prepare(pItem);
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x46AF97, Size = 7)]
    //[Hook(HookType.AresHook, Address = 0x46AF9E, Size = 7)]
    [UnmanagedCallersOnly(EntryPoint = "BulletClass_Load_Suffix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint BulletClass_Load_Suffix(Registers* r)
    {
        BulletEntity.EntityMap.Load();
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x46AFC4, Size = 3)]
    [UnmanagedCallersOnly(EntryPoint = "BulletClass_Save_Suffix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint BulletClass_Save_Suffix(Registers* r)
    {
        BulletEntity.EntityMap.Save();
        return 0;
    }

}