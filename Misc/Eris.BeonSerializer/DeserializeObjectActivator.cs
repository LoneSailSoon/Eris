using System.Diagnostics.CodeAnalysis;
using Activators = System.Collections.Generic.Dictionary<int, Eris.BeonSerializer.DeserializeObjectActivatorDelegate>;

namespace Eris.BeonSerializer;

public static class DeserializeObjectActivator
{
    internal static readonly Activators Activators = [];
    public static bool IsRegistered(int type) => Activators.ContainsKey(type);
    public static void Register(int type, DeserializeObjectActivatorDelegate activator) => Activators[type] = activator;

    public static bool TryGetActivator(int type, [NotNullWhen(true)] out DeserializeObjectActivatorDelegate? activator, Activators? activators = null) 
        => (activators ?? Activators).TryGetValue(type, out activator);
}

public delegate IBeonSerializable DeserializeObjectActivatorDelegate();
