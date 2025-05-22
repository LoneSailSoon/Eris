
namespace Eris.Misc.String.Utf8
{
    public abstract class Utf8StringComparer
    {
        public abstract int Utf16CompareTo(ReadOnlySpan<char> a, ReadOnlySpan<char> b);
    
        public abstract int Utf8CompareTo(ReadOnlySpan<byte> a, ReadOnlySpan<byte> b);
    
        public abstract int HybridCompareTo(ReadOnlySpan<byte> a, ReadOnlySpan<char> b);

        public int HybridCompareTo(ReadOnlySpan<char> a, ReadOnlySpan<byte> b) => -HybridCompareTo(b, a);

        public abstract bool Utf16Equals(ReadOnlySpan<char> a, ReadOnlySpan<char> b);
    
        public abstract bool Utf8Equals(ReadOnlySpan<byte> a, ReadOnlySpan<byte> b);
    
        public abstract bool HybridEquals(ReadOnlySpan<byte> a, ReadOnlySpan<char> b);

        public bool HybridEquals(ReadOnlySpan<char> a, ReadOnlySpan<byte> b) => HybridEquals(b, a);
 
        public abstract int Utf16GetHashCode(ReadOnlySpan<char> obj);

        public abstract int Utf8GetHashCode(ReadOnlySpan<byte> obj);

        public static readonly Utf8StringComparer Default = new DefaultStringCompare();
        public static readonly Utf8StringComparer IgnoreCase = new IgnoreCaseStringCompare();
    
        private class DefaultStringCompare : Utf8StringComparer
        {
            public override int Utf16CompareTo(ReadOnlySpan<char> a, ReadOnlySpan<char> b)
            {
                for (var i = 0; i < Math.Min(a.Length, b.Length); i++)
                {
                    if(a[i] != b[i]) return a[i] < b[i] ? -1 : 1;
                }
            
                if(a.Length != b.Length) return a.Length < b.Length ? -1 : 1;
            
                return 0;
            }

            public override int Utf8CompareTo(ReadOnlySpan<byte> a, ReadOnlySpan<byte> b)
            {
                //
                for (var i = 0; i < Math.Min(a.Length, b.Length); i++)
                {
                    if(a[i] != b[i]) return a[i] < b[i] ? -1 : 1;
                }
            
                if(a.Length != b.Length) return a.Length < b.Length ? -1 : 1;
            
                return 0;
            }

            public override int HybridCompareTo(ReadOnlySpan<byte> a, ReadOnlySpan<char> b)
            {
                var i = 0; 
                foreach (var c in Utf8StringConvert.GetUtf8ToUtf16Enumerable(a))
                {
                    if(i >= b.Length) return 1;
                    if(c != b[i]) return c < b[i] ? -1 : 1;
                    i++;
                }

                if (i < b.Length - 1) return -1;
                return 0;
            }

            public override bool Utf16Equals(ReadOnlySpan<char> a, ReadOnlySpan<char> b)
            {
                if(a.Length != b.Length) return false;
                for (var i = 0; i < a.Length; i++)
                {
                    if(a[i] != b[i]) return false;
                }
                return true;
            }

            public override bool Utf8Equals(ReadOnlySpan<byte> a, ReadOnlySpan<byte> b)
            {
                if(a.Length != b.Length) return false;
                for (var i = 0; i < a.Length; i++)
                {
                    if(a[i] != b[i]) return false;
                }
                return true;
            }

            public override bool HybridEquals(ReadOnlySpan<byte> a, ReadOnlySpan<char> b)
            {
                var i = 0; 
                foreach (var c in Utf8StringConvert.GetUtf8ToUtf16Enumerable(a))
                {
                    if(i >= b.Length) return false;
                    if(c != b[i]) return false;
                    i++;
                }
            
                if (i < b.Length - 1) return false;
                return true;
            }

            public override int Utf16GetHashCode(ReadOnlySpan<char> obj)
            {
                var hash = 0;
                foreach (var c in obj)
                {
                    hash = hash * 31 + c;
                }
                return hash & 0x7FFFFFFF;
            }

            public override int Utf8GetHashCode(ReadOnlySpan<byte> obj)
            {
                var hash = 0;
                foreach (var c in Utf8StringConvert.GetUtf8ToUtf16Enumerable(obj))
                {
                    hash = hash * 31 + c;
                }
                return hash & 0x7FFFFFFF;
            }
        }
    
        private class IgnoreCaseStringCompare : Utf8StringComparer
        {
            public override int Utf16CompareTo(ReadOnlySpan<char> a, ReadOnlySpan<char> b)
            {
                for (var i = 0; i < Math.Min(a.Length, b.Length); i++)
                {
                    var ac = a[i];
                    ac = ac is >= 'A' and <= 'Z' ? (char)(ac + 32) : ac;
                
                    var bc = b[i];
                    bc = bc is >= 'A' and <= 'Z' ? (char)(bc + 32) : bc;
                
                
                    if(ac != bc) return ac < bc ? -1 : 1;
                }
            
                if(a.Length != b.Length) return a.Length < b.Length ? -1 : 1;
            
                return 0;
            }

            public override int Utf8CompareTo(ReadOnlySpan<byte> a, ReadOnlySpan<byte> b)
            {
                //
                for (var i = 0; i < Math.Min(a.Length, b.Length); i++)
                {
                    var ac = a[i];
                    ac = ac is >= 65 and <= 90 ? (byte)(ac + 32) : ac;
                
                    var bc = b[i];
                    bc = bc is >= 65 and <= 90 ? (byte)(bc + 32) : bc;
                
                
                    if(ac != bc) return ac < bc ? -1 : 1;
                }
            
                if(a.Length != b.Length) return a.Length < b.Length ? -1 : 1;
            
                return 0;
            }

            public override int HybridCompareTo(ReadOnlySpan<byte> a, ReadOnlySpan<char> b)
            {
                var i = 0; 
                foreach (var c in Utf8StringConvert.GetUtf8ToUtf16Enumerable(a))
                {
                    if(i >= b.Length) return 1;
                
                    var ac = c;
                    ac = ac is >= 'A' and <= 'Z' ? (char)(ac + 32) : ac;
                
                    var bc = b[i];
                    bc = bc is >= 'A' and <= 'Z' ? (char)(bc + 32) : bc;

                
                    if(ac != bc) return ac < bc ? -1 : 1;
                    i++;
                }

                if (i < b.Length - 1) return -1;
                return 0;
            }

            public override bool Utf16Equals(ReadOnlySpan<char> a, ReadOnlySpan<char> b)
            {
                if(a.Length != b.Length) return false;
                for (var i = 0; i < a.Length; i++)
                {
                    var ac = a[i];
                    ac = ac is >= 'A' and <= 'Z' ? (char)(ac + 32) : ac;
                
                    var bc = b[i];
                    bc = bc is >= 'A' and <= 'Z' ? (char)(bc + 32) : bc;

                
                    if(ac != bc) return false;
                }
                return true;
            }

            public override bool Utf8Equals(ReadOnlySpan<byte> a, ReadOnlySpan<byte> b)
            {
                if(a.Length != b.Length) return false;
                for (var i = 0; i < a.Length; i++)
                {
                    var ac = a[i];
                    ac = ac is >= 65 and <= 90 ? (byte)(ac + 32) : ac;
                
                    var bc = b[i];
                    bc = bc is >= 65 and <= 90 ? (byte)(bc + 32) : bc;

                
                    if(ac != bc) return false;
                }
                return true;
            }

            public override bool HybridEquals(ReadOnlySpan<byte> a, ReadOnlySpan<char> b)
            {
                var i = 0; 
                foreach (var c in Utf8StringConvert.GetUtf8ToUtf16Enumerable(a))
                {
                    if(i >= b.Length) return false;
                
                    var ac = c;
                    ac = ac is >= 'A' and <= 'Z' ? (char)(ac + 32) : ac;
                
                    var bc = b[i];
                    bc = bc is >= 'A' and <= 'Z' ? (char)(bc + 32) : bc;


                    if(ac != bc) return false;
                    i++;
                }
            
                if (i < b.Length - 1) return false;
                return true;
            }

            public override int Utf16GetHashCode(ReadOnlySpan<char> obj)
            {
                var hash = 0;
                foreach (var c in obj)
                {
                    var ac = c is >= 'A' and <= 'Z' ? (char)(c + 32) : c;
                    hash = hash * 31 + ac;
                }
                return hash & 0x7FFFFFFF;
            }

            public override int Utf8GetHashCode(ReadOnlySpan<byte> obj)
            {
                var hash = 0;
                foreach (var c in Utf8StringConvert.GetUtf8ToUtf16Enumerable(obj))
                {
                    var ac = c is >= 'A' and <= 'Z' ? (char)(c + 32) : c;
                    hash = hash * 31 + ac;
                }
                return hash & 0x7FFFFFFF;
            }
        }
    }
}