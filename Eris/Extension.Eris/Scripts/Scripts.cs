using System.Diagnostics.CodeAnalysis;
using Eris.Extension.Eris.Generic;
using Eris.Extension.Generic;
using Eris.Utilities.Ini;
using Eris.Utilities.Logger;
using NaegleriaSerializer;
using NaegleriaSerializer.Streaming;
using PatcherYrSharp;

namespace Eris.Extension.Eris.Scripts;

public static class ScriptManager
{
    private static readonly Dictionary<string, Script> Scripts = [];

    public static void RegisterScript(string scriptName, Func<Component> constructor, Func<IniConfig>? dataConstructor = null) => 
        Scripts[scriptName] = new(scriptName, constructor, dataConstructor);

    public static bool TryGetScript(string scriptName, [NotNullWhen(true)] out Script? script) =>
        Scripts.TryGetValue(scriptName, out script);

    public static void AttachTo<TExt>(TExt ext, ScriptWithData? script)
        where TExt : IGameObjectOwner<TExt>, INaegleriaSerializable
    {
        if (script?.Script.Constructor() is Scriptable<TExt> scriptable)
        {
            (scriptable as IScriptable<TExt>).AttachTo(ext);
            ext.GameObject.AttachComponent(scriptable);
            (scriptable as IScriptConfigWrapper)?.Attach(script.Data);
        }
    }

    public static void AttachTo<TExt>(TExt ext, Script? script, string? data = null)
        where TExt : IGameObjectOwner<TExt>, INaegleriaSerializable
    {
        if (script?.Constructor() is Scriptable<TExt> scriptable)
        {
            (scriptable as IScriptable<TExt>).AttachTo(ext);
            ext.GameObject.AttachComponent(scriptable);
            var config = script.DataConstructor?.Invoke();
            config?.Parser(data);
            (scriptable as IScriptConfigWrapper)?.Attach(config);
        }
    }

    public static void Serialize(ScriptWithData[]? scripts, NaegleriaSerializeStream stream)
    {
        if (scripts is { Length: var length })
        {
            stream.Buffer.WriteInt32(length);

            for (var i = 0; i < length; i++)
            {
                var script = scripts[i];
                stream.Buffer.WriteString(script.Script.Name);
                var data = script.Data;
                stream.ProcessObject(ref data);
            }
            
        }
        else
        {
            stream.Buffer.WriteInt32(-1);
        }

    }

    public static void Deserialize(ref ScriptWithData[]? scripts, NaegleriaDeserializeStream stream)
    {
        var length = stream.Buffer.ReadInt32();
        if (length >= 0)
        {
            scripts = new ScriptWithData[length];
            for (var i = 0; i < length; i++)
            {
                if(TryGetScript(stream.Buffer.ReadString(), out var script))
                {
                    IniConfig? data = null;
                    stream.ProcessObject(ref data);
                    scripts[i] = new(script, data);
                }
                else
                {
                    IniConfig? _ = null;
                    stream.ProcessObject(ref _);
                }
            }
        }
        else
        {
            scripts = null;
        }
    }

    public static bool Parse(Section section, string? val, ref ScriptWithData[]? scripts)
    {
        if (!string.IsNullOrWhiteSpace(val))
        {
            var ids = val.Split(',', StringSplitOptions.RemoveEmptyEntries);
            var array = new ScriptWithData[ids.Length];

            var count = 0;
            for (var i = 0; i < array.Length; i++)
            {
                if (TryGetScript(ids[i], out var script))
                {
                    var data = script.DataConstructor?.Invoke();
                    data?.Read(section);

                    array[count] = new(script, data);
                    count++;
                }
            }

            if (count == 0)
            {
                scripts = [];
                return true;
            }

            if (array.Length != count)
            {
                Array.Resize(ref array, count);
            }

            scripts = array;
            return true;
        }
        
        if (scripts is { Length: > 0 })
        {
            foreach (var script in scripts)
            {
                script.Data?.Read(section);
            }
        }

        return false;
    }
}

public record Script(string Name, Func<Component> Constructor, Func<IniConfig>? DataConstructor = null);

public record ScriptWithData(Script Script, IniConfig? Data);

public interface IScriptable<TExt>
{
    void AttachTo(TExt owner);
}