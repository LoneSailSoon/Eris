using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Eris.BeonSerializer.Streaming;
using Eris.Entity.Generic;
using Eris.Serializer;
using Eris.YRSharp;
using Eris.YRSharp.Helpers;

namespace Eris.Entity;

public class CellEntity : InstanceEntity<CellEntity, CellClass>,
    IExtensionActivator<CellEntity, CellClass>
{
    public CellEntity(Pointer<CellClass> owner) : base(owner)
    {
    }

    public CellEntity()
    {
    }
    public override void Serialize(IBeonStream stream)
    {
        base.Serialize(stream);
    }

    public override int SerializeType => SerializeRegister.CellEntitySerializeType;

    public static CellEntity Create(Pointer<CellClass> owner)
    {
        return new CellEntity(owner);
    }
    
    //[Hook(HookType.AresHook, Address = 0x47BDA1, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "CellClass_CTOR", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint CellClass_CTOR(Registers* r)
    {
        var pItem = (Pointer<CellClass>)r->ESI;
        if (!GlobalSerializer.IsLoading)
        {
            CellEntity.EntityMap.FindOrAllocate(pItem);
        }
        return 0;
    }

//[Hook(HookType.AresHook, Address = 0x47BB60, Size = 6)]
    [UnmanagedCallersOnly(EntryPoint = "CellClass_DTOR", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint CellClass_DTOR(Registers* r)
    {
        var pItem = (Pointer<CellClass>)r->ECX;

        CellEntity.EntityMap.Remove(pItem);
        return 0;
    }

//[Hook(HookType.AresHook, Address = 0x483C10, Size = 5)]
//[Hook(HookType.AresHook, Address = 0x4839F0, Size = 7)]
    [UnmanagedCallersOnly(EntryPoint = "CellClass_SaveLoad_Prefix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint CellClass_SaveLoad_Prefix(Registers* r)
    {
        var pItem = r->Stack<Pointer<CellClass>>(0x4);

        CellEntity.EntityMap.Prepare(pItem);
        return 0;
    }

//[Hook(HookType.AresHook, Address = 0x483C00, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "CellClass_Load_Suffix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint CellClass_Load_Suffix(Registers* r)
    {
        CellEntity.EntityMap.Load();
        return 0;
    }

//[Hook(HookType.AresHook, Address = 0x483C79, Size = 6)]
    [UnmanagedCallersOnly(EntryPoint = "CellClass_Save_Suffix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint CellClass_Save_Suffix(Registers* r)
    {
        CellEntity.EntityMap.Save();
        return 0;
    }
}