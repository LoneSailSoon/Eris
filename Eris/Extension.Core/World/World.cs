using Eris.Extension.Core.Style;
using Eris.Extension.Core.World.NewExtension;
using Eris.Utilities.Ini;
using NaegleriaSerializer.Streaming;

namespace Eris.Extension.Core.World;

public static class World
{
    public static void Clear()
    {
        Clear<StyleType>();
    }

    public static void LoadFromIni(IniReader reader)
    {
        //
        LoadRegister<StyleType>(reader);
        
        //
        LoadFromIni<StyleType>(reader);
    }

    public static void Serialize(NaegleriaSerializeStream stream)
    {
        Serialize<StyleType>(stream);
    }

    public static void Deserialize(NaegleriaDeserializeStream stream)
    {
        Deserialize<StyleType>(stream);
    }


    private static void Clear<TExt>()  where TExt : INewExt => TExt.ExtMap.Clear();
    private static void LoadRegister<TExt>(IniReader reader)  where TExt : INewExt => TExt.ExtMap.LoadRegister(reader);
    private static void LoadFromIni<TExt>(IniReader reader)  where TExt : INewExt => TExt.ExtMap.LoadFromIni(reader);
    private static void Serialize<TExt>(NaegleriaSerializeStream stream)  where TExt : INewExt => TExt.ExtMap.Serialize(stream);
    private static void Deserialize<TExt>(NaegleriaDeserializeStream stream)  where TExt : INewExt => TExt.ExtMap.Deserialize(stream);
    
}