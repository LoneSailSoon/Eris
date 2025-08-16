using System.Runtime.CompilerServices;
using System.Text;

namespace Eris.Misc.String.Utf8;

public static class Utf8StringConvert
{
    private const ushort Utf8OneStart = 0x0001;
    private const ushort Utf8OneEnd = 0x007F;

    private const ushort Utf8TwoStart = 0x0080;
    private const ushort Utf8TwoEnd = 0x07FF;

    private const ushort Utf8ThreeStart = 0x0800;
    private const ushort Utf8ThreeEnd = 0xFFFF;

    private const byte Utf8OneHeadMin = 0;
    private const byte Utf8OneHeadMax = 0x7F;

    private const byte Utf8TwoHeadMin = 0xC0;
    private const byte Utf8TwoHeadMax = 0xDF;

    private const byte Utf8ThreeHeadMin = 0xE0;
    private const byte Utf8ThreeHeadMax = 0xEF;

    public static int Utf8ToUtf16Length(ReadOnlySpan<byte> str, out byte end)
    {
        var length = 0;
        byte head = 0;
        for (var i = 0; i < str.Length; i++)
        {
            head = str[i];
            switch (head)
            {
                case <= Utf8OneHeadMax:
                    length++;
                    break;
                case >= Utf8TwoHeadMin and <= Utf8TwoHeadMax:
                    length++;
                    i++;
                    break;
                case >= Utf8ThreeHeadMin and <= Utf8ThreeHeadMax:
                    length++;
                    i += 2;
                    break;
            }
        }

        end = head;
        return length;
    }

    public static char[] Utf8ToUtf16(ReadOnlySpan<byte> str)
    {
        var length = Utf8ToUtf16Length(str, out var end);
        if (end is not 0) length++;

        if (length is 0) return [];

        var chars = new char[length];
        var targetIndex = 0;

        for (var i = 0; i < str.Length; i++)
        {
            var head = str[i];
            switch (head)
            {
                case <= Utf8OneHeadMax:
                    chars[targetIndex] = (char)str[i];
                    targetIndex++;
                    break;
                case >= Utf8TwoHeadMin and <= Utf8TwoHeadMax:
                    if (i + 1 >= str.Length) throw new EncoderFallbackException();

                    chars[targetIndex] = (char)((str[i] & 0x1F) << 6 | (str[i + 1] & 0x3F));
                    targetIndex++;
                    i++;
                    break;
                case >= Utf8ThreeHeadMin and <= Utf8ThreeHeadMax:
                    if (i + 2 >= str.Length) throw new EncoderFallbackException();

                    chars[targetIndex] = (char)((str[i] & 0xEF) << 12 | (str[i + 1] & 0x3F) << 6 | (str[i + 2] & 0x3F));
                    targetIndex++;
                    i += 2;
                    break;
            }
        }

        return chars;
    }

    public static Utf8ToUtf16Enumerable GetUtf8ToUtf16Enumerable(ReadOnlySpan<byte> str) => new(str);

    public readonly ref struct Utf8ToUtf16Enumerable(ReadOnlySpan<byte> str)
    {
        private readonly ReadOnlySpan<byte> _str = str;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf8ToUtf16Enumerator GetEnumerator() => new(_str);

        [method: MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref struct Utf8ToUtf16Enumerator(ReadOnlySpan<byte> str)
        {

            private readonly ReadOnlySpan<byte> _str = str;
            private int _index = 0;
            private char _current;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool MoveNext()
            {
                if (_index >= _str.Length) return false;
                var head = _str[_index];
                switch (head)
                {
                    case <= Utf8OneHeadMax:
                        if (head == 0) return false;
                        _current = (char)_str[_index];
                        _index++;
                        return true;

                    case >= Utf8TwoHeadMin and <= Utf8TwoHeadMax:
                        if (_index + 1 >= _str.Length) throw new EncoderFallbackException();

                        _current = (char)((_str[_index] & 0x1F) << 6 | (_str[_index + 1] & 0x3F));
                        _index += 2;
                        return true;

                    case >= Utf8ThreeHeadMin and <= Utf8ThreeHeadMax:
                        if (_index + 2 >= _str.Length) throw new EncoderFallbackException();

                        _current = (char)((_str[_index] & 0xEF) << 12 | (_str[_index + 1] & 0x3F) << 6 |
                                          (_str[_index + 2] & 0x3F));
                        _index += 3;
                        return true;
                }

                throw new EncoderFallbackException();
            }

            public char Current => _current;
        }

    }

    public static int Utf16ToUtf8Length(ReadOnlySpan<char> str, out char end)
    {
        var length = 0;
        ushort c = 0;
        for (var i = 0; i < str.Length; i++)
        {
            c = str[i];
            switch (c)
            {
                case <= Utf8OneEnd:
                    length++;
                    break;
                case <= Utf8TwoEnd:
                    length += 2;
                    break;
                case <= Utf8ThreeEnd:
                    length += 3;
                    break;
            }
        }

        end = (char)c;
        return length;
    }

    public static byte[] Utf16ToUtf8(ReadOnlySpan<char> str)
    {
        var length = Utf16ToUtf8Length(str, out var end);
        if (end is not '\0') length++;

        if (length is 0) return [];

        var bytes = new byte[length];
        var targetIndex = 0;


        for (var i = 0; i < str.Length; i++)
        {
            var c = (ushort)str[i];
            switch (c)
            {
                case <= Utf8OneEnd:
                    bytes[targetIndex] = (byte)c;
                    targetIndex++;
                    break;
                case <= Utf8TwoEnd:
                    bytes[targetIndex] = (byte)((c >>> 6) | 0xC0);
                    bytes[targetIndex + 1] = (byte)((c & 0x3F) | 0x80);
                    targetIndex += 2;
                    break;
                case <= Utf8ThreeEnd:
                    bytes[targetIndex] = (byte)((c >>> 12) | 0xE0);
                    bytes[targetIndex + 1] = (byte)(((c >>> 6) & 0x3F) | 0x80);
                    bytes[targetIndex + 2] = (byte)((c & 0x3F) | 0x80);
                    targetIndex += 3;
                    break;
            }
        }

        return bytes;
    }

    public static Utf16ToUtf8Enumerable GetUtf16ToUtf8Enumerable(ReadOnlySpan<char> str) => new(str);

    public readonly ref struct Utf16ToUtf8Enumerable(ReadOnlySpan<char> str)
    {
        private readonly ReadOnlySpan<char> _str = str;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ToUtf8Enumerator GetEnumerator() => new(_str);

        [method: MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref struct Utf16ToUtf8Enumerator(ReadOnlySpan<char> str)
        {

            private readonly ReadOnlySpan<char> _str = str;
            private int _index = 0;
            private byte _current;
            private byte _offset;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool MoveNext()
            {
                if (_index >= _str.Length) return false;
                var c = _str[_index];

                switch ((ushort)c, _offset)
                {
                    case (_, 2):
                        _current = (byte)(((c >> 6) & 0x3F) | 0x80);
                        _offset--;
                        return true;

                    case (_, 1):
                        _current = (byte)((c & 0x3F) | 0x80);
                        _offset--;
                        _index++;
                        return true;

                    case (<= Utf8OneEnd, 0):
                        _current = (byte)c;
                        if (c == '\0') return false;
                        _index++;
                        return true;

                    case (<= Utf8TwoEnd, 0):
                        _current = (byte)((c >>> 6) | 0xC0);
                        _offset = 1;
                        return true;

                    case (<= Utf8ThreeEnd, 0):
                        _current = (byte)((c >>> 12) | 0xE0);
                        _offset = 2;
                        return true;
                }

                throw new EncoderFallbackException();
            }

            public byte Current => _current;
        }
    }
}