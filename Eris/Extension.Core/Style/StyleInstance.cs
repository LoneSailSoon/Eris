using System.Runtime.CompilerServices;
using System.Text;
using Eris.Extension.Core.Generic;
using Eris.Extension.Core.Style.State.DestroySelf;
using Eris.Serializer;
using Eris.Utilities.Helpers;
using Eris.Utilities.Logger;
using Eris.YRSharp;
using Eris.YRSharp.GeneralStructures;
using Eris.YRSharp.Helpers;
using NaegleriaSerializer.Streaming;

namespace Eris.Extension.Core.Style;

public class StyleInstance : Component
{
    private StyleType? _type;
    public StyleType StyleType => _type!;
    
    protected StyleStatus StyleStatus;
    public StyleStatus Status => StyleStatus;

    protected TimerStruct StyleLifeTime;
    public TimerStruct LifeTime => StyleLifeTime;

    private StyleModule[] _styleModules = null!;
    private StyleModule[] _stateStyleModules = null!;

    public DestroySelfState? DestroySelfState;
    
    public override void Serialize(INaegleriaStream stream)
    {
        stream
            .ProcessObject(ref _type)
            .Process(ref StyleStatus)
            .Process(ref StyleLifeTime)
            .Process(ref LoopTimes)
            .Process(ref StyleExpired)
            .Process(ref StyleActive)
            .ProcessObject(ref _house)
            .ProcessObject(ref _warhead)
            .ProcessObject(ref _owner)
            .ProcessObject(ref _source)
            .ProcessObjectArrayInline(ref _styleModules!)
            .ProcessObjectArrayInline(ref _stateStyleModules!)
            .ProcessObject(ref DestroySelfState);
    }

    public override int SerializeType => SerializeRegister.StyleInstanceType;

    public bool TryAttach(TechnoExt owner, StyleType type, HouseExt? house = null, WarheadTypeExt? warhead = null,
        Pointer<ObjectClass> pSource = default)
    {
        
        house ??= HouseExt.ExtMap.Find(owner.OwnerRef.Owner);
        var add = type.GroupMaxCount > 0;
        var count = add ? type.GroupMaxCount : int.MaxValue;
        Console.WriteLine(type.GroupJoin);
        if (type is { Duration: < 0, GroupJoin: SameGroupBehavior.None or SameGroupBehavior.Override or SameGroupBehavior.ResetDuation })
            return false;
        
        
        if (type.Group is null or "none" or "null")
        {
            foreach (var c in owner.Styles.GetLatestBuffer())
            {
                if (c is not StyleInstance { Expired: false } style ||
                    style.StyleType.Section != type.Section) continue;
             
                if (type.GroupJoin is SameGroupBehavior.Override)
                {
                    style.Expire();
                    add = true;
                }
                else
                {
                    count--;
                    if (count <= 0) add = false;
                }
                
                if (type.GroupJoin is SameGroupBehavior.MergeDuation)
                {
                    style.ForceDuration(type.Duration);
                }
                else if (type.GroupJoin is SameGroupBehavior.ResetDuation)
                {
                    style.ForceDuration(style.StyleType.Duration, false);
                }
                else
                {
                    break;
                }
            }
        }
        else
        {
            foreach (var c in owner.Styles.GetLatestBuffer())
            {
                if (c is not StyleInstance { Expired: false } style || style.StyleType.Group != type.Group) continue;
                
                if (type.GroupJoin is SameGroupBehavior.Override)
                {
                    style.Expire();
                    add = true;
                }
                else
                {
                    count--;
                    if (count <= 0) add = false;
                }
                
                if (type.GroupJoin is SameGroupBehavior.MergeDuation)
                {
                    style.ForceDuration(type.Duration);
                }
                else if (type.GroupJoin is SameGroupBehavior.ResetDuation)
                {
                    style.ForceDuration(style.StyleType.Duration, false);
                }
                else
                {
                    break;
                }
            }
        }

        
        
        if (!add) return false;

        if (type.Duration < 0)
            return false;
        
        
        _type = type;
        _owner = owner;
        _house = house;
        _warhead = warhead;

        
        if (pSource && pSource.CastToTechno(out var techno))
            _source = TechnoExt.ExtMap.Find(techno);

        _styleModules = type.ModulesFactory.CreateStyleModules(this);
        _stateStyleModules = type.StateModulesFactory.CreateStyleModules(this);
        
        return true;
    }

    public bool IsActive()
    {
        return StyleActive;
    }

    public bool IsExpired()
    {
        return StyleExpired;
    }

    public bool UpdateActive()
    {
        if (StyleLifeTime.Expired())
        {
            switch (Status)
            {
                case StyleStatus.Duration:
                    if (IsHoldDuration() || IsLoopInProgress())
                    {
                        StartDelay();
                        StyleActive = false;
                    }
                    else
                    {
                        StyleStatus = StyleStatus.None;
                        StyleActive = false;
                        StyleExpired = true;
                    }
                    OnDisable(StyleExpired);
                    //manager.StateNeedReCheck = true;
                    break;
                case StyleStatus.Delay:
                    StartDuration();
                    StyleActive = true;
                    OnEnable();
                    //manager.StateNeedReCheck = true;
                    break;
                case StyleStatus.Initial:
                    StartDuration();
                    StyleActive = true;
                    OnEnable();
                    //manager.StateNeedReCheck = true;
                    break;
                case StyleStatus.None:
                    StyleActive = false;
                    StyleExpired = true;
                    break;
            }
        }
        else
        {
            switch (Status)
            {
                case StyleStatus.Duration:
                    StyleActive = true;
                    break;
                case StyleStatus.None:
                    StyleActive = false;
                    StyleExpired = true;
                    break;
                default:
                    StyleActive = false;
                    break;
            }

        }

        return IsActive() && !IsExpired();
    }

    public void Enable()
    {
        if (GetInitialDelay() > 0)
        {
            StartInitialDelay();
        }
        else
        {
            StyleLifeTime.Start(0);
            StyleStatus = StyleStatus.Initial;
        }
    }

    public void OnEnable()
    {
        foreach (var module in _styleModules)
            module.Enable();
        foreach (var state in _stateStyleModules)
            ((StyleStateModule)state).Dirt();
    }

    public void OnDisable(bool expire = false)
    {
        foreach (var module in _styleModules)
            module.Disable();
        foreach (var state in _stateStyleModules)
            ((StyleStateModule)state).Dirt();

        if (expire)
        {
            if (!Owner.Expired && StyleType is { Next: { Length: > 0 } next })
            {
                foreach (var type in next)
                {
                    StyleManager.Instance.TryCreate(Owner, Owner.Styles, type, House, Warhead,
                        Source?.OwnerObject.Cast<ObjectClass>() ?? 0);
                }
            }
        }
        //Console.WriteLine($"OnDisable {Game.CurrentFrame}");
    }

    private int GetInitialDelay()
    {
        return _type!.InitialDelay;
    }
    private void StartInitialDelay()
    {
        StyleLifeTime.Start(GetInitialDelay());
        StyleStatus = StyleStatus.Initial;
    }
    private int GetDelay()
    {
        return _type!.Delay;
    }
    private void StartDelay()
    {
        StyleLifeTime.Start(GetDelay());
        StyleStatus = StyleStatus.Delay;
    }
    public int GetDuration()
    {
        return _type!.Duration <= 0 ? int.MaxValue >> 1 : _type!.Duration;
    }
    private void StartDuration()
    {
        StyleLifeTime.Start(GetDuration());
        StyleStatus = StyleStatus.Duration;
    }
    private void ForceDuration(int duration, bool offset = true)
    {
        if (duration < 0)
        {
            if (StyleStatus is not StyleStatus.Duration || _type!.Duration <= 0) return;
            
            var timeLeft = StyleLifeTime.GetTimeLeft();
            if (timeLeft > -duration)
            {
                StyleLifeTime.Start(timeLeft + duration);
                return;
            }

            StyleLifeTime.Stop();
            if (IsHoldDuration() || IsLoopInProgress())
            {
                StartDelay();
                StyleActive = false;
            }
            else
            {
                StyleStatus = StyleStatus.None;
                StyleActive = false;
                StyleExpired = true;
            }
            OnDisable(StyleExpired);
            return;
        }
        
        if (StyleStatus is StyleStatus.Duration)
        {
            if (_type!.Duration > 0)
                StyleLifeTime.Start(offset ? duration + StyleLifeTime.GetTimeLeft() : duration);
        }
        else if(StyleStatus is not StyleStatus.None)
        {
            StyleLifeTime.Start(duration);
            StyleStatus = StyleStatus.Duration;
            StyleActive = true;
            Enable();
        }
        
    }
    private bool IsHoldDuration()
    {
        return _type!.HoldDuration;
    }
    private bool IsLoopInProgress()
    {
        LoopTimes++;
        return LoopTimes <= _type!.Loop;
    }

    public override void OnDestroy()
    {
        if (StyleActive && !StyleExpired)
        {
            OnDisable(true);
        }
        
        StyleExpired = true;
        StyleActive = false;
    }

    public override void OnUpdate()
    {
        LaserHelpers.RedLineZ(Owner.OwnerRef.Base.Location, LifeTime.GetTimeLeft() * 10, 3);
        foreach (var module in _styleModules)
            module.OnUpdate();
        Console.WriteLine($"{StyleType.Section}:{RuntimeHelpers.GetHashCode(this)}:{Game.CurrentFrame}");
    }

    public override void Awake()
    {
    }

    
    protected int LoopTimes;

    protected bool StyleExpired = false;
    protected bool StyleActive = true;
    private HouseExt? _house;
    private WarheadTypeExt? _warhead;
    private TechnoExt? _owner; 
    private TechnoExt? _source; 
    
    public override bool Expired => StyleExpired;
    public bool Active => StyleActive;
    public HouseExt? House
    {
        get => _house;
        protected set => _house = value;
    }

    public WarheadTypeExt? Warhead
    {
        get => _warhead;
        protected set => _warhead = value;
    }
    
    public TechnoExt Owner
    {
        get => _owner!;
        protected set => _owner = value;
    }

    public TechnoExt? Source
    {
        get => _source;
        protected set => _source = value;
    }

    public void ToTreeDisplay(StringBuilder sb, string linePrefix)
    {
        
        var subPrefix = TreeDisplayHelper.GetNextPrefix(linePrefix);
        sb
            .AppendTreeLeaf(linePrefix, $"{StyleType.Section}: {RuntimeHelpers.GetHashCode(this)} ")
            .AppendTreeLeaf(subPrefix, $"Status: {StyleStatus} ")
            .AppendTreeLeafLast(subPrefix, $"TimeLeft: {StyleLifeTime.GetTimeLeft()} ");
    }
    
    public static void ToTreeDisplay(Component component, in (StringBuilder sb, string linePrefix) data)
    {
        (component as StyleInstance)?.ToTreeDisplay(data.sb, data.linePrefix);
    }

}

public enum StyleStatus
{
    None = 0,
    Duration = 1,
    Delay = 2,
    Initial = 3
}
