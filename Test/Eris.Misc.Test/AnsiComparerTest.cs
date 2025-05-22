using Eris.Misc.String.HybridString;

namespace Eris.Misc.Test;

[TestClass]
public sealed class AnsiComparerTest
{
    [TestMethod]
    public void AnsiComparerOrdinalEquals()
    {
        Assert.IsTrue(AnsiComparer.Ordinal.Equals("abc", "abc"));
        Assert.IsTrue(AnsiComparer.Ordinal.Equals("abc"u8, "abc"));
        Assert.IsTrue(AnsiComparer.Ordinal.Equals("abc"u8, "abc"u8));

        Assert.IsFalse(AnsiComparer.Ordinal.Equals("abc", "efg"));
        Assert.IsFalse(AnsiComparer.Ordinal.Equals("abc"u8, "efg"));
        Assert.IsFalse(AnsiComparer.Ordinal.Equals("abc"u8, "efg"u8));
    }

    [TestMethod]
    public void AnsiComparerOrdinalGetHashCode()
    {
        Assert.AreEqual(AnsiComparer.Ordinal.GetHashCode("abcd"), AnsiComparer.Ordinal.GetHashCode("abcd"));
        Assert.AreEqual(AnsiComparer.Ordinal.GetHashCode("abcd"u8), AnsiComparer.Ordinal.GetHashCode("abcd"));
        Assert.AreEqual(AnsiComparer.Ordinal.GetHashCode("abcd"u8), AnsiComparer.Ordinal.GetHashCode("abcd"u8));

        Assert.AreNotEqual(AnsiComparer.Ordinal.GetHashCode("abcd"), AnsiComparer.Ordinal.GetHashCode("efgh"));
        Assert.AreNotEqual(AnsiComparer.Ordinal.GetHashCode("abcd"u8), AnsiComparer.Ordinal.GetHashCode("efgh"));
        Assert.AreNotEqual(AnsiComparer.Ordinal.GetHashCode("abcd"u8), AnsiComparer.Ordinal.GetHashCode("efgh"u8));
    }

    [TestMethod]
    public void AnsiComparerOrdinalDictionary()
    {
        Dictionary<string, int> dic = new(AnsiComparer.Ordinal)
        {
            ["a"] = 1,
            ["b"] = 2,
            ["c"] = 3
        };

        Assert.IsTrue(dic.ContainsKey("a"));
        Assert.IsTrue(dic.GetAlternateLookup<ReadOnlySpan<byte>>().ContainsKey("a"u8));

        Assert.IsTrue(dic.ContainsKey("b"));
        Assert.IsTrue(dic.GetAlternateLookup<ReadOnlySpan<byte>>().ContainsKey("b"u8));

        Assert.AreEqual(1, dic["a"]);
        Assert.AreEqual(1, dic.GetAlternateLookup<ReadOnlySpan<byte>>()["a"u8]);

        Assert.AreEqual(2, dic["b"]);
        Assert.AreEqual(2, dic.GetAlternateLookup<ReadOnlySpan<byte>>()["b"u8]);


        Assert.IsFalse(dic.ContainsKey("d"));
        Assert.IsFalse(dic.GetAlternateLookup<ReadOnlySpan<byte>>().ContainsKey("d"u8));
        
        Assert.IsFalse(dic.TryGetValue("d", out _));
        Assert.IsFalse(dic.GetAlternateLookup<ReadOnlySpan<byte>>().TryGetValue("d"u8, out _));

        Assert.IsTrue(dic.TryAdd("d", 4));
        Assert.IsFalse(dic.TryAdd("d", 4));

        Assert.IsTrue(dic.GetAlternateLookup<ReadOnlySpan<byte>>().TryAdd("e"u8, 5));
        Assert.IsFalse(dic.GetAlternateLookup<ReadOnlySpan<byte>>().TryAdd("e"u8, 5));
    }

    [TestMethod]
    public void AnsiComparerOrdinalIgnoreCaseEquals()
    {
        Assert.IsTrue(AnsiComparer.OrdinalIgnoreCase.Equals("abc", "abc"));
        Assert.IsTrue(AnsiComparer.OrdinalIgnoreCase.Equals("abc"u8, "abc"));
        // Assert.IsTrue(AnsiComparer.OrdinalIgnoreCase.Equals("abc"u8, "abc"u8));

        Assert.IsFalse(AnsiComparer.OrdinalIgnoreCase.Equals("abc", "efg"));
        Assert.IsFalse(AnsiComparer.OrdinalIgnoreCase.Equals("abc"u8, "efg"));
        // Assert.IsFalse(AnsiComparer.OrdinalIgnoreCase.Equals("abc"u8, "efg"u8));
        
        Assert.IsTrue(AnsiComparer.OrdinalIgnoreCase.Equals("abc", "ABC"));
        Assert.IsTrue(AnsiComparer.OrdinalIgnoreCase.Equals("abc"u8, "ABC"));
        // Assert.IsTrue(AnsiComparer.OrdinalIgnoreCase.Equals("abc"u8, "ABC"u8));
        
        Assert.IsFalse(AnsiComparer.OrdinalIgnoreCase.Equals("abc", "Efg"));
        Assert.IsFalse(AnsiComparer.OrdinalIgnoreCase.Equals("abc"u8, "eFg"));
        // Assert.IsFalse(AnsiComparer.OrdinalIgnoreCase.Equals("abc"u8, "efG"u8));

    }
    
    [TestMethod]
    public void AnsiComparerOrdinalIgnoreCaseGetHashCode()
    {
        Assert.AreEqual(AnsiComparer.OrdinalIgnoreCase.GetHashCode("abcd"), AnsiComparer.Ordinal.GetHashCode("abcd"));
        Assert.AreEqual(AnsiComparer.OrdinalIgnoreCase.GetHashCode("abcd"u8), AnsiComparer.Ordinal.GetHashCode("abcd"));
        Assert.AreEqual(AnsiComparer.OrdinalIgnoreCase.GetHashCode("abcd"u8), AnsiComparer.Ordinal.GetHashCode("abcd"u8));

        Assert.AreNotEqual(AnsiComparer.OrdinalIgnoreCase.GetHashCode("abcd"), AnsiComparer.Ordinal.GetHashCode("efgh"));
        Assert.AreNotEqual(AnsiComparer.OrdinalIgnoreCase.GetHashCode("abcd"u8), AnsiComparer.Ordinal.GetHashCode("efgh"));
        Assert.AreNotEqual(AnsiComparer.OrdinalIgnoreCase.GetHashCode("abcd"u8), AnsiComparer.Ordinal.GetHashCode("efgh"u8));

        Assert.AreEqual(AnsiComparer.OrdinalIgnoreCase.GetHashCode("abcd"), AnsiComparer.OrdinalIgnoreCase.GetHashCode("abcd"));
        Assert.AreEqual(AnsiComparer.OrdinalIgnoreCase.GetHashCode("abcd"u8), AnsiComparer.OrdinalIgnoreCase.GetHashCode("abcd"));
        Assert.AreEqual(AnsiComparer.OrdinalIgnoreCase.GetHashCode("abcd"u8), AnsiComparer.OrdinalIgnoreCase.GetHashCode("abcd"u8));

        Assert.AreNotEqual(AnsiComparer.OrdinalIgnoreCase.GetHashCode("abcd"), AnsiComparer.OrdinalIgnoreCase.GetHashCode("efgh"));
        Assert.AreNotEqual(AnsiComparer.OrdinalIgnoreCase.GetHashCode("abcd"u8), AnsiComparer.OrdinalIgnoreCase.GetHashCode("efgh"));
        Assert.AreNotEqual(AnsiComparer.OrdinalIgnoreCase.GetHashCode("abcd"u8), AnsiComparer.OrdinalIgnoreCase.GetHashCode("efgh"u8));

        Assert.AreEqual(AnsiComparer.OrdinalIgnoreCase.GetHashCode("abcd"), AnsiComparer.OrdinalIgnoreCase.GetHashCode("ABCD"));
        Assert.AreEqual(AnsiComparer.OrdinalIgnoreCase.GetHashCode("abcd"u8), AnsiComparer.OrdinalIgnoreCase.GetHashCode("ABCD"));
        Assert.AreEqual(AnsiComparer.OrdinalIgnoreCase.GetHashCode("abcd"u8), AnsiComparer.OrdinalIgnoreCase.GetHashCode("ABCD"u8));

        Assert.AreNotEqual(AnsiComparer.OrdinalIgnoreCase.GetHashCode("abcd"), AnsiComparer.OrdinalIgnoreCase.GetHashCode("Efgh"));
        Assert.AreNotEqual(AnsiComparer.OrdinalIgnoreCase.GetHashCode("abcd"u8), AnsiComparer.OrdinalIgnoreCase.GetHashCode("eFgh"));
        Assert.AreNotEqual(AnsiComparer.OrdinalIgnoreCase.GetHashCode("abcd"u8), AnsiComparer.OrdinalIgnoreCase.GetHashCode("efGh"u8));
    }
    
    [TestMethod]
    public void AnsiComparerOrdinalIgnoreCaseDictionary()
    {
        Dictionary<string, int> dic = new(AnsiComparer.OrdinalIgnoreCase)
        {
            ["a"] = 1,
            ["b"] = 2,
            ["c"] = 3
        };

        Assert.IsTrue(dic.ContainsKey("a"));
        Assert.IsTrue(dic.GetAlternateLookup<ReadOnlySpan<byte>>().ContainsKey("a"u8));

        Assert.IsTrue(dic.ContainsKey("b"));
        Assert.IsTrue(dic.GetAlternateLookup<ReadOnlySpan<byte>>().ContainsKey("b"u8));

        Assert.AreEqual(1, dic["a"]);
        Assert.AreEqual(1, dic.GetAlternateLookup<ReadOnlySpan<byte>>()["a"u8]);

        Assert.AreEqual(2, dic["b"]);
        Assert.AreEqual(2, dic.GetAlternateLookup<ReadOnlySpan<byte>>()["b"u8]);


        Assert.IsFalse(dic.ContainsKey("d"));
        Assert.IsFalse(dic.GetAlternateLookup<ReadOnlySpan<byte>>().ContainsKey("d"u8));
        
        Assert.IsFalse(dic.TryGetValue("d", out _));
        Assert.IsFalse(dic.GetAlternateLookup<ReadOnlySpan<byte>>().TryGetValue("d"u8, out _));

        Assert.IsTrue(dic.ContainsKey("A"));
        Assert.IsTrue(dic.GetAlternateLookup<ReadOnlySpan<byte>>().ContainsKey("A"u8));

        Assert.IsTrue(dic.ContainsKey("B"));
        Assert.IsTrue(dic.GetAlternateLookup<ReadOnlySpan<byte>>().ContainsKey("B"u8));

        Assert.AreEqual(1, dic["A"]);
        Assert.AreEqual(1, dic.GetAlternateLookup<ReadOnlySpan<byte>>()["A"u8]);

        Assert.AreEqual(2, dic["B"]);
        Assert.AreEqual(2, dic.GetAlternateLookup<ReadOnlySpan<byte>>()["B"u8]);


        Assert.IsFalse(dic.ContainsKey("D"));
        Assert.IsFalse(dic.GetAlternateLookup<ReadOnlySpan<byte>>().ContainsKey("D"u8));
        
        Assert.IsFalse(dic.TryGetValue("D", out _));
        Assert.IsFalse(dic.GetAlternateLookup<ReadOnlySpan<byte>>().TryGetValue("D"u8, out _));

        
        Assert.IsTrue(dic.TryAdd("d", 4));
        Assert.IsFalse(dic.TryAdd("d", 4));

        Assert.IsTrue(dic.GetAlternateLookup<ReadOnlySpan<byte>>().TryAdd("e"u8, 5));
        Assert.IsFalse(dic.GetAlternateLookup<ReadOnlySpan<byte>>().TryAdd("e"u8, 5));
    }
}