using Eris.Serializer;
using Eris.Utilities.Helpers;
using NaegleriaSerializer;
using NaegleriaSerializer.Streaming;
using System.Text;
using PatcherYrSharp;
using PatcherYrSharp.GeneralStructures;
using PatcherYrSharp.Helpers;

namespace Eris.Extension.Eris.Style;

public class StyleInstance :  INaegleriaSerializable
{
    private StyleType? _type;
    public StyleType? StyleType => _type;
    
    protected StyleStatus StyleStatus;
    public StyleStatus Status => StyleStatus;

    protected TimerStruct StyleLifeTime;
    public TimerStruct LifeTime => StyleLifeTime;

    
    public void Serialize(INaegleriaStream stream)
    {
        stream
            .ProcessObject(ref _type)
            .Process(ref StyleStatus)
            .Process(ref StyleLifeTime)
            .Process(ref LoopTimes)
            .Process(ref Expired)
            .Process(ref Active)
            .ProcessObject(ref _house)
            .ProcessObject(ref _warhead)
            .ProcessObject(ref _owner);
    }

    public int SerializeType => SerializeRegister.StyleInstanceType;
    public ulong SerializeId { get; } = SerializeIdCreater.NewId();
    
    public bool Attach(TechnoExt owner, StyleType type, HouseExt? house, WarheadTypeExt? warhead, Pointer<ObjectClass> pSource = default) 
    {
        _type = type;
        _owner = owner;
        House = house ?? HouseExt.ExtMap.Find(_owner.OwnerRef.Owner); 
        Warhead = warhead; 
        return true; 
    }
    
    // protected int LoopTimes;
    //
    // protected bool Expired = false;
    // protected bool Active = true;
    // private HouseExt? _house;
    // private WarheadTypeExt? _warhead;
    public bool IsActive()
    {
        return Active;
    }

    public bool IsExpired()
    {
        return Expired;
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
                        Active = false;
                    }
                    else
                    {
                        StyleStatus = StyleStatus.None;
                        Active = false;
                        Expired = true;
                    }
                    OnDisable();
                    //manager.StateNeedReCheck = true;
                    break;
                case StyleStatus.Delay:
                    StartDuration();
                    Active = true;
                    OnEnable();
                    //manager.StateNeedReCheck = true;
                    break;
                case StyleStatus.Initial:
                    StartDuration();
                    Active = true;
                    OnEnable();
                    //manager.StateNeedReCheck = true;
                    break;
                case StyleStatus.None:
                    Active = false;
                    Expired = true;
                    break;
            }
        }
        else
        {
            switch (Status)
            {
                case StyleStatus.Duration:
                    Active = true;
                    break;
                case StyleStatus.None:
                    Active = false;
                    Expired = true;
                    break;
                default:
                    Active = false;
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

    }

    public void OnDisable()
    {

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
    public void OnDestroy()
    {
        Expired = true;
        Active = false;
    }

    public void OnUpdate()
    {
        LaserHelpers.RedLineZ(Owner!.OwnerRef.Base.Location, LifeTime.GetTimeLeft() * 10, 3);
    }

    public void Awake()
    {
    }

    
    protected int LoopTimes;

    protected bool Expired = false;
    protected bool Active = true;
    private HouseExt? _house;
    private WarheadTypeExt? _warhead;
    private TechnoExt? _owner; 
    
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
    
    public TechnoExt? Owner
    {
        get => _owner;
        protected set => _owner = value;
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


