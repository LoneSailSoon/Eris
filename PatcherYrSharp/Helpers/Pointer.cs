using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PatcherYrSharp.Helpers;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct Pointer<T> : IEquatable<Pointer<T>>
{
    public static readonly Pointer<T> Zero = new(0);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Pointer(int value)
    {
        Value = (void*)value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Pointer(long value)
    {
        Value = (void*)value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Pointer(void* value)
    {
        Value = value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Pointer(nint value)
    {
        Value = value.ToPointer();
    }

    public void* Value;

    public ref T Ref
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref Unsafe.AsRef<T>(Value);
    }

    public T Data
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Unsafe.Read<T>(Value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Unsafe.Write(Value, value);
    }
    
    public Pointer<T>? AsNullable
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => IsNull ? null : this;
    }


    public ref T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref Unsafe.Add(ref Unsafe.AsRef<T>(Value), index);
    }

    public bool IsNull
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => this == Zero;
    }

    public bool IsNotNull
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => this != Zero;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Pointer<TTo> Convert<TTo>()
    {
        return new Pointer<TTo>(Value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Pointer<TTo> Cast<TTo>()
    {
        return new Pointer<TTo>(Value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public nint RawOffset(int offset)
    {
        return (nint)Value + offset;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Pointer<T> AsPointer(ref T obj)
    {
        return new Pointer<T>(Unsafe.AsPointer(ref obj));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int TypeSize()
    {
        return Unsafe.SizeOf<T>();
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Pointer<T> operator +(Pointer<T> ptr, int val) => (Pointer<T>)Unsafe.Add<T>(ptr.Value, val);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Pointer<T> operator -(Pointer<T> ptr, int val) => (Pointer<T>)Unsafe.Subtract<T>(ptr.Value, val);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long operator -(Pointer<T> value1, Pointer<T> value2) =>
        ((long)value1.Value - (long)value2.Value) / TypeSize();


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(Pointer<T> value1, Pointer<T> value2) => value1.Value == value2.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(Pointer<T> value1, Pointer<T> value2) => value1.Value != value2.Value;

    public override int GetHashCode() => HashCode.Combine((nint)Value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override bool Equals(object obj) => obj is Pointer<T> { Value: var value } && value == Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(Pointer<T> other) => Value == other.Value;
    
    public override string ToString() => ((nint)Value).ToString();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator int(Pointer<T> value) => (int)value.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator void*(Pointer<T> value) => value.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator long(Pointer<T> value) => (long)value.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator nint(Pointer<T> value) => (nint)value.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator bool(Pointer<T> value) => value.IsNotNull;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Pointer<T>(void* value) => new(value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Pointer<T>(int value) => new(value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Pointer<T>(long value) => new(value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Pointer<T>(nint value) => new(value);
    
}

public static class PointerNullReferenceException
{
    public static void ThrowIfNull(nint pointer, [CallerArgumentExpression(nameof(pointer))] string name = null)
    {
        if(nint.Zero == pointer)
        {
            throw new NullReferenceException(name);
        }
    }
}
