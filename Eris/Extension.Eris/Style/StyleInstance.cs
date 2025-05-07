using Eris.Serializer;
using Eris.Utilities.Helpers;
using NaegleriaSerializer;
using NaegleriaSerializer.Streaming;
using System.Text;
using Eris.Extension.Eris.Generic;
using Eris.Extension.Eris.Style.State.DestroySelf;
using Eris.Utilities.Logger;
using PatcherYrSharp;
using PatcherYrSharp.GeneralStructures;
using PatcherYrSharp.Helpers;

namespace Eris.Extension.Eris.Style;

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
        _type = type;
        _owner = owner;
        _house = house ?? HouseExt.ExtMap.Find(_owner.OwnerRef.Owner);
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
                    OnDisable();
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
    private void ForceDuration(int duration)
    {
        StyleLifeTime.Start(duration);
        StyleStatus = StyleStatus.Duration;
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
        if(StyleActive && !StyleExpired)
            OnDisable(true);
        StyleExpired = true;
        StyleActive = false;
    }

    public override void OnUpdate()
    {
        LaserHelpers.RedLineZ(Owner.OwnerRef.Base.Location, LifeTime.GetTimeLeft() * 10, 3);
        foreach (var module in _styleModules)
            module.OnUpdate();
        Console.WriteLine($"{StyleType.Section}:{Game.CurrentFrame}");
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
        sb
            .AppendTreeLeaf(linePrefix, $"Status:{StyleStatus}")
            .AppendTreeLeafLast(linePrefix, $"TimeLeft:{StyleLifeTime.GetTimeLeft()}");
    }
}

public enum StyleStatus
{
    None = 0,
    Duration = 1,
    Delay = 2,
    Initial = 3,
    HoldOn = 4
}
