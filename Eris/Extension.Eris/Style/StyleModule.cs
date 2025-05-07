using System.Runtime.InteropServices;
using Eris.Utilities.Ini;
using NaegleriaSerializer;
using NaegleriaSerializer.Streaming;

namespace Eris.Extension.Eris.Style;

public abstract class StyleModule : INaegleriaSerializable
{
    public virtual void Serialize(INaegleriaStream stream)
    {
        stream
            .ProcessObject(ref Style)
            .ProcessObject(ref Owner!);
    }

    public abstract int SerializeType { get; }
    public ulong SerializeId { get; } = SerializeIdCreater.NewId();

    public virtual void OnUpdate()
    {
    }

    public virtual void Awake(StyleInstance style)
    {
        Style = style;
        Owner = style.Owner;
    }
    
    public virtual void Awake(TechnoExt owner)
    {
        Owner = owner;
    }

    public virtual void Enable()
    {
        Active = true;
    }

    public virtual void Disable()
    {
        Active = false;
    }

    protected StyleInstance? Style;
    protected TechnoExt Owner = null!;
    public bool Active = true;
}

public abstract class StyleModule<TData>(TData data) : StyleModule where TData : FilterableConfig
{
    protected TData Data = data;

    public override void Serialize(INaegleriaStream stream)
    {
        base.Serialize(stream);
        stream.ProcessObject(ref Data!);
    }
}

public class StyleModulesFactory(List<StyleModuleFactory> factories)
{
    public StyleModule[] CreateStyleModules(StyleInstance style)
    {
        var count = factories.Count;

        if (count == 0) return [];

        var modules = new StyleModule[count];

        for (var i = 0; i < count; i++)
        {
            (modules[i] = factories[i].CreateStyleModule()).Awake(style);
        }

        return modules;
    }
}

public abstract class StyleModuleFactory
{
    public abstract StyleModule CreateStyleModule();
}

public class StyleModuleFactory<TModule, TData>(Func<TData, TModule> ctor, TData data)
    : StyleModuleFactory where TModule : StyleModule, new()
    where TData : FilterableConfig
{
    public override StyleModule CreateStyleModule() => ctor(data);
}