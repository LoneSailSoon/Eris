using System.Runtime.InteropServices;

namespace Eris.YRSharp.Helpers;

public static class CollectionsHelpers
{
    public static List<T> CreateList<T>(int count)
    {
        var list = new List<T>(count);
        CollectionsMarshal.SetCount(list, count);
        return list;
    }
}