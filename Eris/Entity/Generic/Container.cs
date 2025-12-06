using Eris.Misc.Functor;
using Eris.Serializer;
using Eris.YRSharp.Helpers;

namespace Eris.Entity.Generic;

public abstract class Container<TEntity, TBase> where TEntity : Entity<TBase>
{
    public abstract TEntity? Find(Pointer<TBase> key);
    
    protected abstract TEntity Allocate(Pointer<TBase> key);
    
    protected abstract void SetItem(Pointer<TBase> key, TEntity entity);
    
    protected abstract void RemoveItem(Pointer<TBase> key);

    public abstract bool TryFind(Pointer<TBase> key, out TEntity? entity);

    public abstract void Clear();

    public MaybeRef<TEntity> TryFind(Pointer<TBase> key) =>
        MaybeRef<TEntity>.OfNullable(Find(key));

    public TEntity FindOrAllocate(Pointer<TBase> key, out bool isAllocate)
    {
        isAllocate = false;
        var val = Find(key);
        if (val is not null) return val;
        isAllocate = true;
        val = Allocate(key);

        return val;
    }

    public TEntity FindOrAllocate(Pointer<TBase> key)
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
        if (nint.Zero != _savingObject && Find(_savingObject) is { } entity) 
        {
            GlobalSerializer.WriteObject(entity);
        }
        else
        {
            Console.WriteLine("[SaveStatic] Saving failed!");
        }
        
        _savingObject = nint.Zero;
    }

    public void Load()
    {
        if (nint.Zero != _savingObject && GlobalSerializer.ReadObject() is TEntity entity)
        {
            SetItem(_savingObject, entity);
            entity.Load(_savingObject);
        }
        else
        {
            Console.WriteLine("[LoadStatic] Loading failed!");
        }
        
        _savingObject = nint.Zero;
    }
}

public class MapContainer<TEntity, TBase> : Container<TEntity, TBase>
    where TEntity : Entity<TBase>, IExtensionActivator<TEntity, TBase>
{
    private readonly Dictionary<Pointer<TBase>, TEntity> _items = [];

    public override TEntity? Find(Pointer<TBase> key)
    {
        return _items.GetValueOrDefault(key);
    }

    public override bool TryFind(Pointer<TBase> key, out TEntity? entity)
    {
        entity = null;
        return _items.TryGetValue(key, out entity);
    }

    public override void Clear()
    {
        _items.Clear();
    }

    protected override TEntity Allocate(Pointer<TBase> key)
    {
        var val = TEntity.Create(key);
        _items.Add(key, val);

        return val;
    }

    protected override void SetItem(Pointer<TBase> key, TEntity entity)
    {
        _items[key] = entity;
    }

    protected override void RemoveItem(Pointer<TBase> key)
    {
        _items.Remove(key);
    }
    
    public int Count => _items.Count;
}