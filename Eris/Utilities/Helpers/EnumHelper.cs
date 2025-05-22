using System.Runtime.CompilerServices;

namespace Eris.Utilities.Helpers;

public static class EnumHelper
{
    public static bool HasFlag<TEnum>(TEnum flag1, TEnum flag2) where TEnum : struct, Enum
    {
        ulong buffer = ToUint64(flag2);

        return (ToUint64(flag1) & buffer) == buffer;
    }

    public static ulong ToUint64<TEnum>(TEnum flag) where TEnum : struct, Enum
    {
        return Unsafe.SizeOf<TEnum>() switch
        {
            1 => Unsafe.As<TEnum, byte>(ref flag),
            2 => Unsafe.As<TEnum, ushort>(ref flag),
            4 => Unsafe.As<TEnum, uint>(ref flag),
            8 => Unsafe.As<TEnum, ulong>(ref flag),
            _ => 0
        };
    }

    public static TEnum FromUint64<TEnum>(ulong value) where TEnum : struct, Enum
    {

        switch (Unsafe.SizeOf<TEnum>())
        {
            case 1:
                var byteValue = (byte)value;
                return Unsafe.As<byte, TEnum>(ref byteValue);
            case 2:
                var ushortValue = (ushort)value;
                return Unsafe.As<ushort, TEnum>(ref ushortValue);
            case 4:
                var uintValue = (uint)value;
                return Unsafe.As<uint, TEnum>(ref uintValue);
            case 8:
                return Unsafe.As<ulong, TEnum>(ref value);
            default:
                return default;
        }
    }

    public static IReadOnlyDictionary<string, ulong> CreatePaser<TEnum>(params ReadOnlySpan<EnumEntry<TEnum>> entrys) where TEnum : struct, Enum
    {
        var dic = new Dictionary<string, ulong>(StringComparer.OrdinalIgnoreCase);
        for (int i = 0; i < entrys.Length; i++)
        {
            var entry = entrys[i];
            dic.Add(entry.Id, entry.Value is null ? (ulong)i : ToUint64(entry.Value.Value));
        }
        
        return dic;
    }
    
    public record struct EnumEntry<TEnum>(string Id, TEnum? Value = null)where TEnum : struct, Enum
    {
        public static implicit operator EnumEntry<TEnum>(string id) => new(id);
        public static implicit operator EnumEntry<TEnum>((string id, int index) tuple) => new(tuple.id, FromUint64<TEnum>((ulong)tuple.index));
        public static implicit operator EnumEntry<TEnum>((string id, TEnum index) tuple) => new(tuple.id, tuple.index);
    }
}