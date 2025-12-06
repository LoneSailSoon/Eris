using Eris.BeonSerializer.Streaming;
using Eris.Utilities.Ini;
using System.Runtime.InteropServices;
using System.Threading;

namespace Eris.Component.Generic;

public struct ConfigSeq
{
    private Dictionary<string, IniConfig>? _configs;
    public readonly bool TryGetConfig<TConfig>(out TConfig? config) where TConfig : IniConfig
    {
        if (_configs?.TryGetValue(typeof(TConfig).Name, out var val) == true)
        {
            config = (TConfig)val;
            return true;
        }

        config = null;
        return false;
    }

    public IniConfig GetOrCreatConfig<TConfig>(Func<TConfig> ctor) where TConfig : IniConfig
    {
        if (_configs == null)
        {
            var value = ctor();
            _configs = new() { [typeof(TConfig).Name] = value };
            return value;
        }
        ref var val = ref CollectionsMarshal.GetValueRefOrAddDefault(_configs, typeof(TConfig).Name, out var exists);
        if (exists)
            return val!;
        return val = ctor();
    }

    public readonly void OnSave(BeonSerializeStream stream)
    {
        if (_configs is null)
            stream.Buffer.WriteInt32(0);
        else
            foreach (var (k, p) in _configs)
            {
                var (k1, p1) = (k, p);
                stream.ProcessStringInline(ref k1)
                    .ProcessObject(ref p1);
            }
    }

    public void OnLoad(BeonDeserializeStream stream)
    {
        var i = stream.Buffer.ReadInt32();
        if (i == 0)
            _configs = null;
        else
        {
            _configs = new(i);
            for (var k = 0; k < i; k++)
            {
                string? k1 = null;
                IniConfig? p1 = null;
                stream.ProcessStringInline(ref k1)
                    .ProcessObject(ref p1);

                if (k1 is not null && p1 is not null)
                    _configs[k1] = p1;
            }
        }
    }
}
