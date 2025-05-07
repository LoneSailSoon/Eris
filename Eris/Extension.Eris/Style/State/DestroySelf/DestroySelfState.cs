using Eris.Serializer;
using NaegleriaSerializer.Streaming;
using PatcherYrSharp;

namespace Eris.Extension.Eris.Style.State.DestroySelf;

public class DestroySelfState(DestroySelfData data) : StyleStateModule<DestroySelfState, DestroySelfData>(data)
{
    public DestroySelfState() : this(null!)
    {
        
    }

    public override int SerializeType => SerializeRegister.DestroySelfStateType;
    public static readonly Func<DestroySelfData, DestroySelfState> Activator = static data => new(data);

    public override void Awake(StyleInstance style)
    {
        base.Awake(style);
        this[style] = this;
    }

    protected override DestroySelfState? StateModule 
    {
        get => Owner.StyleStateManager.DestroySelfState;
        set => Owner.StyleStateManager.DestroySelfState = value;
    }

    protected override DestroySelfState? this[StyleInstance style]
    {
        get => style.DestroySelfState;
        set => style.DestroySelfState = value;
    }

    public override void Serialize(INaegleriaStream stream)
    {
        base.Serialize(stream);
        stream
            .Process(ref _delay);
    }

    public override void OnUpdate()
    {
        if (Owner.Expired) return;

        if (Data.Ammo != default)
        {
            if (Owner.OwnerRef.Ammo is >= 0 and var ammo && Data.Ammo.Match(ammo))
            {
                DestorySelf();
            }
            else if (Data.AfterDelay >= 0)
            {
                if (_delay > Data.AfterDelay)
                {
                    _delay = Data.AfterDelay;
                }

                if (_delay <= 0)
                {
                    DestorySelf();
                }
                else
                {
                    _delay--;
                }
            }
            else
            {
                DestorySelf();
            }
        }
        else if (Data.AfterDelay >= 0)
        {
            if (_delay > Data.AfterDelay)
            {
                _delay = Data.AfterDelay;
            }

            if (_delay <= 0)
            {
                DestorySelf();
            }
            else
            {
                _delay--;
            }
        }
         
    }

    public void DestorySelf()
    {
        Console.WriteLine($"DestroySelfState {Style?.StyleType.Section} {Data.Behavior} {Game.CurrentFrame}");
        switch (Data.Behavior)
        {
            case DestroySelfData.DestroySelfBehavior.Kill:
                Owner.OwnerRef.KillPassengers(Owner.OwnerObject);
                Owner.OwnerRef.Base.TakeDamage(Owner.OwnerRef.Base.Health + 1, Owner.OwnerRef.Type.Ref.Crewed);
                break;
            case DestroySelfData.DestroySelfBehavior.Vanish:
                Owner.OwnerRef.Base.Remove();
                Owner.OwnerRef.Base.Health = 0;
                Owner.OwnerRef.Base.UnInit();
                break;
            case DestroySelfData.DestroySelfBehavior.Sell:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private int _delay = int.MaxValue;

    protected override void Pop()
    {
        //Console.WriteLine($"DestroySelfState Pop {Style?.StyleType.Section}");
    }

    protected override void Push()
    {
        //Console.WriteLine($"DestroySelfState Push {Style?.StyleType.Section}");
    }
}