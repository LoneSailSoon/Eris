using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using Eris.Extension.Generic;
using Eris.Serializer;
using Eris.YRSharp;
using Eris.YRSharp.Helpers;
using NaegleriaSerializer.Streaming;

namespace Eris.Extension;

public class TechnoExt : CommonInstanceExtension<TechnoExt, TechnoClass, TechnoTypeExt, TechnoTypeClass>,
    IExtensionActivator<TechnoExt, TechnoClass>
{
    private TechnoExt(Pointer<TechnoClass> owner) : base(owner)
    {
    }

    public TechnoExt()
    {
    }

    public override void Serialize(INaegleriaStream stream)
    {
        base.Serialize(stream);
        stream
            .Process(ref _showVisualTree);
    }

    public override int SerializeType => SerializeRegister.TechnoExtSerializeType;

    public static TechnoExt Create(Pointer<TechnoClass> owner)
    {
        return new TechnoExt(owner);
    }
    
    //[Hook(HookType.AresHook, Address = 0x6F3260, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "TechnoClass_CTOR", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint TechnoClass_CTOR(Registers* r)
    {
        var pItem = (Pointer<TechnoClass>)r->ESI;

        if (!GlobalSerializer.IsLoading)
        {
            ExtMap.FindOrAllocate(pItem);
        }
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x6F4500, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "TechnoClass_DTOR", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint TechnoClass_DTOR(Registers* r)
    {
        var pItem = (Pointer<TechnoClass>)r->ECX;
        ExtMap.Remove(pItem);
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x70C250, Size = 8)]
    //[Hook(HookType.AresHook, Address = 0x70BF50, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "TechnoClass_SaveLoad_Prefix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint TechnoClass_SaveLoad_Prefix(Registers* r)
    {
        var pItem = r->Stack<Pointer<TechnoClass>>(0x4);

        TechnoExt.ExtMap.Prepare(pItem);
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x70C249, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "TechnoClass_Load_Suffix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint TechnoClass_Load_Suffix(Registers* r)
    {
        TechnoExt.ExtMap.Load();
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x70C264, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "TechnoClass_Save_Suffix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint TechnoClass_Save_Suffix(Registers* r)
    {
        TechnoExt.ExtMap.Save();
        return 0;
    }

    private bool _showVisualTree = false;
    public bool ShowVisualTree { get => _showVisualTree; set => _showVisualTree = value; }


    public override void Awake()
    {
        base.Awake();
    }

    protected override void OnExpire()
    {
        base.OnExpire();
        Console.WriteLine("OnExpire");
    }
}