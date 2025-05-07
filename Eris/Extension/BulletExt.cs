using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Eris.Extension.Generic;
using Eris.Serializer;
using NaegleriaSerializer.Streaming;
using PatcherYrSharp;
using PatcherYrSharp.Helpers;

namespace Eris.Extension;

public class BulletExt : CommonInstanceExtension<BulletExt, BulletClass, BulletTypeExt, BulletTypeClass>,
    IExtensionActivator<BulletExt, BulletClass>
{
    public BulletExt(Pointer<BulletClass> owner) : base(owner)
    {
    }

    public BulletExt()
    {
    }

    public override void Serialize(INaegleriaStream stream)
    {
        base.Serialize(stream);
    }

    public override int SerializeType => SerializeRegister.BulletExtSerializeType;

    public static BulletExt Create(Pointer<BulletClass> owner)
    {
        return new BulletExt(owner);
    }
    
    //[Hook(HookType.AresHook, Address = 0x4664BA, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "BulletClass_CTOR", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 BulletClass_CTOR(Registers* r)
    {
        var pItem = (Pointer<BulletClass>)r->ESI;

        BulletExt.ExtMap.FindOrAllocate(pItem);
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x4665E9, Size = 0xA)]
    [UnmanagedCallersOnly(EntryPoint = "BulletClass_DTOR", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 BulletClass_DTOR(Registers* r)
    {
        var pItem = (Pointer<BulletClass>)r->ESI;

        BulletExt.ExtMap.Remove(pItem);
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x46AFB0, Size = 8)]
    //[Hook(HookType.AresHook, Address = 0x46AE70, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "BulletClass_SaveLoad_Prefix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 BulletClass_SaveLoad_Prefix(Registers* r)
    {
        var pItem = r->Stack<Pointer<BulletClass>>(0x4);

        BulletExt.ExtMap.Prepare(pItem);
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x46AF97, Size = 7)]
    //[Hook(HookType.AresHook, Address = 0x46AF9E, Size = 7)]
    [UnmanagedCallersOnly(EntryPoint = "BulletClass_Load_Suffix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 BulletClass_Load_Suffix(Registers* r)
    {
        BulletExt.ExtMap.Load();
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x46AFC4, Size = 3)]
    [UnmanagedCallersOnly(EntryPoint = "BulletClass_Save_Suffix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 BulletClass_Save_Suffix(Registers* r)
    {
        BulletExt.ExtMap.Save();
        return 0;
    }

}