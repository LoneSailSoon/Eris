using Eris.Utilities.Ini;
using NaegleriaSerializer;
using NaegleriaSerializer.Streaming;

namespace Eris.Extension.Core.World.NewExtension;

public class NewTypeExtensionMapContainer<TExt> : INewExtMap where TExt : NewTypeExtension<TExt>, INewTypeExtension, new()
{
    public NewTypeExtensionMapContainer()
    {
        _indexMap = [];
        _sectionMap = new(StringComparer.OrdinalIgnoreCase);
        IndexMap = _indexMap;
        SectionMap = _sectionMap;
    }

    private readonly Dictionary<int, TExt> _indexMap;
    private readonly Dictionary<string, TExt> _sectionMap;
    private int _count;
    
    public readonly IReadOnlyDictionary<int, TExt> IndexMap;
    public readonly IReadOnlyDictionary<string, TExt> SectionMap;
    
    public int FindIndex(string key) => _sectionMap.TryGetValue(key, out var value) ? value.Index : -1;
    public TExt? Find(string key) => _sectionMap.GetValueOrDefault(key);

    public TExt FindOrCreate(string key, out bool find)
    {
        find = true;
        if (Find(key) is { } ext) return ext;
        find = false;
        ext = new TExt();
        var index = _sectionMap.Count;

        ext.Initialize(index, key);
        _indexMap.Add(index, ext);
        _sectionMap.Add(key, ext);
        _count = index + 1;
        return ext;
    }

    public void Clear()
    {
        _indexMap.Clear();
        _sectionMap.Clear();
        _count = 0;
    }

    public void Serialize(NaegleriaSerializeStream stream)
    {
        stream.Process(ref _count);

        for (var i = 0; i < _count; i++)
        {
            stream.Serialize(_indexMap[i]);
        }
    }

    public void Deserialize(NaegleriaDeserializeStream stream)
    {
        stream.Process(ref _count);

        for (var i = 0; i < _count; i++)
        {
            if (stream.Deserialize() is not TExt ext) continue;
            
            _indexMap[ext.Index] = ext;
            _sectionMap[ext.Section] = ext;
        }
    }

    public void LoadRegister(IniReader reader)
    {
        using var section = reader[$"{TExt.Id}s"];
        foreach (var entry in section)
        {
            FindOrCreate(entry.Value, out _);
        }
    }
    
    public void LoadFromIni(IniReader reader)
    {
        try
        {
            for (var i = 0; i < _count; i++)
            {
                _indexMap[i].LoadFromIni(reader);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}
public abstract class NewTypeExtension<TExt> where TExt : NewTypeExtension<TExt>, INaegleriaSerializable, new()
{
    
    public abstract int Index { get; }
    public abstract string Section { get; }

    public abstract void Initialize(int index, string section);
    public abstract void LoadFromIni(IniReader reader);
}