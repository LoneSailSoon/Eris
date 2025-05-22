using Eris.Utilities.Ini;
using NaegleriaSerializer.Streaming;

namespace Eris.Extension.Core.World.NewExtension;

public interface INewExtMap
{
    void Clear();

    void Serialize(NaegleriaSerializeStream stream);

    void Deserialize(NaegleriaDeserializeStream stream);
    
    void LoadRegister(IniReader reader);

    void LoadFromIni(IniReader reader);
}