using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Eris.Extension.Core.Style;
using Eris.Extension.Generic;
using Eris.Serializer;
using Eris.Utilities.Ini;
using Eris.YRSharp;
using Eris.YRSharp.Helpers;
using NaegleriaSerializer.Streaming;

namespace Eris.Extension;

public class TechnoTypeExt : CommonTypeExtension<TechnoTypeExt, TechnoTypeClass>,
    IExtensionActivator<TechnoTypeExt, TechnoTypeClass>
{
    public TechnoTypeExt(Pointer<TechnoTypeClass> owner) : base(owner)
    {
    }

    public TechnoTypeExt()
    {
    }

    public override void Serialize(INaegleriaStream stream)
    {
        base.Serialize(stream);
        stream
            .ProcessObjectArrayInline(ref SelectedBy!);
    }

    public override int SerializeType => SerializeRegister.TechnoTypeExtSerializeType;

    public static TechnoTypeExt Create(Pointer<TechnoTypeClass> owner)
    {
        return new TechnoTypeExt(owner);
    }

    //[Hook(HookType.AresHook, Address = 0x711835, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "TechnoTypeClass_CTOR", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint TechnoTypeClass_CTOR(Registers* r)
    {
        var pItem = (Pointer<TechnoTypeClass>)r->ESI;

        if (!GlobalSerializer.IsLoading)
        {
            ExtMap.FindOrAllocate(pItem);
        }
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x711AE0, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "TechnoTypeClass_DTOR", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint TechnoTypeClass_DTOR(Registers* r)
    {
        var pItem = (Pointer<TechnoTypeClass>)r->ECX;
        
        ExtMap.Remove(pItem);
        return 0;
    }

    
    //[Hook(HookType.AresHook, Address = 0x716DC0, Size = 5)]
    //[Hook(HookType.AresHook, Address = 0x7162F0, Size = 6)]
    [UnmanagedCallersOnly(EntryPoint = "TechnoTypeClass_SaveLoad_Prefix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint TechnoTypeClass_SaveLoad_Prefix(Registers* r)
    {
        var pItem = r->Stack<Pointer<TechnoTypeClass>>(0x4);

        ExtMap.Prepare(pItem);
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x716DAC, Size = 0xA)]
    [UnmanagedCallersOnly(EntryPoint = "TechnoTypeClass_Load_Suffix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint TechnoTypeClass_Load_Suffix(Registers* r)
    {
        ExtMap.Load();
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x717094, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "TechnoTypeClass_Save_Suffix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint TechnoTypeClass_Save_Suffix(Registers* r)
    {
        ExtMap.Save();
        return 0;
    }

    public override void LoadFromIni(Pointer<CCIniClass> pIni)
    {
        base.LoadFromIni(pIni);
        var ini = IniReader.Default;
        ini.SetCurrentIni(pIni);

        var section = ini[OwnerRef.BaseAbstractType.ID];
        StyleTypeParser.Parse(section["Style.Types"u8], ref SelectedBy);

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

    public StyleType[]? SelectedBy;
}