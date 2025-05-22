using Eris.Extension.Core.Scripts;
using Eris.Utilities.Ini;
using Eris.YRSharp;
using Eris.YRSharp.Helpers;
using NaegleriaSerializer.Streaming;

namespace Eris.Extension.Generic;

public abstract class CommonTypeExtension<TExt, TBase> : InstanceExtension<TExt, TBase> where TExt : CommonTypeExtension<TExt, TBase>, IExtensionActivator<TExt, TBase>
{
    protected CommonTypeExtension(Pointer<TBase> owner) : base(owner)
    {
    }
    
    public CommonTypeExtension()
    {
    }

    public static void LoadFromIni(Pointer<TBase> pItem, Pointer<CCIniClass> pIni)
    {
        var ext = ExtMap.Find(pItem);
        ext?.LoadFromIni(pIni);
    }

    private ScriptWithData[]? _scripts;
    public ScriptWithData[]? Scripts => _scripts;
    public virtual void LoadFromIni(Pointer<CCIniClass> pIni)
    {
        var ini = IniReader.Default;
        ini.SetCurrentIni(pIni);
        
        var section = ini[OwnerObject.Cast<AbstractTypeClass>().Ref.ID];
        
        ScriptManager.Parse(section, section["Script.Types"u8], ref _scripts);
    }

    public override void Serialize(INaegleriaStream stream)
    {
        base.Serialize(stream);
        if (stream is NaegleriaSerializeStream serializeStream)
        {
            ScriptManager.Serialize(_scripts, serializeStream);
        }
        else if(stream is NaegleriaDeserializeStream deserializeStream)
        {
            ScriptManager.Deserialize(ref _scripts!, deserializeStream);
        }

    }
}