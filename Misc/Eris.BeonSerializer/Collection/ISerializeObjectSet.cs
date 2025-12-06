using System.Diagnostics.CodeAnalysis;

namespace Eris.BeonSerializer.Collection;

public interface ISerializeObjectSet
{
    bool GetOrAdd(IBeonSerializable obj, out int index);

    bool Contains(IBeonSerializable obj);

    bool TryGetIndex(IBeonSerializable obj, out int index);

    bool TryGetobject(int index, [NotNullWhen(true)] out IBeonSerializable? obj);
    void Reset();

    IBeonSerializable this[int index] { get; }

    int this[IBeonSerializable obj] { get; }

}
