using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using Eris.Extension.Eris.Generic;
using Eris.Extension.Eris.Style;
using Eris.Extension.Generic;
using Eris.Serializer;
using Eris.Utilities.Helpers;
using Eris.Utilities.Logger;
using Microsoft.Win32;
using NaegleriaSerializer.Streaming;
using PatcherYrSharp;
using PatcherYrSharp.Helpers;

namespace Eris.Extension;

public partial class TechnoExt : CommonInstanceExtension<TechnoExt, TechnoClass, TechnoTypeExt, TechnoTypeClass>,
    IExtensionActivator<TechnoExt, TechnoClass>
{
    public TechnoExt(Pointer<TechnoClass> owner) : base(owner)
    {
        _styles = GameObject.Create();
        _styleStateManager = new StyleStateManager();
    }

    public TechnoExt()
    {
    }

    public override void Serialize(INaegleriaStream stream)
    {
        base.Serialize(stream);
        stream
            .Process(ref _showVisualTree)
            .ProcessObject(ref _styles!)
            .ProcessObject(ref _styleStateManager!);
    }

    public override int SerializeType => SerializeRegister.TechnoExtSerializeType;

    public static TechnoExt Create(Pointer<TechnoClass> owner)
    {
        return new TechnoExt(owner);
    }
    
    //[Hook(HookType.AresHook, Address = 0x6F3260, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "TechnoClass_CTOR", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 TechnoClass_CTOR(Registers* r)
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
    public static unsafe UInt32 TechnoClass_DTOR(Registers* r)
    {
        var pItem = (Pointer<TechnoClass>)r->ECX;
        ExtMap.Remove(pItem);
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x70C250, Size = 8)]
    //[Hook(HookType.AresHook, Address = 0x70BF50, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "TechnoClass_SaveLoad_Prefix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 TechnoClass_SaveLoad_Prefix(Registers* r)
    {
        var pItem = r->Stack<Pointer<TechnoClass>>(0x4);

        TechnoExt.ExtMap.Prepare(pItem);
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x70C249, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "TechnoClass_Load_Suffix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 TechnoClass_Load_Suffix(Registers* r)
    {
        TechnoExt.ExtMap.Load();
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x70C264, Size = 5)]
    [UnmanagedCallersOnly(EntryPoint = "TechnoClass_Save_Suffix", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 TechnoClass_Save_Suffix(Registers* r)
    {
        TechnoExt.ExtMap.Save();
        return 0;
    }

    private GameObject _styles = null!;
    public GameObject Styles => _styles;
    private StyleStateManager _styleStateManager = null!;
    public StyleStateManager StyleStateManager => _styleStateManager;

    //private List<StyleInstance> _styles = null!;
    //public List<StyleInstance> Styles => _styles;

    private bool _showVisualTree = false;
    public bool ShowVisualTree { get => _showVisualTree; set => _showVisualTree = value; }


    public override void Awake()
    {
        base.Awake();
        if (Type.SelectedBy is { } styleType)
        {
            foreach (var type in styleType)
            {
                StyleManager.Instance.TryCreate(this, _styles, type);
            }
        }
    }

    protected override void OnExpire()
    {
        base.OnExpire();
        _styles.Destroy();
        _styleStateManager.Destroy();
    }

    public void ToTreeDisplay(StringBuilder sb, string linePrefix)
    {
        //if (Token.Initialized)
        {
            sb
           .AppendTreeLeaf(linePrefix, $"UniqueID:{OwnerRef.BaseAbstract.UniqueID}")
           .AppendTreeLeaf(linePrefix, $"AbstractType:{OwnerRef.BaseAbstract.WhatAmI()}")
           .AppendTreeLeaf(linePrefix, "StyleManager");

            // if (_styles.Count != 0)
            // {
            //     var subPrefix = TreeDisplayHelper.GetNextPrefix(linePrefix);
            //     var subLastPrefix = TreeDisplayHelper.GetNextPrefix(subPrefix);
            //     int i;
            //     for (i = 0; i < _styles.Count - 1; i++)
            //     {
            //         sb.AppendTreeLeaf(subPrefix, $"Style:{_styles[i].StyleType?.Section ?? "null"}");
            //         _styles[i].ToTreeDisplay(sb, subLastPrefix);
            //         //_styles[i].ToTreeDisplay(sb, subPrefix);
            //     }
            //
            //     //subPrefix = TreeDisplayHelper.GetNextPrefixLast(linePrefix);
            //     sb.AppendTreeLeafLast(subPrefix, $"Style:{_styles[i].StyleType?.Section ?? "null"}");
            //
            //     subLastPrefix = TreeDisplayHelper.GetNextPrefixLast(subPrefix);
            //     _styles[i].ToTreeDisplay(sb, subLastPrefix);
            //     //_styles[i].ToTreeDisplay(sb, subPrefix);
            // }

            sb
                .AppendTreeLeafLast(linePrefix, $"GameObject:null");
        }
       

    }
}