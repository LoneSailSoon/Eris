using Eris.Extension.Eris.Generic;
using Eris.Extension.Eris.Scripts;
using PatcherYrSharp;
using PatcherYrSharp.Helpers;

namespace Eris.Extension.Generic;

public abstract class CommonInstanceExtension<TExt, TBase, TTypeExt, TTypeBase> : InstanceExtension<TExt, TBase>, IGameObjectOwner<TExt>
    where TExt : InstanceExtension<TExt, TBase>, IExtensionActivator<TExt, TBase>, IGameObjectOwner<TExt>
    where TTypeExt : CommonTypeExtension<TTypeExt, TTypeBase>, IExtensionActivator<TTypeExt, TTypeBase>
    where TBase : IYrObject<TTypeBase>
{
    protected TTypeExt TypeField;
    protected GameToken TokenField;
    protected GameObject? ObjectField;

    public TTypeExt Type => TypeField;
    
    public GameObject GameObject
    {
        get
        {
            if (ObjectField is null)
            {
                ObjectField = GameObject.Create();
                Awake();
            }
            
            return ObjectField;
        }
    }


    public ref TTypeBase OwnerTypeRef => ref Type.OwnerRef;

    public virtual void Awake()
    {
        TypeField ??= CommonTypeExtension<TTypeExt, TTypeBase>.ExtMap.Find(OwnerRef.Type)!;
        if (TypeField.Scripts is { } scripts)
        {
            foreach (var script in scripts)
            { 
                ScriptManager.AttachTo((this as TExt)!, script);
            }
        }
        
    }
    
    public CommonInstanceExtension(Pointer<TBase> owner) : base(owner)
    {
        TypeField = null!;
        //Console.WriteLine($"HasType:{TypeFiled is not null}");
    }

    public CommonInstanceExtension()
    {
        TypeField = null!;
    }
}

public struct GameToken
{
    public bool Initialized;
}

public interface IGameObjectOwner<TExt>
{
    public GameObject GameObject { get; }
}