using PatcherYrSharp.Helpers;

namespace Eris.Serializer;

public class SwizzleNode
{
    private static readonly Dictionary<nint, SwizzleNode> SwizzlePointers = [];


    private Action<nint>? _setter;
    private nint _newPointer;

    public static SwizzleNode? Swizzle<T>(ref Pointer<T> pointer)
    {
        if (SwizzlePointers.TryGetValue(pointer, out var node))
        {
            if (node._newPointer != 0)
            {
                pointer = node._newPointer;
                return null;
            }

            return node;
        }

        return SwizzlePointers[pointer] = new();
    }

    public static void HereIAm(nint old, nint newPointer)
    {
        if (SwizzlePointers.TryGetValue(old, out var node))
        {
            node._setter?.Invoke(old);
            node._setter = null;
            node._newPointer = newPointer;
        }
        else
        {
            SwizzlePointers[old] = new() { _newPointer = newPointer };
        }
    }

    public static void Clear()
    {
        SwizzlePointers.Clear();
    }

    public void By(Action<nint> setter)
    {
        _setter += setter;
    }

    private SwizzleNode()
    {
    }
}