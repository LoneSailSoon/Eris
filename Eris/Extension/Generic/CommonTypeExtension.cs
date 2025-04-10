using PatcherYrSharp;
using PatcherYrSharp.Helpers;

namespace Eris.Extension.Generic;

public abstract class CommonTypeExtension<TExt, TBase> : InstanceExtension<TExt, TBase> where TExt : CommonTypeExtension<TExt, TBase>, IExtensionActivator<TExt, TBase>
{
    protected CommonTypeExtension(Pointer<TBase> owner) : base(owner)
    {
    }
    
    public CommonTypeExtension()
    {
    }

    public static void LoadFromIni(Pointer<TBase> pItem, Pointer<CCINIClass> pIni)
    {
        var ext = ExtMap.Find(pItem);
        ext?.LoadFromIni(pIni);
    }
    
    public abstract void LoadFromIni(Pointer<CCINIClass> pIni);
}