using Eris.BeonSerializer.Streaming;
using Eris.Utilities.Ini;
using Eris.YRSharp;
using Eris.YRSharp.Helpers;

namespace Eris.Component.Scripts;

public abstract class AttachEffectScript(int duration, string scriptName) : TechnoScriptable
{
    protected int Duration = duration;
    protected string ScriptName = scriptName;

    public AttachEffectScript() : this(0, null!)
    {
        
    }
    
    public virtual void OnReflsh(int duration, Pointer<int> pDamage, Pointer<WarheadTypeClass> pWH,
         Pointer<ObjectClass> pAttacker, Pointer<HouseClass> pAttackingHouse)
    {
        
    }

    public virtual void Tick()
    {
        
    }

    public sealed override void OnUpdate()
    {
        if(Duration > 0)
        {
            Duration--;
            Tick();
             
        }
        else
            Remove();
    }

    protected override void OnSerialize(IBeonStream stream)
    {
        stream.Process(ref Duration)
            .ProcessStringInline(ref ScriptName!);
    }
}


public abstract class AttachEffectScript<TConfig>(int duration, string scriptName, TConfig config) : AttachEffectScript(duration, scriptName) where TConfig : IniConfig
{
    private TConfig _config = config; 

    protected TConfig Data => _config;

    public AttachEffectScript() : this(0, null!, null!)
    {
        
    }

    protected override void OnSerialize(IBeonStream stream)
    {   
        base.OnSerialize(stream);
        stream.ProcessObject(ref _config!);
    }
}