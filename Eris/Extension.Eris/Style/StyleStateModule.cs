using Eris.Extension.Eris.Generic;
using Eris.Utilities.Ini;
using NaegleriaSerializer.Streaming;

namespace Eris.Extension.Eris.Style;

public abstract class StyleStateModule : StyleModule
{
    public abstract void Dirt();
    public abstract StyleStateModule? GetStateModule();
}

public abstract class StyleStateModule<TState, TData>(TData data) : StyleStateModule
    where TState : StyleStateModule<TState, TData>
    where TData : FilterableConfig

{
    protected TData Data = data;

    public override void Serialize(INaegleriaStream stream)
    {
        base.Serialize(stream);
        stream.ProcessObject(ref Data!);
    }

    
    
    private DirtyFlag _dirty = DirtyFlag.Cleared;

    private enum DirtyFlag : byte
    {
        Cleared,
        Set,
        Temp
    }

    protected abstract TState? StateModule { get; set; }
    protected abstract TState? this[StyleInstance style] { get; set; }

    public override void Dirt()
    {
        var stateModule = StateModule;
        if (stateModule is not null && stateModule._dirty != DirtyFlag.Temp)
        {
            stateModule._dirty = DirtyFlag.Set;
        }
        else
        {
            _dirty = DirtyFlag.Temp;
            StateModule = (TState)this;
        }
    }

    public void ForcePush()
    {
        if(Owner.Expired)
            return;

        if (StateModule is {_dirty : not DirtyFlag.Temp} stateModule)
            stateModule.Pop();

        _dirty = DirtyFlag.Cleared;

        StateModule = (TState)this;
    }

    public void ForcePop()
    {
        if (StateModule is {_dirty : not DirtyFlag.Temp} stateModule)
            stateModule.Pop();
        StateModule = null;
    }

    public override StyleStateModule? GetStateModule()
    {
        var styles = Owner.Styles;
        if (styles.Expired)
        {
            StateModule = null;
            return null;
        }


        var stateModule = StateModule;
        if (stateModule is null)
        {
            return null;
        }

        var flag = stateModule._dirty;

        if (flag != DirtyFlag.Cleared)
        {
            var buffer = styles.GetBuffer();
            for (var i = buffer.Length - 1; i >= 0; i--)
            {
                var component = buffer[i];
                if (component is StyleInstance { Expired: false, Active: true } style &&
                    this[style] is { Active: true } newState)
                {
                    if (flag != DirtyFlag.Temp || !ReferenceEquals(stateModule, newState))
                    {
                        stateModule.Pop();
                    }

                    newState._dirty = DirtyFlag.Cleared;
                    newState.Push();
                    return StateModule = newState;
                }
            }

            if(flag != DirtyFlag.Temp)
                stateModule.Pop();
            return StateModule = null;
        }

        return stateModule;
    }

    protected virtual void Push()
    {

    }

    protected virtual void Pop()
    {

    }
}