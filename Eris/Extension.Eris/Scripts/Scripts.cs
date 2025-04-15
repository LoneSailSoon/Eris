using System.Diagnostics.CodeAnalysis;
using Eris.Extension.Generic;
using NaegleriaSerializer;
using NaegleriaSerializer.Streaming;
using PatcherYrSharp;

namespace Eris.Extension.Eris.Scripts;

public static class ScriptManager
{
    private static readonly Dictionary<string, Script> Scripts = [];

    public static void RegisterScript(string scriptName, Func<Component> constructor) =>
        Scripts[scriptName] = new(scriptName, constructor);

    public static void RegisterScripts(string scriptName, params ReadOnlySpan<Func<Component>> scripts)
    {
        if (scripts.Length != 0)
        {
            var last = new Script(scriptName, scripts[^1]);

            for (var i = scripts.Length - 2; i >= 0; i--)
            {
                last = new Script(scriptName, scripts[i], last);
            }

            Scripts[scriptName] = last;
        }
    }

    public static bool TryGetScript(string scriptName, [NotNullWhen(true)] out Script? script) =>
        Scripts.TryGetValue(scriptName, out script);

    public static void AttachTo<TExt>(TExt ext, Script? script)
        where TExt : IGameObjectOwner<TExt>, INaegleriaSerializable
    {
        while (script is not null)
        {
            if (script.Constructor() is Scriptable<TExt> scriptable)
            {
                (scriptable as IScriptable<TExt>).AttachTo(ext);
                ext.GameObject.AttachComponent(scriptable);
            }

            script = script.Next;
        }
    }

    public static void Serialize(Script[]? scripts, NaegleriaSerializeStream stream)
    {
        if (scripts is { Length: var length })
        {
            stream.Buffer.WriteInt32(length);

            for (var i = 0; i < length; i++)
            {
                stream.Buffer.WriteString(scripts[i].Name);
            }
            
        }
        else
        {
            stream.Buffer.WriteInt32(-1);
        }

    }

    public static void Deserialize(ref Script[]? scripts, NaegleriaDeserializeStream stream)
    {
        var length = stream.Buffer.ReadInt32();
        if (length >= 0)
        {
            scripts = new Script[length];
            for (var i = 0; i < length; i++)
            {
                TryGetScript(stream.Buffer.ReadString(), out scripts[i]!);
            }
        }
        else
        {
            scripts = null;
        }
    }

    public static bool Parse(string? val, ref Script[]? scripts)
    {
        if (string.IsNullOrWhiteSpace(val)) return false;
        
        var ids = val.Split(',');
        var array = new Script[ids.Length];

        var count = 0;
        for (var i = 0; i < array.Length; i++)
        {
            if (TryGetScript(ids[i], out var script))
            {
                array[count] = script;
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
}

public record Script(string Name, Func<Component> Constructor, Script? Next = null);

public interface IScriptable<TExt>
{
    void AttachTo(TExt owner);
}

public abstract class Scriptable<TExt> : Component, IScriptable<TExt>
    where TExt : IGameObjectOwner<TExt>, INaegleriaSerializable
{
    private TExt? _owner;

    public TExt Owner => _owner!;


    void IScriptable<TExt>.AttachTo(TExt owner)
    {
        _owner = owner;
    }

    public sealed override void Serialize(INaegleriaStream stream)
    {
        base.Serialize(stream);
        stream.ProcessObject(ref _owner);
        OnSerialize(stream);
        if (stream is NaegleriaSerializeStream ss)
        {
            OnSave(ss);
        }
        else if (stream is NaegleriaDeserializeStream ds)
        {
            OnLoad(ds);
        }
    }

    protected virtual void OnSerialize(INaegleriaStream stream)
    {

    }

    protected virtual void OnSave(NaegleriaSerializeStream stream)
    {

    }

    protected virtual void OnLoad(NaegleriaDeserializeStream stream)
    {

    }
}