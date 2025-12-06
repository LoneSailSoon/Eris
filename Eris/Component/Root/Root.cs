using Eris.BeonSerializer.Streaming;
using Eris.Component.Root.CustomEntity;
using Eris.Utilities.Ini;

namespace Eris.Component.Root;

public static class Root
{
    public static void Clear()
    {
    }

    public static void LoadFromIni(IniReader reader)
    {
    }

    public static void Serialize(BeonSerializeStream stream)
    {
    }

    public static void Deserialize(BeonDeserializeStream stream)
    {
    }


    private static void Clear<TEntity>()  where TEntity : ICustomEntity => TEntity.EntityMap.Clear();
    private static void LoadRegister<TEntity>(IniReader reader)  where TEntity : ICustomEntity => TEntity.EntityMap.LoadRegister(reader);
    private static void LoadFromIni<TEntity>(IniReader reader)  where TEntity : ICustomEntity => TEntity.EntityMap.LoadFromIni(reader);
    private static void Serialize<TEntity>(BeonSerializeStream stream)  where TEntity : ICustomEntity => TEntity.EntityMap.Serialize(stream);
    private static void Deserialize<TEntity>(BeonDeserializeStream stream)  where TEntity : ICustomEntity => TEntity.EntityMap.Deserialize(stream);
    
}