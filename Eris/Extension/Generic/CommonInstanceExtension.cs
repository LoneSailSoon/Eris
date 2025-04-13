using Eris.Extension.Eris.Generic;
using PatcherYrSharp;
using PatcherYrSharp.Helpers;

namespace Eris.Extension.Generic;

public abstract class CommonInstanceExtension<TExt, TBase, TTypeExt, TTypeBase> : InstanceExtension<TExt, TBase>
    where TExt : InstanceExtension<TExt, TBase>, IExtensionActivator<TExt, TBase>
    where TTypeExt : InstanceExtension<TTypeExt, TTypeBase>, IExtensionActivator<TTypeExt, TTypeBase>
    where TBase : IYrObject<TTypeBase>
{
    protected TTypeExt TypeField;
    protected GameToken TokenField;
    protected GameObject? ObjectField;

    public TTypeExt Type
    {
        get
        {
            if (Token.Initialized)
            {
                return TypeField ??= InstanceExtension<TTypeExt, TTypeBase>.ExtMap.Find(OwnerRef.Type)!;
            }

            return null!;
        }
    }

    public GameToken Token
    {
        get
        {
            if (!TokenField.Initialized)
            {
                TokenField.Initialized = true;
                Awake();
            }
            
            return TokenField;
        }
    }
    
    public GameObject GameObject
    {
        get
        {
            return ObjectField ??= new(Token);
        }
    }


    public ref TTypeBase OwnerTypeRef => ref Type.OwnerRef;

    public virtual void Awake()
    {
        
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