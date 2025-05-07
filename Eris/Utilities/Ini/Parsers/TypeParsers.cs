using System.Runtime.InteropServices;
using NaegleriaSerializer.Streaming;
using PatcherYrSharp;
using PatcherYrSharp.Helpers;

namespace Eris.Utilities.Ini.Parsers;

partial class Parsers
{
    public static bool Parse(string? val, ref TechnoTypePointer buffer)
    {
        if (!string.IsNullOrWhiteSpace(val))
        {
            buffer = new TechnoTypePointer { Id = val };
            return true;
        }

        return false;
    }

    public static INaegleriaStream Process(this INaegleriaStream stream, ref TechnoTypePointer type)
    {
        string? id = type.Id;
        stream.ProcessStringInline(ref id);
        type.Id = id;
        return stream;
    }
    
    public static bool Parse(string? val, ref SuperWeaponTypePointer buffer)
    {
        if (!string.IsNullOrWhiteSpace(val))
        {
            buffer = new SuperWeaponTypePointer { Id = val };
            return true;
        }

        return false;
    }

    public static INaegleriaStream Process(this INaegleriaStream stream, ref SuperWeaponTypePointer type)
    {
        string? id = type.Id;
        stream.ProcessStringInline(ref id);
        type.Id = id;
        return stream;
    }

    public static bool Parse(string? val, ref BulletTypePointer buffer)
    {
        if (!string.IsNullOrWhiteSpace(val))
        {
            buffer = new BulletTypePointer { Id = val };
            return true;
        }

        return false;
    }

    public static INaegleriaStream Process(this INaegleriaStream stream, ref BulletTypePointer type)
    {
        string? id = type.Id;
        stream.ProcessStringInline(ref id);
        type.Id = id;
        return stream;
    }

    public static bool Parse(string? val, ref WeaponTypePointer buffer)
    {
        if (!string.IsNullOrWhiteSpace(val))
        {
            buffer = new WeaponTypePointer { Id = val };
            return true;
        }

        return false;
    }

    public static INaegleriaStream Process(this INaegleriaStream stream, ref WeaponTypePointer type)
    {
        string? id = type.Id;
        stream.ProcessStringInline(ref id);
        type.Id = id;
        return stream;
    }

    public static bool Parse(string? val, ref WarheadTypePointer buffer)
    {
        if (!string.IsNullOrWhiteSpace(val))
        {
            buffer = new WarheadTypePointer { Id = val };
            return true;
        }

        return false;
    }

    public static INaegleriaStream Process(this INaegleriaStream stream, ref WarheadTypePointer type)
    {
        string? id = type.Id;
        stream.ProcessStringInline(ref id);
        type.Id = id;
        return stream;
    }

}

[StructLayout(LayoutKind.Sequential)]
public struct TechnoTypePointer
{
    private byte _hasValue;
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
                _hasValue = 0;
            }
        }
    }
    
    public Pointer<TechnoTypeClass> Type
    {
        get
        {
            if (_hasValue == 0)
            {
                _type = TechnoTypeClass.AbstractTypeArray[_id];
                _hasValue = (byte)(_type == 0 ? 2 : 1);
                return _type;
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
                _type = TechnoTypeClass.AbstractTypeArray[_id];
                _hasValue = (byte)(_type == 0 ? 2 : 1);
                return _hasValue == 2;
            }
            return _hasValue == 2;
        }
    }
}

[StructLayout(LayoutKind.Sequential)]
public struct SuperWeaponTypePointer
{
    private byte _hasValue;
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
                _hasValue = 0;
            }
        }
    }
    
    public Pointer<SuperWeaponTypeClass> Type
    {
        get
        {
            if (_hasValue == 0)
            {
                _type = SuperWeaponTypeClass.AbstractTypeArray[_id];
                _hasValue = (byte)(_type == 0 ? 2 : 1);
                return _type;
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
                _type = SuperWeaponTypeClass.AbstractTypeArray[_id];
                _hasValue = (byte)(_type == 0 ? 2 : 1);
                return _hasValue == 2;
            }
            return _hasValue == 2;
        }
    }
}

[StructLayout(LayoutKind.Sequential)]
public struct BulletTypePointer
{
    private byte _hasValue;
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
                _hasValue = 0;
            }
        }
    }
    
    public Pointer<BulletTypeClass> Type
    {
        get
        {
            if (_hasValue == 0)
            {
                _type = BulletTypeClass.AbstractTypeArray[_id];
                _hasValue = (byte)(_type == 0 ? 2 : 1);
                return _type;
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
                _type = BulletTypeClass.AbstractTypeArray[_id];
                _hasValue = (byte)(_type == 0 ? 2 : 1);
                return _hasValue == 2;
            }
            return _hasValue == 2;
        }
    }
}

[StructLayout(LayoutKind.Sequential)]
public struct WeaponTypePointer
{
    private byte _hasValue;
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
                _hasValue = 0;
            }
        }
    }
    
    public Pointer<WeaponTypeClass> Type
    {
        get
        {
            if (_hasValue == 0)
            {
                _type = WeaponTypeClass.AbstractTypeArray[_id];
                _hasValue = (byte)(_type == 0 ? 2 : 1);
                return _type;
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
                _type = WeaponTypeClass.AbstractTypeArray[_id];
                _hasValue = (byte)(_type == 0 ? 2 : 1);
                return _hasValue == 2;
            }
            return _hasValue == 2;
        }
    }
}

[StructLayout(LayoutKind.Sequential)]
public struct WarheadTypePointer
{
    private byte _hasValue;
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
                _hasValue = 0;
            }
        }
    }
    
    public Pointer<WarheadTypeClass> Type
    {
        get
        {
            if (_hasValue == 0)
            {
                _type = WarheadTypeClass.AbstractTypeArray[_id];
                _hasValue = (byte)(_type == 0 ? 2 : 1);
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
                _type = WarheadTypeClass.AbstractTypeArray[_id];
                _hasValue = (byte)(_type == 0 ? 2 : 1);
                return _hasValue == 2;
            }
            return _hasValue == 2;
        }
    }
}

