using Eris.BeonSerializer.Streaming;
using Eris.Utilities.Ini;

namespace Eris.Component.Root.CustomEntity;

public interface ICustomEntityMap
{
    void Clear();

    void Serialize(BeonSerializeStream stream);

    void Deserialize(BeonDeserializeStream stream);
    
    void LoadRegister(IniReader reader);

    void LoadFromIni(IniReader reader);
}