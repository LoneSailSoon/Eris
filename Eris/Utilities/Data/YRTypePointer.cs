using Eris.YRSharp;
using Eris.YRSharp.Helpers;

namespace Eris.Utilities.Data;

public struct YRTypePointer<T> where T : struct, IYRType<T>
{
    enum State
    {
        Uncheck, Nil, Some
    }

    private State _hasValue;
    private nint _type;
    private string? _id;

    public string? Id
    {
        get => _id;
        set
        {
            if (_id != value)
            {
                _id = value;
                _hasValue = State.Uncheck;
            }
        }
    }

    public Pointer<T> Type
    {
        get
        {
            if (_hasValue == 0)
            {
                _type = T.AbstractTypeArray[_id];
                _hasValue = _type == 0 ? State.Some : State.Nil;
            }
            return _type;
        }
    }

    public bool HasValue
    {
        get
        {
            if (_hasValue == 0)
            {
                _type = T.AbstractTypeArray[_id];
                _hasValue = _type == 0 ? State.Some : State.Nil;
            }
            return _hasValue is State.Some;
        }
    }
}
