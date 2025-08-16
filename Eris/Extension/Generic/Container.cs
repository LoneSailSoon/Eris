using Eris.Serializer;
using Eris.YRSharp.Helpers;

namespace Eris.Extension.Generic;

public abstract class Container<TExt, TBase> where TExt : Extension<TBase>
{
    public abstract TExt? Find(Pointer<TBase> key);
    
    protected abstract TExt Allocate(Pointer<TBase> key);
    
    protected abstract void SetItem(Pointer<TBase> key, TExt ext);
    
    protected abstract void RemoveItem(Pointer<TBase> key);

    public abstract bool TryFind(Pointer<TBase> key, out TExt? ext);

    public abstract void Clear();

    public TExt FindOrAllocate(Pointer<TBase> key, out bool isAllocate)
    {
        isAllocate = false;
        var val = Find(key);
        if (val is not null) return val;
        isAllocate = true;
        val = Allocate(key);

        return val;
    }

    public TExt FindOrAllocate(Pointer<TBase> key)
    {
        return Find(key) ?? Allocate(key);
    }

    public void Remove(Pointer<TBase> key)
    {
        var val = Find(key);
        val?.Expire();

        RemoveItem(key);
    }

    private Pointer<TBase> _savingObject;

    public void Prepare(Pointer<TBase> key)
    {
        _savingObject = key;
    }

    public void Save()
    {
        if (nint.Zero != _savingObject && Find(_savingObject) is { } ext) 
        {
            GlobalSerializer.WriteObject(ext);
        }
        else
        {
            Console.WriteLine("[SaveStatic] Saving failed!");
        }
        
        _savingObject = nint.Zero;
    }

    public void Load()
    {
        if (nint.Zero != _savingObject && GlobalSerializer.ReadObject() is TExt ext)
        {
            SetItem(_savingObject, ext);
            ext.Load(_savingObject);
        }
        else
        {
            Console.WriteLine("[LoadStatic] Loading failed!");
        }
        
        _savingObject = nint.Zero;
    }
}

public class MapContainer<TExt, TBase> : Container<TExt, TBase>
    where TExt : Extension<TBase>, IExtensionActivator<TExt, TBase>
{
    private readonly Dictionary<Pointer<TBase>, TExt> _items = [];

    public override TExt? Find(Pointer<TBase> key)
    {
        return _items.GetValueOrDefault(key);
    }

    public override bool TryFind(Pointer<TBase> key, out TExt? ext)
    {
        ext = null;
        return _items.TryGetValue(key, out ext);
    }

    public override void Clear()
    {
        _items.Clear();
    }

    protected override TExt Allocate(Pointer<TBase> key)
    {
        var val = TExt.Create(key);
        _items.Add(key, val);

        return val;
    }

    protected override void SetItem(Pointer<TBase> key, TExt ext)
    {
        _items[key] = ext;
    }

    protected override void RemoveItem(Pointer<TBase> key)
    {
        _items.Remove(key);
    }
    
    public int Count => _items.Count;

}