using Eris.BeonSerializer.Streaming;
using Eris.Component.Scripts;
using Eris.Utilities.Ini;
using Eris.YRSharp;
using Eris.YRSharp.Helpers;

namespace Eris.Entity.Generic;

public abstract class CommonTypeEntity<TEntity, TBase> : InstanceEntity<TEntity, TBase>, IIniId where TEntity : CommonTypeEntity<TEntity, TBase>, IExtensionActivator<TEntity, TBase>
{
    protected CommonTypeEntity(Pointer<TBase> owner) : base(owner)
    {
    }
    
    public CommonTypeEntity()
    {
    }

    public static void LoadFromIni(Pointer<TBase> pItem, Pointer<CCIniClass> pIni)
    {
        var ext = EntityMap.Find(pItem);
        ext?.LoadFromIni(pIni);
    }

    private ScriptWithData[]? _scripts;
    public ScriptWithData[]? Scripts => _scripts;
    public virtual void LoadFromIni(Pointer<CCIniClass> pIni)
    {
        var ini = IniReader.Read(pIni);

        var section = ini[OwnerObject.Cast<AbstractTypeClass>().Ref.ID];
        
        ScriptManager.Parse(section, section["Script.Types"u8], this, ref _scripts);
    }

    public override void Serialize(IBeonStream stream)
    {
        base.Serialize(stream);
        if (stream is BeonSerializeStream serializeStream)
        {
            ScriptManager.Serialize(_scripts, serializeStream);
        }
        else if(stream is BeonDeserializeStream deserializeStream)
        {
            ScriptManager.Deserialize(ref _scripts!, deserializeStream);
        }
    }

    public abstract bool GetSection(IniReader reader, out IniSection section);
    public abstract bool GetArtSection(IniReader reader, out IniSection section);
}