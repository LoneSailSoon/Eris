using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Eris.Extension.Generic;
using Eris.Serializer;
using NaegleriaSerializer.Streaming;
using PatcherYrSharp;
using PatcherYrSharp.Helpers;

namespace Eris.Extension;

public class SuperWeaponExt : CommonInstanceExtension<SuperWeaponExt, SuperClass, SWTypeExt, SuperWeaponTypeClass>,
    IExtensionActivator<SuperWeaponExt, SuperClass>
{
    public SuperWeaponExt(Pointer<SuperClass> owner) : base(owner)
    {
    }

    public SuperWeaponExt()
    {
    }

    public override void Serialize(INaegleriaStream stream)
    {
        stream.ProcessObject(ref TypeFiled!)
            .Process(ref TokenFiled);
    }

    public override int SerializeType => SerializeRegister.SuperWeaponExtSerializeType;

    public static SuperWeaponExt Create(Pointer<SuperClass> owner)
    {
        return new SuperWeaponExt(owner);
    }
    
    //[Hook(HookType.AresHook, Address = 0x6CB10E, Size = 7)]
    [UnmanagedCallersOnly(EntryPoint = "SuperClass_CTOR", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 SuperClass_CTOR(Registers* r)
    {
        var pItem = (Pointer<SuperClass>)r->ESI;

        if (!GlobalSerializer.IsLoading)
        {
            ExtMap.FindOrAllocate(pItem);
        }
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x6CB120, Size = 7)]
    [UnmanagedCallersOnly(EntryPoint = "SuperClass_DTOR", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 SuperClass_DTOR(Registers* r)
    {
        var pItem = (Pointer<SuperClass>)r->ECX;
        
        ExtMap.Remove(pItem);
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x6CDEF0, Size = 5)]
    //[Hook(HookType.AresHook, Address = 0x6CDFD0, Size = 8)]
    [UnmanagedCallersOnly(EntryPoint = "SuperClass_SaveLoad_Prefix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 SuperClass_SaveLoad_Prefix(Registers* r)
    {
        var pItem = r->Stack<Pointer<SuperClass>>(0x4);

        ExtMap.Prepare(pItem);
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x6CDFC7, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "SuperClass_Load_Suffix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 SuperClass_Load_Suffix(Registers* r)
    {
        ExtMap.Load();
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x6CDFEA, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "SuperClass_Save_Suffix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 SuperClass_Save_Suffix(Registers* r)
    {
        ExtMap.Save();
        return 0;
    }

}