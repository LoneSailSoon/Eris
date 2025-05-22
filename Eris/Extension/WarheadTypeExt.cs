using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Eris.Extension.Core.Style;
using Eris.Extension.Generic;
using Eris.Serializer;
using Eris.Utilities.Ini;
using Eris.Utilities.Ini.Parsers;
using Eris.YRSharp;
using Eris.YRSharp.Helpers;
using NaegleriaSerializer.Streaming;

namespace Eris.Extension;

public class WarheadTypeExt : CommonTypeExtension<WarheadTypeExt, WarheadTypeClass>,
    IExtensionActivator<WarheadTypeExt, WarheadTypeClass>
{
    public WarheadTypeExt(Pointer<WarheadTypeClass> owner) : base(owner)
    {
    }

    public WarheadTypeExt()
    {
    }

    public override void Serialize(INaegleriaStream stream)
    {
        base.Serialize(stream);
        stream
            .ProcessObjectArrayInline(ref SelectedBy!)
            .Process(ref AllowZeroDamage)
            .Process(ref AffectsEnemies);

    }

    public override int SerializeType => SerializeRegister.WarheadTypeExtSerializeType;

    public static WarheadTypeExt Create(Pointer<WarheadTypeClass> owner)
    {
        return new WarheadTypeExt(owner);
    }

    //[Hook(HookType.AresHook, Address = 0x75D1A9, Size = 7)]
    [UnmanagedCallersOnly(EntryPoint = "WarheadTypeClass_CTOR", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint WarheadTypeClass_CTOR(Registers* r)
    {
        var pItem = (Pointer<WarheadTypeClass>)r->EBP;

        if (!GlobalSerializer.IsLoading)
        {
            ExtMap.FindOrAllocate(pItem);
        }
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x75E5C8, Size = 6)]
    [UnmanagedCallersOnly(EntryPoint = "WarheadTypeClass_SDDTOR", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint WarheadTypeClass_SDDTOR(Registers* r)
    {
        var pItem = (Pointer<WarheadTypeClass>)r->ESI;

        ExtMap.Remove(pItem);
        return 0;
    }

    
    //[Hook(HookType.AresHook, Address = 0x75E2C0, Size = 5)]
    //[Hook(HookType.AresHook, Address = 0x75E0C0, Size = 8)]
    [UnmanagedCallersOnly(EntryPoint = "WarheadTypeClass_SaveLoad_Prefix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint WarheadTypeClass_SaveLoad_Prefix(Registers* r)
    {
        var pItem = r->Stack<Pointer<WarheadTypeClass>>(0x4);

        ExtMap.Prepare(pItem);
        return 0;
    }
    
    //[Hook(HookType.AresHook, Address = 0x75E2AE, Size = 7)]
    [UnmanagedCallersOnly(EntryPoint = "WarheadTypeClass_Load_Suffix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint WarheadTypeClass_Load_Suffix(Registers* r)
    {
        ExtMap.Load();
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x75E39C, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "WarheadTypeClass_Save_Suffix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint WarheadTypeClass_Save_Suffix(Registers* r)
    {
        ExtMap.Save();
        return 0;
    }

    public override void LoadFromIni(Pointer<CCIniClass> pIni)
    {
        base.LoadFromIni(pIni);
        var ini = IniReader.Default;
        ini.SetCurrentIni(pIni);


        var section = ini[OwnerRef.Base.ID];
        
        StyleTypeParser.Parse(section["Style.Types"u8], ref SelectedBy);
        Parsers.Parse(section["AllowZeroDamage"u8], ref AllowZeroDamage);
        Parsers.Parse(section["AffectsEnemies"u8], ref AffectsEnemies);
    }
    
    //[Hook(HookType.AresHook, Address = 0x75DEAF, Size = 5)]
    //[Hook(HookType.AresHook, Address = 0x75DEA0, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "WarheadTypeClass_LoadFromINI", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint WarheadTypeClass_LoadFromINI(Registers* r)
    {
        var pItem = (Pointer<WarheadTypeClass>)r->ESI;
        var pIni = r->Stack<Pointer<CCIniClass>>(0x150);

        LoadFromIni(pItem, pIni);
        return 0;
    }

    public StyleType[]? SelectedBy;
    public bool AllowZeroDamage;
    public bool AffectsEnemies = true;
    
    public bool StyleEnable => SelectedBy is { Length: > 0 };
}