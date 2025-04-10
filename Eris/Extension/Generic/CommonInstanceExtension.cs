using PatcherYrSharp;
using PatcherYrSharp.Helpers;

namespace Eris.Extension.Generic;

public abstract class CommonInstanceExtension<TExt, TBase, TTypeExt, TTypeBase> : InstanceExtension<TExt, TBase>
    where TExt : InstanceExtension<TExt, TBase>, IExtensionActivator<TExt, TBase>
    where TTypeExt : InstanceExtension<TTypeExt, TTypeBase>, IExtensionActivator<TTypeExt, TTypeBase>
    where TBase : IYrObject<TTypeBase>
{
    protected TTypeExt TypeFiled;
    protected GameToken TokenFiled;
    
    public TTypeExt Type
    {
        get
        {
            if (Token.Initialized)
            {
                return TypeFiled ??= InstanceExtension<TTypeExt, TTypeBase>.ExtMap.Find(OwnerRef.Type)!;
            }

            return null!;
        }
    }

    public GameToken Token
    {
        get
        {
            if (!TokenFiled.Initialized)
            {
                TokenFiled.Initialized = true;
                Awake();
            }
            
            return TokenFiled;
        }
    }

    public ref TTypeBase OwnerTypeRef => ref Type.OwnerRef;

    public virtual void Awake()
    {
        
    }
    
    public CommonInstanceExtension(Pointer<TBase> owner) : base(owner)
    {
        TypeFiled = null!;
        //Console.WriteLine($"HasType:{TypeFiled is not null}");
    }

    public CommonInstanceExtension()
    {
        TypeFiled = null!;
    }
}

public struct GameToken
{
    public bool Initialized;
}