using Eris.Misc.String.Utf8;

namespace Eris.Misc.String.HybridString
{
    public readonly struct HybridString
    {
        private readonly string? _str;
        private readonly Utf8String _utf8Str;

        public bool Equals(HybridString obj)
        {
            return Default.Equals(this, obj);
        }

        public override string ToString()
        {
            return _str ?? (_utf8Str.IsNull ? "null" : _utf8Str.ToString());
        }

        public override int GetHashCode()
        {
            return _str is not null ? Utf8StringComparer.Default.Utf16GetHashCode(_str) :
                _utf8Str.IsNull ? 0 :
                Utf8StringComparer.Default.Utf8GetHashCode(_utf8Str);
        }
    
        public HybridString(string str) => _str = str;
    
        public HybridString(Utf8String utf8Str) => _utf8Str = utf8Str;
    
        public static readonly IEqualityComparer<HybridString> Default = new HybridStringDefaultCompare(Utf8StringComparer.Default);

        public static readonly IEqualityComparer<HybridString> IgnoreCase = new HybridStringDefaultCompare(Utf8StringComparer.IgnoreCase);
    
        private class HybridStringDefaultCompare(Utf8StringComparer compare) : IEqualityComparer<HybridString>
        {
            private readonly Utf8StringComparer _utf8StringCompare = compare;
            public bool Equals(HybridString x, HybridString y) =>
                x._str is not null
                    ? y._str is not null
                        ? _utf8StringCompare.Utf16Equals(x._str, y._str)
                        : y._utf8Str.IsNotNull && _utf8StringCompare.HybridEquals(x._str, y._utf8Str)
                    : x._utf8Str.IsNotNull
                        ? y._str is not null
                            ? _utf8StringCompare.HybridEquals(x._utf8Str, y._str)
                            : y._utf8Str.IsNotNull && _utf8StringCompare.Utf8Equals(x._utf8Str, y._utf8Str)
                        : y._str is null && y._utf8Str.IsNull;

            public int GetHashCode(HybridString obj) =>
                obj._str is not null ? _utf8StringCompare.Utf16GetHashCode(obj._str) :
                obj._utf8Str.IsNotNull ? _utf8StringCompare.Utf8GetHashCode(obj._utf8Str) : 0;
        }
    }
}