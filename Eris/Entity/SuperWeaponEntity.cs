using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Eris.BeonSerializer.Streaming;
using Eris.Entity.Generic;
using Eris.Serializer;
using Eris.YRSharp;
using Eris.YRSharp.Helpers;

namespace Eris.Entity;

public class SuperWeaponEntity : CommonInstanceEntity<SuperWeaponEntity, SuperClass, SWTypeEntity, SuperWeaponTypeClass>,
    IExtensionActivator<SuperWeaponEntity, SuperClass>
{
    public SuperWeaponEntity(Pointer<SuperClass> owner) : base(owner)
    {
    }

    public SuperWeaponEntity()
    {
    }

    public override void Serialize(IBeonStream stream)
    {
        base.Serialize(stream);
    }

    public override int SerializeType => SerializeRegister.SuperWeaponEntitySerializeType;

    public static SuperWeaponEntity Create(Pointer<SuperClass> owner)
    {
        return new SuperWeaponEntity(owner);
    }
    
    //[Hook(HookType.AresHook, Address = 0x6CB10E, Size = 7)]
    [UnmanagedCallersOnly(EntryPoint = "SuperClass_CTOR", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint SuperClass_CTOR(Registers* r)
    {
        var pItem = (Pointer<SuperClass>)r->ESI;

        if (!GlobalSerializer.IsLoading)
        {
            EntityMap.FindOrAllocate(pItem);
        }
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x6CB120, Size = 7)]
    [UnmanagedCallersOnly(EntryPoint = "SuperClass_DTOR", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint SuperClass_DTOR(Registers* r)
    {
        var pItem = (Pointer<SuperClass>)r->ECX;
        
        EntityMap.Remove(pItem);
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x6CDEF0, Size = 5)]
    //[Hook(HookType.AresHook, Address = 0x6CDFD0, Size = 8)]
    [UnmanagedCallersOnly(EntryPoint = "SuperClass_SaveLoad_Prefix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint SuperClass_SaveLoad_Prefix(Registers* r)
    {
        var pItem = r->Stack<Pointer<SuperClass>>(0x4);

        EntityMap.Prepare(pItem);
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x6CDFC7, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "SuperClass_Load_Suffix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint SuperClass_Load_Suffix(Registers* r)
    {
        EntityMap.Load();
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x6CDFEA, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "SuperClass_Save_Suffix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint SuperClass_Save_Suffix(Registers* r)
    {
        EntityMap.Save();
        return 0;
    }

}