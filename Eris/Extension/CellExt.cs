using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Eris.Extension.Generic;
using Eris.Serializer;
using NaegleriaSerializer.Streaming;
using PatcherYrSharp;
using PatcherYrSharp.Helpers;

namespace Eris.Extension;

public class CellExt : InstanceExtension<CellExt, CellClass>,
    IExtensionActivator<CellExt, CellClass>
{
    public CellExt(Pointer<CellClass> owner) : base(owner)
    {
    }

    public CellExt()
    {
    }
    public override void Serialize(INaegleriaStream stream)
    {
        base.Serialize(stream);
    }

    public override int SerializeType => SerializeRegister.CellExtSerializeType;

    public static CellExt Create(Pointer<CellClass> owner)
    {
        return new CellExt(owner);
    }
    
    //[Hook(HookType.AresHook, Address = 0x47BDA1, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "CellClass_CTOR", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 CellClass_CTOR(Registers* r)
    {
        var pItem = (Pointer<CellClass>)r->ESI;
        if (!GlobalSerializer.IsLoading)
        {
            CellExt.ExtMap.FindOrAllocate(pItem);
        }
        return 0;
    }

//[Hook(HookType.AresHook, Address = 0x47BB60, Size = 6)]
    [UnmanagedCallersOnly(EntryPoint = "CellClass_DTOR", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 CellClass_DTOR(Registers* r)
    {
        var pItem = (Pointer<CellClass>)r->ECX;

        CellExt.ExtMap.Remove(pItem);
        return 0;
    }

//[Hook(HookType.AresHook, Address = 0x483C10, Size = 5)]
//[Hook(HookType.AresHook, Address = 0x4839F0, Size = 7)]
    [UnmanagedCallersOnly(EntryPoint = "CellClass_SaveLoad_Prefix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 CellClass_SaveLoad_Prefix(Registers* r)
    {
        var pItem = r->Stack<Pointer<CellClass>>(0x4);

        CellExt.ExtMap.Prepare(pItem);
        return 0;
    }

//[Hook(HookType.AresHook, Address = 0x483C00, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "CellClass_Load_Suffix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 CellClass_Load_Suffix(Registers* r)
    {
        CellExt.ExtMap.Load();
        return 0;
    }

//[Hook(HookType.AresHook, Address = 0x483C79, Size = 6)]
    [UnmanagedCallersOnly(EntryPoint = "CellClass_Save_Suffix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 CellClass_Save_Suffix(Registers* r)
    {
        CellExt.ExtMap.Save();
        return 0;
    }
}